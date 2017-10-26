using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlyTops.Syncthing
{
    public class SyncthingClient
    {
        private readonly Uri _endpoint;
        private readonly string _apiKey;

        public SyncthingClient(string syncthingEndpoint, string apiKey)
        {
            var uriBuilder = new UriBuilder(syncthingEndpoint);
            if (!uriBuilder.Path.EndsWith("/")) uriBuilder.Path += "/";
            _endpoint = uriBuilder.Uri;
            _apiKey = apiKey;
        }

        #region Internal REST Ops
        private (string url, HttpClient client) PrepareRestCall(string methodEndpoint)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);

            Uri url = null;
            var sanitizedMethodEndpoint = !methodEndpoint.StartsWith("/") ? methodEndpoint : methodEndpoint.Substring(1); // TODO : replace this with a contract assertion thing
            if (!Uri.TryCreate(_endpoint, sanitizedMethodEndpoint, out url))
            {
                throw new Exception("Issue creating REST endpoint");
            }

            return (url.AbsoluteUri, client);
        }

        private async Task<string> GetSyncthingStringAsync(string methodEndpoint)
        {
            var (url, client) = PrepareRestCall(methodEndpoint);
            return await client.GetStringAsync(url);
        }

        private async Task<HttpResponseMessage> PostSyncthingJsonDataAsync<T>(string methodEndpoint, T data)
        {
            var (url, client) = PrepareRestCall(methodEndpoint);
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        private async Task<HttpResponseMessage> PostSyncthingPlainTextDataAsync(string methodEndpoint, StringContent data)
        {
            var (url, client) = PrepareRestCall(methodEndpoint);
            return await client.PostAsync(url, data);
        }

        private async Task<HttpResponseMessage> PostSyncthingJsonDataAsync<T>(string methodEndpoint) where T : class
        {
            return await PostSyncthingJsonDataAsync<T>(methodEndpoint, null as T);
        }
        #endregion

        private async Task<T> GetDeserializedObjectAsync<T>(string methodEndpoint) where T : class
        {
            return JsonConvert.DeserializeObject<T>(await GetSyncthingStringAsync(methodEndpoint));
        }

        private async Task<T> PostDeserializedObjectAsync<T>(string methodEndpoint, T data) where T : class
        {
            string responseString = await PostSyncthingJsonDataAsync<T>(methodEndpoint, data).Result.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseString)) return null;

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        #region System Endpoints

        #region GET Methods
        public async Task<bool> PingSyncthingAsync()
        {
            string pingResponse = await GetSyncthingStringAsync(@"rest/system/ping");
            return pingResponse == "{\"ping\":\"pong\"}";
        }

        public async Task<VersionInfo> GetSyncthingVersionAsync()
        {
            return await GetDeserializedObjectAsync<VersionInfo>(@"rest/system/version");
        }

        public async Task<UpgradeInfo> GetSyncthingUpgradeInfoAsync()
        {
            return await GetDeserializedObjectAsync<UpgradeInfo>(@"rest/system/upgrade");
        }

        public async Task<Configuration> GetSyncthingConfigurationAsync()
        {
            return await GetDeserializedObjectAsync<Configuration>(@"rest/system/config");
        }

        public async Task<bool> GetIsSyncthingConfigInsyncAsync()
        {
            string pingResponse = await GetSyncthingStringAsync(@"rest/system/config/insync");
            return pingResponse == "{\"configInSync\":true}";
        }

        public async Task<ConnectionSummary> GetSyncthingConnectionsAsync()
        {
            return await GetDeserializedObjectAsync<ConnectionSummary>(@"rest/system/connections");
        }

        // SKIPPED : rest/system/debug

        public async Task<Dictionary<string, string[]>> GetSyncthingDiscoveryCacheAsync()
        {
            return await GetDeserializedObjectAsync<Dictionary<string, string[]>>(@"rest/system/discovery");
        }

        public async Task<List<Event>> GetSyncthingErrorsAsync()
        {
            return (await GetDeserializedObjectAsync<ErrorResponse>(@"rest/system/error"))?.ErrorList ?? new List<Event>();
        }

        public async Task<List<Event>> GetSyncthingLogsAsync()
        {
            return (await GetDeserializedObjectAsync<LogResponse>(@"rest/system/log"))?.LogEntries ?? new List<Event>();
        }

        public async Task<SystemStatus> GetSyncthingSystemStatusAsync()
        {
            return await GetDeserializedObjectAsync<SystemStatus>(@"rest/system/status");
        }
        #endregion

        #region POST Methods
        public async Task<bool> PostPingSyncthingAsync()
        {
            string pingResponse = await PostSyncthingJsonDataAsync<string>(@"rest/system/ping").Result.Content.ReadAsStringAsync();
            return pingResponse == "{\"ping\":\"pong\"}";
        }

        public async Task<bool> PostSyncthingConfigAsync(Configuration config)
        {
            await PostSyncthingJsonDataAsync<Configuration>(@"rest/system/config", config);
            return true;
        }

        // SKIPPED : rest/system/debug

        public async Task<bool> ClearSyncthingErrorsAsync()
        {
            await PostSyncthingJsonDataAsync<object>(@"rest/system/error/clear");
            return true;
        }

        public async Task<bool> PostSyncthingErrorsAsync(string message)
        {
            await PostSyncthingPlainTextDataAsync(@"rest/system/error/clear", new StringContent(message));
            return true;
        }

        public async Task<string> PauseSyncthingAsync(string deviceId = null)
        {
            StringBuilder sb = new StringBuilder(@"rest/system/pause");
            if (!string.IsNullOrWhiteSpace(deviceId)) sb.Append($"?device={deviceId}");
            return await PostSyncthingPlainTextDataAsync(sb.ToString(), new StringContent(string.Empty)).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> ResetSyncthingAsync(string folderId = null)
        {
            StringBuilder sb = new StringBuilder(@"rest/system/reset");
            if (!string.IsNullOrWhiteSpace(folderId)) sb.Append($"?folder={folderId}");
            return await PostSyncthingPlainTextDataAsync(sb.ToString(), new StringContent(string.Empty)).Result.Content.ReadAsStringAsync();
        }

        public async Task<bool> RestartSyncthingAsync()
        {
            await PostSyncthingPlainTextDataAsync(@"rest/system/restart", new StringContent(string.Empty));
            return true;
        }

        public async Task<string> ResumeSyncthingAsync(string deviceId = null)
        {
            StringBuilder sb = new StringBuilder(@"rest/system/resume");
            if (!string.IsNullOrWhiteSpace(deviceId)) sb.Append($"?device={deviceId}");
            return await PostSyncthingPlainTextDataAsync(sb.ToString(), new StringContent(string.Empty)).Result.Content.ReadAsStringAsync();
        }

        public async Task<bool> ShutdownSyncthingAsync()
        {
            await PostSyncthingPlainTextDataAsync(@"rest/system/shutdown", new StringContent(string.Empty));
            return true;
        }

        public async Task<bool> UpgradeSyncthingAsync()
        {
            await PostSyncthingPlainTextDataAsync(@"rest/system/upgrade", new StringContent(string.Empty));
            return true;
        }
        #endregion

        #endregion
    }
}

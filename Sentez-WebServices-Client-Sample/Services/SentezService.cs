using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sentez_WebServices_Client_Sample.Services
{
    public class SentezService : ISentezService
    {
        private readonly HttpClient _httpClient;

        public SentezService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<string> GetAll(string loginToken, string BOId)
        {
            string apiLoginUrl = "http://localhost:8080/api/BO/Get";
            string BoId = string.Empty;
            string json = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BOId"] = BOId, };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiLoginUrl, boModel);
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic dynJson = JsonConvert.DeserializeObject(result);
                    json = JsonConvert.SerializeObject(dynJson.Data);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            { Debug.WriteLine($"Error:{ex.Message}"); }

            return json;
        }
        public async Task<string> GetBoId(string loginToken, string BOName, int logicalModuleId, int type, int type2)
        {
            string apiCreateBoUrl = "http://localhost:8080/api/BO/CreateBO";
            string BoId = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BOName"] = BOName, ["initparams.logicalModuleId"] = logicalModuleId.ToString(), ["initparams.type"] = type.ToString(), ["initparams.type2"] = type2.ToString() };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiCreateBoUrl, boModel);
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    BoId = json.Data;
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return BoId;
        }
        public async Task<string> GetById(string loginToken, string BOId, long RecId)
        {
            string apiCreateBoUrl = "http://localhost:8080/api/BO/GetById";
            string boResponse = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BOId"] = BOId, ["RecId"] = RecId.ToString() };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiCreateBoUrl, boModel);
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    boResponse = JsonConvert.SerializeObject(json.Data);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return boResponse;
        }
        public async Task<string> Login(string userCode, string password, string companyCode, string companyPassword, int userType)
        {
            string apiLoginUrl = "http://localhost:8080/api/Authentication/Login";
            string token = string.Empty;
            var userModel = new Dictionary<string, string>()
            {
                ["userCode"] = userCode,
                ["password"] = password,
                ["companyCode"] = companyCode,
                ["companyPassword"] = companyPassword,
                ["userType"] = userType.ToString()
            };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer login");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiLoginUrl, userModel);
                HttpContent c = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(uri, c);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    token = json.Data;
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            { Debug.WriteLine($"Error:{ex.Message}"); }

            return token;
        }
        public async Task<string> PostBO(string loginToken, string boName, Dictionary<string, List<ExpandoObject>> data)
        {
            string apiLoginUrl = "http://localhost:8080/api/BO/PostBO";
            string token = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BoName"] = boName };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiLoginUrl, boModel);
                HttpContent c = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(uri, c);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    token = JsonConvert.SerializeObject(json);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return token;
        }

        public async Task<string> UpdateBO(string loginToken, string boName,long RecId, Dictionary<string, List<ExpandoObject>> data)
        {
            string apiUrl = "http://localhost:8080/api/BO/UpdateBO";
            string token = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BoName"] = boName,["RecId"]=RecId.ToString() };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiUrl, boModel);
                HttpContent c = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(uri, c);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    token = JsonConvert.SerializeObject(json);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return token;
        }
        public async Task<string> ExecuteQuery(string loginToken, string Query)
        {
            string apiUrl = "http://localhost:8080/api/Utility/UtilityQuery";
            string token = string.Empty;
            var boModel = new Dictionary<string, string>() { ["Query"] = Query };

            dynamic QueryModel = new JObject();
            QueryModel.Query = Query;

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginToken}");

            try
            {
                //var uri = QueryHelpers.AddQueryString(apiLoginUrl, boModel);
                HttpContent c = new StringContent(JsonConvert.SerializeObject(QueryModel), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, c);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    token = JsonConvert.SerializeObject(json);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return token;
        }
    }
}

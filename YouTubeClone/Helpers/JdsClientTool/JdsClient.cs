using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeClone.Helpers.JdsClientTool
{
    public static class JdsClient
    {
        public static string BaseAddress;

        public static async Task<JdsMultiReponse<T>> GetManyAsync<T>(string apiBaseLink, string token) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var link = $"{BaseAddress}{apiBaseLink}";
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                        .WaitAndRetryAsync(1, i => TimeSpan.FromSeconds(2), (request, timeSpan, retryCount, context) =>
                        {
                            Debug.WriteLine($"Error With a {request.Result.StatusCode} Waiting {timeSpan} Retry Attempt({retryCount})");
                        })
                        .ExecuteAsync(async () => await client.GetAsync(link));
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode) return new JdsMultiReponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        RequestError = requestContent,
                    };
                    var requestResult = (List<T>)JsonConvert.DeserializeObject(requestContent, typeof(List<T>));
                    return new JdsMultiReponse<T>()
                    {
                        Data = requestResult,
                        StatusCode = response.StatusCode,
                        RequestError = requestContent,
                    };
                }

            }
            catch (Exception ex)
            {
            }
            return new JdsMultiReponse<T>()
            {
                StatusCode = HttpStatusCode.BadGateway,
                RequestError = "UnHandledException"
            };
        }
        public static async Task<JdsMultiReponse<T>> GetManyAsync<T>(string apiBaseLink) where T : new()
        {
            try
            {

                using (var client = new HttpClient())
                {
                    var link = $"{BaseAddress}{apiBaseLink}";
                    var response = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                        .WaitAndRetryAsync(1, i => TimeSpan.FromSeconds(2), (request, timeSpan, retryCount, context) =>
                        {
                            Debug.WriteLine($"Error With a {request.Result.StatusCode} Waiting {timeSpan} Retry Attempt({retryCount})");
                        })
                        .ExecuteAsync(async () => await client.GetAsync(link));
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode) return new JdsMultiReponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        RequestError = requestContent,
                    };
                    var requestResult = (List<T>)JsonConvert.DeserializeObject(requestContent, typeof(List<T>));
                    return new JdsMultiReponse<T>()
                    {
                        Data = requestResult,
                        StatusCode = response.StatusCode,
                        RequestError = requestContent,
                    };
                }

            }
            catch (Exception ex)
            {
            }
            return new JdsMultiReponse<T>()
            {
                StatusCode = HttpStatusCode.BadGateway,
                RequestError = "UnHandledException"
            };
        }
        public static async Task<JdsSingleResponse<T>> GetAsync<T>(string apiEndpoint, string token) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var link = $"{BaseAddress}{apiEndpoint}";
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                        .WaitAndRetryAsync(1, i => TimeSpan.FromSeconds(1), (request, timeSpan, retryCount, context) =>
                        {
                            Debug.WriteLine($"Error With a {request.Result.StatusCode} Waiting {timeSpan} Retry Attempt({retryCount})");
                        })
                        .ExecuteAsync(async () => await client.GetAsync(link));
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode) return new JdsSingleResponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        RequestContent = requestContent,
                    };
                    var requestResult = (T)JsonConvert.DeserializeObject(requestContent, typeof(T));
                    return new JdsSingleResponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        Data = requestResult,
                        RequestContent = requestContent
                    };
                }

            }
            catch
            {
            }
            return new JdsSingleResponse<T>()
            {
                StatusCode = HttpStatusCode.BadGateway,
                RequestContent = "UnHandledException"
            };
        }
        public static async Task<JdsSingleResponse<T>> GetAsync<T>(string apiEndpoint) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var link = $"{BaseAddress}{apiEndpoint}";
                    var response = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                        .WaitAndRetryAsync(1, i => TimeSpan.FromSeconds(1), (request, timeSpan, retryCount, context) =>
                        {
                            Debug.WriteLine($"Error With a {request.Result.StatusCode} Waiting {timeSpan} Retry Attempt({retryCount})");
                        })
                        .ExecuteAsync(async () => await client.GetAsync(link));
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode) return new JdsSingleResponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        RequestContent = requestContent,
                    };
                    var requestResult = (T)JsonConvert.DeserializeObject(requestContent, typeof(T));
                    return new JdsSingleResponse<T>()
                    {
                        StatusCode = response.StatusCode,
                        Data = requestResult,
                        RequestContent = requestContent
                    };
                }

            }
            catch
            {
            }
            return new JdsSingleResponse<T>()
            {
                StatusCode = HttpStatusCode.BadGateway,
                RequestContent = "UnHandledException"
            };
        }
        public static async Task<JdsSingleResponse<TResult>> PostWithSingleReturnAsync<TPram, TResult>(string apiBaseAddres, TPram model) where TResult : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                        return new JdsSingleResponse<TResult>()
                        {
                            StatusCode = response.StatusCode,
                            RequestContent = requestContent,
                        };
                    var convertToModel = (TResult)JsonConvert.DeserializeObject(requestContent, typeof(TResult));
                    return new JdsSingleResponse<TResult>()
                    {
                        StatusCode = response.StatusCode,
                        Data = convertToModel,
                        RequestContent = requestContent
                    };
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
        }

        public static async Task<JdsSingleResponse<TResult>> PostWithSingleReturnAsync<TPram, TResult>(string apiBaseAddres, TPram model, string token) where TResult : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                        return new JdsSingleResponse<TResult>()
                        {
                            StatusCode = response.StatusCode,
                            RequestContent = requestContent,
                        };
                    var convertToModel = (TResult)JsonConvert.DeserializeObject(requestContent, typeof(TResult));
                    return new JdsSingleResponse<TResult>()
                    {
                        StatusCode = response.StatusCode,
                        Data = convertToModel,
                        RequestContent = requestContent
                    };
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
        }

        public static async Task<HttpStatusCode> PutAsync<T>(string apiBaseAddres, T model, string token) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(BaseAddress + apiBaseAddres, null);
                    if (response.IsSuccessStatusCode)
                        return response.StatusCode;
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
            return HttpStatusCode.NotAcceptable;
        }

        public static async Task<HttpStatusCode> PutAsync<T>(string apiBaseAddres, T model) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(BaseAddress + apiBaseAddres, null);
                    if (response.IsSuccessStatusCode)
                        return response.StatusCode;
                }


            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
            return HttpStatusCode.NotAcceptable;
        }

        public static async Task<HttpStatusCode> PutAsyncFromPathWithNoBody(string apiBaseAddres, int value, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await client.PutAsync($"{BaseAddress}{apiBaseAddres}{value}", null);
                    if (response.IsSuccessStatusCode)
                        return response.StatusCode;
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
            return HttpStatusCode.NotAcceptable;
        }
        public static async Task<HttpStatusCode> PutAsyncFromPathWithNoBody(string apiBaseAddres, int value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsync($"{BaseAddress}{apiBaseAddres}{value}", null);
                    if (response.IsSuccessStatusCode)
                        return response.StatusCode;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
            return HttpStatusCode.NotAcceptable;
        }

        public static async Task<JdsMultiReponse<TResult>> PostAsyncWithMultiReturn<TPram, TResult>(string apiBaseAddres, TPram model, string token) where TResult : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        return new JdsMultiReponse<TResult>()
                        {
                            RequestError = requestContent.Trim('"'),
                            StatusCode = response.StatusCode
                        };
                    }
                    var convertedToListModel = (List<TResult>)JsonConvert.DeserializeObject(requestContent, typeof(List<TResult>));
                    return new JdsMultiReponse<TResult>()
                    {
                        StatusCode = response.StatusCode,
                        RequestError = String.Empty,
                        Data = convertedToListModel
                    };
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
        }
        public static async Task<JdsMultiReponse<TResult>> PostAsyncWithMultiReturn<TPram, TResult>(string apiBaseAddres, TPram model) where TResult : new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    var requestContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        return new JdsMultiReponse<TResult>()
                        {
                            RequestError = requestContent.Trim('"'),
                            StatusCode = response.StatusCode
                        };
                    }
                    var convertedToListModel = (List<TResult>)JsonConvert.DeserializeObject(requestContent, typeof(List<TResult>));
                    return new JdsMultiReponse<TResult>()
                    {
                        StatusCode = response.StatusCode,
                        RequestError = String.Empty,
                        Data = convertedToListModel
                    };
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.ToString());
            }
        }

        public static async Task<JdsSingleResponse<string>> PostAsyncWithJsonStringReturn<TPram>(string apiBaseAddres, TPram model, string token) where TPram : class
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    if (!response.IsSuccessStatusCode)
                        return new JdsSingleResponse<string>()
                        {
                            RequestContent = await response.Content.ReadAsStringAsync(),
                            Data = "",
                            StatusCode = response.StatusCode
                        };
                    return new JdsSingleResponse<string>()
                    {
                        RequestContent = await response.Content.ReadAsStringAsync(),
                        Data = response.Content.ToString(),
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        public static async Task<JdsSingleResponse<string>> PostAsyncWithJsonStringReturn<TPram>(string apiBaseAddres, TPram model) where TPram : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(BaseAddress + apiBaseAddres, content);
                    if (!response.IsSuccessStatusCode)
                        return new JdsSingleResponse<string>()
                        {
                            RequestContent = await response.Content.ReadAsStringAsync(),
                            Data = "",
                            StatusCode = response.StatusCode
                        };
                    return new JdsSingleResponse<string>()
                    {
                        RequestContent = await response.Content.ReadAsStringAsync(),
                        Data = response.Content.ToString(),
                        StatusCode = response.StatusCode
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }


    }
}

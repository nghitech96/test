
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Models;

namespace Quanly_NhaSach.Helpers
{
    //internal class API
    //{ }
    internal static class HttpHelper
    {
        // In my case this is https://localhost:44355/
        private static readonly string apiBasicUri = "https://localhost:44355/"; // ConfigurationManager.AppSettings["apiBasicUri"];
        //public static readonly string apiBasicUri = Common.apiBasicUri;

        public static async Task<ResponseModel> Authentication<T>(string url, T contentValue)
        {
            ResponseModel response = new ResponseModel(-1, "Error!");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);

                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                try
                {

                    var httpresponse = await client.PostAsync(url, content);
                    var resultContentString = await httpresponse.Content.ReadAsStringAsync();
                    response.Message = httpresponse.ReasonPhrase;
                    response.ResultCode = (int)httpresponse.StatusCode;
                    httpresponse.EnsureSuccessStatusCode();
                    if (response.ResultCode == 200)
                    {
                        ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);
                        response.ResultCode = resultContent.ResultCode;
                        response.Message += " - " + resultContent.Message;

                        response.Id = resultContent.Id.ToString();
                        response.data = resultContent.data;
                        response.Count = resultContent.Count;
                    }

                }
                catch (Exception ex)
                {

                    response.Message += ";" + ex.Message;
                }
                return response;
            }
        }

        public static async Task<ResponseModel> Post<T>(string url, T contentValue)
        {
            ResponseModel response = new ResponseModel(-1, "Error!");

            using (var client = new HttpClient())
            {
                if (Common.isLogin)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Common.Token);
                }

                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                var httpresponse = await client.PostAsync(url, content);
                var resultContentString = await httpresponse.Content.ReadAsStringAsync();

                ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);

                response.Message = httpresponse.ReasonPhrase;
                response.ResultCode = (int)httpresponse.StatusCode;
                try
                {
                    if (response.ResultCode != 200)
                    {
                        throw new Exception("Lỗi Xác thực");
                    }
                    httpresponse.EnsureSuccessStatusCode();
                    response.ResultCode = resultContent.ResultCode;
                    response.Message += " - " + resultContent.Message;

                    response.Id = resultContent.Id;
                    response.Count = resultContent.Count;
                    response.data = resultContent.data;
                }
                catch (Exception ex)
                {

                    response.Message += ";" + ex.Message;
                }


                return response;
            }
        }

        public static async Task<ResponseModel> Put<T>(string url, T stringValue)
        {
            ResponseModel response = new ResponseModel(1, "Success!");
            using (var client = new HttpClient())
            {
                if (Common.isLogin)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Common.Token);
                }
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8, "application/json");
                var httpresponse = await client.PutAsync(url, content);
                var resultContentString = await httpresponse.Content.ReadAsStringAsync();

                ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);

                response.Message = httpresponse.ReasonPhrase;
                response.ResultCode = (int)httpresponse.StatusCode;
                try
                {
                    httpresponse.EnsureSuccessStatusCode();
                    response.ResultCode = resultContent.ResultCode;
                    response.Message += " - " + resultContent.Message;

                    response.Id = resultContent.Id;
                    response.Count = resultContent.Count;
                    response.data = resultContent.data;


                }
                catch (Exception ex)
                {

                    response.Message += ";" + ex.Message;
                }
            }
            return response;
        }

        public static async Task<T> Get<T>(string url)
        {
            string resultContentString = "";
            try
            {
                using (var client = new HttpClient())
                {
                    if (Common.isLogin)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Common.Token);
                    }
                    var httpresponse = new HttpResponseMessage();
                    client.BaseAddress = new Uri(apiBasicUri);
                    try
                    {
                        httpresponse = await client.GetAsync(url);

                        httpresponse.EnsureSuccessStatusCode();
                        resultContentString = await httpresponse.Content.ReadAsStringAsync();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);

                    }


                    if ((int)httpresponse.StatusCode != 200)
                    {
                        return default(T);
                    }
                    T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resultContent;
                }
            }
            catch (Exception e)
            {

                return default(T);
            }
        }

        /// <summary>
        /// Up file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<ResponseModel> Delete(string url)
        {
            ResponseModel response = new ResponseModel(-1, "Error!");
            using (var client = new HttpClient())
            {
                if (Common.isLogin)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Common.Token);
                }
                client.BaseAddress = new Uri(apiBasicUri);
                var httpresponse = await client.DeleteAsync(url);

                var resultContentString = await httpresponse.Content.ReadAsStringAsync();

                ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);

                response.Message = httpresponse.ReasonPhrase;
                response.ResultCode = (int)httpresponse.StatusCode;
                try
                {
                    httpresponse.EnsureSuccessStatusCode();

                    response.ResultCode = resultContent.ResultCode;
                    response.Message += " - " + resultContent.Message;

                    response.Id = resultContent.Id;
                    response.Count = resultContent.Count;
                    response.data = resultContent.data;
                }
                catch (Exception ex)
                {

                    response.Message += ";" + ex.Message;
                }
            }
            return response;
        }

        public static async Task<ResponseModel> GetFile<T>(string url, T contentValue)
        {
            ResponseModel rs = new ResponseModel(-1, "Error!");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                var httpresponse = await client.PostAsync(url, content);
                var resultContentString = await httpresponse.Content.ReadAsByteArrayAsync();

                //ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);

                rs.Message = httpresponse.ReasonPhrase;
                rs.ResultCode = (int)httpresponse.StatusCode;
                try
                {
                    httpresponse.EnsureSuccessStatusCode();

                }
                catch (Exception ex)
                {

                    rs.Message += ";" + ex.Message;
                }

                if (rs.ResultCode == 200)
                {

                    //rs.Id = resultContent.Id;

                }
                return rs;
            }
        }
        public static async Task<ResponseModel> UploadFile(string url, FileInfo fileInfo)
        {
            ResponseModel result = new ResponseModel(-1, "Error!");
            try
            {

                var filename = fileInfo.Name.Substring(0, fileInfo.Extension.Length);
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(apiBasicUri);

                var multipartFormDataContent = new MultipartFormDataContent();

                var fileContent = new ByteArrayContent(File.ReadAllBytes(fileInfo.FullName));
                multipartFormDataContent.Add(fileContent, filename, fileInfo.Name);

                var httpresponse = await httpClient.PostAsync(url, multipartFormDataContent);

                var resultContentString = await httpresponse.Content.ReadAsStringAsync();

                ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);
                result.Message = httpresponse.ReasonPhrase;
                result.ResultCode = (int)httpresponse.StatusCode;

                httpresponse.EnsureSuccessStatusCode();
                if (result.ResultCode == 200)
                {

                    result.Id = resultContent.Id;
                }
            }
            catch (Exception ex)
            {
                result.Message += ";" + ex.Message;
            }
            return result;
        }
        public static async Task<string> DownloadFile(string url)
        {

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(apiBasicUri);
                // validation
                //_logger.LogInformation($"Downloading File with GUID=[{guid}].");

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                await using var ms = await response.Content.ReadAsStreamAsync();
                var contentType = response.Content.Headers.ContentType;
                var FileName = response.Content.Headers.ContentDisposition.FileName;
                //ResponseModel resultContent = JsonConvert.DeserializeObject<ResponseModel>(resultContentString);
                var fileInfo = new FileInfo($"c:\\temp\\{FileName}");
                if (fileInfo.Exists)
                {
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch (Exception)
                    {

                        fileInfo = new FileInfo($"c:\\temp\\2{FileName}");
                        if (fileInfo.Exists)
                        {
                            try
                            {
                                fileInfo.Delete();
                            }
                            catch (Exception)
                            {
                                return fileInfo.FullName;
                            }
                        }
                    }
                }
                await using var fs = File.Create(fileInfo.FullName);
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(fs);
                ms.Close();
                fs.Close();
                //_logger.LogInformation($"File saved as [{fileInfo.Name}].");
                return fileInfo.FullName;
            }
        }
    }
    
}
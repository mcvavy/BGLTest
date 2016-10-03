using BGL.Core.Entities;
using BGL.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGL.Infrastructure.Repository
{
    public abstract class GitHttpClient : IClient<HttpClient>
    {
        private readonly HttpClient _client;

        protected GitHttpClient(HttpClient client)
        {
            _client = client;

            _client = new HttpClient { BaseAddress = new Uri(BaseURI.GithubApi) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<Owner> GetuserInfoAsync(string username)
        {
            Owner OwerObject = null;

            //string auth = "?client_id=ClienSecret&client_secret=Screret";
            //use client_id & secret to get request in authentication mode

            try
            {
                var ownerUrl = new Uri(_client.BaseAddress, username); // +auth

                var getUserBasicInfo = await _client.GetAsync(ownerUrl);

                if (getUserBasicInfo.IsSuccessStatusCode)
                {
                    var ownersRes = await getUserBasicInfo.Content.ReadAsStringAsync();
                    var owner = JsonConvert.DeserializeObject<Owner>(ownersRes);


                    //fetch All user's repo
                    try
                    {
                        var url = new Uri(_client.BaseAddress, username + "/repos"); // +auth

                        var response = await _client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            var res = await response.Content.ReadAsStringAsync();
                            var repos = JsonConvert.DeserializeObject<List<RootObject>>(res);

                            if (repos != null) owner.Repos.AddRange(repos);

                            return owner;
                        }

                    }
                    catch (Exception ex)
                    {
                        var errorMsg = ex.InnerException.Message;
                    }
                }

            }
            catch (Exception Ex)
            {
                var message = Ex.InnerException.Message;
            }

            return OwerObject;
        }
    }
}

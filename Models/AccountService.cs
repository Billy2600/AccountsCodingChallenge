using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using AccountsCodingChallenge.Models;
using Newtonsoft.Json;

namespace AccountsCodingChallenge.Models
{
    public class AccountService : IAccountService
    {
        private const string accountApiUrl = "https://frontiercodingtests.azurewebsites.net/api/accounts/getall";

        public async Task<List<Account>> GetAccountsAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var accountList = new List<Account>();
                    using(var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(accountApiUrl))
                        {
                            string responseJson = await response.Content.ReadAsStringAsync();
                            accountList = JsonConvert.DeserializeObject<List<Account>>(responseJson);
                            return accountList;
                        }
                    }
                }
                catch (HttpRequestException httpReqException)
                {
                    Console.WriteLine(httpReqException.Message); // TODO: In a 'real' project, this would probably get logged somewhere with more info
                    return new List<Account>();
                }
            }
        }
    }
}

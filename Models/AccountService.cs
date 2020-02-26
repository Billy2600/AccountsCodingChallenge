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

        public async Task<List<AccountModel>> GetAccountsAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var accountList = new List<AccountModel>();
                    using(var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(accountApiUrl))
                        {
                            string responseJson = await response.Content.ReadAsStringAsync();
                            accountList = JsonConvert.DeserializeObject<List<AccountModel>>(responseJson);
                            return accountList;
                        }
                    }
                }
                catch (HttpRequestException httpReqException)
                {
                    Console.WriteLine(httpReqException.Message); // TODO: In a 'real' project, this would probably get logged somewhere with more info
                    return new List<AccountModel>();
                }
            }
        }

        public List<AccountModel> GetActiveAccounts(List<AccountModel> allAccounts)
        {
            return allAccounts.Where(x => x.AccountStatusId == (int)AccountStatuses.Active).ToList();
        }
        public List<AccountModel> GetInctiveAccounts(List<AccountModel> allAccounts)
        {
            return allAccounts.Where(x => x.AccountStatusId == (int)AccountStatuses.Inactive).ToList();
        }
        public List<AccountModel> GetOverdueAccounts(List<AccountModel> allAccounts)
        {
            return allAccounts.Where(x => x.AccountStatusId == (int)AccountStatuses.Overdue).ToList();
        }
    }
}

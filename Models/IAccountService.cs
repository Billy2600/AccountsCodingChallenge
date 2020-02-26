using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace AccountsCodingChallenge.Models
{
    public interface IAccountService
    {
        public Task<List<AccountModel>> GetAccountsAsync();
        public List<AccountModel> GetActiveAccounts(List<AccountModel> allAccounts);
        public List<AccountModel> GetInctiveAccounts(List<AccountModel> allAccounts);
        public List<AccountModel> GetOverdueAccounts(List<AccountModel> allAccounts);
        public void FormatPhoneNumbers(List<AccountModel> accounts);
    }
}

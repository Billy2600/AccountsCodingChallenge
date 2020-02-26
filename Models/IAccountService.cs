using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace AccountsCodingChallenge.Models
{
    public interface IAccountService
    {
        public Task<List<Account>> GetAccountsAsync();
    }
}

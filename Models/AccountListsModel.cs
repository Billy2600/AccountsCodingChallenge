using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsCodingChallenge.Models
{
    // This model exists so we can use multiple lists of the AccountModel on ACcountStatuses view
    public class AccountListsModel
    {
        public List<AccountModel> activeAccounts { get; set; }
        public List<AccountModel> inactiveAccounts { get; set; }
        public List<AccountModel> overdueAccounts { get; set; }
    }
}

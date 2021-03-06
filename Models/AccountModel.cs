﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsCodingChallenge.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? AmountDue { get; set; } // May not be needed if account is inactive
        public DateTimeOffset? PaymentDueDate { get; set; } // May not be needed if account is inactive
        public int AccountStatusId { get; set; }
    }
}

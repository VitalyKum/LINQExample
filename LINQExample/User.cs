using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LINQExample
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }        
    }
    class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }

    }
    class History
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime OperationDate { get; set; }
        public OperationType OperationType { get; set; }
        public decimal Amount { get; set; }
    }
    [Flags]
    public enum OperationType
    {
        Debit,
        Credit
    }
}

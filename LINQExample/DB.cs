using System;
using System.Collections.Generic;
using System.Text;

namespace LINQExample
{
    class DB
    {
        private static DB db;
        private DB() { }
        public static DB GetInstance()
        {
            if (db == null)
                db = new DB();
            return db; 
        }
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
                {
                    new User{
                        Id = 1,
                        FirstName = "Иван",
                        MiddleName="Иванович",
                        LastName = "Иванов",
                        RegisterDate = DateTime.Parse("09/11/2017"),
                        Passport = "2503 456723",
                        Phone="950123457",
                        Login="Ivan",
                        Password="Ivan" },
                    new User{
                        Id = 2,
                        FirstName = "Алексей",
                        MiddleName="Алексеевич",
                        LastName = "Алексеев",
                        RegisterDate = DateTime.Parse("12/12/2015"),
                        Passport = "2412 231212",
                        Phone="924124757",
                        Login="Aleksey",
                        Password="Aleksey" },
                    new User{
                        Id = 3,
                        FirstName = "Петр",
                        MiddleName="Иванович",
                        LastName = "Козлов",
                        RegisterDate = DateTime.Parse("14/08/2019"),
                        Passport = "2222 2547812",
                        Phone="9144875210",
                        Login="Peter",
                        Password="Peter" }
                };
        }
        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>
                {
                    new Account{
                        Id = 1,
                        UserId = 1,
                        CreateDate = DateTime.Parse("09/11/2017"),
                        Amount = 1000
                    },
                    new Account{
                        Id = 2,
                        UserId = 2,
                        CreateDate = DateTime.Parse("12/12/2015"),
                        Amount = 2000
                    },
                    new Account{
                        Id = 3,
                        UserId = 3,
                        CreateDate = DateTime.Parse("14/08/2019"),
                        Amount = 3000
                    }
                };
        }
        public IEnumerable<History> GetHistory()
        {
            return new List<History>
                {
                    new History{
                        Id = 1,
                        AccountId = 1,
                        OperationDate = DateTime.Parse("11/11/2017"),
                        OperationType = OperationType.Credit,
                        Amount = 100
                    },
                    new History{
                        Id = 2,
                        AccountId = 1,
                        OperationDate = DateTime.Parse("14/12/2017"),
                        OperationType = OperationType.Credit,
                        Amount = 400
                    },
                    new History{
                        Id = 3,
                        AccountId = 1,
                        OperationDate = DateTime.Parse("01/11/2018"),
                        OperationType = OperationType.Debit,
                        Amount = 700
                    },
                    new History{
                        Id = 4,
                        AccountId = 2,
                        OperationDate = DateTime.Parse("25/12/2015"),
                        OperationType = OperationType.Debit,
                        Amount = 400
                    },
                    new History{
                        Id = 5,
                        AccountId = 2,
                        OperationDate = DateTime.Parse("14/03/2016"),
                        OperationType = OperationType.Debit,
                        Amount = 1200
                    },
                    new History{
                        Id = 6,
                        AccountId = 2,
                        OperationDate = DateTime.Parse("18/06/2016"),
                        OperationType = OperationType.Credit,
                        Amount = 1800
                    },
                    new History{
                        Id = 7,
                        AccountId = 3,
                        OperationDate = DateTime.Parse("15/08/2019"),
                        OperationType = OperationType.Credit,
                        Amount = 400
                    },
                    new History{
                        Id = 8,
                        AccountId = 3,
                        OperationDate = DateTime.Parse("24/10/2019"),
                        OperationType = OperationType.Credit,
                        Amount = 600
                    },
                    new History{
                        Id = 9,
                        AccountId = 3,
                        OperationDate = DateTime.Parse("11/12/2020"),
                        OperationType = OperationType.Credit,
                        Amount = 750
                    }
                };
        }
    }
}

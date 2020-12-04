using System;
using System.Linq;


namespace LINQExample
{
    public interface IQuery
    {
        public void Execute();
    }

    public class Query1 : IQuery
{
        private readonly string title, login, pass;
        public Query1(string login = "", string pass = "")
        {
            this.title = $"Вывод информации о заданном аккаунте по логину и парол";
            this.login = login;
            this.pass = pass;
        }
        public void Execute()
        {
            Console.WriteLine(title);
            
            var items = DB.GetInstance().GetUsers()
               .Where(u =>
                   u.Login == login &&
                   u.Password == pass)
               .Select(u =>
               {
                   Console.WriteLine($"{u.Id} - {u.RegisterDate.ToShortDateString()} : " +
                       $"{u.LastName} " +
                       $"{u.FirstName} " +
                       $"{u.MiddleName} " +
                       $"{u.Passport} " +
                       $"{u.Phone}");
                   return u;
               })
               .OrderBy(d => d.RegisterDate)
               .ToList();

            Console.WriteLine();
        }
    }
    public class Query2 : IQuery
{
        private readonly string title, login, pass;
        public Query2(string login = "", string pass = "")
        {
            this.title = $"Вывод данных о всех счетах заданного пользователя";
            this.login = login;
            this.pass = pass;
        }
        public void Execute()
        {
            Console.WriteLine(title);

            var users = DB.GetInstance().GetUsers();
            var accounts = DB.GetInstance().GetAccounts();

            var items = users
                .Where(u =>
                    u.Login == login &&
                    u.Password == pass
                )
                .Select(u =>
                {
                    Console.WriteLine($"{u.Id} - " +
                        $"{u.LastName} " +
                        $"{u.FirstName} " +
                        $"{u.MiddleName}:");
                    return u;
                })
                .Join(accounts,
                    u => u.Id,
                    a => a.UserId,
                    (u, a) => new {
                        a.Id,
                        a.CreateDate,
                        a.Amount
                    })
                .Select(a =>
                {
                    Console.WriteLine($"{a.Id} " +
                        $"{a.CreateDate.ToShortDateString()} : " +
                        $"{a.Amount}");
                    return a;
                })
                .OrderBy(d => d.CreateDate)
                .ToList();

            Console.WriteLine();
        }
    }
    public class Query3 : IQuery
{
        private readonly string title, login, pass;
        public Query3(string login = "", string pass = "")
        {
            this.title = $"Вывод данных о всех счетах заданного " +
                $"пользователя, включая историю по каждому счёту";
            this.login = login;
            this.pass = pass;
        }
        public void Execute()
        {
            Console.WriteLine(title);

            var users = DB.GetInstance().GetUsers();
            var accounts = DB.GetInstance().GetAccounts();
            var historys = DB.GetInstance().GetHistory();

            var items = users
                .Where(u =>
                    u.Login == login &&
                    u.Password == pass
                )
                .Select(u =>
                {
                    Console.WriteLine($"{u.Id} - " +
                        $"{u.LastName} " +
                        $"{u.FirstName} " +
                        $"{u.MiddleName}:");
                    return u;
                })
                .Join(accounts,
                    u => u.Id,
                    a => a.UserId,
                    (u, a) => new {
                        a.Id,
                        a.CreateDate,
                        a.Amount
                    })
                .Select(a =>
                {
                    Console.WriteLine($"{a.Id} " +
                        $"{a.CreateDate.ToShortDateString()} : " +
                        $"{a.Amount}");
                    return a;
                })
                .OrderBy(d => d.CreateDate)
                .Join(historys,
                    a => a.Id,
                    h => h.AccountId,
                    (a, h) => new {
                        h.Id,
                        h.OperationDate,
                        h.OperationType,
                        h.Amount
                    })
                .Select(item =>
                {
                    Console.WriteLine($"{item.Id} " +
                        $"{item.OperationDate.ToShortDateString()} " +
                        $"{item.OperationType} " +
                        $"{item.Amount}");
                    return item;
                })
                .OrderBy(d => d.OperationDate)
                .ToList();

            Console.WriteLine();
        }
    }
    public class Query4 : IQuery
    {
        private readonly string title;
        public Query4()
        {
            this.title = $"Вывод данных о всех операциях пополенения " +
                $"счёта с указанием владельца каждого счёта";
        }
        public void Execute()
        {
            Console.WriteLine(title);

            var users = DB.GetInstance().GetUsers();
            var accounts = DB.GetInstance().GetAccounts();
            var history = DB.GetInstance().GetHistory();

            var items = users.Join(accounts,
                u => u.Id,
                a => a.UserId,
                (u, a) => new
                {
                    u.LastName,
                    u.FirstName,
                    u.MiddleName,
                    a.Id,
                    AccountAmount = a.Amount
                })
                .Select(item =>
                {
                    Console.WriteLine($"{item.Id} " +
                        $"{item.LastName} " +
                        $"{item.FirstName} " +
                        $"{item.MiddleName} " +
                        $"{item.AccountAmount}");
                    return item;
                })
                .Join(history,
                a => a.Id,
                h => h.AccountId,
                (a, h) => new
                {
                    h.OperationDate,
                    h.OperationType,
                    h.Amount
                })
                .OrderBy(d => d.OperationDate)
                .Where(h => h.OperationType == OperationType.Debit)
                .Select(item =>
                {
                    Console.WriteLine($"{item.OperationDate} " +
                        $"{item.OperationType} " +
                        $"{item.Amount}");
                    return item;
                })
                .ToList();

            Console.WriteLine();
        }
    }
    public class Query5 : IQuery
    {
        private readonly string title;
        private readonly int minLimit;

        public Query5(int minLimit = 0)
        { 
            this.title = $"Вывод данных о всех пользователях " +
                $"у которых на счёте сумма больше N " +
                $" (N задаётся из вне и может быть любой)";
            this.minLimit = minLimit;
        }
        public void Execute()
        {
            Console.WriteLine(title);

            var users = DB.GetInstance().GetUsers();
            var accounts = DB.GetInstance().GetAccounts();

            var items = users.Join(accounts,
                u => u.Id,
                a => a.UserId,
                (u, a) => new {
                    u.LastName,
                    u.FirstName,
                    u.MiddleName,
                    a.Id,
                    a.Amount})
                .Where(x => x.Amount > minLimit)
                .Select(item => {
                    Console.WriteLine($"{item.LastName} " +
                        $"{item.FirstName} " +
                        $"{item.MiddleName} " +
                        $"{item.Id} " +
                        $"{item.Amount}");
                    return item;})
                .ToList();

            Console.WriteLine();
        }
    }
}

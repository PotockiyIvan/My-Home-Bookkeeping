using MyHomeBookkeeping.BL.Controller;
using System;

namespace MyHomeBookkeeping.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение MyHomeBookkeeping");
            Console.Write("Введите имя аккаунта: ");

            var accountName = Console.ReadLine();
            var AccountController =  new AccountController(accountName);
            var spendingController = new SpendingController(AccountController.CurrentAccount);
            var incomeController =   new IncomeController(AccountController.CurrentAccount);

            while (true)
            {
                Console.WriteLine("\t Выберите действие:");
                Console.WriteLine("1. Добавить расход \t 2. Добавить доход");

                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        //РЕАЛИЗУЙ ДОБАВЛЕНИЕ РАСХОДА

                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

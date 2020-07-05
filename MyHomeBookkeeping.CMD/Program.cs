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
            var accountController =  new AccountController(accountName);
            var actionController = new ActionController(accountController.CurrentAccount);

            while (true)
            {
                Console.WriteLine("\t Выберите действие:");
                Console.WriteLine("1. Добавить расход \t 2. Добавить доход");

                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        var spending = EnterData();
                        actionController.AddSpending(spending.spendingName,
                                                       spending.amount,
                                                       spending.category,
                                                       spending.comment);
                        break;
                    case 2:
                        var income = EnterData();
                        actionController.AddIncome(income.spendingName,
                                                       income.amount,
                                                       income.category,
                                                       income.comment);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Кортежный метод для ввода данных по тратам и доходам.
        /// </summary>
        /// <returns></returns>
        private static (string spendingName, double amount, string category, string comment) EnterData()
        {
            Console.WriteLine("Введите название расхода:");
            var spendingName = Console.ReadLine();
            var amount = ParseDouble("расход");
            Console.WriteLine("В какую категорию его добавить?");
            var category = Console.ReadLine();
            Console.WriteLine("Введите комментарий к расходу:");
            var comment = Console.ReadLine();

            return (spendingName, amount, category, comment);
        }
        /// <summary>
        /// Парс данных из стринг в дабл.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите объем {name}а:");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine("Неверный формат,попробуйте еще раз.");
            }
        }
    }
}

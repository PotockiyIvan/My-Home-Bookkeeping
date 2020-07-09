using MyHomeBookkeeping.BL.Controller;
using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;

namespace MyHomeBookkeeping.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение MyHomeBookkeeping");
            Console.Write("Введите имя аккаунта: ");

            var accountName = Console.ReadLine();
            var accountController = new AccountController(accountName);
            var actionController = new ActionController(accountController.CurrentAccount);

            while (true)
            {
                Console.WriteLine("\t\t\t ВЫБЕРИТЕ ДЕЙСТВИЕ.");
                Console.WriteLine("1. Добавить расход \t 2. Просмотреть расходы за месяц \t 3. Посмотреть расходы и доходы по категориям ");
                Console.WriteLine("4. Добавить доход  \t 5. Посмотреть доходы за месяц   \t 6. ");

                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        var spending = EnterData();
                        actionController.AddSpending(spending.actiongName,
                                                     spending.amount,
                                                     spending.category,
                                                     spending.comment);
                        accountController.SaveAccountData();
                        break;
                    case 2:
                        actionController.ShowActions(actionController.Spendings);
                        break;
                    case 3:
                        var category = ChooseCategory();
                        actionController.ShowActionsByCategory(category);
                        break;
                    case 4:
                        var income = EnterData();
                        actionController.AddIncome(income.actiongName,
                                                   income.amount,
                                                   income.category,
                                                   income.comment);
                        accountController.SaveAccountData();
                        break;
                    case 5:
                        actionController.ShowActions(actionController.Incomes);
                        break;
                    case 6:
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
        private static (string actiongName, double amount, string category, string comment) EnterData()
        {
            var category = ChooseCategory();
            Console.WriteLine("Введите название:");
            var actiongName = Console.ReadLine();
            var amount = ParseDouble();
            Console.WriteLine("Введите комментарий:");
            var comment = Console.ReadLine();

            return (actiongName, amount, category, comment);
        }

        /// <summary>
        /// Выбрать категорию расхода или дохода.
        /// </summary>
        /// <returns></returns>
        private static string ChooseCategory()
        {
            string[] categories = new string[] {"Продукты питания","Коммунальные платежи","Развлечения",
                                                "Одежда","Предметы туалета","Корманные расходы",
                                                "Доход: Зарплата","Доход: Шабашка"};

            Console.WriteLine("Выберите категорию");
            for (int i = 0; i < categories.Length - 4; i++)
            {
                Console.Write((i + 1) + ". " + string.Format("{0,-22}", categories[i]));
            }
            Console.WriteLine();
            for (int i = 4; i < categories.Length; i++)
            {
                Console.Write((i + 1) + ". " + string.Format("{0,-22}", categories[i]));
            }
            Console.WriteLine();
            var command = Convert.ToInt32(Console.ReadLine());
            var category = categories[command - 1];
            return category;
        }

        /// <summary>
        /// Парс данных из стринг в дабл.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double ParseDouble()
        {
            while (true)
            {
                Console.WriteLine("Введите сумму:");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine("Неверный формат,попробуйте еще раз.");
            }
        }
    }
}

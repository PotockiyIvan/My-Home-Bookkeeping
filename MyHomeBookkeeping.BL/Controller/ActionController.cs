using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller
{
    public class ActionController : BaseController
    {
        /// <summary>
        /// Список расходов.
        /// </summary>
        public List<Spending> Spendings { get; }

        /// <summary>
        /// Список доходов.
        /// </summary>
        public List<Income> Incomes { get; }

        /// <summary>
        /// Аккаунт.
        /// </summary>
        public Account CurrentAccount { get; }

        public ActionController(Account account)
        {
            this.CurrentAccount = account ?? throw new ArgumentNullException("Аккаунт не может быть пустым", nameof(account));
            this.Spendings = GetData<Spending>("spendings.dat");
            this.Incomes = GetData<Income>("incomes.dat");
        }

        //ПОДУМАЙ КАК ОБЬЕДЕНИТЬ ЭТИ ДВА МЕТОДА!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        /// <summary>
        /// Добавить расход.
        /// </summary>
        /// <param name="spendingName">Название расхода.</param>
        /// <param name="amount">Объем расхода.</param>
        /// <param name="category">Категория расхода.</param>
        /// <param name="comment">Комментарий к расходу.</param>
        public void AddSpending(string spendingName, double amount, string category, string comment)
        {
            var spending = new Spending(spendingName, amount, category, comment);
            Spendings.Add(spending);
            this.CurrentAccount.AccountBalance -= amount;
            SaveData(spending);
        }

        /// <summary>
        /// Добавить доход.
        /// </summary>
        /// <param name="spendingName">Название дохода.</param>
        /// <param name="amount">Объем дохода.</param>
        /// <param name="category">Категория дохода.</param>
        /// <param name="comment">Комментарий к доходу.</param>
        public void AddIncome(string incomeName, double amount, string category, string comment)
        {
            var income = new Income(incomeName, amount, category, comment);
            Incomes.Add(income);
            this.CurrentAccount.AccountBalance += amount;
            SaveData(income);
        }

        /// <summary>
        /// Показать Расходы.
        /// </summary>
        /// <param name="items"></param>
        public  void ShowActions(List<Spending> items)
        {
            items.Sort((s1, s2) => string.Compare(s1.Category, s2.Category));
            items.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();
        }

        /// <summary>
        /// Показать расходы по категориям.
        /// </summary>
        /// <param name="category"> Категория расхода. </param>
        public void ShowActionsByCategory(string category)
        {
            List<Spending> spendingsByCategory = Spendings.FindAll(s => s.Category == category);
            List<Income> incomesByCategory = Incomes.FindAll(i => i.Category == category);
            if (spendingsByCategory.Count != 0)
            {
                spendingsByCategory.Sort((s1, s2) => DateTime.Compare(s1.DateAdded, s2.DateAdded));
                spendingsByCategory.ForEach(s => Console.WriteLine(s));
                Console.WriteLine();
            }
            else if(incomesByCategory.Count != 0)
            {
                incomesByCategory.Sort((s1, s2) => DateTime.Compare(s1.DateAdded, s2.DateAdded));
                incomesByCategory.ForEach(s => Console.WriteLine(s));
                Console.WriteLine();
            }
            else
                Console.WriteLine("Категория пуста.");
        }

        /// <summary>
        /// Показать доходы.
        /// </summary>
        /// <param name="items"></param>
        public  void ShowActions(List<Income> items)
        {
            items.Sort((s1, s2) => string.Compare(s1.Category, s2.Category));
            items.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();
        }

        /// <summary>
        /// Сохранить список расходов или доходов.
        /// </summary>
        private void SaveData(object item)
        {
            if (item is Spending)
                Save("spendings.dat", Spendings);

            else if (item is Income)
                Save("incomes.dat", Incomes);
            else
                throw new ArgumentException("Обьект не является доходом или расходом", nameof(item));

        }

        /// <summary>
        /// Получить Список расходов или доходов.
        /// </summary>
        /// <returns></returns>
        private List<T> GetData<T>(string fileName) where T : class
        {
            return Load<List<T>>(fileName) ?? new List<T>();
        }
    }   
}

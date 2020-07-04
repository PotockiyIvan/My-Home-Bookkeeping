using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller
{
    public class SpendingController : BaseController
    {
        /// <summary>
        /// Список расходов.
        /// </summary>
        public List<Spending> Spendings { get; }
        /// <summary>
        /// Текущий расход.
        /// </summary>
        public Spending CurrentSpending { get; }//УБЕРИ ЕСЛИ БУДЕТ НЕ НУЖНО
        /// <summary>
        /// Аккаунт.
        /// </summary>
        public virtual Account Account { get; }

        public SpendingController(Account account)
        {
            this.Account = account ?? throw new ArgumentNullException("Аккаунт не может быть пустым", nameof(account));
            GetSpendingData();
        }

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
            SaveSpendingData();
        }


        /// <summary>
        /// Сохранить список расходов.
        /// </summary>
        public void SaveSpendingData()
        {
            Save("spendings.dat", Spendings);
        }

        /// <summary>
        /// Получить Список расходов.
        /// </summary>
        /// <returns></returns>
        public List<Model.Spending> GetSpendingData()
        {
            return Load<List<Spending>>("spendings.dat") ?? new List<Spending>();
        }
    }
}

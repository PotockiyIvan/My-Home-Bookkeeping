using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller
{
    public class IncomeController : BaseController
    {
        /// <summary>
        /// Список доходов.
        /// </summary>
        public List<Income> Incomes { get; }
        /// <summary>
        /// Текущий доход.
        /// </summary>
        public Income CurrentIncome { get; }//УБЕРИ ЕСЛИ БУДЕТ НЕ НУЖНО
        /// <summary>
        /// Аккаунт.
        /// </summary>
        public virtual Account Account { get; }

        public IncomeController(Account account)
        {
            this.Account = account ?? throw new ArgumentNullException("Аккаунт не может быть пустым", nameof(account));
            GetIncomeData();
        }

        /// <summary>
        /// Сохранить список доходов.
        /// </summary>
        public void SaveIncomeData() 
        {
            Save("incomes.dat", Incomes);
        }

        /// <summary>
        /// Получить Список доходов.
        /// </summary>
        /// <returns></returns>
        public List<Income> GetIncomeData()
        {
            return Load<List<Income>>("incomes.dat") ?? new List<Income>();
        }
    }
}





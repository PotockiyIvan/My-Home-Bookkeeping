using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Model
{
    [Serializable]
    public abstract class Action
    {
        #region свойства

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Объем.
        /// </summary>
        public double Amount { get; }

        /// <summary>
        /// Категория.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        public DateTime DateAdded { get; } = DateTime.UtcNow;

        #endregion 

        /// <summary>
        /// Новое действие со счетом.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="amount">Объем.</param>
        /// <param name="category">Категория.</param>
        /// <param name="comment">Комментарий.</param>
        protected Action(string name,
                                double amount,
                                string category,
                                string comment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Название операции не может быть пустым", nameof(name));
            if (amount < 0)
                throw new ArgumentException("Сумма операции не может быть меньше нуля", nameof(amount));
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException("Название операции не может быть пустым", nameof(category));

            Name = name;
            Amount = amount;
            Category = category;
            Comment = comment;
        }

        public override string ToString()
        { 
            return string.Format("{0,-35} {1,-35} {2,-15} {3,-30}",
                                 "Категория: " + Category,
                                 "Наименование:" + Name,
                                 "Сумма:" + Amount,
                                 "Время добавления:" + DateAdded);
        }
    }
}

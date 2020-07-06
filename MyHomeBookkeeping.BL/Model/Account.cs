using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Model
{
    [Serializable]
    public class Account
    {
        /// <summary>
        /// Нащвание Аккаунта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Баланс аккаунта.
        /// </summary>
        public double AccountBalance { get; private set; }

        public Account(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя аккаунта не может быть пустым", nameof(name));
            Name = name;
        }

        /// <summary>
        /// Добавление денег на балланс
        /// </summary>
        /// <param name="sum"> Сумма добавления на балланс. </param>
        public void Put(double sum)
        {
            if (sum < 0)
                throw new ArgumentException("Сумма не может быть отрицательной", nameof(sum));
            AccountBalance += sum;
        }

        /// <summary>
        /// Удаление денег из балланса.
        /// </summary>
        /// <param name="sum"> Сумма удаления из балланса .</param>
        public void Withdrow(double sum)
        {
            if (sum < 0)
                throw new ArgumentException("Сумма не может быть отрицательной", nameof(sum));
            AccountBalance -= sum;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}

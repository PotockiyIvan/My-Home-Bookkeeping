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
        public double AccountBalance { get; }

        public Account(string name, double accountBalance)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя аккаунта не может быть пустым", nameof(name));

            if (accountBalance < 0)
                throw new ArgumentException("Балланс аккаунта не может быть отрицательным", nameof(accountBalance));

            Name = name;
            AccountBalance = accountBalance;
        }

        public Account(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя аккаунта не может быть пустым", nameof(name));
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

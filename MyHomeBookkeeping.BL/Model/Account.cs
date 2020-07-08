using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Model
{
    [Serializable]
    public class Account
    {
        /// <summary>
        /// Название Аккаунта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Баланс аккаунта.
        /// </summary>
        public double AccountBalance { get; set; }

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

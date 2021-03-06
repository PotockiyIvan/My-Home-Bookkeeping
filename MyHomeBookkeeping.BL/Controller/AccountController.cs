﻿using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// Список Аккаунтов.
        /// </summary>
        public List<Account> Accounts { get; }

        /// <summary>
        /// Текущий аккаунт.
        /// </summary>
        public Account CurrentAccount { get; }

        public AccountController() { }

        /// <summary>
        /// Создание нового аккаунта
        /// Или его десериализация.
        /// </summary>
        /// <param name="userName">Имя аккаунта.</param>
        public AccountController(string accountName)
        {
            if (string.IsNullOrWhiteSpace(accountName))
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(accountName));

            Accounts = GetAccountData();

            CurrentAccount = Accounts.FirstOrDefault(a => a.Name == accountName);
            if(CurrentAccount == null)
            {
                CurrentAccount = new Account(accountName);
                Accounts.Add(CurrentAccount);
                SaveAccountData();
            }
            else
            {
                Console.WriteLine($"Вы вошли в аккаунт: {CurrentAccount.Name}");
                Console.WriteLine("Текущий балланс: " + CurrentAccount.AccountBalance + "\n\n");
            }         
        }

        /// <summary>
        /// Сохранить список аккаунтов.
        /// </summary>
        public  void SaveAccountData()
        {
            Save("accounts.dat",Accounts);
        }

        /// <summary>
        /// Получить список аккаунтов.
        /// </summary>
        /// <returns></returns>
        private List<Account> GetAccountData()
        {
            return Load<List<Account>>("accounts.dat") ?? new List<Account>();
        }
    }
}

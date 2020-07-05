using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyHomeBookkeeping.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void AccountControllerTest()
        {
            // Arrange: устанавливает начальные условия для выполнения теста

            //Act: выполняет тест(обычно представляет одну строку кода)

            // Assert: верифицирует результат теста

            // Arrange:
            var accountName = Guid.NewGuid().ToString();

            //Act:
            var accountController = new AccountController(accountName);

            // Assert:
            Assert.AreEqual(accountName, accountController.CurrentAccount.Name);

        }
    }
}
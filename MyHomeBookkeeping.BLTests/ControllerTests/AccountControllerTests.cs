using MyHomeBookkeeping.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyHomeBookkeeping.BLTests.ControllerTests
{
    public class AccountControllerTests
    {
        //Arrange: устанавливает начальные условия для выполнения теста

        //Act: выполняет тест(обычно представляет одну строку кода)

        //Assert: верифицирует результат теста

        [Fact]
        public void GetAccountDataTest()
        {
            //Arrange:
            var accountName = Guid.NewGuid().ToString();

            //Act:
            var controller = new AccountController("accountName");

            //Assert:
            Assert.AreEqual(accountName,controller.CurrentAccount.Name);
            Assert.Equal(accountName, controller.CurrentAccount.Name)

        }

    }
}

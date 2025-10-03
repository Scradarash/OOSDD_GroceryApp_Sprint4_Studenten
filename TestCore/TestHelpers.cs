using Grocery.Core.Helpers;
using Grocery.Core.Models;

namespace TestCore
{
    public class TestHelpers
    {
        [SetUp]
        public void Setup()
        {
        }


        //Happy flow
        [Test]
        public void TestPasswordHelperReturnsTrue()
        {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsTrue(string password, string passwordHash)
        {
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }


        //Unhappy flow
        [Test]
        public void TestPasswordHelperReturnsFalse()
        {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA1";
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM081")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA1")]
        public void TestPasswordHelperReturnsFalse(string password, string passwordHash)
        {
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash));
        }
    }

    public class TestGroceryListItem
    {
        [Test]
        public void GroceryListItem_CreatesWithValidAmount()
        {
            var item = new GroceryListItem(1, 1, 1, 5);

            Assert.That(item.Amount, Is.EqualTo(5));
            Assert.That(item.ProductId, Is.EqualTo(1));
            Assert.That(item.GroceryListId, Is.EqualTo(1));
        }

        [Test]
        public void GroceryListItem_AllowsZeroAmount_CurrentBehavior()
        {
            var item = new GroceryListItem(1, 1, 1, 0);

            // huidige gedrag: Amount mag 0 zijn
            Assert.That(item.Amount, Is.EqualTo(0));
        }

        [Test]
        public void GroceryListItem_AllowsNegativeAmount_CurrentBehavior()
        {
            var item = new GroceryListItem(1, 1, 1, -3);

            // huidige gedrag: negatieve waardes zijn toegestaan
            Assert.That(item.Amount, Is.EqualTo(-3));
        }
    }
}

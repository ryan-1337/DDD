using Domain.Entities;

namespace Domain.Tests
{
    public class WalletTest
    {
        [Fact]
        public void CreateWallet_ShouldGenerateUniqueId()
        {
            var clientId = Guid.NewGuid();
            var amount = 100.0m;
            var currency = "EUR";

            var wallet = new Wallet(clientId, amount, currency);

            Assert.NotNull(wallet.Id);
            Assert.NotEqual(Guid.Empty, wallet.Id);
        }

        [Fact]
        public void CreateWallet_ShouldSetClientId()
        {
            var clientId = Guid.NewGuid();
            var amount = 100.0m;
            var currency = "EUR";

            var wallet = new Wallet(clientId, amount, currency);

            Assert.Equal(clientId, wallet.ClientId);
        }

        [Fact]
        public void CreateWallet_ShouldSetAmount()
        {
            var clientId = Guid.NewGuid();
            var amount = 100.0m;
            var currency = "EUR";

            var wallet = new Wallet(clientId, amount, currency);

            Assert.Equal(amount, wallet.Amount);
        }

        [Fact]
        public void CreateWallet_ShouldSetCurrency()
        {
            var clientId = Guid.NewGuid();
            var amount = 100.0m;
            var currency = "EUR";

            var wallet = new Wallet(clientId, amount, currency);

            Assert.Equal(currency, wallet.Currency);
        }
    }
}
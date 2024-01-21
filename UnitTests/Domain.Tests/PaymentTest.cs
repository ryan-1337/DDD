using Domain.Entities;
using Domain.Services;
using Moq;
using Xunit.Sdk;

namespace Domain.Tests;

public class PaymentTest
{
    // Méthode de test pour vérifier si le paiement est ajouté avec succès
    [Fact]
    public async Task AddPayment_Success()
    {
        // Arrange
        var paymentRepositoryMock = new Mock<IPaymentRepository>();
        var clientRepositoryMock = new Mock<IClientRepository>();

        var paymentService = new PaymentService(paymentRepositoryMock.Object);
        var client = new Client
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890"
        };

        var payment = new Payment(client, 100.00m, DateTime.Now);
        // Act
        var result = await paymentService.ProcessPayment(payment);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(payment.Id, result.Id);
    }
}
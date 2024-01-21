using Domain.Entities;

namespace Domain.Tests;

public class ClientTest
{
    [Fact]
    public void CreateClient_ShouldGenerateUniqueId()
    {
        // Arrange
        string userName = "John Doe";

        // Act
        var client = new Client(Guid.NewGuid(), userName, "test@gmail.com", "0612345689");

        // Assert
        Assert.NotNull(client.Id);
        Assert.NotEqual(Guid.Empty, client.Id);
    }
}
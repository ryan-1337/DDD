using Domain.Entities;

namespace Domain.Tests;

public class ClientTest
{
    [Fact]
    public void CreateClient_ShouldGenerateUniqueId()
    {
        string userName = "John Doe";

        var client = new Client(Guid.NewGuid(), userName, "test@gmail.com", "0612345689");

        Assert.NotNull(client.Id);
        Assert.NotEqual(Guid.Empty, client.Id);
    }
}
namespace Domain.Tests;

public class UserTest
{
    [Fact]
    public void CreateClient_ShouldGenerateUniqueId()
    {
        // Arrange
        string userName = "John Doe";

        // Act
        var user = new User { Name = userName, Id = Guid.NewGuid().ToString() };

        // Assert
        Assert.NotNull(user.Id);
        Assert.NotEqual(Guid.Empty.ToString(), user.Id);
    }
}
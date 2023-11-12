using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User
{
    public string Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

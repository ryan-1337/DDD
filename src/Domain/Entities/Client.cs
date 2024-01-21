using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Client
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    private List<Booking> bookings = new List<Booking>();


    public Client(Guid id, string fullName, string email, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Client()
    {
        
    }
}

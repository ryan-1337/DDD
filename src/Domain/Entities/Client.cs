using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Client
{
    public Guid Id { get; }
    public string FullName { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
    private List<Booking> bookings = new List<Booking>();


    public Client(Guid id, string fullName, string email, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
    } 
}

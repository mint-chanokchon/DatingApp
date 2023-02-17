using System.ComponentModel.DataAnnotations;

namespace server.Entities;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
}

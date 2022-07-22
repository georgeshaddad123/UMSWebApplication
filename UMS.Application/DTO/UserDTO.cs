namespace UMS.Application.DTO;

public class UserDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long RoleId { get; set; }
    public string RoleName { get; set; }
    public string Email { get; set; }
}
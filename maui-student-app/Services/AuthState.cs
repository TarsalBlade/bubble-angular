namespace SAMS.Mobile.Services;

public class AuthState
{
    public bool isLoggedIn { get; set; }
    public Guid? authId { get; set; }
    public Guid id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool isApproved { get; set; }
    public string accessLevel { get; set; } = "student";
}

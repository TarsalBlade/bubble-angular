using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SAMS.Mobile.Models;

[Table("teachers")]
public class Teacher : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("auth_user_id")]
    public Guid? AuthUserId { get; set; }

    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("isApproved")]
    public bool IsApproved { get; set; }

    [Column("isActive")]
    public bool isActive { get; set; }

    [Column("access_level")]
    public string accessLevel { get; set; } = "admin";
}

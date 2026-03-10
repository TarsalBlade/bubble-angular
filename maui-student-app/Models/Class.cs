using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SAMS.Mobile.Models;

[Table("classes")]
public class Class : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("section_name")]
    public string SectionName { get; set; } = string.Empty;

    [Column("teacher_id")]
    public Guid TeacherId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}

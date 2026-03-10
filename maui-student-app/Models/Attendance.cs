using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SAMS.Mobile.Models;

[Table("attendance")]
public class Attendance : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("student_id")]
    public Guid StudentId { get; set; }

    [Column("student_no")]
    public string StudentNo { get; set; } = string.Empty;

    [Column("class_id")]
    public Guid ClassId { get; set; }

    [Column("status")]
    public string Status { get; set; } = "present";

    [Column("attendance_date")]
    public DateTime AttendanceDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}

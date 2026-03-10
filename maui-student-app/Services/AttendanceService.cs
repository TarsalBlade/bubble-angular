using SAMS.Mobile.Models;

namespace SAMS.Mobile.Services;

public class AttendanceService
{
    private readonly SupabaseService _supabaseService;

    public AttendanceService(SupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Attendance>> GetAttendanceByStudentIdAsync(Guid studentId)
    {
        await _supabaseService.InitializeAsync();

        var result = await _supabaseService.Client
            .From<Attendance>()
            .Where(x => x.StudentId == studentId)
            .Order(x => x.AttendanceDate, Supabase.Postgrest.Constants.Ordering.Descending)
            .Get();

        return result.Models;
    }
}

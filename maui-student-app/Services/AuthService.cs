using SAMS.Mobile.Models;

namespace SAMS.Mobile.Services;

public class AuthService
{
    private readonly SupabaseService _supabaseService;

    public AuthState State { get; } = new();

    public AuthService(SupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<(bool Success, string Error)> LoginAsync(string email, string password)
    {
        await _supabaseService.InitializeAsync();

        var session = await _supabaseService.Client.Auth.SignIn(email, password);
        if (session?.User is null)
        {
            return (false, "Invalid credentials.");
        }

        var userId = Guid.Parse(session.User.Id);

        // Mobile app is for students only.
        var studentResponse = await _supabaseService.Client
            .From<Student>()
            .Where(s => s.AuthUserId == userId)
            .Get();

        var student = studentResponse.Models.FirstOrDefault();
        if (student is null)
        {
            await _supabaseService.Client.Auth.SignOut();
            return (false, "No student profile found for this account.");
        }

        State.isLoggedIn = true;
        State.authId = student.AuthUserId;
        State.id = student.Id;
        State.FullName = student.FullName;
        State.Email = student.Email;
        State.CreatedAt = student.CreatedAt;
        State.isApproved = true;
        State.accessLevel = "student";

        return (true, string.Empty);
    }

    public async Task LogoutAsync()
    {
        await _supabaseService.Client.Auth.SignOut();
        State.isLoggedIn = false;
        State.authId = null;
        State.id = Guid.Empty;
        State.FullName = string.Empty;
        State.Email = string.Empty;
        State.CreatedAt = default;
        State.isApproved = false;
        State.accessLevel = "student";
    }
}

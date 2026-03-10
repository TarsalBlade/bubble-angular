using Supabase;

namespace SAMS.Mobile.Services;

public class SupabaseService
{
    // TODO: move to secure storage / appsettings in production.
    private const string SupabaseUrl = "https://YOUR_PROJECT.supabase.co";
    private const string SupabaseAnonKey = "YOUR_ANON_KEY";

    public Client Client { get; }

    public SupabaseService()
    {
        var options = new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        };

        Client = new Client(SupabaseUrl, SupabaseAnonKey, options);
    }

    public async Task InitializeAsync()
    {
        await Client.InitializeAsync();
    }
}

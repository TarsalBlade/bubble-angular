using System.Collections.ObjectModel;
using System.Windows.Input;
using SAMS.Mobile.Models;
using SAMS.Mobile.Services;

namespace SAMS.Mobile.ViewModels;

public class StudentHomeViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private readonly AttendanceService _attendanceService;

    public StudentHomeViewModel(AuthService authService, AttendanceService attendanceService)
    {
        _authService = authService;
        _attendanceService = attendanceService;
        Attendances = new ObservableCollection<Attendance>();

        LoadCommand = new Command(async () => await LoadAsync());
        LogoutCommand = new Command(async () => await LogoutAsync());
    }

    public ObservableCollection<Attendance> Attendances { get; }

    public string FullName => _authService.State.FullName;
    public string StudentEmail => _authService.State.Email;

    public int PresentCount => Attendances.Count(x => x.Status.Equals("present", StringComparison.OrdinalIgnoreCase));
    public int AbsentCount => Attendances.Count(x => x.Status.Equals("absent", StringComparison.OrdinalIgnoreCase));

    public ICommand LoadCommand { get; }
    public ICommand LogoutCommand { get; }

    public async Task LoadAsync()
    {
        if (IsBusy || !_authService.State.isLoggedIn) return;

        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var rows = await _attendanceService.GetAttendanceByStudentIdAsync(_authService.State.id);
            Attendances.Clear();
            foreach (var row in rows.Take(10))
            {
                Attendances.Add(row);
            }

            OnPropertyChanged(nameof(PresentCount));
            OnPropertyChanged(nameof(AbsentCount));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(StudentEmail));
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task LogoutAsync()
    {
        await _authService.LogoutAsync();
        await Shell.Current.GoToAsync("//login");
    }
}

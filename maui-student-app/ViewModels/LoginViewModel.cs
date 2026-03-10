using System.Windows.Input;
using SAMS.Mobile.Services;

namespace SAMS.Mobile.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
        LoginCommand = new Command(async () => await LoginAsync(), () => !IsBusy);
    }

    private string _email = string.Empty;
    public string Email
    {
        get => _email;
        set
        {
            if (_email == value) return;
            _email = value;
            OnPropertyChanged();
        }
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set
        {
            if (_password == value) return;
            _password = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoginCommand { get; }

    private async Task LoginAsync()
    {
        if (IsBusy) return;

        IsBusy = true;
        ErrorMessage = string.Empty;

        var result = await _authService.LoginAsync(Email, Password);
        if (!result.Success)
        {
            ErrorMessage = result.Error;
            IsBusy = false;
            return;
        }

        await Shell.Current.GoToAsync("//home");
        IsBusy = false;
    }
}

using SAMS.Mobile.ViewModels;

namespace SAMS.Mobile.Views;

public partial class StudentHomePage : ContentPage
{
    private readonly StudentHomeViewModel _viewModel;

    public StudentHomePage(StudentHomeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadAsync();
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("attendance-history");
    }
}

using SAMS.Mobile.ViewModels;

namespace SAMS.Mobile.Views;

public partial class AttendanceHistoryPage : ContentPage
{
    private readonly StudentHomeViewModel _viewModel;

    public AttendanceHistoryPage(StudentHomeViewModel viewModel)
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
}

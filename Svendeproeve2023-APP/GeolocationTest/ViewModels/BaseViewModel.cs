using CommunityToolkit.Mvvm.ComponentModel;

namespace GeolocationTest.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;
    }
}

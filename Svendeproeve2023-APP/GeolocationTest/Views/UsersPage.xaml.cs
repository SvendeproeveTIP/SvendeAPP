using GeolocationTest.Services;

namespace GeolocationTest.Views;
public partial class UsersPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public UsersPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		collectionView.ItemsSource = await _dataService.GetAllUsersAsync();
	}

	async void OnAddUserClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("---> Add button clicked!");

		var navigationParameter = new Dictionary<string, object>
		{
			{nameof(Users), new Users() }
		};

		await Shell.Current.GoToAsync(nameof(ManageUserPage), navigationParameter);
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        Debug.WriteLine("---> Item changed clicked!");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Users), e.CurrentSelection.FirstOrDefault() as Users }
        };

        await Shell.Current.GoToAsync(nameof(ManageUserPage), navigationParameter);
    }
}
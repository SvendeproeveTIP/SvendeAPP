using GeolocationTest.Services;

namespace GeolocationTest.Views;

[QueryProperty(nameof(Users), "Users")]
public partial class ManageUserPage : ContentPage
{
    private readonly IRestDataService _dataService;
	Users _user;
	bool _isNew;


	public Users Users
	{
		get => _user;
		set
		{
			_isNew = IsNew(value);
			_user = value;
			OnPropertyChanged();
		}
	}

    public ManageUserPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;

		BindingContext = this;
	}

	bool IsNew(Users user)
	{
		if (user.UserId == 0)
			return true;
		return false;
	}
	
	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("---> Add new Item");
			await _dataService.AddUserAsync(Users);
		}
		else
		{
            Debug.WriteLine("---> Updated Item");
            await _dataService.UpdateUserAsync(Users);
        }

        await Shell.Current.GoToAsync("..");
    }

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		await _dataService.DeleteUserAsync(Users.UserId);
        await Shell.Current.GoToAsync("..");
    }

	async void OnCancelButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}
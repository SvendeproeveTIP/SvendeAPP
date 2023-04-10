using GeolocationTest.Helper;
using Syncfusion.Maui.DataSource;
using ListSortDirection = Syncfusion.Maui.DataSource.ListSortDirection;

namespace GeolocationTest.Views;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
        listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
        {
            PropertyName = "DateOfBirth",
            KeySelector = (object obj1) =>
            {
                var item = (obj1 as Orders);
                return item.DateOfBirth.Month + "/" + item.DateOfBirth.Year;
            },
            Comparer = new CustomGroupComparer()
        });
        this.listView.DataSource.SortDescriptors.Add(new SortDescriptor()
        {
            PropertyName = "DateOfBirth",
            Direction = ListSortDirection.Ascending
        });
    }
}
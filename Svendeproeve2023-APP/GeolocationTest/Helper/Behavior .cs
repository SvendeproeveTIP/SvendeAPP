using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.ListView;
using ListSortDirection = Syncfusion.Maui.DataSource.ListSortDirection;

namespace GeolocationTest.Helper
{
    public class Behavior : Behavior<SfListView>
    {
        SfListView listView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            listView = bindable;

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
                Direction = ListSortDirection.Descending
            });

            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}

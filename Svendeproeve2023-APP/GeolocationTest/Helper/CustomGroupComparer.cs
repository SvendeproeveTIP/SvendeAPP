using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.DataSource.Extensions;
using System;
using System.Collections.Generic;
using ListSortDirection = Syncfusion.Maui.DataSource.ListSortDirection;

namespace GeolocationTest.Helper
{
    class CustomGroupComparer : IComparer<GroupResult>, ISortDirection
    {
        public CustomGroupComparer()
        {
            this.SortDirection = ListSortDirection.Descending;
        }

        public ListSortDirection SortDirection
        {
            get;
            set;
        }

        public int Compare(GroupResult x, GroupResult y)
        {
            DateTime xvalue = Convert.ToDateTime(x.Key);
            DateTime yvalue = Convert.ToDateTime(y.Key);

            // Group results are compared and return the SortDirection
            if (xvalue.CompareTo(yvalue) > 0)
                return SortDirection == ListSortDirection.Descending ? -1 : 1;
            else if (xvalue.CompareTo(yvalue) == -1)
                return SortDirection == ListSortDirection.Descending ? 1 : -1;
            else
                return 0;
        }
    }
}

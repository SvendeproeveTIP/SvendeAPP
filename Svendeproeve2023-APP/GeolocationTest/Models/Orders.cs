using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Models
{
    public class Orders : INotifyPropertyChanged
    {
        private string contactName;
        private DateTimeOffset dateOfBirth;

        public Orders(string name, DateTimeOffset number)
        {
            contactName = name;
            dateOfBirth = number;
        }
        public Orders()
        {

        }
        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }
        public DateTimeOffset DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    this.RaisedOnPropertyChanged("DateOfBirth");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}

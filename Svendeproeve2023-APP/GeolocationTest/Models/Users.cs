using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GeolocationTest.Models
{
    public class Users : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }

        //public long StatusId { get; set; }
        //public long RoleId { get; set; }

        long _userid;
        public long UserId
        {
            get => _userid;
            set
            {
                if (_userid == value)
                    return;

                _userid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserId)));
            }
        }
        string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value)
                    return;

                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }

        string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        int _statusid;
        public int StatusId
        {
            get => _statusid;
            set
            {
                if (_statusid == value)
                    return;

                _statusid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusId)));
            }
        }
        int _roleid;
        public int RoleId
        {
            get => _roleid;
            set
            {
                if (_roleid == value)
                    return;

                _roleid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoleId)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}

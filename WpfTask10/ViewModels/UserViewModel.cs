using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfTask10.Models;

namespace WpfTask10.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public UserModel User { get; set; }

        public int Index
        {
            get => Id - 1;
            set
            {
                Id = value + 1;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => User.Id;
            set
            {
                User.Id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => User.Name;
            set
            {
                User.Name = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => User.Phone;
            set
            {
                User.Phone = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => User.Email;
            set
            {
                User.Email = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel()
        {
            User = new UserModel();
        }

        public UserViewModel(UserModel user)
        {
            User = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

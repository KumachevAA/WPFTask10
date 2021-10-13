using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfTask10.Models;
using WpfTask10.Util;

namespace WpfTask10.ViewModels
{
    public class UserListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserViewModel> Users { get; } = new ObservableCollection<UserViewModel>();
        private IRepository<UserModel> _userRepository;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserListViewModel()
        {
            _userRepository = DependencyInjector.instance.GetDependency<IRepository<UserModel>>();
            _userRepository.CollectionChanged += () =>
            {
                Users.Clear();

                foreach (var user in _userRepository.Get())
                {
                    Users.Add(new UserViewModel(user));
                }
            };

            _userRepository.Pull();
        }
    }
}

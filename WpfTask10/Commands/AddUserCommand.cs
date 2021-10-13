using System;
using System.Windows.Input;
using WpfTask10.Models;
using WpfTask10.Util;
using WpfTask10.ViewModels;

namespace WpfTask10.Commands
{
    internal class AddUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private IRepository<UserModel> _userRepository;

        public AddUserCommand()
        {
            _userRepository = DependencyInjector.instance.GetDependency<IRepository<UserModel>>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is UserViewModel viewModel)
            {
                UserModel user = (UserModel)viewModel.User.Clone();

                if (user.Id > 0)
                {
                    _userRepository.Update(user);
                }
                else
                {
                    _userRepository.Add(user);
                }

                viewModel.Id = 0;
                viewModel.Name = "";
                viewModel.Phone = "";
                viewModel.Email = "";
            }
        }
    }
}

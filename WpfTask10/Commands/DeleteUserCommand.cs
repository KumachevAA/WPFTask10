using System;
using System.Windows.Input;
using WpfTask10.Models;
using WpfTask10.Util;

namespace WpfTask10.Commands
{
    internal class DeleteUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private IRepository<UserModel> _userRepository;

        public DeleteUserCommand()
        {
            _userRepository = DependencyInjector.instance.GetDependency<IRepository<UserModel>>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is int id)
            {
                _userRepository.Remove(id);
            }
        }
    }
}

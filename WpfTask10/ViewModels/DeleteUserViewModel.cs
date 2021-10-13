using System.Windows.Input;
using WpfTask10.Commands;

namespace WpfTask10.ViewModels
{
    public class DeleteUserViewModel
    {
        public ICommand DeleteCommand => new DeleteUserCommand();
    }
}

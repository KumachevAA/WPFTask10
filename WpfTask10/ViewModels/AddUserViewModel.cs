using System.Windows.Input;
using WpfTask10.Commands;

namespace WpfTask10.ViewModels
{
    public class AddUserViewModel
    {
        public ICommand AddCommand => new AddUserCommand();
    }
}

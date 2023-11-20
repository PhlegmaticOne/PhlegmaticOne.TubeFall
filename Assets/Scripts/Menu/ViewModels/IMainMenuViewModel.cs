using System.Windows.Input;

namespace Menu.ViewModels {
    public interface IMainMenuViewModel {
        ICommand StartGameCommand { get; } 
        ICommand SetGyroCommand { get; }
        ICommand SetInputCommand { get; }
        ICommand AddCoinsCommand { get; }
    }
}
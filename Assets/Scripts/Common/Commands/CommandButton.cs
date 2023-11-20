using System;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Commands {
    [RequireComponent(typeof(Button))]
    public class CommandButton : MonoBehaviour {
        [SerializeField] private Button _button;
        
        private ICommand _command;
        private object _parameter;

        private void OnValidate() => _button = GetComponent<Button>();

        public void Setup(ICommand command, object parameter = null) {
            _parameter = parameter;
            _command = command;
            _command.CanExecuteChanged += CommandOnCanExecuteChanged;
            _button.onClick.AddListener(ExecuteCommand);
            UpdateInteractable();
        }

        public void OnReset() {
            if (_command is null) {
                return;
            }
            
            _button.onClick.RemoveListener(ExecuteCommand);
            _command.CanExecuteChanged -= CommandOnCanExecuteChanged;
            _command = null;
            _parameter = null;
        }

        private void CommandOnCanExecuteChanged(object sender, EventArgs e) => UpdateInteractable();
        private void UpdateInteractable() => _button.interactable = _command.CanExecute(_parameter);
        private void ExecuteCommand() => _command.Execute(_parameter);
    }

}
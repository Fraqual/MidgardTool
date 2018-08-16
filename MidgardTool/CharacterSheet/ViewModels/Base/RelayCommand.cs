using Logger;
using System;
using System.Windows.Input;

namespace CharacterSheet.ViewModels.Base
{
    public class RelayCommand : ICommand
    {

        private Action m_Action;


        #region ICommand

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            try
            {
                m_Action();
            }
            catch(Exception ex)
            {
                SimpleLogger.Instance.Log(ex.Message, Logger.Enums.LogLevel.Debug);
            }
        }

        #endregion

    }
}

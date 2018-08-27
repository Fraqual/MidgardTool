using Logger;
using System;
using System.Windows.Input;

namespace CharacterSheet.ViewModels.Base
{
    public class RelayCommand : ICommand
    {

        private readonly Action m_Action;

        #region Construction

        public RelayCommand(Action action)
        {
            m_Action = action;
        }

        #endregion

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
                SimpleLogger.Instance.Log(ex.Message, LogLevel.Debug);
            }
        }

        #endregion

    }

    public class RelayCommand<T> : ICommand
    {

        private readonly Action<T> m_Action;

        #region Construction

        public RelayCommand(Action<T> action)
        {
            m_Action = action;
        }

        #endregion

        #region ICommand

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            try
            {
                m_Action((T)parameter);
            }
            catch(Exception ex)
            {
                SimpleLogger.Instance.Log(ex.Message, LogLevel.Debug);
            }
        }

        #endregion

    }

}

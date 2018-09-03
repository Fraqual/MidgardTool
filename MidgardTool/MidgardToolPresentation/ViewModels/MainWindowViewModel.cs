using CharacterCreationPresentation;
using MidgardToolHelper.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace MidgardToolPresentation.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {



        public MainWindowViewModel()
        {

        }

        #region Commands

        private RelayCommand m_CmdCharacterCreation;
        public ICommand CmdCharacterCreation
        {
            get
            {
                if(m_CmdCharacterCreation == null)
                {
                    m_CmdCharacterCreation = new RelayCommand(() => 
                    {
                        Window characterCreationWindow = new CharacterCreationWindow();
                        characterCreationWindow.Show();
                    });
                }
                return m_CmdCharacterCreation;
            }
        }

        #endregion
    }
}

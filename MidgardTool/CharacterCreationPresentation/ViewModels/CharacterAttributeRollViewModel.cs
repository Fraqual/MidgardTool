using MidgardEntities.Character;
using MidgardToolHelper.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace CharacterCreationPresentation.ViewModels
{
    public class CharacterAttributeRollViewModel : BaseViewModell
    {
        private Character m_Character;

        public Visibility MethodSelectionVisibility { get; set; } = Visibility.Visible;
        public Visibility DiceSelectionVisibility { get; set; } = Visibility.Hidden;

        public bool STRIsEnabled { get; set; } = true;
        public bool GWIsEnabled { get; set; } = true;
        public bool GSIsEnabled { get; set; } = true;
        public bool KOIsEnabled { get; set; } = true;
        public bool INIsEnabled { get; set; } = true;
        public bool ZTIsEnabled { get; set; } = true;
        public bool AUIsEnabled { get; set; } = true;
        public bool PAIsEnabled { get; set; } = true;
        public bool WKIsEnabled { get; set; } = true;
        public bool BIsEnabled { get; set; } = true;

        #region Construction

        public CharacterAttributeRollViewModel()
        {
            
        }

        #endregion

        #region Commands

        private RelayCommand m_CmdRollMethod1;
        public ICommand CmdRollMethod1
        {
            get
            {
                if(m_CmdRollMethod1 == null)
                {
                    m_CmdRollMethod1 = new RelayCommand(() =>
                    {
                        MethodSelectionVisibility = Visibility.Hidden;
                        DiceSelectionVisibility = Visibility.Visible;
                    });
                }
                return m_CmdRollMethod1;
            }
        }

        private RelayCommand m_CmdRollMethod2;
        public ICommand CmdRollMethod2
        {
            get
            {
                if(m_CmdRollMethod2 == null)
                {
                    m_CmdRollMethod2 = new RelayCommand(() =>
                    {
                        MethodSelectionVisibility = Visibility.Hidden;
                        DiceSelectionVisibility = Visibility.Visible;
                    });
                }
                return m_CmdRollMethod2;
            }
        }


        private RelayCommand m_CmdSetSTR;
        public ICommand CmdSetSTR
        {
            get
            {
                if(m_CmdSetSTR == null)
                {
                    m_CmdSetSTR = new RelayCommand(() =>
                    {

                    });
                }
                return m_CmdSetSTR;
            }
        }


        #endregion
    }
}

using CharacterLogic;
using CharacterSheet.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace CharacterSheet.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {

        private ICharacterLogic m_CharacterLogic;

        #region Window Properties

        public string tbFigur { get; set; }

        public string tbName { get => m_CharacterLogic.Name; set => m_CharacterLogic.Name = value; }

        public List<string> cbKlasse { get => m_CharacterLogic.GetCharacterClasses(); }

        public string cbSelectedKlasse { get; set; }

        public List<string> cbRasse { get => m_CharacterLogic.GetRaces(); }

        public string cbSelectedRasse { get; set; }

        #endregion

        #region Commands

        private RelayCommand m_BtnRandomName;

        public ICommand BtnRandomName
        {
            get
            {
                if(m_BtnRandomName == null)
                {
                    m_BtnRandomName = new RelayCommand(setRandomName);
                }
                return m_BtnRandomName;
            }
        }

        #endregion

        #region Construction

        public MainWindowViewModel()
        {
            m_CharacterLogic = new Character();
        }

        #endregion

        private void setRandomName()
        {
            m_CharacterLogic.SetRandomName();
            NotifyPropertyChanged(this, "tbName");
        }

    }
}

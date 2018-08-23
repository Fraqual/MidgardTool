using CharacterLogic;
using CharacterSheet.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CharacterSheet.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {

        private ICharacterLogic m_CharacterLogic;

        #region Window Properties

        public string txtFigur { get; set; }

        public string txtName { get => m_CharacterLogic.Name; set => m_CharacterLogic.Name = value; }

        public List<string> cbKlasse { get => m_CharacterLogic.GetCharacterClasses(); }

        public string cbSelectedKlasse { get; set; }

        public List<string> cbRasse { get => m_CharacterLogic.GetRaces(); }

        public string cbSelectedRasse { get; set; }

        #region Attributes

        private int m_TxtStaerke;

        public int txtStaerke
        {
            get => m_TxtStaerke;           
            set => m_TxtStaerke = validateAttrInput(value);            
        }

        #endregion

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

        private RelayCommand<string> m_cmdRandomAttribValue;

        public ICommand cmdRandomStrength
        {
            get
            {
                if(m_cmdRandomAttribValue == null)
                {
                    m_cmdRandomAttribValue = new RelayCommand<string>(setRandomAttribValue);
                }
                return m_cmdRandomAttribValue;
            }
        }

        #endregion

        #region Construction

        public MainWindowViewModel()
        {
            m_CharacterLogic = new Character();
        }

        #endregion

        private int validateAttrInput(int value)
        {
            if(value <= 0)
            {
                return 1;
            }
            if(value > 100)
            {
                return 100;
            }
            return value;
        }

        private int randomAttributeValue() => (new Random()).Next(1, 101);

        #region Command Methods

        private void setRandomName()
        {
            m_CharacterLogic.SetRandomName();
            NotifyPropertyChanged(this, "tbName");
        }

        private void setRandomAttribValue(string attribute)
        {

            switch(attribute)
            {
                case "txtStaerke":
                    m_TxtStaerke = randomAttributeValue();
                    break;
                default:
                    return;
            }

            NotifyPropertyChanged(this, attribute);
        }

        #endregion

    }
}

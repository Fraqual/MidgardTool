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

        public string strName { get => m_CharacterLogic.Name; set => m_CharacterLogic.Name = value; }

        public List<string> cbKlasse { get => m_CharacterLogic.GetCharacterClasses(); }

        public string cbSelectedKlasse { get; set; }

        public List<string> cbRasse { get => m_CharacterLogic.GetRaces(); }

        public string cbSelectedRasse { get; set; }

        #region Attributes

        private int m_IntStrength;

        public int intStrength
        {
            get => m_IntStrength;           
            set => m_IntStrength = validateAttrInput(value);            
        }

        #endregion

        #endregion

        #region Commands

        private RelayCommand m_CmdRandomName;

        public ICommand cmdRandomName
        {
            get
            {
                if(m_CmdRandomName == null)
                {
                    m_CmdRandomName = new RelayCommand(setRandomName);
                }
                return m_CmdRandomName;
            }
        }

        private RelayCommand<string> m_cmdRandomAttributeValue;

        public ICommand cmdRandomAttributeValue
        {
            get
            {
                if(m_cmdRandomAttributeValue == null)
                {
                    m_cmdRandomAttributeValue = new RelayCommand<string>(setRandomAttribValue);
                }
                return m_cmdRandomAttributeValue;
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
            NotifyPropertyChanged(this, "strName");
        }

        private void setRandomAttribValue(string attribute)
        {

            switch(attribute)
            {
                case "intStrength":
                    intStrength = randomAttributeValue();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}

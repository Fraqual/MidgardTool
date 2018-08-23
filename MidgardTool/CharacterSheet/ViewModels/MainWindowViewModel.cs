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

        #region Basic Information

        public string strName { get; set; }

        public List<string> strlClass { get; set; }
        public int strlClassSelection { get; set; }

        #endregion

        #region Appereance

        public string strDateOfBirth { get; set; }

        public int intAge { get; set; }

        public float fltSize { get; set; }

        public float fltWeight { get; set; }

        public List<string> strlRace { get; set; }
        public int strlRaceSelection { get; set; }

        public List<string> strlSex { get; set; }
        public int strlSexSelection { get; set; }

        public List<string> strlFaith { get; set; }
        public int strlFaithSelection { get; set; }

        public List<string> strlDegree { get; set; }
        public int strlDegreeSelection { get; set; }

        #endregion

        #region Attributes

        public int intStrength { get; set; }

        public int intAppereance { get; set; }

        #endregion

        #endregion

        #region Commands

        private RelayCommand<string> m_CmdRandomSelection;

        public ICommand cmdRandomSelection
        {
            get
            {
                if(m_CmdRandomSelection == null)
                {
                    m_CmdRandomSelection = new RelayCommand<string>(setRandomSelection); 
                }
                return m_CmdRandomSelection;
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

        #region Command Methods

        private void setRandomSelection(string attribute)
        {
            int maxIndex = ((List<string>)this.GetType().GetProperty(attribute).GetValue(this)).Count;
            this.GetType().GetProperty(attribute + "Selection").SetValue(this, (new Random()).Next(0, maxIndex));
        }

        private void setRandomAttribValue(string attribute)
        {
            this.GetType().GetProperty(attribute).SetValue(this, (new Random()).Next(1, 101));
        }

        #endregion

    }
}

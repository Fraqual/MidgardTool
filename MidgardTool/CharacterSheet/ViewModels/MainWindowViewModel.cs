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
        private ICreationLogic m_CreationLogic;

        private Random m_Random;

        #region Window Properties

        #region Basic Information

        public string strName { get; set; }

        public string strPlayerName { get; set; }

        public string strClass { get; set; }

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

        public string strFaith { get; set; }

        public List<string> strlDegree { get; set; }
        public int strlDegreeSelection { get; set; }

        public string strOrigin { get; set; }

        #endregion

        #region Attributes

        private int m_IntStrength;
        public int intStrength { get; set; }

        private int m_IntAppereance;
        public int intAppereance { get; set; }

        private int m_IntGW;
        public int intGW { get; set; }

        private int m_IntPA;
        public int intPA { get; set; }

        private int m_IntDexterity;
        public int intDexterity { get; set; }

        private int m_IntWillpower;
        public int intWillpower { get; set; }

        private int m_IntConstitution;
        public int intConstitution { get; set; }

        private int m_IntIntelligence;
        public int intIntelligence { get; set; }

        private int m_IntMovement;
        public int intMovement { get; set; }

        private int m_IntZT;
        public int intZT { get; set; }

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
            m_Random = new Random();
        }

        #endregion

        #region Command Methods

        private void setRandomSelection(string attribute)
        {
            int maxIndex = ((List<string>)this.GetType().GetProperty(attribute).GetValue(this)).Count;
            this.GetType().GetProperty(attribute + "Selection").SetValue(this, m_Random.Next(0, maxIndex));
        }

        private void setRandomAttribValue(string attribute)
        {
            this.GetType().GetProperty(attribute).SetValue(this, m_CreationLogic.GetRandomAttributeValue());
        }

        #endregion

    }
}

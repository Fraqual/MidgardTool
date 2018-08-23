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

        private Random m_Random;

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

        private int m_IntStrength;
        public int intStrength { get => m_IntStrength; set => m_IntStrength = validateAttributeValue(value); }

        private int m_IntAppereance;
        public int intAppereance { get => m_IntAppereance; set => m_IntAppereance = validateAttributeValue(value); }

        private int m_IntGW;
        public int intGW { get => m_IntGW; set => m_IntGW = validateAttributeValue(value); }

        private int m_IntPA;
        public int intPA { get => m_IntPA; set => m_IntPA = validateAttributeValue(value); }

        private int m_IntDexterity;
        public int intDexterity { get => m_IntDexterity; set => m_IntDexterity = validateAttributeValue(value); }

        private int m_IntWillpower;
        public int intWillpower { get => m_IntWillpower; set => m_IntWillpower = validateAttributeValue(value); }

        private int m_IntConstitution;
        public int intConstitution { get => m_IntConstitution; set => m_IntConstitution = validateAttributeValue(value); }

        private int m_IntKAW;
        public int intKAW { get => m_IntKAW; set => m_IntKAW = validateAttributeValue(value); }

        private int m_IntIntelligence;
        public int intIntelligence { get => m_IntIntelligence; set => m_IntIntelligence = validateAttributeValue(value); }

        private int m_IntMovement;
        public int intMovement { get => m_IntMovement; set => m_IntMovement = validateAttributeValue(value); }

        private int m_IntZT;
        public int intZT { get => m_IntZT; set => m_IntZT = validateAttributeValue(value); }

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

        private int validateAttributeValue(int value)
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
            this.GetType().GetProperty(attribute + "Selection").SetValue(this, m_Random.Next(0, maxIndex));
        }

        private void setRandomAttribValue(string attribute)
        {
            this.GetType().GetProperty(attribute).SetValue(this, m_Random.Next(1, 101));
        }

        #endregion

    }
}

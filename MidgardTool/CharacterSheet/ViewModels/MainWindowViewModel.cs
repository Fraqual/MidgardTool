using CharacterLogic;
using CharacterLogic.Enums;
using CharacterLogic.Interfaces;
using CharacterSheet.UserControls;
using CharacterSheet.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public CharacterAttributeTextBoxViewModel Strength { get; private set; }
        public CharacterAttributeTextBoxViewModel GW { get; private set; }
        public CharacterAttributeTextBoxViewModel Dexterity { get; private set; }
        public CharacterAttributeTextBoxViewModel Constitution { get; private set; }
        public CharacterAttributeTextBoxViewModel Intelligence { get; private set; }
        public CharacterAttributeTextBoxViewModel MagicTalent { get; private set; }
        public CharacterAttributeTextBoxViewModel Appereance { get; private set; }
        public CharacterAttributeTextBoxViewModel PA { get; private set; }
        public CharacterAttributeTextBoxViewModel Willpower { get; private set; }
        public CharacterAttributeTextBoxViewModel Movement { get; private set; }

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

        private void setRandomSelection(string attribute)
        {
            int maxIndex = ((List<string>)this.GetType().GetProperty(attribute).GetValue(this)).Count;
            this.GetType().GetProperty(attribute + "Selection").SetValue(this, m_Random.Next(0, maxIndex));
        }

        #endregion

        #region Construction

        public MainWindowViewModel()
        {
            m_CharacterLogic = new Character();
            m_Random = new Random();
            initialize();
        }

        private void initialize()
        {
            Strength = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Strength);
            GW = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.GW);
            Dexterity = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Dexterity);
            MagicTalent = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.MagicTalent);
            Appereance = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Appereance);
            PA = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.PA);
            Willpower = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Willpower);
            Movement = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Movement);
            Constitution = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Constitution, Willpower);
            Intelligence = new CharacterAttributeTextBoxViewModel(m_CharacterLogic.Intelligence, PA, Willpower);
        }

        #endregion

    }
}

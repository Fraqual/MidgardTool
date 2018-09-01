using CharacterLogic;
using CharacterLogic.Enums;
using CharacterLogic.Interfaces;
using CharacterSheet.UserControls;
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

        public string CharacterName { get => m_CharacterLogic.Name; set => m_CharacterLogic.Name = value; }
        public string PlayerName { get => m_CharacterLogic.PlayerName; set => m_CharacterLogic.PlayerName = value; }

        public List<string> Classes { get => m_CreationLogic.GetCharacterClasses(); }
        public string ClassSelection { get => m_CharacterLogic.Class.ToString(); set => m_CharacterLogic.Class = (ECharacterClass)Enum.Parse(typeof(ECharacterClass), value); }

        #endregion

        #region Appereance
        
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

        private RelayCommand m_CmdSave;
        public ICommand CmdSave
        {
            get
            {
                if(m_CmdSave == null)
                {
                    m_CmdSave = new RelayCommand(() => {
                        
                    });
                }
                return m_CmdSave;
            }
        }

        #endregion

        #region Construction

        public MainWindowViewModel()
        {
            m_CharacterLogic = new Character();
            m_CreationLogic = new CreationLogic();
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

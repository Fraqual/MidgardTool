using CharacterLogic;
using CharacterLogic.Interfaces;
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

        public int intStrength { get => m_CharacterLogic.Strength.Value; set => m_CharacterLogic.Strength.Value = value; }
        public bool bStrengthIsEnabled { get => m_CharacterLogic.Strength.CanBeSet; }

        public int intAppereance { get => m_CharacterLogic.Appereance.Value; set => m_CharacterLogic.Appereance.Value = value; }
        public bool bAppereanceIsEnabled { get => m_CharacterLogic.Appereance.CanBeSet; }

        public int intGW { get => m_CharacterLogic.GW.Value; set => m_CharacterLogic.GW.Value = value; }
        public bool bGWIsEnabled { get => m_CharacterLogic.GW.CanBeSet; }

        public int intPA { get => m_CharacterLogic.PA.Value; set => m_CharacterLogic.PA.Value = value; }
        public bool bPAIsEnabled { get => m_CharacterLogic.PA.CanBeSet; }

        public int intDexterity { get => m_CharacterLogic.Dexterity.Value; set => m_CharacterLogic.Dexterity.Value = value; }
        public bool bDexterityIsEnabled { get => m_CharacterLogic.Dexterity.CanBeSet; }

        public int intWillpower { get => m_CharacterLogic.Willpower.Value; set => m_CharacterLogic.Willpower.Value = value; }
        public bool bWillpowerIsEnabled { get => m_CharacterLogic.Willpower.CanBeSet; }

        public int intConstitution
        {
            get => m_CharacterLogic.Constitution.Value;
            set
            {
                m_CharacterLogic.Constitution.Value = value;
                NotifyPropertyChanged(this, nameof(bWillpowerIsEnabled));
            }
        }
        public bool bConstitutionIsEnabled { get => m_CharacterLogic.Constitution.CanBeSet; }

        public int intIntelligence
        {
            get => m_CharacterLogic.Intelligence.Value;
            set
            {
                m_CharacterLogic.Intelligence.Value = value;
                NotifyPropertyChanged(this, nameof(bPAIsEnabled));
                NotifyPropertyChanged(this, nameof(bWillpowerIsEnabled));
            }
        }
        public bool bIntelligenceIsEnabled { get => m_CharacterLogic.Intelligence.CanBeSet; }

        public int intMovement { get => m_CharacterLogic.Movement.Value; set => m_CharacterLogic.Movement.Value = value; }
        public bool bMovementIsEnabled { get => m_CharacterLogic.Movement.CanBeSet; }

        public int intMagicTalent { get => m_CharacterLogic.MagicTalent.Value; set => m_CharacterLogic.MagicTalent.Value = value; }
        public bool bMagicTalentIsEnabled { get => m_CharacterLogic.MagicTalent.CanBeSet; }

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

        private RelayCommand<string> m_CmdRandomAttributeValue;

        public ICommand cmdRandomAttributeValue
        {
            get
            {
                if(m_CmdRandomAttributeValue == null)
                {
                    m_CmdRandomAttributeValue = new RelayCommand<string>((name) =>
                    {
                        this.GetType().GetProperty(name).SetValue(this, CharacterAttribute.RollDice(100));
                    });
                }
                return m_CmdRandomAttributeValue;
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

    }
}

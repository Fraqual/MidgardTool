using CharacterCreationLogic;
using MidgardEntities.Character;
using MidgardEntities.Enums;
using MidgardEntities.Interfaces;
using CharacterCreationLogic.Interfaces;
using MidgardToolHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;

namespace CharacterCreationPresentation.ViewModels
{
    public class CharacterCreationViewModel : BaseViewModell
    {
        private ICharacter m_CharacterLogic;
        private ICreationLogic m_CreationLogic;

        private Random m_Random;

        #region Window Properties

        public string CharacterName { get => m_CharacterLogic.Name; set => m_CharacterLogic.Name = value; }
        public string PlayerName { get => m_CharacterLogic.PlayerName; set => m_CharacterLogic.PlayerName = value; }

        public List<CharacterClass> Classes { get => m_CreationLogic.AvailableClasses(); }
        public int ClassSelection { get; set; }
        public bool ClassesEnabled { get; set; } = true;

        public List<CharacterRace> Races { get => m_CreationLogic.AvailableRaces(); }
        public int RaceSelection { get; set; }
        public bool RacesEnabled { get; set; } = true;


        public Visibility MethodSelectionVisibility { get; set; } = Visibility.Visible;
        public Visibility DiceSelectionVisibility { get; set; } = Visibility.Hidden;

        public bool AttributesIsEnabled { get; set; } = false;
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
        public bool AttributeConfirmIsEnabled { get; set; } = false;

        #endregion

        #region Commands

        private RelayCommand m_CmdSetRace;
        public ICommand CmdSetRace
        {
            get
            {
                if(m_CmdSetRace == null)
                {
                    m_CmdSetRace = new RelayCommand(() =>
                    {
                        RacesEnabled = false;
                        m_CharacterLogic.Race = m_CreationLogic.AvailableRaces()[RaceSelection];
                        NotifyPropertyChanged(this, nameof(Classes));
                    });
                }
                return m_CmdSetRace;
            }
        }

        private RelayCommand m_CmdSetClass;
        public ICommand CmdSetClass
        {
            get
            {
                if(m_CmdSetClass == null)
                {
                    m_CmdSetClass = new RelayCommand(() => 
                    {
                        ClassesEnabled = false;
                        m_CharacterLogic.Class = m_CreationLogic.AvailableClasses()[ClassSelection];
                        NotifyPropertyChanged(this, nameof(Races));
                    });
                }
                return m_CmdSetClass;
            }
        }

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
                        AttributesIsEnabled = true;
                        ClassesEnabled = false;
                        RacesEnabled = false;
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
                        AttributesIsEnabled = true;
                        ClassesEnabled = false;
                        RacesEnabled = false;
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

        public CharacterCreationViewModel()
        {
            m_CharacterLogic = new Character();
            m_CreationLogic = new CreationLogic(m_CharacterLogic);
            m_Random = new Random();
        }

        #endregion

    }
}

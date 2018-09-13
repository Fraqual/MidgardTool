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
using CharacterCreationPresentation.Windows;

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

        private RelayCommand m_CmdSetAttributes;
        public ICommand CmdSetAttributes
        {
            get
            {
                if(m_CmdSetAttributes == null)
                {
                    m_CmdSetAttributes = new RelayCommand(() => {
                        Window attributeWindow = new CharacterAttributeRollWindow();
                        attributeWindow.ShowDialog();
                    });
                }
                return m_CmdSetAttributes;
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

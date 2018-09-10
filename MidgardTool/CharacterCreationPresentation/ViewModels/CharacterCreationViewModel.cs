using CharacterCreationLogic;
using MidgardEntities.Character;
using MidgardEntities.Enums;
using MidgardEntities.Interfaces;
using CharacterCreationLogic.Interfaces;
using MidgardToolHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

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

        public List<string> Classes { get => m_CreationLogic.GetAvailableCharacterClasses(); }
        public string ClassSelection { get; set; }
        public bool ClassesEnabled { get; set; } = true;

        public List<string> Races { get => m_CreationLogic.GetAvailableRaces(); }
        public string RaceSelection { get; set; }
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
                        m_CharacterLogic.Race = (ERace)Enum.Parse(typeof(ERace), RaceSelection);
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
                        m_CharacterLogic.Class = (ECharacterClass)Enum.Parse(typeof(ECharacterClass), ClassSelection);
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

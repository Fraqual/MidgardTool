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
        private ICharacter m_Character;
        private ICreationLogic m_CreationLogic;

        private Random m_Random;

        #region Window Properties

        public string CharacterName { get => m_Character.Name; set => m_Character.Name = value; }
        public string PlayerName { get => m_Character.PlayerName; set => m_Character.PlayerName = value; }

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
        private bool m_PAIsEnabled = true;
        public bool PAIsEnabled { get => m_Character.PA.CanBeSet && m_PAIsEnabled; set => m_PAIsEnabled = value; }
        private bool m_WKIsEnabled = true;
        public bool WKIsEnabled { get => m_Character.Willpower.CanBeSet && m_WKIsEnabled; set => m_WKIsEnabled = value; }
        public bool BIsEnabled { get; set; } = true;
        public bool AttributeConfirmIsEnabled { get; set; } = false;

        public int STRValue { get => m_Character.Strength.Value; set => m_Character.Strength.Value = value; }
        public int GWValue { get => m_Character.GW.Value; set => m_Character.GW.Value = value; }
        public int GSValue { get => m_Character.Dexterity.Value; set => m_Character.Dexterity.Value = value; }
        public int KOValue { get => m_Character.Constitution.Value; set => m_Character.Constitution.Value = value; }
        public int INValue { get => m_Character.Intelligence.Value; set => m_Character.Intelligence.Value = value; }
        public int ZTValue { get => m_Character.MagicTalent.Value; set => m_Character.MagicTalent.Value = value; }
        public int AUValue { get => m_Character.Appereance.Value; set => m_Character.Appereance.Value = value; }
        public int PAValue { get => m_Character.PA.Value; set => m_Character.PA.Value = value; }
        public int WKValue { get => m_Character.Willpower.Value; set => m_Character.Willpower.Value = value; }
        public int BValue { get => m_Character.Movement.Value; set => m_Character.Movement.Value = value; }

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
                        m_Character.Race = m_CreationLogic.AvailableRaces()[RaceSelection];
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
                        m_Character.Class = m_CreationLogic.AvailableClasses()[ClassSelection];
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
                        m_CreationLogic.RollMethod = ERollMethod.W2;
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
                        m_CreationLogic.RollMethod = ERollMethod.W9;
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

        #region Attribute Commands

        private RelayCommand m_CmdRollSTR;
        public ICommand CmdRollSTR
        {
            get
            {
                if(m_CmdRollSTR == null)
                {
                    m_CmdRollSTR = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Strength);
                        NotifyPropertyChanged(this, nameof(STRValue));
                        STRIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollSTR;
            }
        }

        private RelayCommand m_CmdRollGW;
        public ICommand CmdRollGW
        {
            get
            {
                if(m_CmdRollGW == null)
                {
                    m_CmdRollGW = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.GW);
                        NotifyPropertyChanged(this, nameof(GWValue));
                        GWIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollGW;
            }
        }

        private RelayCommand m_CmdRollGS;
        public ICommand CmdRollGS
        {
            get
            {
                if(m_CmdRollGS == null)
                {
                    m_CmdRollGS = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Dexterity);
                        NotifyPropertyChanged(this, nameof(GSValue));
                        GSIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollGS;
            }
        }

        private RelayCommand m_CmdRollKO;
        public ICommand CmdRollKO
        {
            get
            {
                if(m_CmdRollKO == null)
                {
                    m_CmdRollKO = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Constitution);
                        NotifyPropertyChanged(this, nameof(KOValue));
                        KOIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollKO;
            }
        }

        private RelayCommand m_CmdRollIN;
        public ICommand CmdRollIN
        {
            get
            {
                if(m_CmdRollIN == null)
                {
                    m_CmdRollIN = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Intelligence);
                        NotifyPropertyChanged(this, nameof(INValue));
                        INIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollIN;
            }
        }

        private RelayCommand m_CmdRollZT;
        public ICommand CmdRollZT
        {
            get
            {
                if(m_CmdRollZT == null)
                {
                    m_CmdRollZT = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.MagicTalent);
                        NotifyPropertyChanged(this, nameof(ZTValue));
                        ZTIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollZT;
            }
        }

        private RelayCommand m_CmdRollAU;
        public ICommand CmdRollAU
        {
            get
            {
                if(m_CmdRollAU == null)
                {
                    m_CmdRollAU = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Appereance);
                        NotifyPropertyChanged(this, nameof(AUValue));
                        AUIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollAU;
            }
        }

        private RelayCommand m_CmdRollPA;
        public ICommand CmdRollPA
        {
            get
            {
                if(m_CmdRollPA == null)
                {
                    m_CmdRollPA = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.PA);
                        NotifyPropertyChanged(this, nameof(PAValue));
                        PAIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollPA;
            }
        }

        private RelayCommand m_CmdRollWK;
        public ICommand CmdRollWK
        {
            get
            {
                if(m_CmdRollWK == null)
                {
                    m_CmdRollWK = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Willpower);
                        NotifyPropertyChanged(this, nameof(WKValue));
                        WKIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollWK;
            }
        }

        private RelayCommand m_CmdRollB;
        public ICommand CmdRollB
        {
            get
            {
                if(m_CmdRollB == null)
                {
                    m_CmdRollB = new RelayCommand(() =>
                    {
                        m_CreationLogic.RollAttribute(m_Character.Movement);
                        NotifyPropertyChanged(this, nameof(BValue));
                        BIsEnabled = false;
                        notifyAttribute();
                        enableConfirmIfFinished();
                    });
                }
                return m_CmdRollB;
            }
        }

        #endregion

        private RelayCommand m_CmdConfirmAttributes;
        public ICommand CmdConfirmAttributes
        {
            get
            {
                if(m_CmdConfirmAttributes == null)
                {
                    m_CmdConfirmAttributes = new RelayCommand(() => {
                        if(m_Character.Race == null)
                        {
                            RacesEnabled = true;
                        }
                        if(m_Character.Class == null)
                        {
                            ClassesEnabled = true;
                        }
                        AttributesIsEnabled = false;
                    });
                }
                return m_CmdConfirmAttributes;
            }
        }

        #endregion

        #region Construction

        public CharacterCreationViewModel()
        {
            m_Character = new Character();
            m_CreationLogic = new CreationLogic(m_Character);
            m_Random = new Random();
        }

        #endregion

        private void notifyAttribute()
        {
            NotifyPropertyChanged(this, nameof(STRIsEnabled));
            NotifyPropertyChanged(this, nameof(GWIsEnabled));
            NotifyPropertyChanged(this, nameof(GSIsEnabled));
            NotifyPropertyChanged(this, nameof(KOIsEnabled));
            NotifyPropertyChanged(this, nameof(INIsEnabled));
            NotifyPropertyChanged(this, nameof(ZTIsEnabled));
            NotifyPropertyChanged(this, nameof(AUIsEnabled));
            NotifyPropertyChanged(this, nameof(PAIsEnabled));
            NotifyPropertyChanged(this, nameof(WKIsEnabled));
            NotifyPropertyChanged(this, nameof(BIsEnabled));
        }

        private void enableConfirmIfFinished()
        {
            if(
                !STRIsEnabled &&
                !GWIsEnabled &&
                !GSIsEnabled &&
                !KOIsEnabled &&
                !INIsEnabled &&
                !ZTIsEnabled &&
                !AUIsEnabled &&
                !PAIsEnabled &&
                !WKIsEnabled &&
                !BIsEnabled)
            {
                AttributeConfirmIsEnabled = true;
            }
        }

    }
}

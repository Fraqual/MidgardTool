﻿using CharacterCreationLogic;
using CharacterCreationLogic.Character;
using MidgardToolHelper.ViewModels;
using System.Windows.Input;

namespace CharacterCreationPresentation.UserControls
{
    public class CharacterAttributeTextBoxViewModel : BaseViewModell
    {
        private CharacterAttribute m_Attribute;
        private CharacterAttributeTextBoxViewModel[] m_Notify;

        public int Value
        {
            get => m_Attribute.Value;
            set
            {
                m_Attribute.SetValue(value);

                foreach(var item in m_Notify)
                {
                    NotifyPropertyChanged(item, nameof(IsEnabled));
                }                
            }

        }
        public bool IsEnabled { get => m_Attribute.CanBeSet; }

        private RelayCommand m_CmdRandomValue;
        public ICommand CmdRandomValue
        {
            get
            {
                if(m_CmdRandomValue == null)
                {
                    m_CmdRandomValue = new RelayCommand(() => 
                    {
                        CreationLogic.RollAttribute(m_Attribute);
                        NotifyPropertyChanged(this, nameof(Value));
                        foreach(var item in m_Notify)
                        {
                            NotifyPropertyChanged(item, nameof(IsEnabled));
                        }
                    });
                }
                return m_CmdRandomValue;
            }
        }

        public CharacterAttributeTextBoxViewModel(CharacterAttribute attribute, params CharacterAttributeTextBoxViewModel[] notify)
        {
            m_Attribute = attribute;
            m_Notify = notify;
        }
    }
}
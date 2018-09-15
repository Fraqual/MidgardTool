using CharacterCreationLogic;
using MidgardEntities.Character;
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
                m_Attribute.Value = value;

                foreach(var item in m_Notify)
                {
                    NotifyPropertyChanged(item, nameof(IsEnabled));
                }                
            }

        }
        public bool IsEnabled { get => m_Attribute.CanBeSet; }

        public CharacterAttributeTextBoxViewModel(CharacterAttribute attribute, params CharacterAttributeTextBoxViewModel[] notify)
        {
            m_Attribute = attribute;
            m_Notify = notify;
        }
    }
}

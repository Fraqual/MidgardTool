using CharacterLogic;
using CharacterSheet.ViewModels.Base;

namespace CharacterSheet.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {

        private ICharacterLogic m_CharacterLogic;

        #region Construction

        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(ICharacterLogic characterLogic)
        {
            m_CharacterLogic = characterLogic;
        }

        #endregion



    }
}

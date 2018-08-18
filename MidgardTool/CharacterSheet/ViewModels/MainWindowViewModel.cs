using CharacterLogic.Interfaces;
using CharacterSheet.ViewModels.Base;

namespace CharacterSheet.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {

        private ICharacterLogic m_CharacterLogic;

        #region Window Properties

        public string tbName { get; set; }

        #endregion


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

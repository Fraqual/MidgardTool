using CharacterLogic;
using CharacterSheet.ViewModels.Base;
using System.Collections.Generic;

namespace CharacterSheet.ViewModels
{
    public class MainWindowViewModel : BaseViewModell
    {

        private ICharacterLogic m_CharacterLogic;

        #region Window Properties

        public string tbFigur { get; set; }

        public string tbName { get; set; }

        public List<string> cbKlasse { get => m_CharacterLogic.GetCharacterClasses(); }

        public string cbSelectedKlasse { get; set; }

        public List<string> cbRasse { get => m_CharacterLogic.GetRaces(); }

        public string cbSelectedRasse { get; set; }

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

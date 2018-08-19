using PropertyChanged;
using System.ComponentModel;

namespace CharacterSheet.ViewModels.Base
{
    [ImplementPropertyChanged]
    public abstract class BaseViewModell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}

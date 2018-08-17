using System.ComponentModel;

namespace CharacterSheet.ViewModels.Base
{
    public abstract class BaseViewModell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}

using PropertyChanged;
using System.ComponentModel;

namespace MidgardToolHelper.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void NotifyPropertyChanged(object sender, string propertyName)
        {
            PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}

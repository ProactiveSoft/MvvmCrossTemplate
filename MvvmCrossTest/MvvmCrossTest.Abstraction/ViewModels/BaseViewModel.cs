using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossTest.Abstraction.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmCrossTest.Abstraction.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel, INotifyPropertyChanged
    {
        public string Title
        {
            get => _title;
            protected set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }


        #region INPC

        public new event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Fields

        private string _title;


        protected readonly IMvxNavigationService NavigationService;

        #endregion
    }
}
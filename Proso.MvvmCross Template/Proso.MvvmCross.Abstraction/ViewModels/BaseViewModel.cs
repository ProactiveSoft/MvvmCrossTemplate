using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using $safeprojectname$.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace $safeprojectname$.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel, INotifyPropertyChanged
    {
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }


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



    public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>, INotifyPropertyChanged
    {
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }


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


    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>, INotifyPropertyChanged
    {
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }


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
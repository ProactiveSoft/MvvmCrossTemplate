﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossTest.Core.Annotations;

namespace MvvmCrossTest.Core.ViewModels
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
}
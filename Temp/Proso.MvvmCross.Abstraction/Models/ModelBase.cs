using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using $safeprojectname$.Annotations;

namespace $safeprojectname$.Models
{
    public class ModelBase<TId> : IModel<TId> where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        public TId Id
        {
            get => _id;
            set
            {
                if (value.Equals(_id)) return;
                _id = value;
                OnPropertyChanged();
            }
        }



        #region Equality members

        /// <inheritdoc />
        public bool Equals(ModelBase<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id.Equals(other._id);
        }


        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ModelBase<TId> other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public static bool operator ==(ModelBase<TId> left, ModelBase<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ModelBase<TId> left, ModelBase<TId> right)
        {
            return !Equals(left, right);
        }

        #endregion



        #region Relational members

        /// <inheritdoc />
        public int CompareTo(ModelBase<TId> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return _id.CompareTo(other._id);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is ModelBase<TId> other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ModelBase<TId>)}");
        }

        public static bool operator <(ModelBase<TId> left, ModelBase<TId> right)
        {
            return Comparer<ModelBase<TId>>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(ModelBase<TId> left, ModelBase<TId> right)
        {
            return Comparer<ModelBase<TId>>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(ModelBase<TId> left, ModelBase<TId> right)
        {
            return Comparer<ModelBase<TId>>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(ModelBase<TId> left, ModelBase<TId> right)
        {
            return Comparer<ModelBase<TId>>.Default.Compare(left, right) >= 0;
        }

        #endregion

        

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



        #region Fields

        private TId _id;

        #endregion
    }
}

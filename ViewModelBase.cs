namespace appfactory.core
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            GoBack = Command.Construct((Window.Current.Content as Frame).GoBack);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoBack { get; private set; }

        public void Navigate<T>()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(T));
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Updates the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentValue">The current value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public bool UpdateProperty<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (currentValue == null || !currentValue.Equals(newValue))
            {
                currentValue = newValue;
                RaisePropertyChanged(propertyName);
                return true;
            }

            return false;
        }
    }
}
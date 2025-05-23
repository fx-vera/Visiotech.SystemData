using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Visiotech.SystemData.MVVM.Models
{
    /// <summary>
    /// Base model that implements the NotifyPropertyChanged to refresh the data between model and view
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Apply the updated when the property changes from the View
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

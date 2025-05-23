using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Visiotech.SystemData.MVVM.Models
{
    /// <summary>
    /// Model with the data displayed in the view.
    /// </summary>
    public class DisplayModel : BaseModel
    {
        public DisplayModel() { }

        private ObservableCollection<DataStoredModel> dataStoredModels { get; set; } = new ObservableCollection<DataStoredModel>();
        public ObservableCollection<DataStoredModel> DataStoredModels
        {
            get { return dataStoredModels; }
            set
            {
                dataStoredModels = value;
            }
        }

        private int interval = 1000; // miliseconds

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void OnCollectionChanged(NotifyCollectionChangedAction action)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
            }
        }

        /// <summary>
        /// Interval in miliseconds
        /// </summary>
        public int Interval

        {
            get { return interval; }
            set
            {
                interval = value;
                OnPropertyChanged();
            }
        }
    }
}

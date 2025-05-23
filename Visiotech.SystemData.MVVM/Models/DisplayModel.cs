using System.Collections.ObjectModel;

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

        private int interval = 1000; // miliseconds, default 1000

        /// <summary>
        /// Interval in miliseconds: 1000 by default
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

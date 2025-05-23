namespace Visiotech.SystemData.MVVM.Models
{
    /// <summary>
    /// Model that stores the data from the UI.
    /// </summary>
    public class DataStoredModel : BaseModel
    {
        private string dateTime;
        /// <summary>
        /// Datetime when the data is retrieved
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged();
            }
        }
        private string cpuSerialNumber;
        /// <summary>
        /// Local machine CPU serial number
        /// </summary>
        public string CPUSerialNumber
        {
            get { return cpuSerialNumber; }
            set
            {
                cpuSerialNumber = value;
                OnPropertyChanged();
            }
        }
        private string motherBoardSerialNumber;
        /// <summary>
        /// Local machine MotherBoard serial number
        /// </summary>
        public string MotherBoardSerialNumber
        {
            get { return motherBoardSerialNumber; }
            set
            {
                motherBoardSerialNumber = value;
                OnPropertyChanged();
            }
        }
        private string gpuSerialNumber;
        /// <summary>
        /// Local machine GPU serial number
        /// </summary>
        public string GPUSerialNumber
        {
            get { return gpuSerialNumber; }
            set
            {
                gpuSerialNumber = value;
                OnPropertyChanged();
            }
        }
        private string cpuUsage;
        /// <summary>
        /// Local machine current GPU usage in %
        /// </summary>
        public string CPUUsage
        {
            get { return cpuUsage; }
            set
            {
                cpuUsage = value;
                OnPropertyChanged();
            }
        }
        private string ramUsage;
        /// <summary>
        /// Local machine current RAM usage in GB
        /// </summary>
        public string RAMUsage
        {
            get { return ramUsage; }
            set
            {
                ramUsage = value;
                OnPropertyChanged();
            }
        }
    }
}

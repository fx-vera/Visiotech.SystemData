using System;

namespace Visiotech.SystemData.MVVM.Models
{
    public class DataStoredModel : BaseModel
    {
        private string dateTime;
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

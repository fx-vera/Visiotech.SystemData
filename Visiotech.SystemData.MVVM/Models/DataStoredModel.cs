using System;

namespace Visiotech.SystemData.MVVM.Models
{
    public class DataStoredModel
    {
        public DateTime DateTime { get; set; }
        public string CPUSerialNumber { get; set; }
        public string MotherBoardSerialNumber { get; set; }
        public string GPUSerialNumber { get; set; }
        public string CPUUsage { get; set; }
        public string RAMUsage { get; set; }
    }
}

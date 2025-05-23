using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Visiotech.SystemData.MVVM.Models;

namespace Visiotech.SystemData.MVVM.Interfaces
{
    /// <summary>
    /// Interface with the main functionality
    /// </summary>
    public interface ISystemDataService
    {
        /// <summary>
        /// Get the CPU serial number
        /// </summary>
        /// <returns></returns>
        string GetCPUSerialNumber();
        /// <summary>
        /// Get the MotherBoard Serial Number
        /// </summary>
        /// <returns></returns>
        string GetMotherBoardSerialNumber();
        /// <summary>
        /// Get the GPU SerialNumber
        /// </summary>
        /// <returns></returns>
        string GetGPUSerialNumber();
        /// <summary>
        /// Get the CPU Usage
        /// </summary>
        /// <param name="cpuCounter"></param>
        /// <returns></returns>
        string GetCPUUsage(PerformanceCounter cpuCounter);
        /// <summary>
        /// Get the RAM Usage
        /// </summary>
        /// <returns></returns>
        string GetRAMUsage();
        /// <summary>
        /// Read the data from file and load in model (JSON)
        /// </summary>
        /// <param name="dataStoredModels"></param>
        void ReadData(ObservableCollection<DataStoredModel> dataStoredModels, string dataStoredPath);
        /// <summary>
        /// Save the model data in the file (JSON)
        /// </summary>
        /// <param name="dataStoredModels"></param>
        void SaveData(List<DataStoredModel> dataStoredModels, string dataStoredPath);
    }
}

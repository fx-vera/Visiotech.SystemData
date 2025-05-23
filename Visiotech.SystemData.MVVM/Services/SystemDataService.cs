using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Visiotech.SystemData.MVVM.Interfaces;
using Visiotech.SystemData.MVVM.Models;

namespace Visiotech.SystemData.MVVM.Services
{
    /// <summary>
    /// Singletom class for SystemDataService
    /// </summary>
    public sealed class SystemDataService : ISystemDataService
    {
        private static ISystemDataService _instance;
        private SystemDataService() { }

        public static ISystemDataService Instance()
        {
            if (_instance == null)
            {
                _instance = new SystemDataService();
            }
            return _instance;
        }
        /// <summary>
        /// Get the CPU serial number
        /// </summary>
        /// <returns></returns>
        public string GetCPUSerialNumber()
        {
            return HardwareInfo.HardwareInfo.GetProcessorID();
        }
        /// <summary>
        /// Get the MotherBoard Serial Number
        /// </summary>
        /// <returns></returns>
        public string GetMotherBoardSerialNumber()
        {
            return Visiotech.HardwareInfo.HardwareInfo.GetMotherboardID();
        }
        /// <summary>
        /// Get the GPU SerialNumber. TODO
        /// </summary>
        /// <returns></returns>
        public string GetGPUSerialNumber() // "TODO-GetGPUSerialNumber";
        {
            string result = string.Empty;
            try
            {
                result = Visiotech.HardwareInfo.HardwareInfo.GetGpuID();
            }
            catch (Exception ex)
            {
                // Log ex
                // For the moment the Visiotech.HardwareInfo does not implement this method.
            }
            return string.Empty;    
        }
        /// <summary>
        /// Get the CPU Usage
        /// </summary>
        /// <param name="cpuCounter"></param>
        /// <returns></returns>
        public string GetCPUUsage(PerformanceCounter cpuCounter)
        {
            int usage = (int)cpuCounter.NextValue();
            return $"{usage} %";
        }
        /// <summary>
        /// Get the RAM Usage
        /// </summary>
        /// <returns></returns>
        public string GetRAMUsage()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            float availableMB = ramCounter.NextValue();

            ulong totalMemory = (new Microsoft.VisualBasic.Devices.ComputerInfo()).TotalPhysicalMemory;
            float usedMemory = (totalMemory / 1024 / 1024) - availableMB; // Convert bytes to MB

            return $"{usedMemory / 1024} GB";
        }
        /// <summary>
        /// Read the data from file and load in model (JSON)
        /// </summary>
        /// <param name="dataStoredModels"></param>
        public void ReadData(ObservableCollection<DataStoredModel> dataStoredModels, string dataStoredPath)
        {
            if (!File.Exists(dataStoredPath))
            {
                return;
            }
            try
            {
                List<DataStoredModel> dataStored = new List<DataStoredModel>();
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamReader reader = new StreamReader(dataStoredPath))
                {
                    using (JsonReader reader2 = new JsonTextReader(reader))
                    {
                        dataStored = serializer.Deserialize<List<DataStoredModel>>(reader2);
                    }
                }
                if (dataStored != null && dataStored.Count > 0)
                {
                    foreach (var item in dataStored)
                    {
                        dataStoredModels.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // here log the exception

                File.Delete(dataStoredPath); // probably the file is corrupted
                File.Create(dataStoredPath).Dispose();
            }
        }
        public void SaveData(List<DataStoredModel> dataStoredModels, string dataStoredPath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            if (!File.Exists(dataStoredPath))
            {
                File.Create(dataStoredPath).Dispose();
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(dataStoredPath))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, dataStoredModels);
                    }
                }
            }
            catch (Exception ex)
            {
                // log
            }
        }
    }
}

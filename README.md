# Visiotech.SystemData

## Description
This application register periodically some system data of the local machine and store in a json file to load the data each time that the user opens the app.

## Author
Francisco Vera

## Requirements
.NET Framework v4.8.1;

Newtonsoft.Json.13.0.3 for parsing files;

MSTest.TestAdapter.2.2.10 for unit testing;

## Patterns applied
MVVM to build the WPF application.

Command patter (Relay command recommended by Microsoft).

Singleton for call main service ISystemDataService

## SOLID Principles
Applied as the project needs.

## Unit testing.
This project uses MSTest to check the services functionality: Visiotech.SystemData.MVVM.Test

## External dependencies
The library Visiotech.HardwareInfo to obtain some system data.

## Solution Structure
The solution contains three projects
1. * Visiotech.SystemData.MVVM * that cover all the MVVM development. It was not necessary separate in other projects because the functionality required was minimal.
2. * Visiotech.SystemData.Launcher * this project references the MVVM project and do nothing more.
3. * Visiotech.SystemData.MVVM.Test * this project inclused the unit test implemented.

## Functionality

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
	
## Notes
To implement some functionality like retrieve the system data I visited some technical webs.

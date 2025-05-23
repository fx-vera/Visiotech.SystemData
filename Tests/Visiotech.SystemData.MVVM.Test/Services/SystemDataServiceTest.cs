using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Visiotech.SystemData.MVVM.Interfaces;
using Visiotech.SystemData.MVVM.Models;
using Visiotech.SystemData.MVVM.Services;

namespace Visiotech.SystemData.MVVM.Test
{
    /// <summary>
    /// Test to check Service functionality.
    /// Applied Assert/Act/Arrange and GivenWhenThen methodology
    /// </summary>
    [TestClass]
    public class SystemDataServiceTest
    {
        private readonly ISystemDataService systemDataService;
        private string dataStoredPath = $"{Environment.CurrentDirectory}/dataStoredTest.json";
        public SystemDataServiceTest()
        {
            systemDataService = SystemDataService.Instance();

        }

        [TestMethod]
        public void WhenGetCPUSerialNumberThenReturnNotNull()
        {
            // Arrange
            string cpuSN;
            // Act
            cpuSN = systemDataService.GetCPUSerialNumber();
            // Assert
            Assert.IsNotNull(cpuSN);
        }

        [TestMethod]
        public void WhenGetMotherBoardSerialNumberThenReturnNotNull()
        {
            // Arrange
            string mbSN;
            // Act
            mbSN = systemDataService.GetMotherBoardSerialNumber();
            // Assert
            Assert.IsNotNull(mbSN);
        }

        [TestMethod]
        public void WhenGetGPUSerialNumberThenReturnEmpty()
        {
            // Arrange
            string gpuSN;
            // Act
            gpuSN = systemDataService.GetGPUSerialNumber();
            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(gpuSN));
        }

        //[TestMethod]
        public void WhenGetGPUSerialNumberThenReturnNotNull()
        {
            // not implemented

            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void WhenGetCPUUsageThenGetDistintToZero()
        {
            // Arrange
            string cpuUsage;
            int cpuPercent = 0;
            // Act
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            int usage = (int)cpuCounter.NextValue();
            Thread.Sleep(400);
            cpuUsage = systemDataService.GetCPUUsage(cpuCounter);
            if (!string.IsNullOrWhiteSpace(cpuUsage) && cpuUsage.Length > 2)
            {
                int.TryParse(cpuUsage.Substring(0, cpuUsage.IndexOf(" ")), out cpuPercent);
            }
            // Assert
            Assert.IsNotNull(cpuUsage);
            Assert.IsTrue(cpuPercent > 0);
        }

        [TestMethod]
        public void WhenGetRAMUsageThenGetDistintToZero()
        {
            // Arrange
            string ramUsage;
            double cpuPercent = 0;
            // Act
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            int usage = (int)cpuCounter.NextValue();
            Thread.Sleep(400);
            ramUsage = systemDataService.GetRAMUsage();// cpuCounter);
            if (!string.IsNullOrWhiteSpace(ramUsage) && ramUsage.Length > 2)
            {
                double.TryParse(ramUsage.Substring(0, ramUsage.IndexOf(" ")), out cpuPercent);
            }
            // Assert
            Assert.IsNotNull(ramUsage);
            Assert.IsTrue(cpuPercent > 0);
        }

        [TestMethod]
        public void GivenStringJsonThenSerializeInLocalPath()
        {
            // Arrange
            List<DataStoredModel> dataStoredModels = new List<DataStoredModel>
            {
                new DataStoredModel
                {
                    CPUSerialNumber = "1-CPUSerialNumber",
                    CPUUsage = "10 %",
                    DateTime = DateTime.Now.ToString(),
                    GPUSerialNumber = "1-GPUSerialNumber",
                    MotherBoardSerialNumber = "1-MotherBoardSerialNumber",
                    RAMUsage = "1 GB"
                },
                new DataStoredModel
                {
                    CPUSerialNumber = "2-CPUSerialNumber",
                    CPUUsage = "20 %",
                    DateTime = DateTime.Now.ToString(),
                    GPUSerialNumber = "2-GPUSerialNumber",
                    MotherBoardSerialNumber = "2-MotherBoardSerialNumber",
                    RAMUsage = "2 GB"
                }
            };

            // Act
            systemDataService.SaveData(dataStoredModels, dataStoredPath);
            // Assert
            bool fileExists = File.Exists(dataStoredPath);
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void GivenJsonPathThenDeserialize() // Depends on the previous test GivenStringJsonThenSerializeInLocalPath
        {
            // Arrange
            ObservableCollection<DataStoredModel> dataStoredModels = new ObservableCollection<DataStoredModel>();

            if (!File.Exists(dataStoredPath))   // create dummy data
            {
                // Arrange
                List<DataStoredModel> dataStoredModelsNew = new List<DataStoredModel>
                {
                    new DataStoredModel
                    {
                        CPUSerialNumber = "1-CPUSerialNumber",
                        CPUUsage = "10 %",
                        DateTime = DateTime.Now.ToString(),
                        GPUSerialNumber = "1-GPUSerialNumber",
                        MotherBoardSerialNumber = "1-MotherBoardSerialNumber",
                        RAMUsage = "1 GB"
                    },
                    new DataStoredModel
                    {
                        CPUSerialNumber = "2-CPUSerialNumber",
                        CPUUsage = "20 %",
                        DateTime = DateTime.Now.ToString(),
                        GPUSerialNumber = "2-GPUSerialNumber",
                        MotherBoardSerialNumber = "2-MotherBoardSerialNumber",
                        RAMUsage = "2 GB"
                    }
                };

                // Act
                systemDataService.SaveData(dataStoredModelsNew, dataStoredPath);
            }

            // Act
            systemDataService.ReadData(dataStoredModels, dataStoredPath);
            // Assert
            Assert.IsNotNull(dataStoredModels);
            Assert.AreEqual(dataStoredModels.Count, 2);
        }
    }
}

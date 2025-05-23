using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Visiotech.SystemData.MVVM.Interfaces;
using Visiotech.SystemData.MVVM.Models;
using Visiotech.SystemData.MVVM.Services;
using Visiotech.SystemData.MVVM.Utils;

namespace Visiotech.SystemData.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel with the requirements data.
    /// </summary>
    public class DisplayViewModel : BaseViewModel, IDisposable
    {
        /// <summary>
        /// Will be used to read and write in the UI on the background
        /// </summary>
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private readonly ISystemDataService systemDataService;
        private string dataStoredPath = $"{Environment.CurrentDirectory}/dataStored.json";

        public DisplayViewModel()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            systemDataService = SystemDataService.Instance();

            systemDataService.ReadData(DisplayModel.DataStoredModels, dataStoredPath);

            StartCommand.Execute(null);
        }

        /// <summary>
        /// Name of the ViewModel
        /// </summary>
        public override string Name { get; } = "Display System Data";
        /// <summary>
        /// Unique Id
        /// </summary>
        public override string Id { get; } = "{AFEB1E98-DBAF-48DE-9884-EA679083778F}"; // Generated with Tool GUID from VS2022
        /// <summary>
        /// The Model
        /// </summary>
        public DisplayModel DisplayModel { get; set; } = new DisplayModel();

        public ICommand StartCommand => new RelayCommand(PerformStartCommand);

        public ICommand PauseCommand => new RelayCommand(PerformPauseCommand);
        public ICommand DownIntervalCommand => new RelayCommand(PerformDownIntervalCommand);

        public ICommand UpIntervalCommand => new RelayCommand(PerformUpIntervalCommand);

        public override void SaveData()
        {
            systemDataService.SaveData(DisplayModel.DataStoredModels.ToList(), dataStoredPath);
        }

        public void Dispose()
        {
            backgroundWorker.Dispose();
        }

        private void PerformStartCommand(object obj)
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }
        private void PerformPauseCommand(object obj)
        {
            backgroundWorker.CancelAsync();
        }

        private void PerformDownIntervalCommand(object obj)
        {
            if (DisplayModel.Interval == 500)
                return;
            DisplayModel.Interval -= 500;
        }
        private void PerformUpIntervalCommand(object obj)
        {
            if (DisplayModel.Interval == 10000)
                return;
            DisplayModel.Interval += 500;
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            // Reguster the System Data and update the Model to display the View correctly.
            e.Result = RegisterSystemData(bw);

            // The user click Pause
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private int RegisterSystemData(BackgroundWorker bw)
        {
            while (!bw.CancellationPending)
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                int usage = (int)cpuCounter.NextValue();

                Thread.Sleep(DisplayModel.Interval);

                // extract data and write in the datagrid
                string dateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.f tt");

                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    DisplayModel.DataStoredModels.Add(
                    new DataStoredModel()
                    {
                        DateTime = dateTime,
                        CPUSerialNumber = systemDataService.GetCPUSerialNumber(),
                        GPUSerialNumber = systemDataService.GetGPUSerialNumber(),
                        MotherBoardSerialNumber = systemDataService.GetMotherBoardSerialNumber(),
                        RAMUsage = systemDataService.GetRAMUsage(),
                        CPUUsage = systemDataService.GetCPUUsage(cpuCounter),
                    });
                });
            }
            return 1;
        }
    }
}

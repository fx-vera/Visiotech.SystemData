using System.ComponentModel;
using Visiotech.SystemData.MVVM.Interfaces;

namespace Visiotech.SystemData.MVVM.ViewModels
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        public abstract string Name { get; }
        public abstract string Id { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

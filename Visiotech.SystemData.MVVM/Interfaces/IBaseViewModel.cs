using System.ComponentModel;

namespace Visiotech.SystemData.MVVM.Interfaces
{
    /// <summary>
    /// Interface with the basic IBaseViewModel data
    /// </summary>
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        string Name { get; }
        string Id { get; }
    }
}

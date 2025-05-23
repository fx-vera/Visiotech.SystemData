namespace Visiotech.SystemData.MVVM.Interfaces
{
    /// <summary>
    /// Interface with the basic IBaseViewModel data
    /// </summary>
    public interface IBaseViewModel
    {
        /// <summary>
        /// Name of the viewmodel
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Unique Id
        /// </summary>
        string Id { get; }
    }
}

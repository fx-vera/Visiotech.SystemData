namespace Visiotech.SystemData.MVVM.Models
{
    /// <summary>
    /// Model with the data displayed in the view.
    /// </summary>
    public class DisplayModel
    {
        public DisplayModel() { }
        public DataStoredModel DataStoredModel { get; set; }
        public int Interval { get; set; }
    }
}

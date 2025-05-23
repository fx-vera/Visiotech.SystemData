using System.Windows;
using Visiotech.SystemData.MVVM.Interfaces;

namespace Visiotech.SystemData.MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        public MainView(IMainViewModel mainViewModel) : this()
        {
            this.DataContext = mainViewModel;
        }
    }
}
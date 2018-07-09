using ColorViewer.ViewModels;
using System.Windows;

namespace ColorViewer.Views
{
	internal sealed partial class MainWindowView : Window
	{

		public MainWindowView(MainWindowViewModel viewModel)
		{
			InitializeComponent();

			DataContext = viewModel;
		}
	}
}
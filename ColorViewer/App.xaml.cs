using System.Windows;
using ColorViewer.Models;
using ColorViewer.ViewModels;
using ColorViewer.Views;

namespace ColorViewer
{
	internal sealed partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var colorManager = new ColorManager();
			var viewModelFactory = new ViewModelFactory(colorManager);
			var mainViewModel = new MainWindowViewModel(colorManager, viewModelFactory);
			var view = new MainWindowView(mainViewModel);
			view.Show();
		}
	}
}
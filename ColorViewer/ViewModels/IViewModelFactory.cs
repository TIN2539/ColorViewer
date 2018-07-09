using ColorViewer.ViewModels;
using System.Windows.Media;

namespace ColorViewer.Models
{
	interface IViewModelFactory
	{
		ColorViewModel CreateColorViewModel(Color color);
	}
}
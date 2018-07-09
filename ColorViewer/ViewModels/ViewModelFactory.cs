using ColorViewer.ViewModels;
using System.Windows.Media;

namespace ColorViewer.Models
{
	internal class ViewModelFactory : IViewModelFactory
	{
		private readonly IColorManager colorManager;

		public ViewModelFactory(IColorManager colorManager)
		{
			this.colorManager = colorManager;
		}

		public ColorViewModel CreateColorViewModel(Color color)
		{
			return new ColorViewModel(color, colorManager);
		}
	}
}
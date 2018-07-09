using ColorViewer.Models;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorViewer.ViewModels
{
	internal class ColorViewModel
	{
		private readonly IColorManager colorManager;
		private readonly ICommand deleteCommand;
		private readonly Color model;

		public ColorViewModel(Color model, IColorManager colorManager)
		{
			this.model = model;
			this.colorManager = colorManager;

			deleteCommand = new DelegateCommand(Delete);
		}

		public ICommand DeleteCommand => deleteCommand;

		public string Name => model.ToString();

		private void Delete()
		{
			colorManager.DeleteColor(model);
		}
	}
}
using System.Windows.Media;

namespace ColorViewer.Models
{
	internal class ColorEventArgs
	{
		private readonly Color color;

		public ColorEventArgs(Color color)
		{
			this.color = color;
		}

		public Color Color => color;
	}
}
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ColorViewer.Models
{
	interface IColorManager
	{
		event EventHandler<ColorEventArgs> ColorAdded;
		event EventHandler<ColorEventArgs> ColorDeleted;

		IEnumerable<Color> Colors { get; }

		void AddColor(Color color);

		void DeleteColor(Color color);
	}
}
﻿using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ColorViewer.Models
{
	internal class ColorManager : IColorManager
	{
		private readonly ICollection<Color> colors = new List<Color>();

		public IEnumerable<Color> Colors => colors;

		public event EventHandler<ColorEventArgs> ColorAdded;
		public event EventHandler<ColorEventArgs> ColorDeleted;

		public void AddColor(Color color)
		{
			colors.Add(color);
			OnColorAdded(new ColorEventArgs(color));
		}

		public void DeleteColor(Color color)
		{
			if (colors.Remove(color))
			{
				OnColorDeleted(new ColorEventArgs(color));
			}
		}

		private void OnColorAdded(ColorEventArgs e)
		{
			ColorAdded?.Invoke(this, e);
		}

		private void OnColorDeleted(ColorEventArgs e)
		{
			ColorDeleted?.Invoke(this, e);
		}
	}
}
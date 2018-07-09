using ColorViewer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorViewer.ViewModels
{
	internal class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly ICommand addCommand;
		private readonly IColorManager colorManager;
		private readonly ICollection<ColorViewModel> colors = new ObservableCollection<ColorViewModel>();
		private readonly IViewModelFactory viewModelFactory;
		private int alpha = 255;
		private int blue = 0;
		private Color currentColor;
		private int green = 0;
		private int red = 0;

		public MainWindowViewModel(IColorManager colorManager, IViewModelFactory viewModelFactory)
		{
			this.colorManager = colorManager;
			this.viewModelFactory = viewModelFactory;

			addCommand = new DelegateCommand(Add);

			currentColor = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);

			this.colorManager.ColorAdded += (sender, e) =>
			{
				ColorViewModel color = viewModelFactory.CreateColorViewModel(e.Color);
				colors.Add(color);
				OnPropertyChanged(new PropertyChangedEventArgs(nameof(CanAdd)));
			};

			this.colorManager.ColorDeleted += (sender, e) =>
			{
				foreach (ColorViewModel color in colors)
				{
					if (color.Name.Equals(e.Color.ToString()))
					{
						colors.Remove(color);
						break;
					}
				}
				OnPropertyChanged(new PropertyChangedEventArgs(nameof(CanAdd)));
			};

			PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName.Equals(nameof(Alpha)) || e.PropertyName.Equals(nameof(Red)) || e.PropertyName.Equals(nameof(Green)) ||
				e.PropertyName.Equals(nameof(Blue)))
				{
					UpdateColor();
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(CanAdd)));
				}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand AddCommand => addCommand;

		public int Alpha
		{
			get => alpha;
			set
			{
				if (!alpha.Equals(value))
				{
					alpha = value;
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(Alpha)));
				}
			}
		}

		public int Blue
		{
			get => blue;
			set
			{
				if (!blue.Equals(value))
				{
					blue = value;
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(Blue)));
				}
			}
		}

		public bool CanAdd => !HasSameColor();

		public IEnumerable<ColorViewModel> Colors => colors;

		public Color CurrentColor
		{
			get => currentColor;
			set
			{
				if (!currentColor.Equals(value))
				{
					currentColor = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentColor)));
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(SolidColor)));
				}
			}
		}

		public int Green
		{
			get => green;
			set
			{
				if (!green.Equals(value))
				{
					green = value;
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(Green)));
				}
			}
		}

		public int Red
		{
			get => red;
			set
			{
				if (!red.Equals(value))
				{
					red = value;
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(Red)));
				}
			}
		}

		public SolidColorBrush SolidColor => new SolidColorBrush(Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue));

		private void Add()
		{
			colorManager.AddColor(currentColor);
		}

		private bool HasSameColor()
		{
			var hasSameColor = false;
			foreach(var color in Colors)
			{
				if (color.Name == currentColor.ToString())
				{
					hasSameColor = true;
					break;
				}
			}
			return hasSameColor;
		}

		private void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		private void UpdateColor()
		{
			CurrentColor = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
		}
	}
}
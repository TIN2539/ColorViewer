using System;
using System.Windows.Input;

namespace ColorViewer
{
	internal abstract class Command : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public virtual bool CanExecute()
		{
			return true;
		}

		public abstract void Execute();

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute();
		}

		void ICommand.Execute(object parameter)
		{
			Execute();
		}
	}
}
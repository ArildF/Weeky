﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.SampleMainViewModel
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleMainViewModel { }
#else

	public class SampleMainViewModel : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleMainViewModel()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/Weeky;component/SampleData/SampleMainViewModel/SampleMainViewModel.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private Days _Days = new Days();

		public Days Days
		{
			get
			{
				return this._Days;
			}
		}
	}

	public class DaysItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private bool _IsHoliday = false;

		public bool IsHoliday
		{
			get
			{
				return this._IsHoliday;
			}

			set
			{
				if (this._IsHoliday != value)
				{
					this._IsHoliday = value;
					this.OnPropertyChanged("IsHoliday");
				}
			}
		}

		private bool _IsToday = false;

		public bool IsToday
		{
			get
			{
				return this._IsToday;
			}

			set
			{
				if (this._IsToday != value)
				{
					this._IsToday = value;
					this.OnPropertyChanged("IsToday");
				}
			}
		}

		private string _MainText = string.Empty;

		public string MainText
		{
			get
			{
				return this._MainText;
			}

			set
			{
				if (this._MainText != value)
				{
					this._MainText = value;
					this.OnPropertyChanged("MainText");
				}
			}
		}
	}

	public class Days : System.Collections.ObjectModel.ObservableCollection<DaysItem>
	{ 
	}
#endif
}

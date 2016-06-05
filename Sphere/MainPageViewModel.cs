using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Sphere.Annotations;

namespace Sphere
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private string _text1;
		private ICommand _loadPictureFromFileCommand;
		public event PropertyChangedEventHandler PropertyChanged;

		public string Text1
		{
			get { return _text1; }
			set
			{
				_text1 = value;
				OnPropertyChanged();
			}
		}

		private ImageSource mainImage;
		public ImageSource MainImage
		{
			get { return mainImage; }
			set
			{
				if (mainImage != value)
				{
					mainImage = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand LoadPictureFromFileCommand
		{
			get
			{
				return _loadPictureFromFileCommand ?? (_loadPictureFromFileCommand = new Command(async () =>
				{
					var openPicker = new FileOpenPicker
					{
						ViewMode = PickerViewMode.Thumbnail,
						SuggestedStartLocation = PickerLocationId.PicturesLibrary,
						FileTypeFilter =
						{
							".jpg",
							".png"
						}
					};
					
					var file = await openPicker.PickSingleFileAsync();

					if (file != null)
					{
						using (var imageStream = await file.OpenReadAsync())
						{
							var a = new BitmapImage();
							await a.SetSourceAsync(imageStream);
							MainImage = a;

							BitmapImage myBitmap = new BitmapImage();

							
						}
					}
				}));
			}
		}


		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Command : ICommand
	{
		private readonly Action _action;

		public Command(Action action)
		{
			_action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		public event EventHandler CanExecuteChanged;
	}
}
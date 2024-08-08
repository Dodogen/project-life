using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using PL.Core.Models;

namespace project_life
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DispatcherTimer timer;
		private TimeSpan interval;
		private Field field;
		public MainWindow()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			interval = new TimeSpan(0, 0, 0, 1, 0);
			timer.Interval = interval;
			timer.Tick += timer_Tick;

			//create field
			field = new Field(FieldImage);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			field.Update();
		}

		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void SaveBotButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void StartStopButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void NewFieldButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void SaveFieldButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void LoadFieldButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void CurrentLanguageCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			return;
		}

		private void MutationChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			return;
		}

		private void CurrentSeasonCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			return;
		}

		private void CurrentColorFilterCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			return;
		}

		private void CurrentDaytimeCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			return;
		}

		public BitmapImage Convert(Image img)
		{
			using (var memory = new MemoryStream())
			{
				img.Save(memory, ImageFormat.Png);
				memory.Position = 0;

				var bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();

				return bitmapImage;
			}
		}
	}
}

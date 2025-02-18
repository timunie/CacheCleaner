﻿using System.ComponentModel;
using Avalonia.Media;

namespace CacheCleaner.Models;

public class CleaningEntryModel : INotifyPropertyChanged
{
	public string Path { get; init; }
	
	private int files;
	public int Files
	{
		get => files;
		set
		{
			files = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Files)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
		}
	}

	private int folders;
	public int Folders
	{
		get => folders;
		set
		{
			folders = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Folders)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

		}
	}
	public int Total => Files + Folders;
	private string status;
	public string Status
	{
		get => status;
		set
		{
			status = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brush)));
		}
	}

	// public ISolidColorBrush Brush => Status == "Scanned" ? Brushes.Wheat : Brushes.Aquamarine;
	public ISolidColorBrush Brush => Status == "Scanned" ? Brushes.Wheat : Brushes.Transparent;

	public event PropertyChangedEventHandler? PropertyChanged;
}
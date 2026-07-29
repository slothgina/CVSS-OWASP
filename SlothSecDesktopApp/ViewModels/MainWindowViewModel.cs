using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SlothSecDesktopApp.Views;

namespace SlothSecDesktopApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ICommand ShowAbuseCheckerCommand { get; }
    public ICommand ShowCvssCommand { get; }
    public ICommand ShowOwaspCommand { get; }

    private object _currentView;
    public object CurrentView
    {
        get => _currentView;
        set { _currentView = value; OnPropertyChanged(); }
    }

    public MainWindowViewModel()
    {
        ShowAbuseCheckerCommand = new RelayCommand(_ => CurrentView = new AbuseCheckerView());
        ShowCvssCommand = new RelayCommand(_ => CurrentView = new CvssView());
        ShowOwaspCommand = new RelayCommand(_ => CurrentView = new OwaspRiskView());

        CurrentView = new AbuseCheckerView();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

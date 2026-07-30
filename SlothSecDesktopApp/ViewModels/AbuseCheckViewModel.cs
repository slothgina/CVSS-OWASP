using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SlothSecDesktopApp.Services;

namespace SlothSecDesktopApp.ViewModels;

public class AbuseCheckViewModel : INotifyPropertyChanged
{
    private readonly AbuseLookupService _service;

    public AbuseCheckViewModel()
    {
        _service = new AbuseLookupService();
        CheckIpCommand = new RelayCommand(async _ => await CheckIpAsync());
    }

    private string _ipAddress = "";
    public string IpAddress
    {
        get => _ipAddress;
        set { _ipAddress = value; OnPropertyChanged(); }
    }

    private string _resultText = "";
    public string ResultText
    {
        get => _resultText;
        set { _resultText = value; OnPropertyChanged(); }
    }

    public ICommand CheckIpCommand { get; }

    private async Task CheckIpAsync()
    {
        if (string.IsNullOrWhiteSpace(IpAddress))
        {
            ResultText = "Please enter an IP address.";
            return;
        }

        var result = await _service.LookupAsync(IpAddress);

        if (result == null)
        {
            ResultText = "No data returned for this IP.";
            return;
        }

        ResultText =
            $"IP Address: {result.IpAddress}\n" +
            $"Country: {result.CountryName}\n" +
            $"Usage Type: {result.UsageType}\n" +
            $"Confidence Score: {result.ConfidenceScore}\n" +
            $"Is Whitelisted: {result.IsWhitelisted}\n" +
            $"Total Reports: {result.TotalReports}\n" +
            $"Last Reported At: {result.LastReportedAt}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
  
    
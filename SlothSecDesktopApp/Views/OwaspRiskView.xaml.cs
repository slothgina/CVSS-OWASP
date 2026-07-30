using System.Windows.Controls;
using SlothSecDesktopAppViewModels;

namespace SlothSecDesktopApp.Views;

public partial class OwaspRiskView : UserControl
{
    public OwaspRiskView()
    {
        InitializeComponent();
        DataContext = new OwaspRiskViewModel();
    }
}
using System.Windows.Controls;
using SlothSecDesktopAppViewModels;

namespace SlothSecDesktopApp.Views;

public partial class CvssCalculatorView : UserControl
{
    public CvssCalculatorView()
    {
        InitializeComponent();
        DataContext = new CvssCalculatorViewModel();
    }
}
using System.Windows.Controls;
using SlothSecDesktopApp.ViewModels;

namespace SlothSecDesktopApp.Views
{
    public partial class AbuseCheckView : UserControl
    {
        public AbuseCheckView()
        {
            InitializeComponent();
            DataContext = new AbuseCheckViewModel();
        }
    }
}
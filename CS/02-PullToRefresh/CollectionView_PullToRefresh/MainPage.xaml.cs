using Xamarin.Forms;

namespace CollectionView_PullToRefresh {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            BindingContext = new ViewModel(new MailMessageRepository());
        }
    }
}
using Xamarin.Forms;

namespace CollectionView_PullToRefresh {
    public partial class MainPage : ContentPage {
        public MainPage() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
            BindingContext = new ViewModel(new MailMessageRepository());
        }
    }
}
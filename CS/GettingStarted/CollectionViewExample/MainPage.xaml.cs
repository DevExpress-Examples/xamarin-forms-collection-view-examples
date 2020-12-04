using Xamarin.Forms;

namespace CollectionViewExample {
    public partial class MainPage : ContentPage {
        public MainPage() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
        }
    }
}

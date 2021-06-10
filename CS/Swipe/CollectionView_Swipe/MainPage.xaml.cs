using Xamarin.Forms;
using DevExpress.XamarinForms.CollectionView;

namespace CollectionView_Swipe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
        }

        void SwipeItem_Invoked(System.Object sender, SwipeItemTapEventArgs e)
        {
            this.collectionView.DeleteItem(e.ItemHandle);
        }
    }
}

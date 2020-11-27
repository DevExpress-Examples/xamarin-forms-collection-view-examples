using Xamarin.Forms;

namespace ToDoList {
    public partial class SwipeItemViewEx : SwipeItemView {
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create("LabelText",
            typeof(string), typeof(SwipeItemViewEx), defaultValue: string.Empty,
            propertyChanged: LabelTextPropertyChanged);

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource",
            typeof(ImageSource), typeof(SwipeItemViewEx), defaultValue: null,
            propertyChanged: ImageSourcePropertyChanged);

        static void LabelTextPropertyChanged(BindableObject bindable, object oldValue, object newValue) { }
        static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) { }

        public SwipeItemViewEx() {
            InitializeComponent();
            this.swipeItemContainer.BindingContext = this;
        }

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public ImageSource ImageSource {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
    }
}

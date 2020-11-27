using System;
using DevExpress.XamarinForms.CollectionView;
using Xamarin.Forms;

namespace ToDoList {
    public partial class MainPage : ContentPage {
        readonly DragDropModel vm;
        SwipeView openedSwipeView;

        public MainPage() {
            InitializeComponent();
            this.vm = new DragDropModel(new EmployeeTaskRepository());
            BindingContext = vm;
        }

        void DragItem(object sender, DragItemEventArgs e) {
            CloseSwipeViewIfNeeded();
            e.Allow = IsItemDraggable(e.DragItem);
        }

        void DragItemOver(object sender, DropItemEventArgs e) {
            e.Allow = IsItemDraggable(e.DropItem);
        }

        bool IsItemDraggable(object item) {
            return !((EmployeeTask)item).Completed;
        }

        void OnItemBindingContextChanged(object sender, EventArgs e) {
            CloseSwipeViewIfNeeded();
            openedSwipeView = sender as SwipeView;
            CloseSwipeViewIfNeeded();
        }
        void OnSwipeStarted(object sender, SwipeStartedEventArgs e) {
            CloseSwipeViewIfNeeded();
        }
        void OnSwipeEnded(object sender, SwipeEndedEventArgs e) {
            openedSwipeView = sender as SwipeView;
        }

        void OnTap(object sender, CollectionViewGestureEventArgs e) {
            if (openedSwipeView == null || openedSwipeView.BindingContext == e.Item)
                return;
            CloseSwipeViewIfNeeded();
        }

        void CloseSwipeViewIfNeeded() {
            if (openedSwipeView != null) {
                openedSwipeView.Close();
                openedSwipeView = null;
            }
        }

        void OnDeleteTask(object sender, EventArgs e) {
            if (sender is BindableObject bindableObject) {
                if (bindableObject.BindingContext is EmployeeTask task)
                    vm.ItemSource.Remove(task);
            }
        }
    }

    class ItemTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is EmployeeTask task))
                return null;

            return task.Completed ? CompletedDataTemplate : UncompletedDataTemplate;
        }

        public DataTemplate CompletedDataTemplate { get; set; }
        public DataTemplate UncompletedDataTemplate { get; set; }
    }
}

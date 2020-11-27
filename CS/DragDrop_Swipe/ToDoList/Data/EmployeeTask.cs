using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoList {
    public class EmployeeTask : NotificationObject {
        public EmployeeTask() {
            CompleteTaskCommand = new Command(() => Status = 100);
            UnCompleteTaskCommand = new Command(() => Status = 0);
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }

        int status;
        public int Status {
            get => this.status;
            set => SetProperty(ref this.status, value, () => OnPropertyChanged(nameof(Completed)));
        }

        public bool Completed => Status == 100;

        public ICommand CompleteTaskCommand { get; }
        public ICommand UnCompleteTaskCommand { get; }
    }
}

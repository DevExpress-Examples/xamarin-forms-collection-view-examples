using System.Collections.Generic;

namespace ToDoList {
    public class DragDropModel : NotificationObject {
        readonly EmployeeTaskRepository repository;

        public IList<EmployeeTask> ItemSource => this.repository.EmployeeTasks;

        public DragDropModel(EmployeeTaskRepository repository) {
            this.repository = repository;
        }
    }
}

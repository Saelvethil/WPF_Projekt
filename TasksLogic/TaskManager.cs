using System.Collections.ObjectModel;

namespace TasksLogic
{
    public class TaskManager
    {
        public ObservableCollection<Category> CategoriesList;
        public ObservableCollection<Task> TasksList;

        public TaskManager()
        {
            CategoriesList = new ObservableCollection<Category>();
            TasksList = new ObservableCollection<Task>();
        }
    }
}

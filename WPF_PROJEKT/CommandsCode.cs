using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TasksLogic;

namespace WPF_PROJEKT
{
    public partial class MainWindow : Window
    {
        void BackExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (Subtasks.Visibility == Visibility.Visible)
            {
                IEnumerator enumerator = TasksCollection.ItemsSource.GetEnumerator();
                enumerator.MoveNext();
                Task task = (Task)enumerator.Current;
                LabelHeader.Content = task.Category.Name;
                Subtasks.Visibility = Visibility.Collapsed;
                Tasks.Visibility = Visibility.Visible;

            }
            else if (Tasks.Visibility == Visibility.Visible)
            {
                LabelHeader.Content = "Categories";
                Tasks.Visibility = Visibility.Collapsed;
                Categories.Visibility = Visibility.Visible;
            }
        }

        void BackCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            if (Subtasks != null && Tasks != null)
            {
                if (Subtasks.Visibility == Visibility.Visible || Tasks.Visibility == Visibility.Visible)
                {
                    e.CanExecute = true;
                }
            }
        }

        void EditSubtaskExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CreateSubtaskWindow subtaskWindow = new CreateSubtaskWindow();
            subtaskWindow.Title = "Edit Subtask";
            Subtask edited = (Subtask)e.Parameter;
            subtaskWindow.SubtaskName = edited.Name;
            subtaskWindow.Result.Description = edited.Description;
            subtaskWindow.SubtaskPriorityComboBox.SelectedIndex = (int)edited.Priority;

            if (subtaskWindow.ShowDialog() == true)
            {
                Subtask subtask = subtaskWindow.Result;

                if (currentTask.ToDoList.Remove(edited))
                {
                    currentTask.ToDoList.Add(subtask);
                }
                else if (currentTask.DoingList.Remove(edited))
                {
                    currentTask.DoingList.Add(subtask);
                }
                else if (currentTask.DoneList.Remove(edited))
                {
                    currentTask.DoneList.Add(subtask);
                }

            }
        }

        void EditSubtaskCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void DeleteSubtaskExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Subtask edited = (Subtask)e.Parameter;

            currentTask.ToDoList.Remove(edited);
            currentTask.DoingList.Remove(edited);
            currentTask.DoneList.Remove(edited);

        }

        void DeleteSubtaskCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void EditTaskExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Task task = (Task)e.Parameter;
            CreateTaskWindow window = new CreateTaskWindow();
            window.SetCategory(task.Category);
            window.TaskName = task.Name;
            window.DatePickerStartDate.SelectedDate = task.StartDate;
            window.DatePickerDueDate.SelectedDate = task.DueDate;

            if (window.ShowDialog() == true)
            {
                task.Name = window.Result.Name;
                task.DueDate = window.Result.DueDate;
                task.StartDate = window.Result.StartDate;
                TasksCollection.ItemsSource = tm.TasksList.Where(obj => obj.Category.Name == task.Category.Name);
            }
        }

        void EditTaskCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void DeleteTaskExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Task task = (Task)e.Parameter;
            tm.TasksList.Remove(task);
            TasksCollection.ItemsSource = tm.TasksList.Where(obj => obj.Category.Name == task.Category.Name);
        }

        void DeleteTaskCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

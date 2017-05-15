using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TasksLogic;

namespace WPF_PROJEKT
{
    public partial class MainWindow : Window
    {
        Subtask dragged;
        ObservableCollection<Subtask> draggedContainer;

        private void Subtask_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Subtask subtask = (Subtask)((Button)sender).Tag;
            Task task = currentTask;

            ObservableCollection<Subtask> container = null;
            if (task.ToDoList.Contains(subtask))
                container = task.ToDoList;
            else if (task.DoingList.Contains(subtask))
                container = task.DoingList;
            else if (task.DoneList.Contains(subtask))
                container = task.DoneList;

            if (container != null)
            {
                dragged = subtask;
                draggedContainer = container;
                Button button = (Button)sender;
                DragDrop.DoDragDrop(button, button, DragDropEffects.Move);

            }
        }

        private void Subtask_Drop(object sender, DragEventArgs e)
        {
            ItemsControl container = null;
            container = (ItemsControl)sender;

            ObservableCollection<Subtask> collection = (ObservableCollection<Subtask>)container.ItemsSource;
            draggedContainer.Remove(dragged);
            collection.Add(dragged);
        }
    }
}

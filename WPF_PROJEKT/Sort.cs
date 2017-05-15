using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TasksLogic;

namespace WPF_PROJEKT
{
    public partial class MainWindow : Window
    {

        private ListCollectionView GetViewByName(String name)
        {
            if (TasksCollection != null && TasksCollection.ItemsSource != null)
            {
                IEnumerator enumerator = TasksCollection.ItemsSource.GetEnumerator();
                enumerator.MoveNext();
                Task task = (Task)enumerator.Current;
                if(name == "ToDo") return (ListCollectionView)CollectionViewSource.GetDefaultView(task.ToDoList);
                else if (name == "Doing") return (ListCollectionView)CollectionViewSource.GetDefaultView(task.DoingList);
                else if (name == "Done") return (ListCollectionView)CollectionViewSource.GetDefaultView(task.DoneList);                
            }
            return null;
        }

        private class SortByPriority : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Subtask bookX = (Subtask)x;
                Subtask bookY = (Subtask)y;
                return bookY.Priority.CompareTo(bookX.Priority);
            }
        }
        private void SortPriority(object sender, RoutedEventArgs e)
        {
            ListCollectionView View = GetViewByName((string)((ComboBox)((ComboBoxItem)sender).Parent).Tag); if (View != null)
                View.CustomSort = new SortByPriority();
        }
        private void SortName(object sender, RoutedEventArgs e)
        {
            ListCollectionView View = GetViewByName((string)((ComboBox)((ComboBoxItem)sender).Parent).Tag); if (View != null)
            {
                View.SortDescriptions.Clear();
                View.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }
        private void SortNone(object sender, RoutedEventArgs e)
        {
            ListCollectionView View = GetViewByName((string)((ComboBox)((ComboBoxItem)sender).Parent).Tag);
            if (View != null)
            {
                View.SortDescriptions.Clear();
                View.CustomSort = null;
            }
        }
    }
}

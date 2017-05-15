using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TasksLogic;

namespace WPF_PROJEKT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskManager tm;
        Task currentTask;

        public MainWindow()
        {
            InitializeComponent();
            this.Foreground = Brushes.White;
            tm = new TaskManager();
            tm.CategoriesList.Add(new Category() { Name = "Work", ImagePath = "images/Work.png" });
            tm.CategoriesList.Add(new Category() { Name = "House", ImagePath = "images/Home.png" });
            tm.CategoriesList.Add(new Category() { Name = "Hobby", ImagePath = "images/Hobby.png" });
            tm.CategoriesList.Add(new Category() { Name = "Education", ImagePath = "images/Education.png" });
            tm.CategoriesList.Add(new Category() { Name = "Organisation", ImagePath = "images/Organisation.png" });
            tm.CategoriesList.Add(new Category() { Name = "Other", ImagePath = "images/Other.png" });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(1),
                Name = "Clean house"
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(2),
                Name = "Złożyć model samolotu",
                DueDate = DateTime.Now.AddDays(20)
            });
            TasksCollection.ItemsSource = tm.TasksList;

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 2",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 3",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 4",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 5",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 6",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList.Add(new Task()
            {
                Category = tm.CategoriesList.ElementAt(0),
                Name = "WPF project 7",
                StartDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2)
            });

            tm.TasksList[0].ToDoList.Add(new Subtask()
            {
                Name = "Subtask1",
                Description = "Subtask1 description",
                Priority = SubtaskPriorities.VeryHigh
            });
            tm.TasksList[0].ToDoList.Add(new Subtask()
            {
                Name = "Subtask2",
                Description = "Subtask2 description",
                Priority = SubtaskPriorities.High
            });
            tm.TasksList[0].ToDoList.Add(new Subtask()
            {
                Name = "Subtask3",
                Description = "Subtask3 description",
                Priority = SubtaskPriorities.Normal

            });
            tm.TasksList[0].ToDoList.Add(new Subtask()
            {
                Name = "Subtask4",
                Description = "Subtask4 description",
                Priority = SubtaskPriorities.Low
            });
            tm.TasksList[0].DoingList.Add(new Subtask()
            {
                Name = "Subtask5",
                Description = "Subtask5 description",
                Priority = SubtaskPriorities.High
            });


            CategoriesCollection.ItemsSource = tm.CategoriesList;

            LabelHeader.Content = "Categories";

        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            Categories.Visibility = Visibility.Collapsed;
            Tasks.Visibility = Visibility.Visible;
            Subtasks.Visibility = Visibility.Collapsed;

            LabelHeader.Content = (string)((Button)sender).Tag;
            TextBoxFilter.Text = "";

            TasksCollection.ItemsSource = tm.TasksList.Where(obj => obj.Category.Name == (string)((Button)sender).Tag);
        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {
            Categories.Visibility = Visibility.Collapsed;
            Tasks.Visibility = Visibility.Collapsed;
            Subtasks.Visibility = Visibility.Visible;

            Task task = (Task)((Button)sender).Tag;
            LabelHeader.Content = task.Name;
            currentTask = task;

            ToDoCollection.ItemsSource = task.ToDoList;
            DoingCollection.ItemsSource = task.DoingList;
            DoneCollection.ItemsSource = task.DoneList;

        }



        private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        {
            Category cat = tm.CategoriesList.Where(obj => obj.Name == (string)LabelHeader.Content).FirstOrDefault();
            CreateTaskWindow window = new CreateTaskWindow();
            window.SetCategory(cat);

            if (window.ShowDialog() == true)
            {
                tm.TasksList.Add(window.Result);
                TasksCollection.ItemsSource = tm.TasksList.Where(obj => obj.Category.Name == cat.Name);
            }
        }



        private void AddSubtaskClick(object sender, RoutedEventArgs e)
        {
            CreateSubtaskWindow subtaskWindow = new CreateSubtaskWindow();
            subtaskWindow.Title = "Create Subtask";
            if (subtaskWindow.ShowDialog() == true)
            {
                Subtask subtask = subtaskWindow.Result;

                Task task = currentTask;
                if (task != null)
                {
                    if ((string)((Button)sender).Tag == "ToDo")
                    {
                        task.ToDoList.Add(subtask);
                    }
                    else if ((string)((Button)sender).Tag == "Doing")
                    {
                        task.DoingList.Add(subtask);
                    }
                    else
                    {
                        task.DoneList.Add(subtask);
                    }
                }
            }
        }





    }
}

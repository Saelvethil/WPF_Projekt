using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TasksLogic;

namespace WPF_PROJEKT
{
    /// <summary>
    /// Interaction logic for CreateTaskWindow.xaml
    /// </summary>
    public partial class CreateTaskWindow : Window
    {

        public CreateTaskWindow()
        {
            InitializeComponent();
            this.Title = "Create new task";
            Result = new Task();
            
            TaskName = "Task";
            
            this.DataContext = this;
        }

        public void SetCategory(Category c)
        {
            Result.Category = c;
        }

        private String _taskName;
        public String TaskName
        {
            get { return _taskName; }
            set {
                if (value.Length == 0)
                    throw new ArgumentException("Name cannot be empty!");                
                _taskName = value;
            }
        }
        

        public Task Result { get; set; }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (DatePickerStartDate.SelectedDate != null)
                Result.StartDate = (DateTime)DatePickerStartDate.SelectedDate;
            if (DatePickerDueDate.SelectedDate != null)
                Result.DueDate = (DateTime)DatePickerDueDate.SelectedDate;
            Result.Name = TaskName;
            DialogResult = true;
            Close();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(TextBoxTaskName);
        }
    }
}

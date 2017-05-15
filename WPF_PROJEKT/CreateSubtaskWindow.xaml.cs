using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TasksLogic;

namespace WPF_PROJEKT
{
    /// <summary>
    /// Interaction logic for CreateSubtaskWindow.xaml
    /// </summary>
    public partial class CreateSubtaskWindow : Window
    {
        public CreateSubtaskWindow()
        {
            InitializeComponent();
            Result = new Subtask();
            DataContext = this;
            SubtaskName = "Subtask name";
            
        }

        private String _subtaskName;

        public String SubtaskName
        {
            get { return _subtaskName; }
            set {
                if (value.Length == 0)
                    throw new ArgumentException("Name cannot be empty!");
                _subtaskName = value; 
            }
        }
        public Subtask Result { get; set; }

        private void CreateSubtaskConfirmClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Result.Name = SubtaskName;
            string priority = ((ComboBoxItem)SubtaskPriorityComboBox.SelectedItem).Content.ToString();
            Result.Priority = (SubtaskPriorities)Enum.Parse(typeof(SubtaskPriorities), priority);
            DialogResult = true;
            Close();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(SubtaskNameTextBox);
        }

    }
}

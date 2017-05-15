using System.Windows.Input;

namespace WPF_PROJEKT
{
    public class Commands
    {
        private static RoutedCommand back;
        private static RoutedCommand editTask;
        private static RoutedCommand editSubtask;
        private static RoutedCommand deleteTask;
        private static RoutedCommand deleteSubtask;

        static Commands()
        {
            back = new RoutedCommand("Go Back", typeof(Commands));
            editTask = new RoutedCommand("Edit Task", typeof(Commands));
            editSubtask = new RoutedCommand("Edit Subtask", typeof(Commands));
            deleteTask = new RoutedCommand("Delete Task", typeof(Commands));
            deleteSubtask = new RoutedCommand("Delete Subtask", typeof(Commands));
        }
        public static RoutedCommand Back
        {
            get { return back; }
        }
        public static RoutedCommand EditTask
        {
            get { return editTask; }
        }
        public static RoutedCommand EditSubtask
        {
            get { return editSubtask; }
        }
        public static RoutedCommand DeleteTask
        {
            get { return deleteTask; }
        }
        public static RoutedCommand DeleteSubtask
        {
            get { return deleteSubtask; }
        }

    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TasksLogic;
namespace WPF_PROJEKT
{
    public partial class MainWindow : Window
    {
        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (View != null)
            {
                View.Filter = delegate(object item)
                {
                    Task product = (Task)item;
                    return product.Name.ToLower().Contains(TextBoxFilter.Text.ToLower());
                };
            }
        }

        private CollectionView View
        {
            get
            {
                if (TasksCollection != null && TasksCollection.ItemsSource != null)
                {
                    return (CollectionView)CollectionViewSource.GetDefaultView(TasksCollection.ItemsSource);
                }
                return null;
            }
        }




    }
}

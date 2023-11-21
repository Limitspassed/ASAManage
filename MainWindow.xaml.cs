using ASAManager.Classes;
using System.Windows;
using System.Windows.Controls;

namespace ASAManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TabManager.LoadTabs(tabControl);
        }

        private void SaveTabs()
        {
            TabManager.SaveTabs(tabControl);
        }

        public void AddNewTab()
        {
            TabManager.CreateNewTab(tabControl, txtServer);
        }


        private void AddTabButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTab();
        }

        private void DeleteTabButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem != null)
            {
                string selectedTabText = TabManager.GetSelectedTabText(tabControl);
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete this tab? {selectedTabText}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    tabControl.Items.Remove(tabControl.SelectedItem);
                }
            }
        }


        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveTabs();
        }
    }
}

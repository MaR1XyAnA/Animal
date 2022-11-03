using Animal.ViewFolder.PageFolder;
using System.Windows;
using System.Windows.Input;

namespace Animal.ViewFolder.WindowFolder
{
    public partial class AnimalMainWindow : Window
    {
        public AnimalMainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new NewAnimalPage());
            NewAnimalToggleButton.IsChecked = true;
        }

        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы окно перетаскивать
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e) // Для того, чтобы свернуть окно
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void NewAnimalToggleButton_Click(object sender, RoutedEventArgs e)
        {
            NewAnimalToggleButton.IsChecked = true;
            ListAnimalToggleButton.IsChecked = false;
            MainFrame.Navigate(new NewAnimalPage());
        }

        private void ListAnimalToggleButton_Click(object sender, RoutedEventArgs e)
        {
            NewAnimalToggleButton.IsChecked = false;
            ListAnimalToggleButton.IsChecked = true;
            MainFrame.Navigate(new ListAnimalPage());
        }
    }
}

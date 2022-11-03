using System.Windows;
using System.Windows.Input;

namespace Animal.ViewFolder.WindowFolder
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
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
            Application.Current.Shutdown();
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e) // Для того, чтобы свернуть окно
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void AnimalNextButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalMainWindow animalMainWindow = new AnimalMainWindow();
            animalMainWindow.Show();
            this.Close();
        }

        private void BookNextButton_Click(object sender, RoutedEventArgs e)
        {
            BookMainWindow bookMainWindow = new BookMainWindow();
            bookMainWindow.Show();
            this.Close();
        }
    }
}

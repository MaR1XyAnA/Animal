using Animal.ClassFolder;
using System.Linq;
using System.Windows.Controls;

namespace Animal.ViewFolder.PageFolder
{
    public partial class ListBookPage : Page
    {
        public ListBookPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new ModelFolder.AnimalDateBaseEntities(); // Подключаем БД к этой странице      
            ListBookDataGrid.ItemsSource = AppConnectClass.DataBase.BookTable.ToList(); // Выводим в ListBookDataGrid список данных из таблицы BookTable
        }
    }
}

using Animal.ClassFolder;
using System.Linq;
using System.Windows.Controls;

namespace Animal.ViewFolder.PageFolder
{
    public partial class ListAnimalPage : Page
    {
        public ListAnimalPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new ModelFolder.AnimalDateBaseEntities();
            ListAnimalDataGrid.ItemsSource = AppConnectClass.DataBase.AnimalTable.ToList();
        }
    }
}

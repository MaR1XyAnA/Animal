using Animal.ClassFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

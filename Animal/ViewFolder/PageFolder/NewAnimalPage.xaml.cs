using Animal.ClassFolder;
using Animal.ModelFolder;
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
    public partial class NewAnimalPage : Page
    {
        public NewAnimalPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new AnimalDateBaseEntities();
            ViewAnialCB.ItemsSource = AppConnectClass.DataBase.VievTable.ToList();
        }

        public void GetClear()
        {
            ViewAnialCB.Text = "";
            NameAnimalTB.Text = "";
            AgeTB.Text = "";
            ServiesTB.Text = "";
            DataEndDP.Text = "";
            PassportCB.IsChecked = false;
        }

        public void GetErrorCheck()
        {
            if (DataStartDP.Text == "" ||
                ViewAnialCB.Text == "" ||
                NameAnimalTB.Text == "" ||
                AgeTB.Text == "" ||
                ServiesTB.Text == "" ||
                DataEndDP.Text == "")
            {
                MessageBox.Show("ПОЛЯ ДОЛЖНЫ БЫТЬ ЗАПОЛНЕНЫ");
                return;
            }
        }

        private void NewAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            GetErrorCheck();
            if (AppConnectClass.DataBase.AnimalTable.Count
                (data => data.NameAnimal == NameAnimalTB.Text) > 0)
            {
                MessageBox.Show("ДАННОЕ ЖИВОТНОЕ УЖЕ СУЩЕСТВУЕТ");
                return;
            }
            else
            {
                try
                {
                    AnimalTable animalTable = new AnimalTable()
                    {
                        DataEntranceAnimal = (DateTime)DataStartDP.SelectedDate,
                        VievTable = ViewAnialCB.SelectedItem as VievTable,
                        NameAnimal = NameAnimalTB.Text,
                        PassportAnimal = (bool)PassportCB.IsChecked,
                        AgeAnimal = int.Parse(AgeTB.Text),
                        ServiesAnimal = ServiesTB.Text,
                        DateEnd = (DateTime)DataEndDP.SelectedDate
                    };
                    string _NameAmimal = NameAnimalTB.Text;
                    AppConnectClass.DataBase.AnimalTable.Add(animalTable);
                    AppConnectClass.DataBase.SaveChanges();
                    MessageBox.Show("ДАННЫЕ ОБ " + _NameAmimal + " ДОБАВЛЕННЫ УСПЕШНО");
                    GetClear();
                }
                catch
                {
                    MessageBox.Show("ОШИБКА ПРИ ДОБАВЛЕНИИ ДАННЫХ");
                }
            }
        }
    }
}

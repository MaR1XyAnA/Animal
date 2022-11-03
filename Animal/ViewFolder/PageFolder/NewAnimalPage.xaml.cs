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
            AppConnectClass.DataBase = new AnimalDateBaseEntities(); // Подключаем БД к этой странице
            ViewAnialCB.ItemsSource = AppConnectClass.DataBase.VievTable.ToList(); // В ViewAnialCB выводим все элементы из таблицы VievTable в виде листа
        }

        public void GetClear() // Метод по очистке текстовых полей
        {
            ViewAnialCB.Text = "";
            NameAnimalTB.Text = "";
            AgeTB.Text = "";
            ServiesTB.Text = "";
            DataEndDP.Text = "";
            PassportCB.IsChecked = false;
        }

        private void NewAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataStartDP.Text == "" ||
                ViewAnialCB.Text == "" ||
                NameAnimalTB.Text == "" ||
                AgeTB.Text == "" ||
                ServiesTB.Text == "" ||
                DataEndDP.Text == "") // Проверка на пустоту текстовых полей
            {
                MessageBox.Show("ПОЛЯ ДОЛЖНЫ БЫТЬ ЗАПОЛНЕНЫ");
                return;
            }
            else
            {
                // Проверки на наличае в БД книги с таким именем не будет
                // т.к. в БД есть много книг с одинаковым названием.

                try
                {
                    string _NameAmimal = NameAnimalTB.Text;
                    AnimalTable animalTable = new AnimalTable() // Таблица в которое едёт сохранение
                    {
                        DataEntranceAnimal = (DateTime)DataStartDP.SelectedDate,
                        VievTable = ViewAnialCB.SelectedItem as VievTable,
                        NameAnimal = NameAnimalTB.Text,
                        PassportAnimal = (bool)PassportCB.IsChecked,
                        AgeAnimal = int.Parse(AgeTB.Text),
                        ServiesAnimal = ServiesTB.Text,
                        DateEnd = (DateTime)DataEndDP.SelectedDate
                    };
                    AppConnectClass.DataBase.AnimalTable.Add(animalTable); // Метод добавления
                    AppConnectClass.DataBase.SaveChanges(); // Метод сохранения
                    MessageBox.Show("ДАННЫЕ ОБ " + _NameAmimal + " ДОБАВЛЕННЫ УСПЕШНО");
                    GetClear(); // Вызываем метод, который прописали выше
                }
                catch
                {
                    MessageBox.Show("ОШИБКА ПРИ ДОБАВЛЕНИИ ДАННЫХ");
                }
            }
        }
    }
}

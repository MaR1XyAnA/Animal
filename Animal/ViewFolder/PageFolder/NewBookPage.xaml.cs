using Animal.ClassFolder;
using Animal.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Animal.ViewFolder.PageFolder
{
    public partial class NewBookPage : Page
    {
        DateTime GetDate = DateTime.Today; // Метод, который берёт Дату и время системы
        public NewBookPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new AnimalDateBaseEntities(); // Подключаем БД к этой странице
            GenreBookComboBox.ItemsSource = AppConnectClass.DataBase.GenreTable.ToList(); // В GenreBookComboBox выводим все элементы из таблицы GenreTable в виде листа
        }

        public void GetClear() // Метод по очистке текстовых полей
        {
            SNMAuthorsTextBox.Text = "";
            NameBoobTextBox.Text = "";
            DatePublicationBookDatePicker.Text = "";
            GenreBookComboBox.Text = "";
            NecessarilyBookCheckBox.IsChecked = false;
        }

        private void NewBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                SNMAuthorsTextBox.Text == "" ||
                NameBoobTextBox.Text == "" ||
                DatePublicationBookDatePicker.Text == "" ||
                GenreBookComboBox.Text == "") // Проверка на пустоту текстовых полей
            {
                MessageBox.Show("ПОЛЯ ДОЛЖНЫ БЫТЬ ЗАПОЛНЕНЫ");
                return;
            }
            else
            {
                // Проверки на наличае в БД книги с таким именем не будет
                // т.к. в БД есть много книг с одинаковым названием.
                string _NameBookString = Convert.ToString(NameBoobTextBox.Text); // Получаем название книги для MessageBox

                try
                {
                    BookTable NewBook = new BookTable() // Таблица в которое едёт сохранение
                    {
                        DateofreceiptBook = GetDate,
                        GenreTable = GenreBookComboBox.SelectedItem as GenreTable,
                        SnmauthorBook = SNMAuthorsTextBox.Text,
                        NameBook = NameBoobTextBox.Text,
                        DateofpublicationBook = (DateTime)DatePublicationBookDatePicker.SelectedDate,
                        NecessarilyBook = (bool)NecessarilyBookCheckBox.IsChecked
                    };
                    AppConnectClass.DataBase.BookTable.Add(NewBook); // Метод добавления
                    AppConnectClass.DataBase.SaveChanges(); // Метод сохранения
                    GetClear(); // Вызываем метод, который прописали выше
                    MessageBox.Show("ДАННЫЕ ДЛЯ КНИГИ " + _NameBookString + " УСПЕШНО ДОБАВЛЕННЫ!");
                }
                catch
                {
                    MessageBox.Show("ОШИБКА ПРИ ДОБАВЛЕНИИ ДАННЫХ");
                }
            }
        }
    }
}

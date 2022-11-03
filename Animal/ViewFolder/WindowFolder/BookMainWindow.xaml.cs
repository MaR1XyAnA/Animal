﻿using Animal.ViewFolder.PageFolder;
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
using System.Windows.Shapes;

namespace Animal.ViewFolder.WindowFolder
{
    public partial class BookMainWindow : Window
    {
        public BookMainWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new NewAnimalPage());
            NewBookToggleButton.IsChecked = true;
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

        private void NewBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            NewBookToggleButton.IsChecked = true;
            ListBookToggleButton.IsChecked = false;
            //MainFrame.Navigate(new NewAnimalPage());
        }

        private void ListBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            NewBookToggleButton.IsChecked = false;
            ListBookToggleButton.IsChecked = true;
            //MainFrame.Navigate(new ListAnimalPage());
        }
    }
}

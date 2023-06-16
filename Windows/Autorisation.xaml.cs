using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblVersion.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox1.Text)) 
            {
                MessageBox.Show("Ошибка, введите пользователя"); 
            }
            else 
            { 
                if (string.IsNullOrEmpty(textbox2.Text))
                {
                    MessageBox.Show("Введите пароль", "Внимание");
                }
                else
                {
                    if (textbox1.Text.Contains("admin") && textbox2.Text.Contains("admin"))
                    {
                        Application.Current.Properties["name"] = textbox1.Text;
                        new MainWindow().Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль", "Внимание");
                    }
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}

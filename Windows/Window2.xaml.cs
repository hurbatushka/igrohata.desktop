using Igrohata.app.Pages;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            Application.Current.Properties["name"] = "Admin";
            versionLbl.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            label1.Content = $"Добро пожаловать: {(string)Application.Current.Properties["name"]}";
            updateUIMenu();
        }

        private void BookingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainFrame.Content is Booking))
            {
                MainFrame.Navigate(new Booking());
            }

        }

        void updateUIMenu()
        {
            BurgerMenu.Width = Igrohata.app.Settings.Default.BurgerMenu;
            if (BurgerMenu.Width != 230)
            {
                BookingBtn.Content = "Бронь";
                VipBtn.Content = "VIP";
                GameBtn.Content = "Игры";
                label1.Content = $"{(string)Application.Current.Properties["name"]}";
            }
        }

        private void ToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BurgerMenu.Width == 230)
            {
                // Сворачиваем бургер-меню
                DoubleAnimation animation = new DoubleAnimation(85, new Duration(TimeSpan.FromSeconds(0.3)));
                BurgerMenu.BeginAnimation(WidthProperty, animation);
                BookingBtn.Content = "Бронь";
                VipBtn.Content = "VIP";
                GameBtn.Content = "Игры";
                label1.Content = $"{(string)Application.Current.Properties["name"]}";
            }
            else
            {
                // Разворачиваем бургер-меню
                DoubleAnimation animation = new DoubleAnimation(230, new Duration(TimeSpan.FromSeconds(0.3)));
                BurgerMenu.BeginAnimation(WidthProperty, animation);
                BookingBtn.Content = "Бронирование";
                VipBtn.Content = "VIP клиенты";
                GameBtn.Content = "База игр";
                label1.Content = $"Добро пожаловать: {(string)Application.Current.Properties["name"]}";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Igrohata.app.Settings.Default.BurgerMenu = (int)BurgerMenu.Width;
            Igrohata.app.Settings.Default.Save();
        }
    }
}

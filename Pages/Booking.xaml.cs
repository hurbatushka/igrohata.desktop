using Igrohata.app.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Igrohata.app.Pages
{
    /// <summary>
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Page
    {
        private ObservableCollection<Person> people;
        private int currentPage = 0;
        private int itemsPerPage = 9;
        private int totalPages = 0;
        Random random = new Random();   
        public Booking()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>();
            for (int i = 1; i <= 154; i++)
            {
                people.Add(new Person
                {
                    Name = $"Джон {i}",
                    Age = random.Next(18, 51),
                    Email = $"John{i}@example.com"
                });
            }
            totalPages = (int)Math.Ceiling((double)people.Count / itemsPerPage) -1;
            // Отображение первой страницы
            ShowPage(0);
        }

        private void ShowPage(int pageNumber)
        {
            // Определите индекс начального элемента и количество элементов для текущей страницы
            int startIndex = pageNumber * itemsPerPage;
            int count = Math.Min(itemsPerPage, people.Count - startIndex);

            // Создайте подколлекцию для текущей страницы
            var pageItems = new ObservableCollection<Person>(people.Skip(startIndex).Take(count));

            // Установите подколлекцию в качестве источника данных для DataGrid
            dataGrid.ItemsSource = pageItems;

            // Обновите доступность кнопок навигации
            btnPrevious.IsEnabled = pageNumber > 0;
            btnNext.IsEnabled = startIndex + count < people.Count;
            pagenumberLbl.Content = $"Страница: {currentPage} из {totalPages}";
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            ShowPage(currentPage);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            ShowPage(currentPage);
        }

    }
}

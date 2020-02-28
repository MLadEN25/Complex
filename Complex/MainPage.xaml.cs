using Complex.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Complex
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnComplex_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ComplexListPage());
        }

        private void BtnHouse_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new HouseListPage());
        }

        private void BtnApartament_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ApartamentListPage());
        }
    }
}

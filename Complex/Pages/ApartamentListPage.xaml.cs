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

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApartamentListPage.xaml
    /// </summary>
    public partial class ApartamentListPage : Page
    {
        private readonly House house;

        public ApartamentListPage(House house = null)
        {
            InitializeComponent(); 
            if (house == null)
            {
                ApartamentLV.ItemsSource = MainWindow.db.Apartment.ToList();
            }
            else
            {
                ApartamentLV.ItemsSource = MainWindow.db.Apartment.Where(h => h.HouseID == house.ID).ToList();
            }

            this.house = house;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditOPEN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ApartamentLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите дом", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddComplexPage(ApartamentLV.SelectedItem as Complex));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

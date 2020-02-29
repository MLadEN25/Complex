using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            Navigation.NextPage(new AddApartamentPage(ApartamentLV.SelectedItem as Apartment));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ApartamentLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите квартиру", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddApartamentPage(ApartamentLV.SelectedItem as Apartment));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ApartamentLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите квартиру", "Ошибка");
            }
            else
            {
                var apartment = ApartamentLV.SelectedItem as Apartment;
                MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о квартире?", "Удаление", MessageBoxButton.YesNo);
                switch (MBRes)
                {
                    case MessageBoxResult.Yes:
                        MainWindow.db.Apartment.Remove(apartment);
                        MainWindow.db.SaveChanges();
                        ApartamentLV.ItemsSource = MainWindow.db.Complex.ToList();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}

using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для HouseListPage.xaml
    /// </summary>
    public partial class HouseListPage : Page
    {
        private readonly Complex complex;

        public HouseListPage(Complex complex = null)
        {
            InitializeComponent();
            this.complex = complex;
            if (complex == null)
            {
                HouseLV.ItemsSource = MainWindow.db.House.ToList();
            }
            else
            {
                HouseLV.ItemsSource = MainWindow.db.House.Where(h => h.ComplexID == complex.ID).ToList();
                ComplexBOX.Text = complex.Name;
                ComplexBOX.IsEnabled = false;
            }
        }

        private void StreetBOX_TextChanged(object sender, TextChangedEventArgs e) => Update();

        private void ComplexBOX_TextChanged(object sender, TextChangedEventArgs e) => Update();

        private void Update()
        {
            var lv = MainWindow.db.House.Where(c => c.Street.Contains(StreetBOX.Text.Trim())|| StreetBOX.Text.Trim() == "")
                .Where(c => c.Complex.Name.Contains(ComplexBOX.Text.Trim()) || ComplexBOX.Text.Trim() == "").ToList();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddHousePage(null));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

            if (HouseLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите дом", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddHousePage(HouseLV.SelectedItem as House));
            }
        }

        private void EditOPEN_Click(object sender, RoutedEventArgs e)
        {
            if (HouseLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите дома", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new ApartamentListPage(HouseLV.SelectedItem as House));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

            if (HouseLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите комплекс", "Ошибка");
            }
            else
            {
                var house = HouseLV.SelectedItem as House;
                if (house.Apartment.Count == 0)
                {
                    MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о комплексе?", "Удаление", MessageBoxButton.YesNo);
                    switch (MBRes)
                    {
                        case MessageBoxResult.Yes:
                            MainWindow.db.Complex.Remove(HouseLV.SelectedItem as Complex);
                            MainWindow.db.SaveChanges();
                            HouseLV.ItemsSource = MainWindow.db.Complex.ToList();
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    return;
                }
                MessageBox.Show("В домах есть зарегестрированные квартиры", "Ошибка");
            }
        }
    }
}

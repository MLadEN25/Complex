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

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

            if (HouseLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите дом", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddComplexPage(HouseLV.SelectedItem as Complex));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

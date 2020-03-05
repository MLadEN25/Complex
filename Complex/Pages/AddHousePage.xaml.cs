using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddHousePage.xaml
    /// </summary>
    public partial class AddHousePage : Page
    {
        private readonly House house;

        public AddHousePage(House house)
        {
            InitializeComponent();
            ComplexLV.ItemsSource = MainWindow.db.Complex.Where(h => h.VisibleStatus).ToList();
            if (house != null)
            {
                HouseNumerTB.Text = house.NumberOfHouse;
                StreetTB.Text = house.Street;
                AddValueTB.Text = house.AddedValue.ToString();
                ConstructionCostTB.Text = house.ConstructionCost.ToString();
                ComplexLV.SelectedItem = house.Complex;
                AddEditBTN.Content = "Редактировать";
            }
            else
            {
                AddEditBTN.Content = "Добавить";
            }

            this.house = house;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ComplexListPage());
        }

        private void AddEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplexLV.SelectedIndex != -1)
            {
                var sel = ComplexLV.SelectedItem as Complex;
                if (house != null)
                {
                    house.NumberOfHouse = HouseNumerTB.Text;
                    house.AddedValue = Convert.ToInt32(AddValueTB.Text);
                    house.Street = StreetTB.Text;
                    house.ConstructionCost = Convert.ToInt32(ConstructionCostTB.Text);
                    house.ComplexID = sel.ID;
                }
                else
                {
                    MainWindow.db.House.Add(new House
                    {
                        NumberOfHouse = HouseNumerTB.Text,
                        AddedValue = Convert.ToInt32(AddValueTB.Text),
                        Street = StreetTB.Text,
                        ConstructionCost = Convert.ToInt32(ConstructionCostTB.Text),
                        ComplexID = sel.ID
                    });
                }
                MainWindow.db.SaveChanges();
                MessageBox.Show("Успешно", "Добавление");
                Navigation.BackPage();
            }
            else
            {
                MessageBox.Show("Не выбран комплекс!", "Ошибка!");
            }
        }
    }
}

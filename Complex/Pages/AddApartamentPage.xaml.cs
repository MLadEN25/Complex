using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddApartamentPage.xaml
    /// </summary>
    public partial class AddApartamentPage : Page
    {
        private readonly Apartment apartment;

        public AddApartamentPage(Apartment apartment)
        {
            InitializeComponent();
            this.apartment = apartment;
            HouseLV.ItemsSource = MainWindow.db.House.Where(h => h.VisibleStatus).ToList();
            StateCB.ItemsSource = MainWindow.db.SaleStatus.ToList();
            StateCB.DisplayMemberPath = "Name";
            if (apartment != null)
            {
                NumnOfFlatTB.Text = apartment.NumOfFlat.ToString();
                AreaTB.Text = apartment.Area.ToString();
                AddValueTB.Text = apartment.AddedValue.ToString();
                CountOfRoomsTB.Text = apartment.CountOfRooms.ToString();
                CostOfBuildingTB.Text = apartment.CostOfBuilding.ToString();
                PorchTB.Text = apartment.Porch.ToString();
                FloorTB.Text = apartment.Floor.ToString();
                StateCB.SelectedItem = apartment.SaleStatus;
                HouseLV.SelectedItem = apartment.House;
                AddEditBTN.Content = "Редактировать";
            }
            else
            {
                AddEditBTN.Content = "Добавить";
            }
        }

        private void AddEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (HouseLV.SelectedIndex != -1)
            {
                if (apartment != null)
                {
                    apartment.NumOfFlat = Convert.ToInt32(NumnOfFlatTB.Text);
                    apartment.AddedValue = Convert.ToInt32(AddValueTB.Text);
                    var status = StateCB.SelectedItem as SaleStatus;
                    apartment.SaleStatusID = status.ID;
                    apartment.Porch = Convert.ToInt32(PorchTB.Text);
                    var house = HouseLV.SelectedItem as House;
                    apartment.HouseID = house.ID;
                    apartment.Floor = Convert.ToInt32(FloorTB.Text);
                    apartment.Area = Convert.ToDecimal(AreaTB.Text);
                    apartment.CostOfBuilding = Convert.ToInt32(CostOfBuildingTB.Text);
                    apartment.CountOfRooms = Convert.ToInt32(CountOfRoomsTB.Text);
                }
                else
                {
                    var status = StateCB.SelectedItem as SaleStatus;
                    var house = HouseLV.SelectedItem as House;
                    MainWindow.db.Apartment.Add(new Apartment
                    {
                        NumOfFlat = Convert.ToInt32(NumnOfFlatTB.Text),
                        AddedValue = Convert.ToInt32(AddValueTB.Text),
                        SaleStatusID = status.ID,
                        Porch = Convert.ToInt32(PorchTB.Text),
                        HouseID = house.ID,
                        Floor = Convert.ToInt32(FloorTB.Text),
                        Area = Convert.ToDecimal(AreaTB.Text),
                        CostOfBuilding = Convert.ToInt32(CostOfBuildingTB.Text),
                        CountOfRooms = Convert.ToInt32(CountOfRoomsTB.Text)
                    });
                }
                MainWindow.db.SaveChanges();
                MessageBox.Show("Успешно", "Добавление");
                Navigation.BackPage();
                return;
            }
        }
    }
}

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
    /// Логика взаимодействия для AddApartamentPage.xaml
    /// </summary>
    public partial class AddApartamentPage : Page
    {
        private readonly Apartment apartment;

        public AddApartamentPage(Apartment apartment)
        {
            InitializeComponent();
            this.apartment = apartment;
            HouseLV.ItemsSource = MainWindow.db.House.ToList();
            CtateCB.ItemsSource = MainWindow.db.SaleStatus.ToList();
            CtateCB.DisplayMemberPath = "Name";
            if (apartment != null)
            {
                CountOfRooms.Text = apartment.CountOfRooms.ToString();
                AreaTB.Text = apartment.Area.ToString();
                AddValueTB.Text = apartment.AddedValue.ToString();
                CountOfRoomsTB.Text = apartment.CountOfRooms.ToString();
                CostOfBuildingTB.Text = apartment.CostOfBuilding.ToString();
                PorchTB.Text = apartment.Porch.ToString();
                FloorTB.Text = apartment.Floor.ToString();
                CtateCB.SelectedItem = apartment.SaleStatus;
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

        }
    }
}

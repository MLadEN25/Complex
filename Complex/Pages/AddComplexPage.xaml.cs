using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddComplexPage.xaml
    /// </summary>
    public partial class AddComplexPage : Page
    {
        public AddComplexPage(Complex sel)
        {
            InitializeComponent();
            if (sel.House.All(h => h.Apartment.Any(a => a.SaleStatusID == 1)))
                StatusCB.ItemsSource = MainWindow.db.BuildStatus.Where(s=>s.ID!=2).ToList();
            else
                StatusCB.ItemsSource = MainWindow.db.BuildStatus.ToList();
            StatusCB.DisplayMemberPath = "Name";
            CityCB.ItemsSource = MainWindow.db.City.ToList();
            CityCB.DisplayMemberPath = "Name";
            if (sel != null)
            {
                ComplexNameTB.Text = sel.Name;
                AddedValueTB.Text = Convert.ToString(sel.AddedValue);
                StatusCB.SelectedItem = sel.BuildStatus;
                CostTB.Text = Convert.ToString(sel.ConstructionCost);
                CityCB.SelectedItem = sel.City;
                AddEditBTN.Content = "Редактировать";
            }
            else
            {
                AddEditBTN.Content = "Добавить";
            }
            this.DataContext = sel;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ComplexListPage());
        }

        private void AddEditBTN_Click(object sender, RoutedEventArgs e)
        {
            var Complex = this.DataContext as Complex;
            if (Complex != null)
            {
                Complex.Name = ComplexNameTB.Text;
                Complex.AddedValue = Convert.ToInt32(AddedValueTB.Text);
                BuildStatus SelBuildStatus = StatusCB.SelectedItem as BuildStatus;
                Complex.BuildStatusID = SelBuildStatus.ID;
                Complex.ConstructionCost = Convert.ToInt32(CostTB.Text);
                City SelCity = CityCB.SelectedItem as City;
                Complex.CityID = SelCity.ID;
            }
            else
            {
                BuildStatus SelBuildStatus = StatusCB.SelectedItem as BuildStatus;
                City SelCity = CityCB.SelectedItem as City;
                MainWindow.db.Complex.Add(new Complex
                {
                    Name = ComplexNameTB.Text,
                    AddedValue = Convert.ToInt32(AddedValueTB.Text),
                    BuildStatusID = SelBuildStatus.ID,
                    ConstructionCost = Convert.ToInt32(CostTB.Text),
                    CityID = SelCity.ID,
                });
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Успешно","Добавление");
            Navigation.BackPage();
        }
    }
}

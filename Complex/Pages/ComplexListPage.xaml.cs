using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Complex.Pages
{
    /// <summary>
    /// Логика взаимодействия для ComplexListPage.xaml
    /// </summary>
    public partial class ComplexListPage : Page
    {
        public ComplexListPage()
        {
            InitializeComponent();
            ComplexLV.ItemsSource = MainWindow.db.Complex.Where(c => c.VisibleStatus).ToList();

            CityCB.ItemsSource = MainWindow.db.City.ToList();
            CityCB.DisplayMemberPath = "Name";
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddComplexPage(null));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplexLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите комплекс","Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddComplexPage(ComplexLV.SelectedItem as Complex));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplexLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите комплекс", "Ошибка");
            }
            else
            {
                var complex = ComplexLV.SelectedItem as Complex;
                if (complex.House.Count == 0)
                {
                    MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о комплексе?", "Удаление", MessageBoxButton.YesNo);
                    switch (MBRes)
                    {
                        case MessageBoxResult.Yes:
                            complex.VisibleStatus = false;
                            MainWindow.db.SaveChanges();
                            ComplexLV.ItemsSource = MainWindow.db.Complex.Where(h => h.VisibleStatus).ToList();
                            MessageBox.Show("Удалено!");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    return;
                }
                MessageBox.Show("В комплексах есть зарегестрированные дома", "Ошибка");
            }
        }

        private void EditOPEN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplexLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите комплекс", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new HouseListPage(ComplexLV.SelectedItem as Complex));
            }
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityCB.SelectedIndex != -1)
            {
                var sel = CityCB.SelectedItem as City;
                ComplexLV.ItemsSource = MainWindow.db.Complex.Where(c => c.VisibleStatus && c.CityID == sel.ID).ToList();
            }
        }
    }
}

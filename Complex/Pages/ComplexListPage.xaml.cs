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
            ComplexLV.ItemsSource = MainWindow.db.Complex.ToList();
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
                MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о комплексе?", "Удаление", MessageBoxButton.YesNo);
                switch (MBRes)
                {
                    case MessageBoxResult.Yes:
                        MainWindow.db.Complex.Remove(ComplexLV.SelectedItem as Complex);
                        MainWindow.db.SaveChanges();
                        ComplexLV.ItemsSource = MainWindow.db.Complex.ToList();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void EditOPEN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplexLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите комплекс", "Ошибка");
            }
        }
    }
}

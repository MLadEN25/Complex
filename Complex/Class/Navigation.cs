using System.Windows.Controls;

namespace Complex
{
    class Navigation
    {
        public static MainWindow main;

        public static void NextPage(Page Page)
        {
            main.MainFrame.Navigate(Page);
        }
    }
}

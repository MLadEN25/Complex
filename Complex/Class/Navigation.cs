using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

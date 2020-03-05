using System.Collections.Generic;
using System.Windows.Controls;

namespace Complex
{
    class Navigation
    {
        public static MainWindow main;

        private static List<Page> pages = new List<Page>();

        public static void NextPage(Page Page)
        {
            main.MainFrame.Navigate(Page);
            main.TitlePageName.Content = Page.Title;
            pages.Add(Page);
        }

        internal static void BackPage()
        {
            if (pages.Count > 1)
            {
                pages.Remove(pages[pages.Count - 1]);
                main.TitlePageName.Content = (pages[pages.Count - 1]).Title;
                main.MainFrame.GoBack();
            }
        }
    }
}

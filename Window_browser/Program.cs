/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Window_browser
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Appcontainer container = new Appcontainer();

            container.Tabs.Add(
                new TitleBarTab(container)
                {
                    Content =new FrmMain
                    {
                        Text="New Tab"
                    }
                }

                );

            container.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();

            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
    }
}
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Window_browser
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Appcontainer container = new Appcontainer();

            container.Tabs.Add(
                new TitleBarTab(container)
                {
                    Content = new FrmMain
                    {
                        Text = "New Tab"
                    }
                }

                );

            container.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();

            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
    }
}

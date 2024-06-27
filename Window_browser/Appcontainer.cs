/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Window_browser
{
    internal class Appcontainer : TitleBarTabs
    {
        public Appcontainer()
        {
            //InitializeComponent();

            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }


        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new FrmMain
                {
                    Text="New Tab"
                }
            };
        }
    }

}
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Window_browser
{
    internal class Appcontainer : TitleBarTabs
    {
        public Appcontainer()
        {
            //InitializeComponent();

            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }


        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new FrmMain
                {
                    Text = "New Tab"
                }
            };
        }
    }

}

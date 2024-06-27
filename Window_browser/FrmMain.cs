/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Window_browser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }



    }
}

*/

/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;

namespace Window_browser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public CefSharp.WinForms.ChromiumWebBrowser Browser;

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Browser = new CefSharp.WinForms.ChromiumWebBrowser("https://www.google.co.uk/")
            {

            };

            this.panel1.Controls.Add(Browser);
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Ensure this is executed on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
               loader.Visible=e.IsLoading;
                Url.Text=
            });
        }

        void LoadUrl(string url)
        {
            if (url.StartsWith("http"))
            {
                Browser.Load(url);
            }

            else
            {
                Browser.Load($"https://www.google.com/search?q={url}");
            }
        }

        private void Url_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                LoadUrl(Url.Text.Trim());
            } 
        }

        

    }
}
*/



using System;
using System.Windows.Forms;
using EasyTabs;
using CefSharp;
using CefSharp.WinForms;
using System.Drawing;

namespace Window_browser
{
    public partial class FrmMain : Form
    {
        public ChromiumWebBrowser Browser;
        private Label loader;

        public FrmMain()
        {
            InitializeComponent();

            // Convert Bitmap to Icon
            //Icon appIcon = Icon.FromHandle(Properties.Resources.icon.GetHicon());

            // Set the form icon
            //this.Icon = appIcon;

            // Set the form text (title)
            //Text = "Window";
        }

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Browser = new ChromiumWebBrowser("https://www.google.co.uk/")
            {
                Dock = DockStyle.Fill
            };

            // Create and configure the loader label
            loader = new Label
            {
                Text = " ",
                AutoSize = true,
                Visible = false,
                // ForeColor = Color.Red,
                Dock = DockStyle.Top
            };

            // Add loader and browser to the panel
            this.panel1.Controls.Add(loader);
            this.panel1.Controls.Add(Browser);

            // Subscribe to the LoadingStateChanged event
            Browser.LoadingStateChanged += Browser_LoadingStateChanged;

            // Subscribe to the TitleChanged event
            Browser.TitleChanged += Browser_TitleChanged;
        }

        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Browser.Load(url);
            }
            else
            {
                Browser.Load($"https://www.google.com/search?q={url}");
            }
        }

        private void Url_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadUrl(Url.Text.Trim());
            }
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Ensure this is executed on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                loader.Visible = e.IsLoading;
                if (!e.IsLoading)
                {
                    // Update the URL textbox with the current browser address
                    Url.Text = Browser.Address;
                }
            });
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = e.Title; // Update the form's title with the page title
            });
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.Back();
            }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (Browser.CanGoForward) 
            {
                Browser.Forward();
            }

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Browser.Reload();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.google.co.uk/");
        }
    }
}

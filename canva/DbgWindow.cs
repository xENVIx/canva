using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canva
{
    public partial class DbgWindow : Form
    {

        public static DbgWindow Instance { get { return _instance; } }

        private DbgWindow()
        {
            InitializeComponent();

            this.Load += DbgWindow_Load;
        }

        private void DbgWindow_Load(object? sender, EventArgs e)
        {

            _loaded = true;
        }

        private void NewMsg(String msg)
        {

            DateTime now = DateTime.Now;

            String fmt = String.Format("{0:00}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}.{6:00}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);

            _rtbLog.Text += $"{fmt}: {msg}\n";
        }

        public static void NewLogMsg(String msg)
        {
            _instance.Invoke(new Action(() => _instance.NewMsg(msg)));
        }


        private static DbgWindow _instance = new DbgWindow();
       

        private bool _loaded = false;
    }
}

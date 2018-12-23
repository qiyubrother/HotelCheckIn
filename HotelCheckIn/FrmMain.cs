using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCheckIn
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Width = Width > 1024 ? 1024 : Width;
            Height = Height > 768 ? 768 : Height;
            base.OnSizeChanged(e);
        }
    }
}

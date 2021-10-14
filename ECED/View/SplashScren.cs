using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECED_FORMS.View
{
    public partial class SplashScren : Form
    {
        public SplashScren()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            ProgresseBar22.Increment(1);
            if (ProgresseBar22.Value == 100)
            {
                timer1.Enabled = false;
                TelaLogin log = new TelaLogin();
                log.Show();
                this.Hide();

            }
        }
    }
}

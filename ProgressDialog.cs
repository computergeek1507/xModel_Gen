using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xModel_Gen
{
    public partial class ProgressDialog : Form
    {
        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public int ProgressValue
        {
            set { if(value > progressBar1.Maximum )
                    progressBar1.Maximum = value;
                progressBar1.Value = value; }
        }

        public int ProgressMaximum
        {
            set { progressBar1.Maximum = value; }
        }

        public ProgressDialog()
        {
            InitializeComponent();
        }
    }
}

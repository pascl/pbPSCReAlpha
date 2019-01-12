using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public ClPbProgessBarLabeled addNewLine(String sCaption)
        {
            ClPbProgessBarLabeled c1 = new ClPbProgessBarLabeled(tlpFilesCopying);
            c1.setCaption(sCaption);

            return c1;
        }

        private void tmAutoHide_Tick(object sender, EventArgs e)
        {
            bool bVisible = false;
            if(tlpFilesCopying.HasChildren)
            {
                foreach(Control c in tlpFilesCopying.Controls)
                {
                    if(c.Visible == true)
                    {
                        bVisible = true;
                    }
                }
                this.Visible = bVisible;
            }
        }
    }
}

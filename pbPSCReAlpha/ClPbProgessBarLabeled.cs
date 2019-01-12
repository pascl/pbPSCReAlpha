using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public class ClPbProgessBarLabeled
    {
        ProgressBar _pb;
        Label _lb;

        public ClPbProgessBarLabeled(Control cParent)
        {
            _pb = new ProgressBar();
            _pb.Parent = cParent;
            _pb.Width = 150;
            _pb.Height = 16;

            _lb = new Label();
            _lb.AutoSize = true;
            _lb.Parent = cParent;
        }

        public Label PbLabel { get => _lb; set => _lb = value; }
        public ProgressBar PbProgressBar { get => _pb; set => _pb = value; }

        public void setCaption(String sCaption)
        {
            _lb.Text = sCaption;
        }
    }
}

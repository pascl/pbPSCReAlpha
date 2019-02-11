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
        Panel _pn;

        public ClPbProgessBarLabeled(Control cParent)
        {
            _pn = new Panel();
            _pn.Height = 16;
            _pn.Parent = cParent;
            _pn.Dock = DockStyle.Top;

            _pb = new ProgressBar();
            _pb.Parent = _pn;
            _pb.Width = 150;
            _pb.Height = 16;

            _lb = new Label();
            _lb.Parent = _pn;
            _lb.Left = 155;
            _lb.AutoSize = true;
        }

        public Label PbLabel { get => _lb; set => _lb = value; }
        public ProgressBar PbProgressBar { get => _pb; set => _pb = value; }
        public Panel PbPanel { get => _pn; set => _pn = value; }

        public void setCaption(String sCaption)
        {
            _lb.Text = sCaption;
        }
    }
}

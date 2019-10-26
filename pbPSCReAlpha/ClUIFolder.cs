using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public class ClUIFolder
    {
        List<int> _listGameIds;
        String _title;
        String _imgpath;

        public ClUIFolder(string title, List<int> listGameIds, String imgpath)
        {
            _listGameIds = listGameIds;
            _title = title;
            _imgpath = imgpath;
        }

        public string Title { get => _title; set => _title = value; }
        public List<int> ListGameIds { get => _listGameIds; set => _listGameIds = value; }
        public string Imgpath { get => _imgpath; set => _imgpath = value; }
    }
}

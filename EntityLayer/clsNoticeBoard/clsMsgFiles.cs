using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.clsNoticeBoard
{
    class clsMsgFiles
    {
        public int Id { get; set; }
        public byte[] fileBytes { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class truyenyeuthich
    {
        public int iMaTK { get; set; }
        public int iMatruyen { get; set; }

        public int iSochuong { get; set; }
        public string dNgaythem { get; set; }

        public truyenyeuthich() { }

        public truyenyeuthich(int iMaTK, int iMatruyen,int iSochuong, string dNgaythem)
        {
            this.iMaTK = iMaTK;
            this.iMatruyen = iMatruyen;
            this.iSochuong = iSochuong;
            this.dNgaythem = dNgaythem;
        }
    }
}
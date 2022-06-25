using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class Chuongtruyen
    {
        

        public int iMaTruyen { get; set; }
        public int iMaChuong { get; set; }
        public string sTenchuong { get; set; }
        public string sNdchuong { get; set; }
        public string dNgaydang { get; set; }
        public int iLuotdocchuong { get; set; }


        public Chuongtruyen() { }
        public Chuongtruyen(int iMaTruyen, int iMaChuong, string sTenchuong, string sNdchuong, string dNgaydang, int iLuotdocchuong) {
            this.iMaTruyen = iMaTruyen;
            this.iMaChuong = iMaChuong;
            this.sTenchuong = sTenchuong;
            this.sNdchuong = sNdchuong;
            this.dNgaydang = dNgaydang;
            this.iLuotdocchuong = iLuotdocchuong;
        }
    }
}
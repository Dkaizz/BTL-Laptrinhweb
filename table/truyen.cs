using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class truyen
    {
        
        public int iMatruyen { get; set; }
        public string sTentruyen { get; set; }
        public string sMota { get; set; }
        public int iMaTK { get; set; }
        public string sMaTheloai { get; set; }

        public string dNgaydang { get; set; }
        public int iLuotthichtong { get; set; }
        public int iLuotdoctong { get; set; }
        public float fdiemdanhgiatong { get; set; }

        public string uAnh { get; set; }
        public int bTrangthai { get; set; }
        public string sTacgia { get; set; }

        public truyen() { }
        public truyen(int iMatruyen, string sTentruyen, string sMota, int iMaTK, string sMaTheloai, string dNgaydang, int iLuotthichtong, int iLuotdoctong, float fdiemdanhgiatong, string uAnh, int bTrangthai, string sTacgia)
        {
            this.iMatruyen = iMatruyen;
            this.sTentruyen = sTentruyen;
            this.sMota = sMota;
            this.iMaTK = iMaTK;
            this.sMaTheloai = sMaTheloai;
            this.dNgaydang = dNgaydang;
            this.iLuotthichtong = iLuotthichtong;
            this.iLuotdoctong = iLuotdoctong;
            this.fdiemdanhgiatong = fdiemdanhgiatong;
            this.uAnh = uAnh;
            this.bTrangthai = bTrangthai;
            this.sTacgia = sTacgia;
        }
        public truyen(int iMatruyen, string sTentruyen, string sMota, string dNgaydang, int iLuotthichtong, int iLuotdoctong, float fdiemdanhgiatong, string uAnh, int bTrangthai, string sTacgia)
        {
            this.iMatruyen = iMatruyen;
            this.sTentruyen = sTentruyen;
            this.sMota = sMota;
            this.dNgaydang = dNgaydang;
            this.iLuotthichtong = iLuotthichtong;
            this.iLuotdoctong = iLuotdoctong;
            this.fdiemdanhgiatong = fdiemdanhgiatong;
            this.uAnh = uAnh;
            this.bTrangthai = bTrangthai;
            this.sTacgia = sTacgia;
        }
    }
}
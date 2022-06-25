using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class taikhoan
    {
        
        public int iMaTK { get; set; }
        public string sTaikhoan { get; set; }
        public string sMatkhau { get; set; }
        public string sEmail { get; set; }

        public string sTenhienthi { get; set; }

        public string sTennguoidung { get; set; }
        public string bGioitinh { get; set; }

        public string dNgaysinh { get; set; }
        public string dNgaytao { get; set; }
        public int iQuyen { get; set; }
        public string uavatar { get; set; }
        

        public taikhoan() { }

        public taikhoan(int iMaTK, string sTaikhoan, string sMatkhau, string sEmail, string sTenhienthi,string sTennguoidung, string dNgaytao, string uavatar) {
            this.iMaTK = iMaTK;
            this.sTaikhoan = sTaikhoan;
            this.sMatkhau = sMatkhau;
            this.sEmail = sEmail;
            this.sTenhienthi = sTenhienthi;
            this.sTennguoidung = sTennguoidung;
            this.dNgaytao = dNgaytao;
            this.uavatar = uavatar;
        }
        public taikhoan(int iMaTK, string sTaikhoan, string sMatkhau, string sEmail, string sTenhienthi, string bGioitinh, string dNgaysinh, int iQuyen, string dNgaytao, string uavatar)
        {
            this.iMaTK = iMaTK;
            this.sTaikhoan = sTaikhoan;
            this.sMatkhau = sMatkhau;
            this.sEmail = sEmail;
            this.sTenhienthi = sTenhienthi;
            this.bGioitinh = bGioitinh;
            this.dNgaysinh = dNgaysinh;
            this.iQuyen = iQuyen;
            this.dNgaytao = dNgaytao;
            this.uavatar = uavatar;
        }
        
    }
}
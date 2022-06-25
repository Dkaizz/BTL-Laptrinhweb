using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class lichsudoc
    {
        public int iMaTK { get; set; }
        public int iMatruyen { get; set; }

        public int iMaChuong { get; set; }

        public string dThoigiandoc { get; set; }

        public lichsudoc() { }
        public lichsudoc(int iMaTK, int iMatruyen, int iMaChuong, string dThoigiandoc) {
            this.iMaTK = iMaTK;
            this.iMatruyen = iMatruyen;
            this.iMaChuong = iMaChuong;
            this.dThoigiandoc = dThoigiandoc;
        }
    }
}
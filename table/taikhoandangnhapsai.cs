using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class taikhoandangnhapsai
    {
        public int iMaTK { set; get; }
        public int solansai { set; get; }

        public string dThoigianbatdaukhoa { set; get; }

        public taikhoandangnhapsai() { }

        public taikhoandangnhapsai(int iMaTK, int solansai, string dThoigianbatdaukhoa)
        {
            this.iMaTK = iMaTK;
            this.solansai = solansai;
            this.dThoigianbatdaukhoa = dThoigianbatdaukhoa;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btl_LTW.table
{
    public class danhgiatruyen
    {
        public int iMaTK { get; set; }

        public int iMatruyen { get; set; }

        public float iDiemtcnv { get; set; }

        public float iDiemndct { get; set; }

        public float iDiembocuctg { get; set; }

        public danhgiatruyen() { }

        public danhgiatruyen(int iMaTK, int iMatruyen, float iDiemtcnv, float iDiemndct, float iDiembocuctg)
        {
            this.iMaTK = iMaTK;
            this.iMatruyen = iMatruyen;
            this.iDiemtcnv = iDiemtcnv;
            this.iDiemndct = iDiemndct;
            this.iDiembocuctg = iDiembocuctg;
        }
    }
}
using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class thongtintaikhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Htmltttacgia = "";

            taikhoan tkhd = (taikhoan)Session["taikhoan"];

            int sotruyenst = 0;
            List<taikhoan> TaikhoanLists =  (List<taikhoan>)Application["ListTaikhoan"];
            List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
            List<lichsudoc> Lichsudoc = (List<lichsudoc>)Application["Lichsudoc"];
            List<truyenyeuthich> ListTruyenyeuthich = (List<truyenyeuthich>)Application["ListTruyenyeuthich"];

            List<lichsudoc> Lichsudoccuatg = new List<lichsudoc>(Lichsudoc);
            List<truyenyeuthich> listtruyenyt = new List<truyenyeuthich>(ListTruyenyeuthich);



            string Htmltruyenst = "";

            string tktg = Request.QueryString["Taikhoantg"];

            int sotruyenyeuthich = 0;
            int sotruyendadoc = 0;

            List<lichsudoc> lsd = Lichsudoccuatg.GroupBy(p => p.iMatruyen).Select(g => g.First()).ToList();
            List<truyenyeuthich> truyenyeuthich = listtruyenyt.GroupBy(p => p.iMatruyen).Select(g => g.First()).ToList();
            if (tktg != null && tktg != "")
            {
                 sotruyenyeuthich = (from n2 in truyenyeuthich where n2.iMaTK == int.Parse(tktg) select n2).Count();
                 sotruyendadoc = (from n2 in lsd where n2.iMaTK == int.Parse(tktg) select n2).Count();
            }
                


            foreach ( truyen truyen in TruyenLists)
            {
                if (tktg != null && tktg != "")
                {
                    if (int.Parse(tktg) == truyen.iMaTK)
                    {



                        Htmltruyenst += "<div class='btvdc_section'>                             " +
                        "<div class='imgtruyen'>                               " +
                        "<a href = 'Thongtintruyen.aspx?iMatruyen=" + truyen.iMatruyen + "'>" +
                        "<img src = '" + truyen.uAnh + "' alt=''/>" +
                        "</a></div>                             " +
                        "<div class='thongtintruyen'>                               " +
                        "<a href = 'Thongtintruyen.aspx?iMatruyen=" + truyen.iMatruyen + "'" +
                        "><h4>" + truyen.sTentruyen + "</h4></a>                               " +
                        "<div class='gioithieutruyen'>                                 " +
                        "" + truyen.sMota + "                               " +
                        "</div>                               " +
                        "<div class='tacgia display-ib'>                                 " +
                        "<i class='fas fa-user-edit icontacgia'></i> " + truyen.sTacgia + "" +
                        "</div>                               " +
                        "<div class='theloai display-ib'><a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                    }
                }
                else
                {
                    if (tkhd.iMaTK == truyen.iMaTK)
                    {



                        Htmltruyenst += "<div class='btvdc_section'>                             " +
                        "<div class='imgtruyen'>                               " +
                        "<a href = 'Thongtintruyen.aspx?iMatruyen=" + truyen.iMatruyen + "'>" +
                        "<img src = '" + truyen.uAnh + "' alt=''/>" +
                        "</a></div>                             " +
                        "<div class='thongtintruyen'>                               " +
                        "<a href = 'Thongtintruyen.aspx?iMatruyen=" + truyen.iMatruyen + "'" +
                        "><h4>" + truyen.sTentruyen + "</h4></a>                               " +
                        "<div class='gioithieutruyen'>                                 " +
                        "" + truyen.sMota + "                               " +
                        "</div>                               " +
                        "<div class='tacgia display-ib'>                                 " +
                        "<i class='fas fa-user-edit icontacgia'></i> " + truyen.sTacgia + "" +
                        "</div>                               " +
                        "<div class='theloai display-ib'><a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                    }
                }
                    
            }

            foreach (taikhoan taikhoan in TaikhoanLists)
            {
                if (tktg != null && tktg != "")
                {
                    sotruyenst = (from n2 in TruyenLists where n2.iMaTK == int.Parse(tktg) select n2).Count();
                    if (int.Parse(tktg) == taikhoan.iMaTK)
                    {
                        Htmltttacgia = "<div class='avatar'>             " +
                    "<img src = '" + taikhoan.uavatar + "' width='80px' alt='' />           " +
                    "</div>           <h1>" + taikhoan.sTenhienthi + "</h1>           " +
                    "<div class='ngaygianhap'>Gia nhập: " + taikhoan.dNgaytao + "</div>           " +
                    "<div class='thongtintacgia'>             " +
                    "<ul>               " +
                    "<li style = 'color: #a6b3b3' > Thông tin công khai:</li>               " +
                    "<li><div class='ten di-ib'>Tên:</div><div class='thongtint di-ib'>" + taikhoan.sTennguoidung + "</div></li>               " +
                    "<li><div class='gioitinh di-ib'>Giới tính</div><div class='thongtint di-ib'>" + taikhoan.bGioitinh + "</div></li>               " +
                    "<li><div class='truyendangdoc di-ib'>Số truyện đã đọc</div><div class='thongtint di-ib'>"+sotruyendadoc+"</div> </li>               " +
                    "<li><div class='truyendangdoc di-ib'>Số truyện yêu thích</div><div class='thongtint di-ib'>"+sotruyenyeuthich+"</div></li>               " +
                    "<li>                 <div class='truyensangtac di-ib'>Truyện sáng tác:</div><div class='thongtint di-ib'>" + sotruyenst + "</div></li>             " +
                    "</ul>           </div>";
                    }
                }
                else
                {
                    sotruyenst = (from n2 in TruyenLists where n2.iMaTK == tkhd.iMaTK select n2).Count();
                    if (tkhd.iMaTK == taikhoan.iMaTK)
                    {
                        Htmltttacgia = "<div class='avatar'>             " +
                    "<img src = '" + taikhoan.uavatar + "' width='80px' alt='' />           " +
                    "</div>           <h1>" + taikhoan.sTenhienthi + "</h1>           " +
                    "<div class='ngaygianhap'>Gia nhập: " + taikhoan.dNgaytao + "</div>           " +
                    "<div class='thongtintacgia'>             " +
                    "<ul>               " +
                    "<li style = 'color: #a6b3b3' > Thông tin công khai:</li>               " +
                    "<li><div class='ten di-ib'>Tên:</div><div class='thongtint di-ib'>" + taikhoan.sTennguoidung + "</div></li>               " +
                    "<li><div class='gioitinh di-ib'>Giới tính</div><div class='thongtint di-ib'>" + taikhoan.bGioitinh + "</div></li>               " +
                    "<li><div class='truyendangdoc di-ib'>Số truyện đã đọc</div><div class='thongtint di-ib'>0</div> </li>               " +
                    "<li><div class='truyendangdoc di-ib'>Số truyện yêu thích</div><div class='thongtint di-ib'>0</div></li>               " +
                    "<li>                 <div class='truyensangtac di-ib'>Truyện sáng tác:</div><div class='thongtint di-ib'>" + sotruyenst + "</div></li>             " +
                    "</ul>           </div>";
                    }
                }
            }

            thongtintacgia.InnerHtml = Htmltttacgia;
            dstruyenst.InnerHtml = Htmltruyenst;
        }
    }
}
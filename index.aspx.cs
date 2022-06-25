using Btl_LTW.table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class index : System.Web.UI.Page
    {
        List<Chuongtruyen> Listchuongtruyen = new List<Chuongtruyen>();

        int i = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
            List<Chuongtruyen> Listchuong = (List<Chuongtruyen>)Application["Chuonglist"];

            List<taikhoan> TaikhoanLists = new List<taikhoan>();
            taikhoan tkhd = (taikhoan)Session["taikhoan"];
            i++;
            Session["sx"] = "";

            if (i == 1)
            {
                Listchuongtruyen = new List<Chuongtruyen>(Listchuong);

                Listchuongtruyen.Reverse();
            }
            




            string yeucau = Request.QueryString["yeucau"];
            string Htmlbtvdc = "";
            string Htmltmcn = "";
            string Htmltmcnmobile = "";
            string Htmltruyenhoanthanh = "";
            

            if(yeucau == "dangxuat")
            {
                Session["login"] = 0;
                Application["sotaikhoanhoatdong"] = int.Parse(Application["sotaikhoanhoatdong"].ToString()) - 1;


            }


            int n = 0;

            int dem = 0;
            

           
            




            

            foreach (truyen truyen in TruyenLists)
            {
                if (dem < 9)
                {
                    dem++;
                    
                        
                        Htmlbtvdc += "<div class='btvdc_section'>                             " +
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
                        "<i class='fas fa-user-edit icontacgia'></i><a href = 'thongtintaikhoan.aspx?Taikhoantg=" + truyen.iMaTK + "'> " + truyen.sTacgia + "</a>" +
                        "</div>                               " +
                        "<div class='theloai display-ib'><a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                       
                    if(truyen.bTrangthai == 0)
                    {
                        Htmltruyenhoanthanh += "<div class='btvdc_section'>                             " +
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
                    "<i class='fas fa-user-edit icontacgia'></i><a href = 'thongtintaikhoan.aspx?Taikhoantg=" + truyen.iMaTK + "'> " + truyen.sTacgia + "</a>" +
                    "</div>                               " +
                    "<div class='theloai display-ib'><a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "' >" + truyen.sMaTheloai + "</a></div>" +
                    "</div>                         " +

                    "</div>";
                    }

                    
                }

            }
            foreach (Chuongtruyen Lchuong in Listchuongtruyen)
            {
                foreach (truyen truyen in TruyenLists)
                {
                    if (Lchuong.iMaTruyen == truyen.iMatruyen)
                    {
                        n++;

                        if (n < 9)
                        {
                            Htmltmcn += "       <tr>                   " +
                         "<td class='tb-color w-150'><a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "'><span>[" + truyen.sMaTheloai + "]</span></a></td>                   " +
                          "<td><h2> <a class='text-overflow-1-lines' href='Thongtintruyen.aspx?iMatruyen=" + Lchuong.iMaTruyen + "'>" + truyen.sTentruyen + "</a></h2></td>                   " +
                          "<td><a href = 'doctruyen.aspx?iMatruyen=" + Lchuong.iMaTruyen + "&iMachuong=" + Lchuong.iMaChuong + "' class='text-overflow-1-lines'>Chương " + Lchuong.iMaChuong + ": " + Lchuong.sTenchuong + "</a></td>" +
                          "<td><span> <a href = 'thongtintaikhoan.aspx?Taikhoantg=" + truyen.iMaTK + "'> " + truyen.sTacgia + "</a> </span></td>                                    " +
                          "</tr>";

                            Htmltmcnmobile += "  <li class='tttruyen-mobile'>                     " +
                                "<div class='item-i'>                       " +
                                "<a href = 'Thongtintruyen.aspx?iMatruyen=" + Lchuong.iMaTruyen + "' class='text-overflow-1-lines tentruyen-mobile'>" + truyen.sTentruyen + "</a>                       " +
                                "<a href = 'doctruyen.aspx?iMatruyen=" + Lchuong.iMaTruyen + "&iMachuong=" + Lchuong.iMaChuong + "' class='chuongmoi'> C." + Lchuong.iMaChuong + "</a>                     " +
                                "</div>                     " +
                                "<div class='item-i2'>                       " +
                                "<i class='fas fa-user-edit icontacgia'></i><a href = 'thongtintaikhoan.aspx?Taikhoantg=" + truyen.iMaTK + "'> " + truyen.sTacgia + "</a> <div class='theloai1 display-ib'>" +
                                "<a href = 'timkiem.aspx?Theloai=" + truyen.sMaTheloai + "' > " + truyen.sMaTheloai + "</a>                       " +
                                "</div>                     </div>                   " +
                                "</li>";
                        }
                    }
                    
                }
                
                    
                
            }

            

            btvdc.InnerHtml = Htmlbtvdc;
            truyenmoi.InnerHtml = "<table>"+

                Htmltmcn
              + "</table> " ;

            dschuongmobible.InnerHtml = "<ul>"+
                Htmltmcnmobile
               +"</ul> ";

            dstruyenht.InnerHtml = Htmltruyenhoanthanh;
           
        }
    }
}
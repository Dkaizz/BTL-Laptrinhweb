using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    
    public partial class timkiem : System.Web.UI.Page
    {
        List<truyen> truyentimkiem = new List<truyen>();

        
        protected void sapxeptheocapnhat_Click(object sender,EventArgs e)
        {

                Session["sx"] = sxcapnhat.InnerText;
                Page_Load(sender, e); 
        }
        protected void sapxeptheoluotdoc_Click(object sender, EventArgs e)
        {

            Session["sx"] = sxluotdoc.InnerText;
            Page_Load(sender, e);
        }

        protected void sapxeptheoluotthich_Click(object sender, EventArgs e)
        {

            Session["sx"] = sxluotthich.InnerText;
            Page_Load(sender, e);
        }

        void sapxep_Click(object sender, EventArgs e)
        {
            if(btnsapxep.InnerText == "Giảm dần")
            {
                
                btnsapxep.InnerText = "Tăng dần";

                Page_Load(sender, e);
            }
            else
            {
                btnsapxep.InnerText = "Giảm dần";

                Page_Load(sender, e);


            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string ndtimkiem = Request.QueryString["txtTimkiem"];
            string theloai = Request.QueryString["Theloai"];
            string trangthai = Request.QueryString["Trangthai"];
            string loaitrangthai = "";
            List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
            string Htmlndtimkiem = "";

            if (trangthai != null && trangthai != "")
            {
                if (int.Parse(trangthai) == 1)
                {
                    loaitrangthai = "Đang ra";

                }
                else
                {
                    loaitrangthai = "Hoàn thành";
                }
            }

            btnsapxep.ServerClick  += new EventHandler(this.sapxep_Click);
            




            
           if(Session["sx"].ToString() == "Cập nhật"|| Session["sx"].ToString() == "")
           {
                    if (btnsapxep.InnerText == "Giảm dần")
                    {
                        truyentimkiem = new List<truyen>(TruyenLists);
                        truyentimkiem.Sort((p1, p2) => {
                            if (p1.iMatruyen == p2.iMatruyen) return 0;
                            if (p1.iMatruyen < p2.iMatruyen) return 1;
                            return -1;
                        });

                        iconsx.InnerHtml = "<i class='fas fa-sort-amount-up sx-icon2'></i>";



                    }
                    else
                    {
                        truyentimkiem = new List<truyen>(TruyenLists);

                        truyentimkiem.Sort((p1, p2) => {
                            if (p1.iMatruyen == p2.iMatruyen) return 0;
                            if (p1.iMatruyen < p2.iMatruyen) return -1;
                            return 1;
                        });


                        iconsx.InnerHtml = "<i class='fas fa-sort-amount-up-alt sx-icon1'></i>";
                    }
           }
           else
           {
                    if(Session["sx"].ToString() == "Lượt đọc")
                    {
                        if (btnsapxep.InnerText == "Giảm dần")
                        {
                            truyentimkiem = new List<truyen>(TruyenLists);
                            truyentimkiem.Sort((p1, p2) => {
                                if (p1.iLuotdoctong == p2.iLuotdoctong) return 0;
                                if (p1.iLuotdoctong < p2.iLuotdoctong) return 1;
                                return -1;
                            });

                            iconsx.InnerHtml = "<i class='fas fa-sort-amount-up sx-icon2'></i>";



                        }
                        else
                        {
                            truyentimkiem = new List<truyen>(TruyenLists);

                            truyentimkiem.Sort((p1, p2) => {
                                if (p1.iLuotdoctong == p2.iLuotdoctong) return 0;
                                if (p1.iLuotdoctong < p2.iLuotdoctong) return -1;
                                return 1;
                            });


                            iconsx.InnerHtml = "<i class='fas fa-sort-amount-up-alt sx-icon1'></i>";
                        }
                    }
                    else
                    {
                        if (btnsapxep.InnerText == "Giảm dần")
                        {
                            truyentimkiem = new List<truyen>(TruyenLists);
                            truyentimkiem.Sort((p1, p2) => {
                                if (p1.iLuotthichtong == p2.iLuotthichtong) return 0;
                                if (p1.iLuotthichtong < p2.iLuotthichtong) return 1;
                                return -1;
                            });

                            iconsx.InnerHtml = "<i class='fas fa-sort-amount-up sx-icon2'></i>";



                        }
                        else
                        {
                            truyentimkiem = new List<truyen>(TruyenLists);

                            truyentimkiem.Sort((p1, p2) => {
                                if (p1.iLuotthichtong == p2.iLuotthichtong) return 0;
                                if (p1.iLuotthichtong < p2.iLuotthichtong) return -1;
                                return 1;
                            });


                            iconsx.InnerHtml = "<i class='fas fa-sort-amount-up-alt sx-icon1'></i>";
                        }      
                    }
           }
            


            if (ndtimkiem != null)
            {
                
                
                foreach (truyen truyen in truyentimkiem)
                {
                    


                    if (truyen.sTentruyen.ToLower().Contains(ndtimkiem.ToLower()))
                    {
                        Htmlndtimkiem += "<div class='btvdc_section'>                             " +
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
                        "<div class='theloai display-ib'><a href = '' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                    }
                }
                thongtintimkiem.InnerHtml = "<h3>Kết quả cho: </h3>" + ndtimkiem;
                csstimkiem.InnerHtml = "#capnhat{ color:#ccc}";
            }
            else
            {
                if(theloai!=null && theloai != "")
                {
                    foreach (truyen truyen in truyentimkiem)
                    {
                        if(truyen.sMaTheloai == theloai)
                        {
                            Htmlndtimkiem += "<div class='btvdc_section'>                             " +
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
                        "<div class='theloai display-ib'><a href = '' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                        }
                    }
                    thongtintimkiem.InnerHtml = "<h3>Thể loại: </h3>" + theloai;
                    csstimkiem.InnerHtml = "#capnhat{ color:#ccc}";


                }
                else
                {
                    if (trangthai != "" && trangthai != null)
                    {
                        foreach(truyen truyen in truyentimkiem)
                        {
                            if (truyen.bTrangthai == int.Parse(trangthai))
                            {
                                Htmlndtimkiem += "<div class='btvdc_section'>                             " +
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
                        "<div class='theloai display-ib'><a href = '' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";
                            }
                        }
                        thongtintimkiem.InnerHtml = "<h3>Trạng thái truyện: </h3>" + loaitrangthai;
                        csstimkiem.InnerHtml = "#capnhat{ color:#ccc}";
                    }
                    else
                    {
                         foreach (truyen truyen in truyentimkiem)
                        {
                            Htmlndtimkiem += "<div class='btvdc_section'>                             " +
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
                        "<div class='theloai display-ib'><a href = '' >" + truyen.sMaTheloai + "</a></div>" +
                        "</div>                         " +

                        "</div>";

                        }
                        thongtintimkiem.InnerHtml = "<h3>Tất cả:</h3>";


                    }
                }
            }
            

            kqtimkiem.InnerHtml = Htmlndtimkiem;
        }

        
        

    }
}
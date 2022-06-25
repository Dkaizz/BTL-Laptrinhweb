using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class doctruyen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString.Get("iMatruyen");
            string idc = Request.QueryString.Get("iMaChuong");
            string Html = "";
            string tentruyen = "";
            string tentacgia = "";
            string ngaydang = "";
            int soc =0;
            string displaytien = "block";
            string displaylui = "block";

            string Htmldschuong = "";



            if (id != "")
            {
                int idt = int.Parse(id);
                int idct = int.Parse(idc);

                vethongtintruyen.HRef = "Thongtintruyen.aspx?iMatruyen="+idt+"";

                List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
                List<Chuongtruyen> ListsChuong = (List<Chuongtruyen>)Application["Chuonglist"];
                List<lichsudoc> Lichsudoc = (List<lichsudoc>)Application["Lichsudoc"];
                taikhoan tkhd = (taikhoan)Session["taikhoan"];


                foreach (truyen truyen in TruyenLists)
                {
                    if (idt == truyen.iMatruyen)
                    {
                        tentruyen = truyen.sTentruyen;
                        tentacgia = truyen.sTacgia;
                        ngaydang = truyen.dNgaydang;

                        soc = (from n2 in ListsChuong where n2.iMaTruyen == idt select n2).Count();


                    }
                }

                //hiện nút chuyển chương
                if(idct == soc)
                {
                    displaytien = "none";
                    displaylui = "inline-block";
                }
                else
                {
                    if(idct == 1)
                    {
                        displaytien = "inline-block";
                        displaylui = "none";
                    }
                    else
                    {
                        displaytien = "inline-block";
                        displaylui = "inline-block";
                    }
                }
                int dem = 0;
                //thêm truyện vào lịch sử đọc
                if (int.Parse(Session["login"].ToString()) == 1)
                {
                    if (Lichsudoc.Count == 0)
                    {
                        Lichsudoc.Add(new lichsudoc() { iMaTK = tkhd.iMaTK, iMatruyen = idt, iMaChuong = idct, dThoigiandoc = DateTime.Now.ToString() });

                    }
                    else
                    {
                        foreach (lichsudoc ls in Lichsudoc)
                        {
                            if (tkhd.iMaTK == ls.iMaTK && idt == ls.iMatruyen && idct == ls.iMaChuong)
                            {
                                dem = 0;
                                break;
                            }
                            else
                            {
                                dem = 1;
                            }
                        }
                        if (dem == 1)
                        {
                            Lichsudoc.Add(new lichsudoc() { iMaTK = tkhd.iMaTK, iMatruyen = idt, iMaChuong = idct, dThoigiandoc = DateTime.Now.ToString() });
                        }
                        
                        
                    }

                }

                //hiện nội dung truyện
                foreach (Chuongtruyen chuong in ListsChuong)
                {
                    
                    if (idt == chuong.iMaTruyen)
                    {
                        Htmldschuong += "<a href = 'doctruyen.aspx?iMatruyen=" + idt + "&iMachuong="+chuong.iMaChuong+"'>Chương "+chuong.iMaChuong+": "+chuong.sTenchuong+" </a>";
                        

                        if (idct == chuong.iMaChuong)
                        {
                            chuong.iLuotdocchuong = chuong.iLuotdocchuong + 1;
                            Html += "<div class='btntruyen'>             " +
                                "<a href='doctruyen.aspx?iMatruyen="+idt+ "&iMaChuong="+(idct-1)+"' class='btnchuyenchuong luichuong' style='display: " + displaylui + "'>" +
                                "<i class='fas fa-arrow-left'></i> Chương trước" +
                                "</a>" +
                                "<a href='doctruyen.aspx?iMatruyen=" + idt + "&iMaChuong=" + (idct + 1) + "' class='btnchuyenchuong tienchuong'  style='display: " + displaytien+ "'> Chương sau<i class='fas fa-arrow-right'></i></a> " +
                                "<div class='clear'> </div>" +
                                "</div>           " +
                                "<div class='tenchuong'>             " +
                                "<h2>Chương "+chuong.iMaChuong+": "+chuong.sTenchuong+"</h2>" +
                                "</div>           " +
                                "<div class='thongtinchuong'>             " +
                                "<ul>               " +
                                "<li> <a id = 'tentruyen' href='#'><i class='fas fa-book icontt'></i>"+tentruyen+"</a></li>               " +
                                "<li><i class='fas fa-marker icontt'></i>"+tentacgia+"</li>               " +
                                "<li id = 'sochu' >< i class='fas fa-book-open icontt'></i>4500 chữ </li>               " +
                                "<li><i class='far fa-clock icontt'></i>"+ngaydang+"</li>" +
                                "</ul>           " +
                                "</div>           " +
                                "<div class='ndchuong'>"+chuong.sNdchuong+"</div>           " +
                                "<div class='btntruyen'>             " +
                                "<a href='doctruyen.aspx?iMatruyen=" + idt + "&iMaChuong=" + (idct - 1) + "' class='btnchuyenchuong luichuong' style='display: " + displaylui + "'>" +
                                "<i class='fas fa-arrow-left'></i> Chương trước" +
                                "</a>" +
                                "<a href='doctruyen.aspx?iMatruyen=" + idt + "&iMaChuong=" + (idct + 1) + "' class='btnchuyenchuong tienchuong'  style='display: " + displaytien + "'> Chương sau<i class='fas fa-arrow-right'></i></a> " +
                                "<div class='clear'> </div>" +
                                "</div>";
                        }

                       


                    }

                    ndtruyen.InnerHtml = Html;
                    dschuongtruyen.InnerHtml = Htmldschuong;


                }




                var dstr = (from n2 in ListsChuong where n2.iMaTruyen == idt select n2).ToList();
                int soluotdoc = dstr.Aggregate<Chuongtruyen, int>(0, (luotdoc, s) => luotdoc += s.iLuotdocchuong);

                foreach (truyen truyen in TruyenLists)
                {
                    if (idt == truyen.iMatruyen)
                    {
                        truyen.iLuotdoctong = soluotdoc;
                    }
                }






            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}
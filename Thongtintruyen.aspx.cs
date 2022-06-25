using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class Thongtintruyen : System.Web.UI.Page
    {

        

        protected void Danhdau_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("iMatruyen");
            taikhoan tkhd = (taikhoan)Session["taikhoan"];

            int n = 0;

            
            int idt = int.Parse(id);
            List<Chuongtruyen> ListsChuong = (List<Chuongtruyen>)Application["Chuonglist"];
            List<truyenyeuthich> ListTruyenyeuthich = (List<truyenyeuthich>)Application["ListTruyenyeuthich"];

            foreach (Chuongtruyen chuong in ListsChuong)
            {
                if (idt == chuong.iMaTruyen)
                {
                    n = ListsChuong.Count();

                }
            }
            if (int.Parse(Session["login"].ToString()) == 1)
            {


                if (btnDanhdau.InnerText == "Lưu Truyện")
                {
                    if (ListTruyenyeuthich.Count == 0)
                    {
                        btnDanhdau.InnerText = "Đã lưu";
                        ListTruyenyeuthich.Add(new truyenyeuthich() { iMaTK = tkhd.iMaTK, iMatruyen = idt, iSochuong = n, dNgaythem = DateTime.Now.ToString() });
                        Page_Load(sender, e);
                        
                    }
                    else
                    {
                        foreach (truyenyeuthich tryt in ListTruyenyeuthich)
                        {
                            if (idt == tryt.iMatruyen && tkhd.iMaTK == tryt.iMaTK)
                            {

                                Page_Load(sender, e);
                                break;
                            }
                            else
                            {

                                ListTruyenyeuthich.Add(new truyenyeuthich() { iMaTK = tkhd.iMaTK, iMatruyen = idt, iSochuong = n, dNgaythem = DateTime.Now.ToString() });
                                Page_Load(sender, e);
                                break;
                            }


                        }
                    }

                }
                else
                {
                    for (int i = 0; i < ListTruyenyeuthich.Count; i++)
                    {
                        if (idt == ListTruyenyeuthich[i].iMatruyen && tkhd.iMaTK == ListTruyenyeuthich[i].iMaTK)
                        {

                            ListTruyenyeuthich.RemoveAt(i);
                            Page_Load(sender, e);
                            break;
                        }


                    }
                }
            }
            


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["iMatruyen"];
            // int so = t;


            Session["sx"] = "";


            string Html = "";

            string Htmlanhtuyen = "";

            string Htmltentruyen = "";
            string Tacgiatheloai = "";
            string Htmldiemdanhgia = "";
            string Htmlgioithieu = "";
            string Htmldanhgiatruyen = "";
            string Htmldschuong = "";

            string btndoctruyen = "";

            float diemtcnv = 0;
            float diemndct = 0;
            float diembctg = 0;

            float tongdiemdanhgia = 0;
            if (id != "")
            {
                int idt = int.Parse(id);
                int n = 0;

                

                List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
                List<Chuongtruyen> ListsChuong = (List<Chuongtruyen>)Application["Chuonglist"];
                List<truyenyeuthich> ListTruyenyeuthich = (List<truyenyeuthich>)Application["ListTruyenyeuthich"];
                taikhoan tkhd = (taikhoan)Session["taikhoan"];
                List<lichsudoc> Lichsudoc = (List<lichsudoc>)Application["Lichsudoc"];
                List<danhgiatruyen> Danhgiatruyen = (List<danhgiatruyen>)Application["Danhgiatruyen"];


                string diemtinhcachnhanvat = Request.Form["dtinhcachnv"];
                string diemnoidungcottruyen = Request.Form["dndcotruyen"];
                string diembocucthegioi = Request.Form["dbocucthegioi"];
                int cacdanhgia = Danhgiatruyen.Count();

                if (int.Parse(Session["login"].ToString()) == 1)
                {
                    if (diemtinhcachnhanvat != "" && diemtinhcachnhanvat != null && diemnoidungcottruyen != "" && diemnoidungcottruyen != null && diembocucthegioi != "" && diembocucthegioi != null)
                    {

                        int kiemtra = 0;
                        diemtcnv = (float)float.Parse(diemtinhcachnhanvat);
                        if (diemtcnv > 10)
                        {
                            diemtcnv = diemtcnv / 10;
                        }
                        diemndct = (float)float.Parse(diemnoidungcottruyen);
                        if (diemndct > 10)
                        {
                            diemndct = diemndct / 10;
                        }
                        diembctg = (float)float.Parse(diembocucthegioi);
                        if (diembctg > 10)
                        {
                            diembctg = diembctg / 10;
                        }
                        if (cacdanhgia != 0)
                        {
                            foreach (danhgiatruyen danhgia in Danhgiatruyen)
                            {
                                if (danhgia.iMaTK == tkhd.iMaTK)
                                {
                                    danhgia.iDiemtcnv = diemtcnv;
                                    danhgia.iDiemndct = diemndct;
                                    
                                    danhgia.iDiembocuctg = diembctg;
                                    kiemtra = 0;
                                    break;
                                }
                                else
                                {
                                    kiemtra = 1;
                                }
                            }
                        }
                        else
                        {
                            kiemtra = 1;
                        }
                        if (kiemtra == 1)
                        {
                            Danhgiatruyen.Add(new danhgiatruyen() { iMaTK = tkhd.iMaTK, iMatruyen = idt, iDiemtcnv = diemtcnv, iDiemndct = diemndct, iDiembocuctg = diembctg });

                        }
                    }

                }
                var dsdanhgiacuatruyen = (from n2 in Danhgiatruyen where n2.iMatruyen == idt select n2).ToList();

                float iTongdiemtcnv = dsdanhgiacuatruyen.Aggregate<danhgiatruyen, float>(0, (iDiemtcnv, s) => iDiemtcnv += s.iDiemtcnv);
                float iTongdiemndct = dsdanhgiacuatruyen.Aggregate<danhgiatruyen, float>(0, (iDiemndct, s) => iDiemndct += s.iDiemndct);
                float iTongdiembctg = dsdanhgiacuatruyen.Aggregate<danhgiatruyen, float>(0, (iDiembctg, s) => iDiembctg += s.iDiembocuctg);

                float tongdanhgia = 0;

                int soluongdanhgia = 0;
                soluongdanhgia = dsdanhgiacuatruyen.Count();
                tongdanhgia = (iTongdiemtcnv + iTongdiemndct + iTongdiembctg) / (3 * soluongdanhgia);

               
                

                int m = (from n2 in Lichsudoc where n2.iMatruyen == idt select n2).Count(); //số truyện đã đọc

                if (m==0)
                {
                    btndoctruyen = "<a id='adoctruyen' href='doctruyen.aspx?iMatruyen=" + idt + "&iMachuong=1'>Đọc truyện</a>";
                }
                else
                {
                    List<lichsudoc> lsd = new List<lichsudoc>(Lichsudoc);
                    lsd.Reverse();
                    foreach(lichsudoc ls in lsd)
                    {
                        btndoctruyen = "<a href='doctruyen.aspx?iMatruyen=" + idt + "&iMachuong=" + ls.iMaChuong + "'>Đọc tiếp</a>";
        
                        thongtintruyencss.InnerHtml = ".btltttruyen li a{background-color: #ccc; color: #fff;}";
                        break;
                    }
                }

                btndoc.InnerHtml = btndoctruyen;

                if (ListTruyenyeuthich.Count !=0)
                {
                    foreach(truyenyeuthich tr in ListTruyenyeuthich)
                    {
                        if (idt == tr.iMatruyen && tkhd.iMaTK == tr.iMaTK)
                        {
                            btnDanhdau.InnerText = "Đã lưu";
                            break;
                        }
                        else
                        {
                            btnDanhdau.InnerText = "Lưu Truyện";

                        }

                    }
                }
                else
                {
                    btnDanhdau.InnerText = "Lưu Truyện";

                }


                foreach (Chuongtruyen chuong in ListsChuong)
                {
                    if (idt == chuong.iMaTruyen)
                    {
                        n = (from n2 in ListsChuong where n2.iMaTruyen == idt select n2).Count();

                      
                        Htmldschuong += "<a href = 'doctruyen.aspx?iMatruyen=" + idt + "&iMachuong="+chuong.iMaChuong+"'>Chương "+chuong.iMaChuong+": "+chuong.sTenchuong+" </a>";


                    }
                    dschuongtruyen.InnerHtml = Htmldschuong;
                }

                foreach (truyen truyen in TruyenLists)
                {
                    if (idt == truyen.iMatruyen)
                    {
                        int soluotthichcuatruyen = (from n2 in ListTruyenyeuthich where n2.iMatruyen == idt select n2).Count(); //số truyện đã đọc
                        truyen.iLuotthichtong = soluotthichcuatruyen;
                        truyen.fdiemdanhgiatong = tongdanhgia;
                        tongdiemdanhgia = truyen.fdiemdanhgiatong;
                        
                        Htmlanhtuyen += "<img src = '" + truyen.uAnh + "' alt='' width='100%' height='100%';/>";
                        Htmltentruyen += truyen.sTentruyen;
                        Tacgiatheloai += "<h3> " + truyen.sTacgia + "</h3>                         " +
                                         "<h3>" + truyen.sMaTheloai + "</h3>                       ";

                        Html += "<li>                              " +
                           "<div class='soluong' id='sochuongtruyen'>" + n + "</div>                                                 " +
                           "<div class='dv'>Chương</div>                           </li>                                             " +
                           "<li>                             " +
                           "<div class='soluong'>" + truyen.iLuotdoctong + "</div>                             " +
                           "<div class='dv'>Lượt đọc</div>                           </li>                         ";

                        Htmlgioithieu += "<p>" + truyen.sMota + "</p>";

                       


                    }
                }

                

                if (soluongdanhgia != 0)
                {
                    foreach (danhgiatruyen danhgia in Danhgiatruyen)
                    {


                        if (danhgia.iMatruyen == idt)
                        {
                           

                            string widthSaoDanhgia = ((tongdiemdanhgia / 5) * 100).ToString();

                            string phantramdiemdgtong = widthSaoDanhgia.Replace(",", ".");

                            string WidthSaoDGtcnv = ((iTongdiemtcnv / (5*soluongdanhgia)) * 100).ToString();
                            string phantramdgtcnv = WidthSaoDGtcnv.Replace(",", ".");

                            string WidthSaoDGndct = ((iTongdiemndct / (5*soluongdanhgia)) * 100).ToString();
                            string phantramdgndct = WidthSaoDGndct.Replace(",", ".");
                            
                            string WidthSaoDGbctg = ((iTongdiembctg / (5*soluongdanhgia)) * 100).ToString();
                            string phantrandgbctg= WidthSaoDGbctg.Replace(",", ".");



                            //điểm đánh giá của tài khoản
                            string diemdgtcnv = "";


                            string diemdgndct = "";


                            string diemdgbctg = "";
                            if (danhgia.iMaTK == tkhd.iMaTK)
                            {
                                string tcnv = danhgia.iDiemtcnv.ToString();
                                diemdgtcnv = tcnv.Replace(",", ".");

                                string ndct = danhgia.iDiemndct.ToString();
                                diemdgndct = ndct.Replace(",", ".");

                                string bctg = danhgia.iDiembocuctg.ToString();
                                diemdgbctg = bctg.Replace(",", ".");
                            }

                            Htmldiemdanhgia = "<span class='nh-rating'>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     " +
                               "<span class='active' style='width: " + phantramdiemdgtong + "%'>     <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> " +
                               "</span>                   </span>                   " +
                               "<span class='d-inline-block ml-2'>                     " +
                               "<span class='font-weight-semibold'>"+tongdanhgia+"</span>/5</span>                   " +
                               "<span class='d-inline-block text-secondary ml-1'>("+soluongdanhgia+" đánh giá)</span>";

                            Htmldanhgiatruyen = " <form action = 'Thongtintruyen.aspx?iMatruyen=" + idt + "' method='post'>                     " +
                            "<div class='dvdanhgia' style='display: none'>               " +
                            "<div class='nddanhgia'>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Tính cách nhân vật</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgtcnv'  min='0'  max='5'  step='0.5' class='js-range-slider'  value='" + diemdgtcnv + "' name='dtinhcachnv'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>"+diemdgtcnv+"</div>                 </div>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Nội dung cốt truyện</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgndct' min='0' max='5' step='0.5' class='js-range-slider' value='" + diemdgndct + "' name='dndcotruyen'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-2' class='col-1'>"+diemdgndct+"</div>                 " +
                            "</div>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Bố cục thế giới</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgbocuctg' min='0' max='5' step='0.5' class='js-range-slider' value='" + diemdgbctg + "' name='dbocucthegioi'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-3' class='col-1'>"+diemdgbctg+"</div>                 </div>                  " +
                            "<div class='guidanhgia'>                  " +
                            " <button type = 'submit' class='btn-submit'>Gửi</button>                 " +
                            "</div>               </div>            " +
                            " " +
                            "<div class='thongtindanhgia'>                 " +
                            "<div class='tongdanhgia'>                   " +
                            "<div class='col-5'><b>Có "+soluongdanhgia+" lượt đánh giá</b></div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       " +
                            "<i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       " +
                            "<span class='active' style='width: "+phantramdiemdgtong+ "%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>"+tongdanhgia+"</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='kengang'></div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-5'>Điểm tính cách nhân vật</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       " +
                            "<span class='active' style='width: "+phantramdgtcnv+"%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-2'>"+(iTongdiemtcnv/soluongdanhgia)+"</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-5'>Điểm nội dung cốt truyện</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       " +
                            "<span class='active' style='width: "+phantramdgndct+"%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-2'>"+(iTongdiemndct/soluongdanhgia)+"</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-5'>Điểm bố cục thế giới</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       " +
                            "<span class='active' style='width: "+phantrandgbctg+"%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-2'>"+(iTongdiembctg/soluongdanhgia)+"</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>               </div>" +
                            "</div>                 </form>";
                            break;
                        }
                        else
                        {
                            Htmldiemdanhgia = "<span class='nh-rating'>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     " +
                                        "<span class='active' style='width: 0%'> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i>" +
                                        "</span>                   </span>                   " +
                                        "<span class='d-inline-block ml-2'>                     " +
                                        "<span class='font-weight-semibold'>0</span>/5</span>                   " +
                                        "<span class='d-inline-block text-secondary ml-1'>(0 đánh giá)</span>";

                            Htmldanhgiatruyen = " <form action = 'Thongtintruyen.aspx?iMatruyen=" + idt + "' method='post'>                     " +
                            "<div class='dvdanhgia' style='display: none'>               " +
                            "<div class='nddanhgia'>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Tính cách nhân vật</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgtcnv'  min='0'  max='5'  step='0.5' class='js-range-slider'  value='0' name='dtinhcachnv'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>0</div>                 </div>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Nội dung cốt truyện</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgndct' min='0' max='5' step='0.5' class='js-range-slider' value='0' name='dndcotruyen'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-2' class='col-1'>0</div>                 " +
                            "</div>                 " +
                            "<div class='rowdg'>                   " +
                            "<div class='col-3'>Bố cục thế giới</div>                   " +
                            "<div class='col-8'>                     " +
                            "<input type = 'range' id='dgbocuctg' min='0' max='5' step='0.5' class='js-range-slider' value='0' name='dbocucthegioi'/>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-3' class='col-1'>0</div>                 </div>                  " +
                            "<div class='guidanhgia'>                  " +
                            " <button type = 'submit' class='btn-submit'>Gửi</button>                 " +
                            "</div>               </div>            " +
                            " " +
                            "<div class='thongtindanhgia'>                 " +
                            "<div class='tongdanhgia'>                   " +
                            "<div class='col-6'><b>Có 0 lượt đánh giá</b></div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       " +
                            "<i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='kengang'></div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-6'>Điểm tính cách nhân vật</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-6'>Điểm nội dung cốt truyện</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>                 " +
                            "<div class='divdiem'>                   " +
                            "<div class='col-6'>Điểm bố cục thế giới</div>                   " +
                            "<div class='col-5'>                     " +
                            "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                            "</div>                   " +
                            "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                            "<div class='clear'></div>                 " +
                            "</div>               </div>" +
                            "</div>                 </form>";


                        }
                    }
                }
                else
                {
                    Htmldiemdanhgia = "<span class='nh-rating'>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     <i class='far fa-star'></i>                     " +
                                "<span class='active' style='width: 0%'> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i> <i class='fas fa-star'></i>" +
                                "</span>                   </span>                   " +
                                "<span class='d-inline-block ml-2'>                     " +
                                "<span class='font-weight-semibold'>0</span>/5</span>                   " +
                                "<span class='d-inline-block text-secondary ml-1'>(0 đánh giá)</span>";

                    Htmldanhgiatruyen = " <form action = 'Thongtintruyen.aspx?iMatruyen=" + idt + "' method='post'>                     " +
                    "<div class='dvdanhgia' style='display: none'>               " +
                    "<div class='nddanhgia'>                 " +
                    "<div class='rowdg'>                   " +
                    "<div class='col-3'>Tính cách nhân vật</div>                   " +
                    "<div class='col-8'>                     " +
                    "<input type = 'range' id='dgtcnv'  min='0'  max='5'  step='0.5' class='js-range-slider'  value='0' name='dtinhcachnv'/>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-1' class='col-1'>0</div>                 </div>                 " +
                    "<div class='rowdg'>                   " +
                    "<div class='col-3'>Nội dung cốt truyện</div>                   " +
                    "<div class='col-8'>                     " +
                    "<input type = 'range' id='dgndct' min='0' max='5' step='0.5' class='js-range-slider' value='0' name='dndcotruyen'/>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-2' class='col-1'>0</div>                 " +
                    "</div>                 " +
                    "<div class='rowdg'>                   " +
                    "<div class='col-3'>Bố cục thế giới</div>                   " +
                    "<div class='col-8'>                     " +
                    "<input type = 'range' id='dgbocuctg' min='0' max='5' step='0.5' class='js-range-slider' value='0' name='dbocucthegioi'/>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-3' class='col-1'>0</div>                 </div>                  " +
                    "<div class='guidanhgia'>                  " +
                    " <button type = 'submit' class='btn-submit'>Gửi</button>                 " +
                    "</div>               </div>            " +
                    " " +
                    "<div class='thongtindanhgia'>                 " +
                    "<div class='tongdanhgia'>                   " +
                    "<div class='col-6'><b>Có 0 lượt đánh giá</b></div>                   " +
                    "<div class='col-5'>                     " +
                    "<span class='nh-rating'>                       " +
                    "<i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                    "<div class='clear'></div>                 " +
                    "</div>                 " +
                    "<div class='kengang'></div>                 " +
                    "<div class='divdiem'>                   " +
                    "<div class='col-6'>Điểm tính cách nhân vật</div>                   " +
                    "<div class='col-5'>                     " +
                    "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                    "<div class='clear'></div>                 " +
                    "</div>                 " +
                    "<div class='divdiem'>                   " +
                    "<div class='col-6'>Điểm nội dung cốt truyện</div>                   " +
                    "<div class='col-5'>                     " +
                    "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                    "<div class='clear'></div>                 " +
                    "</div>                 " +
                    "<div class='divdiem'>                   " +
                    "<div class='col-6'>Điểm bố cục thế giới</div>                   " +
                    "<div class='col-5'>                     " +
                    "<span class='nh-rating'>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <i class='far fa-star'></i>                       <span class='active' style='width: 0%'>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                         <i class='fas fa-star'></i>                       </span>                     </span>                   " +
                    "</div>                   " +
                    "<div id = 'js-value-1' class='col-1'>0</div>                   " +
                    "<div class='clear'></div>                 " +
                    "</div>               </div>" +
                    "</div>                 </form>";


                }



                anhtruyen.InnerHtml = Htmlanhtuyen;
                tentruyen.InnerHtml = Htmltentruyen;
                tg_tl.InnerHtml = Tacgiatheloai;
                thongtinsoluong.InnerHtml = Html;
                diemdanhgia.InnerHtml = Htmldiemdanhgia;
                gioithieu.InnerHtml = Htmlgioithieu;
                danhgiatruyen.InnerHtml = Htmldanhgiatruyen;




            }
            else
            {
                Response.Redirect("index.aspx");
            }



        }
    }
}
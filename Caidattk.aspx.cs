using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class Caidattk : System.Web.UI.Page
    {
        int idt = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            taikhoan tkhd = (taikhoan)Session["taikhoan"];
            List<taikhoan> TaikhoanLists = (List<taikhoan>)Application["ListTaikhoan"];
            List<truyenyeuthich> ListTruyenyeuthich = (List<truyenyeuthich>)Application["ListTruyenyeuthich"];
            List<truyen> TruyenLists = (List<truyen>)Application["TruyenList"];
            List<Chuongtruyen> ListsChuong = (List<Chuongtruyen>)Application["Chuonglist"];
            List<lichsudoc> Lichsudoc = (List<lichsudoc>)Application["Lichsudoc"];


            string Html = "";
            string gioitinhbm = "";
            string gioitinhnam = "";
            string gioitinhnu = "";

            

            //cập nhật tài khoản
            string tenhienthi = Request.Form["tenhienthi"];
            HttpPostedFile avarta = Request.Files["fileavarta"];
            string linkfile = "";
            string hoten = Request.Form["hoten"];
            string namsinh = Request.Form["namsinh"];
            string gioitinh = Request.Form["gioitinh"];
            string email = Request.Form["email"];
            //cập nhật mật khẩu
            string matkhau = Request.Form["matkhau"];
            string matkhaumoi = Request.Form["matkhaumoi"];


            //thêm truyện
            string tentruyen = Request.Form["tentruyen"];
            string gioithieutruyen = Request.Form["gioithieutruyen"];
            string theloai = Request.Form["theloai"];
            HttpPostedFile anhtruyen = Request.Files["anhbia"];
            string linkanhbia = "";
            string tacgia = "";


            //dstruyen sang tac
            string xuly = Request.Form["xuly"];
            string xoatruyenst = Request.Form["xoatruyenst"];

            //ds chương truyện sáng tác

            
            string idtruyen =   Request.QueryString["IDtruyen"];
            string idtruyen2 = Request.Form["idtruyenst"];

            string xoachuong = Request.Form["xoachuong"];


            //thêm chương truyện


            
            string sc = Request.Form["sochuong"];
            string tenchuong = Request.Form["tieudechuong"];
            string ndchuong = Request.Form["noidungchuong"];

            if (idtruyen != null&& idtruyen!="")
            {
                idt = int.Parse(idtruyen);
            }
            else
            {
                if(idtruyen2 !=null&& idtruyen2 != "")
                {
                    idt = int.Parse(idtruyen2);
                }
               
            }

            //edit truyện

            string trangthaitruyen = Request.Form["trangthai"];
            HttpPostedFile editanhtruyen = Request.Files["anhbiatruyen"];
            string editmota = Request.Form["editgioithieutruyen"];



            //chỉnh sửa chương
            int chuongedit = 0;
            if (Request.Form["chuongedit"] != null)
            {
                chuongedit = int.Parse(Request.Form["chuongedit"]);
            }
            
            string edittenchuong = Request.Form["edittieudechuong"];
            string editndchuong = Request.Form["editnoidungchuong"];
            if (chuongedit != 0)
            {
            }

            foreach (Chuongtruyen chuongt in ListsChuong)
            {
                if (chuongt.iMaTruyen == idt && chuongt.iMaChuong == chuongedit)
                {
                    if (edittenchuong != "" && edittenchuong != null)
                    {
                        chuongt.sTenchuong = edittenchuong;
                    }
                    if (editndchuong != "")
                    {
                        chuongt.sNdchuong = editndchuong;
                    }
                }
            }

            //...
            string xoatruyen = Request.Form["xoatruyen"];

            string xoalichsu = Request.Form["xoals"];

            //xóa lịch sử đọc
            if(xoalichsu!=null&& xoalichsu != "")
            {
                int idtx = int.Parse(xoalichsu);
                for(int i = 0; i < Lichsudoc.Count(); i++)
                {
                    if (idtx == Lichsudoc[i].iMatruyen && tkhd.iMaTK == Lichsudoc[i].iMaTK)
                    {
                        
                        Lichsudoc.RemoveAt(i);
                        i--;
                        
                    }

                }

            }
            List<lichsudoc> listlsdoc = new List<lichsudoc>(Lichsudoc);

            List<lichsudoc> lsd = listlsdoc.GroupBy(p => p.iMatruyen).Select(g => g.First()).ToList();

            //xóa truyện yêu thích
            if (xoatruyen!=null && xoatruyen != "")
            {
                int idtx = int.Parse(xoatruyen);
                for (int i = 0; i < ListTruyenyeuthich.Count; i++)
                {
                    if (idtx == ListTruyenyeuthich[i].iMatruyen && tkhd.iMaTK == ListTruyenyeuthich[i].iMaTK)
                    {

                        ListTruyenyeuthich.RemoveAt(i);
                        
                        break;
                    }


                }
            }

            //xóa truyện sáng tác
            if (xoatruyenst !=null && xoatruyenst !="")
            {
                int idtx = int.Parse(xoatruyenst);
                int xoa = 0;
                for (int i = 0; i < TruyenLists.Count; i++)
                {
                    if (idtx == TruyenLists[i].iMatruyen && tkhd.iMaTK == TruyenLists[i].iMaTK)
                    {

                        TruyenLists.RemoveAt(i);
                        xoa = 1;
                        

                        
                    }
                    if(xoa == 1)
                    {
                        TruyenLists[i].iMatruyen = TruyenLists[i].iMatruyen - 1;
                    }
                    
                }
                for(int a = 0; a< ListsChuong.Count(); a++)
                {
                    if(ListsChuong[a].iMaTruyen== idtx)
                    {
                        ListsChuong.RemoveAt(a);
                        a--;
                    }
                }
            }


            //xóa chương trong truyện
            if(xoachuong !=null && xoachuong != "")
            {
                int idcx = int.Parse(xoachuong);
                int xoa = 0;
                for (int i = 0; i < ListsChuong.Count; i++)
                {
                    if (idcx == ListsChuong[i].iMaChuong && idt== ListsChuong[i].iMaTruyen)
                    {

                        ListsChuong.RemoveAt(i);
                        xoa = 1;



                    }
                    if(i==(ListsChuong.Count))
                    {
                        xoa = 0;
                    }
                    else
                    {
                        if (xoa == 1)
                        {
                            if (idt == ListsChuong[i].iMaTruyen)
                            {

                                ListsChuong[i].iMaChuong = ListsChuong[i].iMaChuong - 1;
                            }

                        }
                    }
                   

                }
            }


            string Chon = Request.QueryString["Chon"];
            string Next = Request.QueryString["Next"];

            int n = 0;
            int m = 0;
            foreach(taikhoan tk in TaikhoanLists)
            {
                if(tk.iMaTK == tkhd.iMaTK)
                {
                    tacgia = tk.sTenhienthi;
                    break;
                }
            }

            

            if(Next == "caidattk")
            {

                cssquanly.InnerHtml += ".caidattintaikhoan{display: block!important;} .navbartk{display: block!important;} #nut2{ background-color:#ccc;}         #nut2 a{color:#fff;}";


                if (Chon == "thongtin")
                {
                    foreach (taikhoan tk in TaikhoanLists)
                    {

                        if (tk.bGioitinh == "Nam")
                        {
                            gioitinhnam = "selected='selected'";
                        }
                        else
                        {
                            if (tk.bGioitinh == "Nữ")
                            {
                                gioitinhnu = "selected='selected'";
                            }
                            else
                            {
                                gioitinhbm = "selected='selected'";
                            }
                        }
                        if (tkhd.iMaTK == tk.iMaTK)
                        {
                            if (tenhienthi != null)
                            {
                                tk.sTenhienthi = tenhienthi;
                            }
                            if (avarta != null && avarta.FileName != "")
                            {
                                linkfile = Server.MapPath("~/assets/img/" + avarta.FileName);
                                tk.uavatar = "./assets/img/" + avarta.FileName;
                                avarta.SaveAs(linkfile);
                            }
                            if (hoten != null)
                            {
                                tk.sTennguoidung = hoten;
                            }
                            if (namsinh != null)
                            {
                                tk.dNgaysinh = namsinh;
                            }
                            if (gioitinh != null)
                            {
                                tk.bGioitinh = gioitinh;
                            }
                            if (email != null)
                            {
                                tk.sEmail = email;
                            }
                            Html += "<form id = 'tttk' action='Caidattk.aspx?Next=caidattk&Chon=thongtin' method='post' enctype='multipart/form-data'>                " +
                                "<div class='khungtttk'>             " +
                                "<table>               " +
                                "<tr>                 " +
                                "<td><label for=''>Tên tài khoản:</label></td>                 " +
                                "<td><h3 style = 'margin-left: 15px' >" + tk.sTaikhoan + "</h3></td>          " +
                                "    " +
                                "</tr>               " +
                                "<tr>                 " +
                                "<td><label for=''>Tên hiển thị:</label></td>                 " +
                                "<td> <input type = 'text' id= 'txttenhienthi' name= 'tenhienthi' class='inputtt'   value='" + tk.sTenhienthi + "'/></td>               " +
                                "</tr>               " +
                                "<tr>                   " +
                                "<td><label for=''>Ảnh đại diện:</label></td>" +
                                "<td>  <input type = 'file' id='fileavarta' accept='image/*' name='fileavarta' class='inputtt'/></td>               " +
                                "</tr>               " +
                                "<tr>                 " +
                                "<td><label for=''>Họ và tên:</label></td>                 " +
                                "<td> <input type = 'text' id='txthoten' name='hoten' class='inputtt' value='" + tk.sTennguoidung + "' /> </td>               " +
                                "</tr>               " +
                                "<tr>                 " +
                                "<td><label for=''>Năm sinh:</label></td>                 " +
                                "<td> <input type = 'date' id='txtnamsinh'  name='namsinh' class='inputtt'  value='" + tk.dNgaysinh + "'/> </td>               " +
                                "</tr>               " +
                                "<tr> <td><label for=''>Giới tính:</label></td>                 " +
                                "<td> " +
                                "<select name = 'gioitinh' id='gioitinh' class='inputtt'>                     " +
                                "<option value = 'Bí Mật' " + gioitinhbm + "> Bí Mật</option>                     " +
                                "<option value = 'Nam' " + gioitinhnam + " > Nam </ option >                     " +
                                "<option value='Nữ' " + gioitinhnu + ">Nữ</option>                   " +
                                "</select>                 " +
                                "</td>               " +
                                "</tr>               " +
                                "<tr>                 " +
                                "<td><label for=''>Email:</label></td>                 " +
                                "<td> <input type = 'text' id='txtemail' name='email'  class='inputtt' value='" + tk.sEmail + "'  />  </td>  " +
                                "</tr>               " +
                                "<tr> <td colspan = '2' > <input type='submit' id='btncapnhat' class='btncntt' value='Cập nhật'/></td> " +
                                "</tr>             " +
                                "</table>           " +
                                "</div>            " +
                                "</form>";
                        }
                    }
                    khungcaidat.InnerHtml = Html;
                    cssquanly.InnerHtml += ".btnthongtin {border-bottom: 1px solid #ccc; }";


                }
                else
                {
                    cssquanly.InnerHtml += ".khungbaomat{display: block!important;} .btnbaomat {border-bottom: 1px solid #ccc;}";
                    foreach (taikhoan tk in TaikhoanLists)
                    {
                        if (tkhd.iMaTK == tk.iMaTK)
                        {
                            if (matkhau != null || matkhaumoi != null)
                            {
                                if (matkhau != tk.sMatkhau)
                                {
                                    msgmatkhau.InnerText = "Mật khẩu không đúng vui lòng nhập lại!";
                                    msgmatkhaumoi.InnerText = "";
                                    msgmatkhaumoi2.InnerText = "";
                                }
                                else
                                {
                                    tk.sMatkhau = matkhaumoi;
                                    msgthongbao.InnerText = "Đổi mật khẩu thành công!";
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                            if (Next == "truyenyeuthich")
               {
                   cssquanly.InnerHtml += ".truyenyeuthich{display: block!important;} #nut3{ background-color:#ccc;}         #nut3 a{color:#fff;}";


                   foreach (truyenyeuthich truyenyt in ListTruyenyeuthich)
                   {
                       if (tkhd.iMaTK == truyenyt.iMaTK)
                       {
                           foreach (Chuongtruyen chuong in ListsChuong)
                           {
                               if (truyenyt.iMatruyen == chuong.iMaTruyen)
                               {
                                   n = (from n2 in ListsChuong where n2.iMaTruyen == truyenyt.iMatruyen select n2).Count();


                                   break;
                               }
                               else
                               {
                                   n = 0;
                               }

                           }
                           foreach (truyen truyen in TruyenLists)
                           {


                               if (truyenyt.iMatruyen == truyen.iMatruyen)
                               {


                                   Html += "<li>                 " +
                                    "<div class='thongtintruyenyt'>                   " +
                                    "<img src = '" + truyen.uAnh + "' class='imgtyt' alt='' />                   " +
                                    "<div class='thongt'> <a href = '#' ><h3>" + truyen.sTentruyen + "</h3></a> <p>số chương: " + n + "</p></div>                   " +
                                    "<button class='btnxoa' type='submit' name='xoatruyen' value='" + truyenyt.iMatruyen + "'><i class='far fa-trash-alt'></i></button>                 " +
                                    "</div>               </li>";


                               }


                           }

                       }
                   }
                   dstruyenyt.InnerHtml = Html;
               }
               else
               {
                   if (Next == "lichsudoc")
                   {
                       cssquanly.InnerHtml += ".lichsudoc{display: block!important;} #nut4{ background-color:#ccc;}         #nut4 a{color:#fff;}";


                       foreach (lichsudoc ls in lsd)
                       {
                           if (tkhd.iMaTK == ls.iMaTK)
                           {


                               foreach (Chuongtruyen chuong in ListsChuong)
                               {
                                   if (ls.iMatruyen == chuong.iMaTruyen)
                                   {
                                       n = (from n2 in ListsChuong where n2.iMaTruyen == ls.iMatruyen select n2).Count();
                                       m = (from n2 in Lichsudoc where n2.iMatruyen == chuong.iMaTruyen select n2).Count();

                                       break;
                                   }


                               }

                               foreach (truyen truyen in TruyenLists)
                               {


                                   if (ls.iMatruyen == truyen.iMatruyen)
                                   {

                                       Html += "<li>                 " +
                                        "<div class='thongtintruyenyt'>                   " +
                                        "<img src = '" + truyen.uAnh + "' class='imgtyt' alt=''/> " +
                                        "<div class='thongt'> " +
                                        "<a href = '#' ><h3> " + truyen.sTentruyen + "</h3></a>                     " +
                                        "<p>Đã đọc " + m + "/" + n + "</p>                   " +
                                        "</div>                   " +
                                        "<button class='btnxoa' type='submit' name='xoals' value='" + ls.iMatruyen + "'><i class='far fa-trash-alt'></i></button>                 " +
                                        "</div>               </li>";



                                   }



                               }

                           }
                       }
                       lichsudoct.InnerHtml = Html;
                   }
                   else
                   {
                       if (Next == "themmoitruyen")
                       {
                           cssquanly.InnerHtml += ".themmoitruyen{display: block!important;} #nut5{ background-color:#fff;}    #nut6 a{color:#fff;}     #nut5 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";
                           if (tentruyen == "" || gioithieutruyen == "" || theloai == "" || anhtruyen == null)
                           {

                           }
                           else
                           {
                               if(anhtruyen.FileName.Trim() != "")
                                {
                                    linkanhbia = Server.MapPath("~/assets/img/" + anhtruyen.FileName);
                                    anhtruyen.SaveAs(linkanhbia);
                                    TruyenLists.Add(new truyen() { iMaTK = tkhd.iMaTK, iMatruyen = TruyenLists.Count() + 1, sTentruyen = tentruyen, sTacgia = tacgia, sMota = gioithieutruyen, bTrangthai = 1, uAnh = "./assets/img/" + anhtruyen.FileName, sMaTheloai = theloai, dNgaydang = DateTime.Now.ToString(), fdiemdanhgiatong = 0, iLuotdoctong = 0, iLuotthichtong = 0 });
                                }
                                else
                                {
                                    TruyenLists.Add(new truyen() { iMaTK = tkhd.iMaTK, iMatruyen = TruyenLists.Count() + 1, sTentruyen = tentruyen, sTacgia = tacgia, sMota = gioithieutruyen, bTrangthai = 1, uAnh = "./assets/img/no_img.png", sMaTheloai = theloai, dNgaydang = DateTime.Now.ToString(), fdiemdanhgiatong = 0, iLuotdoctong = 0, iLuotthichtong = 0 });

                                }
                            }
                       }
                       else
                       {
                           if (Next == "dstruyenst")
                           {
                               cssquanly.InnerHtml += ".dstruyencuatoi{display: block!important;} #nut6{ background-color:#fff;}    #nut5 a{color:#fff;}     #nut6 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";

                               foreach (truyen truyen in TruyenLists)
                               {
                                   if (truyen.iMaTK == tkhd.iMaTK)
                                   {
                                       string trangthai = "";
                                       if (truyen.bTrangthai == 0)
                                       {
                                           trangthai = "Hoàn thành";
                                       }
                                       else
                                       {
                                           trangthai = "Đang ra";
                                       }


                                       Html += "<tr>                   " +
                                       "<td><a href = '#' >" + truyen.sTentruyen + "</a></td>                   " +
                                       "<td>" + truyen.dNgaydang + "</td>                   " +
                                       "<td>" + trangthai + "</td>                   " +
                                       "<td>" +
                                       "<button class='btn-dstruyen btnthemchuong' type='button' onclick=\"window.location.href='Caidattk.aspx?Next=edittruyen&IDtruyen=" + truyen.iMatruyen + "'\" >                       " +
                                       "<i class='far fa-edit'></i>                       " +
                                       "<div class='texttb'>Chỉnh sửa</div>" +
                                       "</button>" +
                                       "<button class='btn-dstruyen btnthemchuong' type='button' onclick=\"window.location.href='Caidattk.aspx?Next=themchuong&IDtruyen=" + truyen.iMatruyen + "'\">                       " +
                                       "<i class='fas fa-plus'></i>                       " +
                                       "<div class='texttb'>Thêm chương</div>" +
                                       "</button>" +
                                       "<button class='btn-dstruyen btndschuong' type='button' onclick=\"window.location.href='Caidattk.aspx?Next=dschuongst&IDtruyen=" + truyen.iMatruyen + "'\">                       " +
                                       "<i class='fas fa-list'></i>                       " +
                                       "<div class='texttb'>Danh sách chương</div></button>" +
                                       "<button class='btn-dstruyen btnxoatruyen' type='submit' value='" + truyen.iMatruyen + "' name='xoatruyenst'>                      " +
                                       "<i class='far fa-trash-alt'></i><div class='texttb'>Xóa truyện</div>                     " +
                                       "</button>                   " +
                                       "</td>                 " +
                                       "</tr>";




                                   }
                               }

                               dstruyen.InnerHtml = Html;
                           }
                           else
                           {
                               if (Next == "dschuongst")
                               {
                                   cssquanly.InnerHtml += ".dschuongtruyen{display: block!important;} #nut6{ background-color:#fff;}    #nut5 a{color:#fff;}     #nut6 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";

                                   foreach (truyen truyen in TruyenLists)
                                   {
                                       if (truyen.iMatruyen == idt)
                                       {
                                           tentruyenst.InnerHtml = truyen.sTentruyen + " <input  type='text' name='idtruyenst' value='" + idt + "' style='display: none'/>";
                                           break;
                                       }
                                   }


                                   foreach (Chuongtruyen chuong in ListsChuong)
                                   {
                                       if (chuong.iMaTruyen == idt)
                                       {
                                           Html += " <tr>                   " +
                                       "<td><a href = '#' > Chương " + chuong.iMaChuong + ": " + chuong.sTenchuong + "</a></td>                   " +
                                       "<td>" + chuong.dNgaydang + "</td>                   " +
                                       "<td>" + chuong.iLuotdocchuong + "</td>                   " +
                                       "<td>                     " +
                                       "<button class='btnedit btn-dstruyen' type='button' onclick=\"window.location.href='Caidattk.aspx?Next=editchuong&IDtruyen=" + idt + "'\">                       " +
                                       "<i class='far fa-edit'></i>                       " +
                                       "<div class='texttb'>Chỉnh sửa</div></button>" +

                                       "<button class='btnxoachuong btn-dstruyen' type='submit' value='" + chuong.iMaChuong + "' name='xoachuong'>                       " +
                                       "<i class='far fa-trash-alt'></i>                       " +
                                       "<div class='texttb'>Xóa chương</div>                     " +
                                       "</button>                   </td>                 </tr>";
                                       }
                                   }





                                   dschuongtruyenst.InnerHtml = Html;


                               }
                               else
                               {
                                   if (Next == "themchuong")
                                   {
                                       cssquanly.InnerHtml += ".themchuongmoi{display: block!important;} #nut6{ background-color:#fff;}    #nut5 a{color:#fff;}     #nut6 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";

                                       foreach (truyen truyen in TruyenLists)
                                       {
                                           if (truyen.iMatruyen == idt)
                                           {
                                               tentruyenthemchuong.InnerHtml = truyen.sTentruyen + " <input  type='text' name='idtruyenst' value='" + idt + "' style='display: none'/>";
                                               break;
                                           }
                                       }
                                       int sochuong = (from n2 in ListsChuong where n2.iMaTruyen == idt select n2).Count();
                                       sttchuong.InnerText = (sochuong + 1).ToString();


                                       int idc = 0;

                                       int check = 0;

                                       if (sc != null && sc != "")
                                       {
                                           idc = int.Parse(sc);
                                       }


                                       foreach (Chuongtruyen chuong in ListsChuong)
                                       {
                                           if (chuong.iMaTruyen == idt)
                                           {
                                               if (idc == chuong.iMaChuong)
                                               {
                                                   thongbao.InnerHtml = "Số chương đã tồn tại!";
                                                   check = 0;
                                                   break;
                                               }
                                               else
                                               {
                                                   check = 1;
                                               }
                                            }
                                            else
                                            {
                                                check = 1;
                                            }
                                       }
                                       if (check == 1)
                                       {
                                           if (tenchuong != null && ndchuong != null && idc != 0 && tenchuong != "" && ndchuong != "")
                                           {
                                               ListsChuong.Add(new Chuongtruyen() { iMaChuong = idc, iMaTruyen = idt, sTenchuong = tenchuong, sNdchuong = ndchuong, dNgaydang = DateTime.Now.ToString(), iLuotdocchuong = 0 });
                                               Response.Redirect("Caidattk.aspx?Next=dschuongst&IDtruyen=" + idt + "");
                                           }

                                       }
                                   }
                                   else
                                   {
                                       if (Next == "edittruyen")
                                       {
                                           cssquanly.InnerHtml += ".edittruyen{display: block!important;} #nut6{ background-color:#fff;}    #nut5 a{color:#fff;}     #nut6 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";

                                           string a1 = "";
                                           string a2 = "";
                                           string a3 = "";
                                           string a4 = "";
                                           string a5 = "";
                                           string a6 = "";
                                           string a7 = "";
                                           string a8 = "";
                                           string a9 = "";
                                           string a10 = "";
                                           string a11 = "";
                                           string a12 = "";
                                           string a13 = "";
                                           string a14 = "";
                                           string a15 = "";
                                           string a16 = "";
                                           string a17 = "";
                                           string a0 = "selected='selected'";

                                           string trangthai0 = "";
                                           string trangthai1 = "";
                                           foreach (truyen truyen in TruyenLists)
                                           {
                                               if (truyen.iMatruyen == idt)
                                               {
                                                   if (tentruyen != "" && tentruyen != null)
                                                   {
                                                       truyen.sTentruyen = tentruyen;
                                                   }
                                                   if (editmota != "" && editmota != null)
                                                   {
                                                       truyen.sMota = editmota;

                                                   }
                                                   if (theloai != "" && theloai != null)
                                                   {
                                                       truyen.sMaTheloai = theloai;

                                                   }
                                                   if (editanhtruyen != null && editanhtruyen.ContentLength != 0)
                                                   {
                                                       truyen.uAnh = "./assets/img/" + editanhtruyen.FileName;
                                                       linkanhbia = Server.MapPath("~/assets/img/" + editanhtruyen.FileName);
                                                       editanhtruyen.SaveAs(linkanhbia);
                                                   }
                                                   if (trangthaitruyen != "" && trangthaitruyen != null)
                                                   {
                                                       truyen.bTrangthai = int.Parse(trangthaitruyen);
                                                   }


                                                   if (truyen.sMaTheloai == "Kỳ Ảo")
                                                   {
                                                       a1 = a0;
                                                   }
                                                   else
                                                   {
                                                       if (truyen.sMaTheloai == "Tiên Hiệp")
                                                       {
                                                           a2 = a0;
                                                       }
                                                       else
                                                       {
                                                           if (truyen.sMaTheloai == "Huyền Huyễn")
                                                           {
                                                               a3 = a0;
                                                           }
                                                           else
                                                           {
                                                               if (truyen.sMaTheloai == "Khoa Huyễn")
                                                               {
                                                                   a4 = a0;
                                                               }
                                                               {
                                                                   if (truyen.sMaTheloai == "Võng Du")
                                                                   {
                                                                       a5 = a0;
                                                                   }
                                                                   else
                                                                   {
                                                                       if (truyen.sMaTheloai == "Đô Thị")
                                                                       {
                                                                           a6 = a0;
                                                                       }
                                                                       else
                                                                       {
                                                                           if (truyen.sMaTheloai == "Đồng Nhân")
                                                                           {
                                                                               a7 = a0;
                                                                           }
                                                                           else
                                                                           {
                                                                               if (truyen.sMaTheloai == "Dã Sử")
                                                                               {
                                                                                   a8 = a0;
                                                                               }
                                                                               else
                                                                               {
                                                                                   if (truyen.sMaTheloai == "Cạnh Kỹ")
                                                                                   {
                                                                                       a9 = a0;
                                                                                   }
                                                                                   else
                                                                                   {
                                                                                       if (truyen.sMaTheloai == "Huyền Nghi")
                                                                                       {
                                                                                           a10 = a0;
                                                                                       }
                                                                                       else
                                                                                       {
                                                                                           if (truyen.sMaTheloai == "Kiếm Hiệp")
                                                                                           {
                                                                                               a11 = a0;
                                                                                           }
                                                                                           else
                                                                                           {
                                                                                               if (truyen.sMaTheloai == "Ngôn Tình")
                                                                                               {
                                                                                                   a12 = a0;
                                                                                               }
                                                                                               else
                                                                                               {
                                                                                                   if (truyen.sMaTheloai == "Linh Dị")
                                                                                                   {
                                                                                                       a13 = a0;
                                                                                                   }
                                                                                                   else
                                                                                                   {
                                                                                                       if (truyen.sMaTheloai == "Hệ Thống")
                                                                                                       {
                                                                                                           a14 = a0;
                                                                                                       }
                                                                                                       else
                                                                                                       {
                                                                                                           if (truyen.sMaTheloai == "Cổ Đại")
                                                                                                           {
                                                                                                               a15 = a0;
                                                                                                           }
                                                                                                           else
                                                                                                           {
                                                                                                               if (truyen.sMaTheloai == "Trinh Thám")
                                                                                                               {
                                                                                                                   a16 = a0;
                                                                                                               }
                                                                                                               else
                                                                                                               {
                                                                                                                   a17 = a0;
                                                                                                               }
                                                                                                           }
                                                                                                       }
                                                                                                   }
                                                                                               }
                                                                                           }
                                                                                       }
                                                                                   }
                                                                               }
                                                                           }
                                                                       }
                                                                   }
                                                               }
                                                           }
                                                       }
                                                   }

                                                   if (truyen.bTrangthai == 1)
                                                   {
                                                       trangthai1 = a0;
                                                   }
                                                   else
                                                   {
                                                       trangthai0 = a0;
                                                   }




                                                   Html = "<form id = 'suatruyen' action='Caidattk.aspx?Next=edittruyen' method='post' enctype='multipart/form-data'>         " +
                                                       "<div class='themmoitruyen col-10 bd-l'>           " +
                                                       "<div class='hthemmoi'>             " +
                                                       "<input  type='text' name='idtruyenst' value='" + idt + "' style='display: none'/>" +
                                                       "<h2>Tận hưởng sáng tác</h2>             " +
                                                       "<p>Hãy bắt đầu sáng tạo thế giới riêng của bạn</p>                       " +
                                                       "</div>           " +
                                                       "<div class='bodytruyenmoi'> <img src = '" + truyen.uAnh + "' alt='' style='margin: 0 auto; display: block;  width: 150px;  height: 200px;'/>             " +
                                                       "<p>Tên truyện:</p>             " +
                                                       "<input type = 'text' id='tentruyenst' name='tentruyen' class='boder-r' value='" + truyen.sTentruyen + "'/>   " +

                                                       "<p>Giới thiệu truyện:</p>             " +
                                                       "<textarea form='suatruyen' name = 'editgioithieutruyen' id='gioithieutruyenst' cols='30'   rows='50' class='boder-r'>" + truyen.sMota + "</textarea>             " +
                                                       "<p>Thể loại</p>             " +
                                                       "<select class='theloai-select boder-r' id='theloaitruyen' name='theloai'>   " +
                                                       "<option value = 'Kỳ Ảo' " + a1 + "> Kỳ Ảo</option>               " +
                                                       "<option value = 'Tiên Hiệp' " + a2 + "> Tiên Hiệp</option>               " +
                                                       "<option value = 'Huyền Huyễn' " + a3 + "> Huyền Huyễn</option>               " +
                                                       "<option value = 'Khoa Huyễn' " + a4 + "> Khoa Huyễn</option>               " +
                                                       "<option value = 'Võng Du' " + a5 + "> Võng Du</option>               " +
                                                       "<option value = 'Đô Thị' " + a6 + "> Đô Thị</option>               " +
                                                       "<option value = 'Đồng Nhân' " + a7 + "> Đồng Nhân</option>               " +
                                                       "<option value = 'Dã Sử' " + a8 + "> Dã Sử</option>               " +
                                                       "<option value = 'Cạnh Kỹ' " + a9 + "> Cạnh Kỹ</option>               " +
                                                       "<option value = 'Huyền Nghi' " + a10 + "> Huyền Nghi</option>               " +
                                                       "<option value = 'Kiếm Hiệp' " + a11 + "> Kiếm Hiệp</option>               " +
                                                       "<option value = 'Ngôn Tình' " + a12 + "> Ngôn Tình</option>               " +
                                                       "<option value = 'Linh Dị' " + a13 + "> Linh Dị</option>               " +
                                                       "<option value = 'Hệ Thống' " + a14 + "> Hệ Thống</option>               " +
                                                       "<option value = 'Cổ Đại' " + a15 + "> Cổ Đại</option>               " +
                                                       "<option value = 'Trinh Thám' " + a16 + "> Trinh Thám</option>               " +
                                                       "<option value = 'Quân Sự' " + a17 + "> Quân Sự</option>             " +
                                                       "</select>             " +
                                                       "<p>Đổi ảnh bìa:</p>             " +
                                                       "<input type = 'file' name='anhbiatruyen' id='anhbiatruyen' placeholder='vui lòng chọn ảnh bìa' class='boder-r' accept='image/*'/>             " +
                                                       "<p>Trạng thái:</p>             " +
                                                       "<select class='theloai-select boder-r' id='txttrangthai' name='trangthai'>               " +
                                                       "<option value = '0' " + trangthai0 + "> Hoàn thành</option>               " +
                                                       "<option value = '1' " + trangthai1 + "> Đang ra</option>             " +
                                                       "</select>              " +
                                                       "<button id = 'btndangtruyen' type='submit' class='btndang'>Cập nhật</button>           " +
                                                       "</div>         </div>       </form>";
                                               }
                                           }

                                           edittruyen.InnerHtml = Html;
                                       }
                                       else
                                       {
                                           if (Next == "editchuong")
                                           {
                                               cssquanly.InnerHtml += ".editchuong{display: block!important;} #nut6{ background-color:#fff;}    #nut5 a{color:#fff;}     #nut6 a{color:#000;} .qltruyn {display: block;} .thanhmenu .menugoc,.qltruyn li {background-color: #ccc;} .thanhmenu .menugoc a{color:#fff;}";

                                               string tentruyenedit = "";
                                               foreach (truyen truyen in TruyenLists)
                                               {
                                                   if (idt == truyen.iMatruyen)
                                                   {
                                                       tentruyenedit = truyen.sTentruyen;
                                                   }
                                               }
                                               foreach (Chuongtruyen chuong in ListsChuong)
                                               {

                                                   if (chuong.iMaTruyen == idt)
                                                   {
                                                       Html = "<form id = 'themchuongmoi' action='Caidattk.aspx?Next=dschuongst&IDtruyen=" + chuong.iMaTruyen + "' method='post'>           " +
                                                       "<div class='editchuong col-10 bd-l' style='display: block'>             " +
                                                       "<div class='hthemmoi'>               " +
                                                       "<h2>Sửa chương:</h2>               " +
                                                       "<br />               " +
                                                       "<h3 id = 'tentruyeneditchuong' runat='server'>Chương" + chuong.iMaChuong + ": " + chuong.sTenchuong + " - " + tentruyenedit + "</h3>               " +
                                                       "<br/>             " +
                                                       "</div>             " +
                                                       "<div class='ndthemmoi'>               " +
                                                       "<p>Tiêu đề chương:</p>               " +
                                                       "<input type = 'text' class='boder-r' id='edittieudechuong' name='edittieudechuong' value='" + chuong.sTenchuong + "'/>                " +
                                                       "<p>Nội dung chương:</p>               " +
                                                       "<textarea name = 'editnoidungchuong' id='editndchuong' cols='30' rows='10' class='boder-r textnd'>" + chuong.sNdchuong + "</textarea>               " +
                                                       "<button id = 'btncapnhatc' type='submit' class='btndang' value='" + chuong.iMaChuong + "' name='chuongedit'>Cập nhật</button>             " +
                                                       "</div>           </div>         </form>";
                                                   }
                                               }

                                               editchuong.InnerHtml = Html;
                                           }
                                       }
                                   }
                               }
                           }
                       }
                   }
               }


        }



        }
    }
}
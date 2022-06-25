using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<taikhoan> TaikhoanLists = (List<taikhoan>)Application["ListTaikhoan"];

            List<taikhoandangnhapsai> Taikhoandangnhapsai = (List<taikhoandangnhapsai>)Application["Taikhoandangnhapsai"];

            taikhoan tkhd = (taikhoan)Session["taikhoan"];

            


            string taikhoan = Request.Form["taikhoan"];
            string matkhau = Request.Form["matkhau"];
            int dem = 0;

           
            
           

            


            string msgthongbao = "Tài khoản hoặc mật khẩu không chính xác!";

            int sotaikhoandnsai = 0;

            

                Boolean check = true;
            if (taikhoan != null && matkhau != null)
            {
                if (TaikhoanLists != null)
                {
                    foreach (taikhoan tk in TaikhoanLists)
                    {
                        if (taikhoan == tk.sTaikhoan)
                        {
                            sotaikhoandnsai = Taikhoandangnhapsai.Count();
                            for (int i = 0; i < Taikhoandangnhapsai.Count(); i++)
                            {
                                DateTime DateTimeNow = DateTime.Now;

                                DateTime timedns5lan = Convert.ToDateTime(Taikhoandangnhapsai[i].dThoigianbatdaukhoa);

                                // Khoảng thời gian từ lúc đăng nhập sai 5 lần tới hiện tại.
                                TimeSpan time = DateTimeNow.Subtract(timedns5lan);
                                if (Taikhoandangnhapsai[i].iMaTK == tk.iMaTK)
                                {
                                    if (time.Minutes > 4)
                                    {
                                        Taikhoandangnhapsai.RemoveAt(i);
                                    }
                                }
                            }

                            if (matkhau == tk.sMatkhau)
                            {
                                string idclient = ID;
                                tkhd.iMaTK = tk.iMaTK;
                                tkhd.sTaikhoan = taikhoan;
                                tkhd.sMatkhau = matkhau;
                                tkhd.sTenhienthi = tk.sTenhienthi;

                                Session["login"] = 1;

                                
                                check = false;
                                
                                
                            }
                            else
                            {
                                check = true;
                                int themtkdns = 0;
                                
                                if (sotaikhoandnsai != 0)
                                {
                                    foreach(taikhoandangnhapsai tkdns in Taikhoandangnhapsai)
                                    {
                                        if (tkdns.iMaTK == tk.iMaTK)
                                        {
                                            if (tkdns.solansai < 5)
                                            {
                                                tkdns.solansai += 1;
                                                tkdns.dThoigianbatdaukhoa = DateTime.Now.ToString();
                                            }
                                            

                                        }
                                        else
                                        {
                                            themtkdns = 1;
                                        }
                                    }
                                    if (themtkdns == 1)
                                    {
                                        Taikhoandangnhapsai.Add(new taikhoandangnhapsai() { iMaTK = tk.iMaTK, solansai = 1, dThoigianbatdaukhoa = DateTime.Now.ToString() });

                                    }
                                }
                                else
                                {
                                    Taikhoandangnhapsai.Add(new taikhoandangnhapsai() { iMaTK = tk.iMaTK,solansai=1,dThoigianbatdaukhoa=DateTime.Now.ToString() });
                                }
                            }

                            if (sotaikhoandnsai != 0)
                            {
                                foreach (taikhoandangnhapsai tkdns in Taikhoandangnhapsai)
                                {
                                    if (tkdns.iMaTK == tk.iMaTK)
                                    {
                                        if (tkdns.solansai > 4)
                                        {
                                            check = true;
                                            msgthongbao = "Tài khoản này đã bị khóa trong vòng 15p";
                                        }
                                    }
                                }
                            }
                        }
                        

                    }
                }

                if (check)
                {
                    thongbao.InnerHtml = msgthongbao;
                    

                }
                else
                {
                    Response.Redirect("index.aspx");
                   
                }
            }
        }
    }
}
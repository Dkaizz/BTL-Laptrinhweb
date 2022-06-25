using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class Dangky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string taikhoandk = Request.Form["txttaikhoandk"];
            string matkhaudk = Request.Form["txtmatkhaudk"];
            string emaildk = Request.Form["txtEmail"];

            List<taikhoan> TaikhoanLists =  (List<taikhoan>)Application["ListTaikhoan"];
            taikhoan tkhd = (taikhoan)Session["taikhoan"];
            Boolean check = false;
            if(taikhoandk!=null && matkhaudk!=null && emaildk != null)
            {
                if (TaikhoanLists.Count() > 0)
                {
                    foreach (taikhoan tk in TaikhoanLists)
                    {
                        if (tk.sTaikhoan == taikhoandk)
                        {

                            msgtaikhoan.InnerHtml = "Tài khoản đã tồn tại";
                            check = false;
                            break;
                        }
                        else
                        {
                            check = true;
                        }

                    }
                }
                else
                {
                    check = true;
                }
                

                
                
            }
            int stttk = TaikhoanLists.Count;
            Random rnd = new Random();
            int random = rnd.Next(1, 999999999);

            if (check)
            {
                TaikhoanLists.Add(new taikhoan(stttk + 1, taikhoandk, matkhaudk, emaildk, "account" + stttk.ToString()+random.ToString(),"", DateTime.Now.ToString(), "./assets/img/avata0.jpg"));
                thongbao.InnerHtml = "Đã Đăng ký thành công!";
            }
        }
    }
}
using Btl_LTW.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Btl_LTW
{
    public partial class header_footer_home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            taikhoan tkhd = (taikhoan)Session["taikhoan"];
            string Html = "";
            if(int.Parse(Session["login"].ToString()) ==1)
            {
                Html += "<ul class='ulnavbar'>                 " +
                    "<li>                   " +
                    "<a> <i class='fas fa-user-circle'></i> "+tkhd.sTenhienthi+"</a>                   " +
                    "<ul class='subnav subnav2'>                     " +
                    "<li><a href = 'thongtintaikhoan.aspx' > Thông tin tài khoản</a></li>                     " +
                    "<li><a href = 'Caidattk.aspx?Next=caidattk&Chon=thongtin' > Cài đặt tài khoản</a></li>                     " +
                    "<li><a href = 'Caidattk.aspx?Next=truyenyeuthich' > Tủ truyện</a></li>                     " +
                    "<li><a href = 'index.aspx?Yeucau=dangxuat' > Đăng xuất</a></li>                   " +
                    "</ul>                 </li>                 " +
                    "</ul>";
            }
            else
            {
                Html += "<ul class='ulnavbar'>                 " +
                    "<li>                   " +
                    "<a href='Dangnhap.aspx' id = 'js-dangnhap' type='button' class='btntk dpnone'>Đăng nhập</a></li>" +
                    "<li><a href='Dangky.aspx' id = 'js-dangky' type= 'button' class='btntk dpnone'>Đăng ký</a></li></ul>";
            }

            btnlogin.InnerHtml = Html;

        }
    }
}
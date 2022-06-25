<%@ Page Title="" Language="C#" MasterPageFile="~/header-footer-home.Master" AutoEventWireup="true" CodeBehind="timkiem.aspx.cs" Inherits="Btl_LTW.timkiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="./assets/css/timkiem.css" />
    <style id="csstimkiem" runat="server">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="sx" runat="server" style="display: inline-block;">
    <div class="main_container">
        <!-- container -->
        <div class="container">
            
              
            <div class="cactheloai col-3">
            <h3>Thể loại</h3>
            <div class="ndtheloai">
              <ul>
                <li><a href="timkiem.aspx?Theloai=Tiên Hiệp">Tiên hiệp</a></li>
                <li><a href="timkiem.aspx?Theloai=Huyền Huyễn">Huyền huyễn</a></li>
                <li><a href="timkiem.aspx?Theloai=Đô Thị">Đô Thị</a></li>
                <li><a href="timkiem.aspx?Theloai=Trinh Thám">Trinh thám</a></li>
                <li><a href="timkiem.aspx?Theloai=Linh Dị">Linh Dị</a></li>
                <li><a href="timkiem.aspx?Theloai=Hệ Thống">Hệ Thống</a></li>
                <li><a href="timkiem.aspx?Theloai=Quân Sự">Quân sự</a></li>
                <li><a href="timkiem.aspx?Theloai=Cổ Đại">Cổ Đại</a></li>
                <li><a href="timkiem.aspx?Theloai=Ngôn Tình">Ngôn Tình</a></li>
                <li><a href="timkiem.aspx?Theloai=Võng Du">Võng Du</a></li>
                <li><a href="timkiem.aspx?">Tất cả</a></li>
              </ul>
            </div>
                
          </div>
          <div class="ndtimkiem col-9">
            <div class="navtimkiem" style="display:none">
              <ul>
                <li><a  id="capnhat">Cập nhật</a></li>
                <li><a  id="luotdoc">Lượt đọc</a></li>
                <li><a  id="luotdanhgia">lượt đánh giá</a></li>
                <li><a  id="luotthich">Lượt thích</a></li>
              </ul>
            </div>
              
            <div class="ketquatimkiem" >
              <span id="thongtintimkiem" runat="server"
                ></span>
              <div class="sxdstruyen">
                  
                      <div class="chonloaitimkiem">
                  <span>Sắp xếp theo theo: </span>
                     <ul class="menuchon">
                         <li> <p id="btnmochonsx">Chọn</p>
                             <ul class="sub_menuchon">
                                 <li><button id="sxcapnhat" runat="server" onserverclick="sapxeptheocapnhat_Click">Cập nhật</button></li>
                                 <li><button id="sxluotdoc" runat="server" onserverclick="sapxeptheoluotdoc_Click">Lượt đọc</button></li>
                                 <li><button id="sxluotthich" runat="server" onserverclick="sapxeptheoluotthich_Click">Lượt thích</button></li>
                             </ul>
                         </li>
                     </ul>


                      
              </div>
                      <div>
                          <button id="btnsapxep" type="button" runat="server">Giảm dần</button>
                      <div id="iconsx" runat="server" style="display: inline-block;"></div>
                      </div>
                
                      
                  
                
              </div>
              <!-- nội dung tìm kiếm -->
              <div class="btvdc">
                <div class="btvdc_body grid" id="kqtimkiem" runat="server">
                  
                </div>
              </div>
            </div>
          </div>
          <div style="clear: both"></div>
          
        </div>

        <!-- end container -->
      </div>
</form>
          
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
     <script>
    const sxtangdan = document.querySelector(".sx-icon1");
    const sxgiamdan = document.querySelector(".sx-icon2");
         var sx = document.getElementById("btnsapxep");
         var dem = 0;
         var btnmochonsx = document.getElementById('btnmochonsx');
         var sub_menuchon = document.querySelector(".sub_menuchon");
         btnmochonsx.onclick = function () {
             dem++;
             if (dem % 2 == 0) {
                 sub_menuchon.style.display = "none";
             } else {
                 sub_menuchon.style.display = "block";

             }
         }
     </script>
</asp:Content>




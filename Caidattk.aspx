<%@ Page Title="" Language="C#" MasterPageFile="~/header-footer-home.Master" AutoEventWireup="true" CodeBehind="Caidattk.aspx.cs" Inherits="Btl_LTW.Caidattk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./assets/css/quanly.css" />
    <title>Quản lý</title>
    <style id="cssquanly" runat="server">
        .slider{
            display:none
                
        }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- begin main_container -->
      <div class="bodyquanly bg-light">
        <div class="nut"><i class="fas fa-angle-right"></i></div>
        <div class="thanhmenu col-2">
          <ul>
            <li class="nutmenu" id="nut1">
              <a href="thongtintaikhoan.aspx"><i class="far fa-user"></i> Thông tin tài khoản</a>
            </li>
            <li class="nutmenu" id="nut2">
              <a href="Caidattk.aspx?Next=caidattk&Chon=thongtin"><i class="fas fa-user-cog"></i> Cài đăt thông tin</a>
            </li>
            <li class="nutmenu" id="nut3">
              <a href="Caidattk.aspx?Next=truyenyeuthich"><i class="far fa-thumbs-up"></i> Truyện yêu thích</a>
            </li>
            <li class="nutmenu" id="nut4">
              <a href="Caidattk.aspx?Next=lichsudoc"><i class="fas fa-history"></i> Lịch sử truyện</a>
            </li>
            <li class="nutmenu menugoc">
              <a href="#"><i class="fas fa-book"></i> Quản lý truyện</a>
              <ul class="qltruyn">
                <li class="nutmenu" id="nut5">
                  <a href="Caidattk.aspx?Next=themmoitruyen"
                    ><i class="fas fa-folder-plus"></i> Thêm truyện mới</a
                  >
                </li>
                <li class="nutmenu" id="nut6">
                  <a href="Caidattk.aspx?Next=dstruyenst"><i class="fas fa-th-list"></i> Truyện của tôi</a>
                </li>
              </ul>
            </li>
          </ul>
        </div>
        
        <div class="caidattintaikhoan col-10 bd-l" style="display:none">
          <div class="navbartk" style="display:none">
            <ul>
              <li><a href="Caidattk.aspx?Next=caidattk&Chon=thongtin" class="btnthongtin">Thông tin</a></li>
              <li><a href="Caidattk.aspx?Next=caidattk&Chon=baomat" class="btnbaomat">Bảo mật</a></li>
            </ul>
          </div>
           <div id="khungcaidat" runat="server"></div>
          <form id = "baomat" action="Caidattk.aspx?Next=caidattk&Chon=baomat" onsubmit="return ckeck()" method="post" >
              <div class="khungbaomat" style="display:none">
            <table>
              <tr>
                <td><label for="">Mật khẩu hiện tại:</label></td>
                <td>
                  <input
                    type="password"
                    id="txtmatkhau"
                    name="matkhau"
                    class="inputtt"
                  />
                </td>
                  <td>
                  <p id="msgmatkhau" runat="server" ClientIDMode="Static"></p>

                  </td>
                  
              </tr>
              <tr>
                <td><label for="">Mật khẩu mới:</label></td>
                <td>
                  <input
                    type="password"
                    id="txtmatkhaumoi"
                    name="matkhaumoi"
                    class="inputtt"
                  />
                </td>
                  <td>
                  <p id="msgmatkhaumoi" runat="server" ClientIDMode="Static"></p>

                  </td>
              </tr>

              <tr>
                <td><label for="">Xác nhận mật khẩu mới:</label></td>
                <td>
                  <input
                    type="password"
                    id="txtmatkhaumoi2"
                    name="matkhaumoi2"
                    class="inputtt"
                  />
                </td>
                  <td>
                  <p id="msgmatkhaumoi2" runat="server" ClientIDMode="Static"></p>

                  </td>
              </tr>
                <tr>
                    <td colspan="2">
                  <p id="msgthongbao" runat="server" ClientIDMode="Static"></p>

                  </td>
                </tr>
              <tr>
                  
                <td colspan="2">
                    
                  <input
                    type="submit"
                    id="btncapnhat"
                    class="btncntt"
                    value="Cập nhật"
                      
                  />
                </td>
              </tr>
            </table>
          </div>
          </form>
            
          
        </div>
          <form id="truyenyeuthich" action="Caidattk.aspx?Next=truyenyeuthich" method="post">
                <div class="truyenyeuthich col-10 bd-l" style="display: none">
          <div class="htruyenyt">
            <h2>Danh sách truyện yêu thích</h2>
          </div>
          <div class="dstruyenyt">
            <ul id="dstruyenyt" runat="server">
              
             
            </ul>
          </div>
        </div>
            </form>

          <form id="lichsudoc" action="Caidattk.aspx?Next=lichsudoc" method="post">
              <div class="lichsudoc col-10 bd-l" style="display: none">
          <div class="htruyenyt">
            <h2>Lịch sử đọc truyện</h2>
          </div>
          <div class="dstruyenyt">
            <ul id="lichsudoct" runat="server">
              
              
            </ul>
          </div>
        </div>
          </form>

          <form id="themmoitruyen" action="Caidattk.aspx?Next=themmoitruyen" method="post" enctype='multipart/form-data'>
              <div class="themmoitruyen col-10 bd-l" style="display: none">
          <div class="hthemmoi">
            <h2>Thêm mới truyện</h2>
            <p>Hãy bắt đầu sáng tạo thế giới riêng của bạn</p>
          </div>
          <div class="bodytruyenmoi">
            <p>Tên truyện:</p>
            <input
              type="text"
              id="txttentruyen"
              name="tentruyen"
              class="boder-r"
            />
            <p>Giới thiệu truyện:</p>
            <textarea
              name="gioithieutruyen"
              id="txtgioithieutruyen"
              cols="30"
              rows="50"
              class="boder-r"

            ></textarea>
            <p>Thể loại</p>
            <select class="theloai-select boder-r" id="txttheloai" name="theloai">
              <option value="Kỳ Ảo">Kỳ Ảo</option>
              <option value="Tiên Hiệp">Tiên Hiệp</option>
              <option value="Huyền Huyễn">Huyền Huyễn</option>
              <option value="Khoa Huyễn">Khoa Huyễn</option>
              <option value="Võng Du">Võng Du</option>
              <option value="Đô Thị">Đô Thị</option>
              <option value="Đồng Nhân">Đồng Nhân</option>
              <option value="Dã Sử">Dã Sử</option>
              <option value="Cạnh Kỹ">Cạnh Kỹ</option>
              <option value="Huyền Nghi">Huyền Nghi</option>
              <option value="Kiếm Hiệp">Kiếm Hiệp</option>
              <option value="Ngôn Tình">Ngôn Tình</option>
              <option value="Linh Dị">Linh Dị</option>
              <option value="Hệ Thống">Hệ Thống</option>
              <option value="Cổ Đại">Cổ Đại</option>
              <option value="Trinh Thám">Trinh Thám</option>
              <option value="Quân Sự">Quân Sự</option>

              

            </select>
            <p>ảnh bìa:</p>
            <input
              type="file"
              name="anhbia"
              id="txtanhbia"
              placeholder="vui lòng chọn ảnh bìa"
              class="boder-r"
              accept='image/*'
                
            />

            <button id="btndangt" type="submit" class="btndang">Đăng truyện</button>
          </div>
        </div>
          </form>

          <form id="dstruyenst" action="Caidattk.aspx?Next=dstruyenst" method="post">
              <div class="dstruyencuatoi col-10 bd-l" style="display: none">
          <div class="hthemmoi">
            <h2>Danh sách truyện bạn sáng tác</h2>
            <br />
            <p>Hãy bắt đầu sáng tạo thế giới riêng của bạn</p>
            <br />
          </div>
          <div class="ndds">
            <table>
              <thead>
                <tr>
                  <th>Tên truyện</th>
                  <th>Ngày đăng</th>
                  <th>Trạng thái</th>
                  <th>Xử lý</th>
                </tr>
              </thead>
              <tbody class="dstruyenst" id="dstruyen" runat="server">
                
              
              </tbody>
            </table>
          </div>
        </div>
          </form>

          <form id="dschuongst" action="Caidattk.aspx?Next=dschuongst" method="post">
              <div class="dschuongtruyen col-10 bd-l" style="display: none">
          <div class="hthemmoi">
              <p><b id="tentruyenst" runat="server"></b></p>
            <br/>
            <h2>Danh sách chương:</h2>
            
            
          </div>
          <div class="ndds">
            <table>
              <thead>
                <tr>
                  <th>Tên Chương</th>
                  <th>Ngày đăng</th>
                    <th>Lượt đọc</th>
                  <th>Xử lý</th>
                </tr>
              </thead>
              <tbody class="dstruyenst" id="dschuongtruyenst" runat="server">
                
                
              </tbody>
            </table>
          </div>
        </div>
          </form>

          <form id="themchuongmoi" action="Caidattk.aspx?Next=themchuong" method="post">
              <div class="themchuongmoi col-10 bd-l" style="display: none">
          <div class="hthemmoi">
            <h2 id="tentruyenthemchuong" runat="server"></h2>
            <br/>
          </div>
          <div class="ndthemmoi">
              <p id="sttchuong" runat="server" ClientIDMode="Static" style="display:none"></p>
            <p>Số chương: <span id="thongbao" runat="server" class="red"></span></p>
            <input
              type="number"
              class="boder-r"
              id="txtsochuong"
              name="sochuong"
                
                
            />


            <p>Tiêu đề chương:</p>
            <input
              type="text"
              class="boder-r"
              id="txttieudechuong"
              name="tieudechuong"
            />

            <p>Nội dung chương:</p>
            <textarea
              name="noidungchuong"
              id="txtndchuong"
              cols="30"
              rows="10"
              class="boder-r textnd"
            ></textarea>
            <button id="btndangc" type="submit" class="btndang">Đăng truyện</button>
          </div>
        </div>
            </form>
          
        <div class="edittruyen" id="edittruyen" runat="server" style="display:none">
            
        </div>

        <div class="editchuong" id="editchuong" runat="server" style="display:none">

</div>


          
        
        <div class="clear" style="clear: both"></div>
      </div>
      <!-- end main_container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
    <script>
        var check = true;
        var sttchuong = document.getElementById('sttchuong');
        if (document.getElementById('txtsochuong').value.trim().length == 0) {
        document.getElementById('txtsochuong').value = sttchuong.innerText;

        }
        
        function ckeck() {
            var matkhau = document.getElementById('txtmatkhau');
            var matkhaumoi = document.getElementById('txtmatkhaumoi');
            var matkhaumoi2 = document.getElementById('txtmatkhaumoi2');
            var msgmk = document.getElementById('msgmatkhau');
            var msgmkm = document.getElementById('msgmatkhaumoi');
            var msgmkm2 = document.getElementById('msgmatkhaumoi2');

            var thongbao = document.getElementById('msgthongbao');


            if (matkhau.value.trim().length==0) {
                msgmk.innerText = "Bạn chưa nhập mật khẩu!"
                msgmkm.innerText = "";
                msgmkm2.innerText = "";
                matkhau.focus();
                return false;
            }
            else {
                if (matkhaumoi.value.trim().length == 0) {
                    msgmkm.innerText = "Bạn chưa nhập mật khẩu mới!";
                    msgmk.innerText = "";
                    msgmkm2.innerText = "";
                    matkhaumoi.focus();
                    return false;
                } else {
                    if (matkhaumoi2.value.trim().length == 0) {
                        msgmkm2.innerText = "Bạn chưa nhập lại mật khẩu mới"
                        msgmk.innerText = "";
                        msgmkm.innerText = "";
                        matkhaumoi2.focus();
                        return false;
                    } else {
                        
                            if (matkhaumoi.value.length<8) {
                                msgmkm.innerText = "Mật khẩu mới phải lớn hơn 8 kí tự!";
                                msgmk.innerText = "";
                                msgmkm2.innerText = "";
                                matkhaumoi.focus();
                                return false;
                            } else {
                                
                                    if (matkhaumoi.value != matkhaumoi2.value) {
                                        msgmk.innerText = "";
                                        msgmkm.innerText = "";
                                        msgmkm2.innerText = "Mật khẩu mới nhập lại chưa đúng!"
                                        matkhaumoi2.focus();
                                        return false;
                                    }
                                    else {

                                        msgmk.innerText = "";
                                        msgmkm.innerText = "";
                                        msgmkm2.innerText = "";
                                        return confirm('Bạn chắc chắn muốn đổi mật khẩu');

                                    }
                            }
                        
                        
                    }
                }
            }
        }

            

          
        
        
        /*
         
         
         */

        
        
    </script>
    
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="Btl_LTW.Dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link rel="stylesheet" href="./assets/css/dangnhap.css" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"
    />
</head>
<body>
    <div class="modal js-modal">
      <div class="modal-container js-modalContainer">
        <div class="model-header">
            <a href="index.aspx" class="home" ><img  src="assets/img/ic_appbar_back.png" style=" width: 24px;position: absolute;left: 15px;"/></a>
            <div class="vehome" style="position: absolute;left: 15px;top:30px">Về Home</div>
            <h1 class="dangnhap">Đăng Nhập</h1>
            <h3 class="dangnhap red" id="thongbao" runat="server"> </h3>
        </div>
          <form action="Dangnhap.aspx" method="post" onsubmit="return check();">
              <div class="model-login">
            <div class="modal-body">
              <label for="txttaikhoandn" class="modal-label">
                <i class="far fa-user"></i> Tài khoản
              </label>
              <input
                type="text"
                class="modal-input"
                id="txttaikhoandn"
                name="taikhoan"
                placeholder="Tài khoản"
              />
                <p id="msgtaikhoan"></p>


              <label for="txtmatkhoandn" class="modal-label">
                <i class="fas fa-key"></i> Mật khẩu
              </label>
              <input
                type="password"
                class="modal-input"
                id="txtmatkhaudn"
                name="matkhau"
                placeholder="Mật khẩu"
                
              />
                <p id="msgmatkhau"></p>


              <button id="btn-dangnhap" class="buy-ticks" type="submit" name="sotruongdangtexxt"> 
                Đăng nhập <i class="ti-check"></i>
              </button>
            </div>
          </div>
          </form>
        
        <div class="modal-footer js-modal-footer">
          <p class="modal-text js-modal-text">
            Bạn chưa có tài khoản?
            <a href="Dangky.aspx" class="js-adangky">Đăng ký ngay</a>
          </p>
        </div>
      </div>
    </div>
</body>
    
    <script>
        let ktra = true;
        var msgtaikhoan = document.getElementById('msgtaikhoan');
        var msgmatkhau = document.getElementById('msgmatkhau');
        var taikhoan = document.getElementById('txttaikhoandn');
        var matkhau = document.getElementById('txtmatkhaudn');

        console.log(taikhoan.type);
        function check() {
            var taikhoan = document.getElementById('txttaikhoandn');
            var matkhau = document.getElementById('txtmatkhaudn');

            console.log(taikhoan.type);
            /*if (taikhoan.value.trim().length == 0) {
                msgtaikhoan.innerHTML = "Tài khoản còn trống!";
                taikhoan.focus();
                ktra = false;
            }
            else {
                msgtaikhoan.innerHTML = "";
                if (matkhau.value.trim().length == 0) {
                    msgmatkhau.innerHTML = "Mật khẩu còn trống!";
                    matkhau.focus();
                    ktra = false;
                }
                else {
                    msgmatkhau.innerHTML = "";
                    ktra = true;
                }
            }*/
            
            return ktra;
        }
    </script>
</html>

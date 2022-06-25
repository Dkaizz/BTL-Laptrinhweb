<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangky.aspx.cs" Inherits="Btl_LTW.Dangky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
          <h1 class="dangnhap">Đăng Ký</h1>
            <h3 class="dangnhap red" id="thongbao" runat="server"> </h3>
        </div>
        <form action="Dangky.aspx" id="dangky" method="post" onsubmit="return check()">
          <div class="model-Register">
            <div class="modal-body">
              <label for="txttaikhoandk" class="modal-label">
                <i class="far fa-user"></i> Tài khoản 
              </label>
                
              <input
                type="text"
                class="modal-input"
                id="txttaikhoandk"
                placeholder="Tài khoản"
                name="txttaikhoandk"
                  <%--onkeyup="taikhoanChanged()"--%>
              />
                <p id="msgtaikhoan" runat="server" ClientIDMode="Static"></p>


              <label for="txtEmail" class="modal-label">
                <i class="fas fa-at"></i> Email 
              </label>
                
              <input
                type="email"
                class="modal-input"
                id="txtEmail"
                placeholder="Email"
                name="txtEmail"
              />
                <p id="msgmail" ></p>
              <label for="txtpassworddk" class="modal-label">
                <i class="fas fa-key"></i> Mật khẩu 
              </label>
                
              <input
                type="password"
                class="modal-input"
                id="txtpassworddk"
                placeholder="Mật khẩu"
                name="txtmatkhaudk"
                  <%--onkeyup="passwordChanged()"--%>
              />
                
                <p id="msgmatkhau" ></p>
              
              <label for="txtpassworddk2" class="modal-label">
                <i class="fas fa-key"></i> Nhập mật khẩu
              </label>
              <input
                type="password"
                class="modal-input"
                id="txtpassworddk2"
                placeholder="Mật khẩu"
              />
                <p id="msgmatkhau2"></p>

                <div class="khungbtlshow"><input type="checkbox" class="showBtn" id="btnShow" /> <span class="txtshowbtn">Hiện mật khẩu</span></div>
              <button id="btn-dangky" class="buy-ticks" type="submit"> 
                Đăng Ký <i class="ti-check"></i>
              </button>
            </div>
          </div>
        </form>
        <div class="modal-footer js-modal-footer">
          <p class="modal-text js-modal-text">
            Bạn đã có tài khoản?
            <a href="Dangnhap.aspx" class="js-adangky">Đăng nhập ngay</a>
          </p>
        </div>
      </div>
    </div>
</body>
    <script>
        let ktra = true;
        var msgtaikhoan = document.getElementById('msgtaikhoan');
        var msgmail = document.getElementById('msgmail');
        var msgmatkhau = document.getElementById('msgmatkhau');
        var regSĐT = /^(0[1-9][0-9]{8}|1[89]00[0-9]{4})$/;
        let regEmail = /^[A-Za-z][\w$.]+@[\w]+\.\w+$/;

        document.getElementById('btnShow').onclick = function () {
            if (this.checked) {
                document.getElementById("txtpassworddk").type = "text";
                document.getElementById("txtpassworddk2").type = "text";
            } else {
                document.getElementById("txtpassworddk").type = "password";
                document.getElementById("txtpassworddk2").type = "password";
            }
        }

        function taikhoanChanged() {
            var taikhoan = document.getElementById('txttaikhoandk');

            if (taikhoan.value.trim().length == 0) {

                msgtaikhoan.innerText = "Không thể để trống tài khoản";
                return false;
            } else {
                msgtaikhoan.innerText = "";
                return true;
            }
        }

        function passwordChanged() {

            var strongRegex = new RegExp("^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
            var mediumRegex = new RegExp("^(?=.{8,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*\\W)(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[a-z])(?=.*\\W))|((?=.*[A-Z])(?=.*\\W))).*$", "g");
            var enoughRegex = new RegExp("(?=.{8,}).*", "g");
            var pwd = document.getElementById("txtpassworddk");
            var pwd2 = document.getElementById("txtpassworddk2");
            var msgmatkhau2 = document.getElementById("msgmatkhau2");
            if (pwd.value.trim().length == 0) {
                msgmatkhau.innerHTML = 'Nhập mật khẩu!';
                return false;
            }
            else {
                if (false == enoughRegex.test(pwd.value)) {
                    msgmatkhau.innerHTML = 'Mật khẩu phải ít nhất có 8 ký tự';
                    return false;
                } else
                {
                    if (strongRegex.test(pwd.value)) {
                        msgmatkhau.innerHTML = '<span style="color:green">Mạnh!</span>';

                        if (pwd2.value.trim().length == 0) {
                            msgmatkhau2.innerHTML = 'Nhập mật khẩu!';
                            return false;
                        } else {
                            if (pwd.value != pwd2.value) {
                                msgmatkhau2.innerHTML = 'Nhập mật khẩu nhập lại không đúng!';
                                return false;
                            } else {
                                msgmatkhau2.innerHTML = '';
                                return true;
                            }
                        }
                    } else {
                        if (mediumRegex.test(pwd.value)) {
                            msgmatkhau.innerHTML = '<span style="color:orange">Mật khẩu ở mức trung bình, chỉ nhận mật khẩu mạnh!</span>';
                            return false;
                        } else {
                            msgmatkhau.innerHTML = '<span style="color:red">Mật khẩu ở mức yếu, chỉ nhận mật khẩu mạnh!</span>';
                            return false;
                        }
                    }
                }
            }
        }
        function check() {
            
            var email = document.getElementById('txtEmail');
            var acong = email.value.indexOf('@');
            var dodai = email.value.length - 1;
            var daucham = email.value.lastIndexOf('.');
            var daucach = email.value.indexOf(' ');

            if (taikhoanChanged() != true) {
                ktra = false;
            } else {
                if ((dodai <= 5) || (acong < 1) || (daucham <= acong + 1) || (daucach != -1)) {
                    msgmail.innerText = "Email không thể để trống!";
                    ktra = false;

                } else {
                    msgmail.innerText = "";
                    ktra = true;
                    if (passwordChanged() == true) {
                        ktra = true;
                    } else {
                        ktra = false;
                    }
                }
            }
            

            

            //if (email.value.trim().length == 0) {
                
            //    msgmail.innerText = "Email không thể để trống!";
            //    ktra = false;
            //} else {
            //    if (regEmail.test(email)) {
            //        msgmail.innerText = "";
            //        ktra = true;
            //    } else {
            //        ktra = false;
                    
            //        msgmail.innerText="Email không hợp lệ"
            //    }
            //}
            

            //if (matkhau.value.trim().length == 0 || matkhau.value.trim().length <8) {
            //    matkhau.focus();
            //    msgmatkhau.innerHTML = '<span style="color:red">Mật khẩu phải ít nhất có 8 ký tự!</span>';
            //    ktra = false;
            //}
            //else {
                
            //}
            
            
            return ktra;
        }

        
    </script>
</html>

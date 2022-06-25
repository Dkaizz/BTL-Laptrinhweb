<%@ Page Title="" Language="C#" MasterPageFile="~/header-footer-home.Master" AutoEventWireup="true" CodeBehind="Thongtintruyen.aspx.cs" Inherits="Btl_LTW.Thongtintruyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin truyện</title>
    <link rel="stylesheet" href="./assets/css/thongtintruyen.css" />
    <style id="thongtintruyencss" runat="server">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="main_container">
        
        <!-- container -->
        <div class="container">

          <div class="ttTruyen">
            <div class="imgtruyen" id="anhtruyen" runat="server">
              
            </div>
            <div class="gioithieutruyen">
              <h2 id="tentruyen" runat="server"></h2>
              <div class="tacgia" id="tg_tl" runat="server">
                
              </div>
              <div class="thongtin">
                <ul class="txtthongtin" id="thongtinsoluong" runat="server">
                  
                </ul>
                <div class="divdanhgia" id="diemdanhgia" runat="server">
                  
                </div>
                  

                <form id="formluutruyen" runat="server">
                    <ul class="btltttruyen">
                  <li id="btndoc" runat="server" ClientIDMode="Static"></li>
                    
                  <li id="btnluutruyen"><button id="btnDanhdau" runat="server" type="button" onserverclick="Danhdau_Click">Lưu Truyện</button></li>
                </ul>
                </form>

                  
                
                      
                  
              </div>
            </div>
              <div class="clear"></div>
              
          </div>

            
            
          <div class="navtruyen">
            <a id="gioithieuT" class="btnT">Giới thiệu</a>
            <a id="danhgiaT"  class="btnT">Đánh giá</a>
            <a id="dschuong"  class="btnT">D.s.chương</a>
          </div>
          <div class="bodyttTruyen">
              <div class="dvgioithieu" id="gioithieu" runat="server" style="white-space: pre-wrap">
             
            </div>

            <div id="danhgiatruyen" runat="server">
                
            </div>

            <div class="dvdschuong" style="display: none">
              <div>
            <div class="hdschuong">
                <h2>Danh sách chương</h2>
                
              </div>
              <div class="dschuong" id="dschuongtruyen" runat="server">
                  
               
              </div>
        </div>
            </div>

        </div>
    </div>
    </div>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
    <script>
        var btnGioithieutruyen = document.getElementById("gioithieuT");
        var btndgTruyen = document.getElementById("danhgiaT");
        var btnDschuong = document.getElementById("dschuong");

        var btndoctruyen = document.getElementById('adoctruyen');

        btndoctruyen.onclick = function () {
            var sct = document.getElementById('sochuongtruyen');
            if (parseInt(sct.innerText) == 0) {
                btndoctruyen.href = "";
                alert('Truyện chưa có chương nên ko thể đọc')
            }
        }

        var btnsx = document.getElementById("sxds");

        var dgtcnv = document.getElementById("dgtcnv");
        var dgndct = document.getElementById("dgndct");
        var dgbocuctg = document.getElementById("dgbocuctg");
        var dtcnv = document.getElementById("js-value-1");
        var dndct = document.getElementById("js-value-2");
        var dbocuctg = document.getElementById("js-value-3");

        dgtcnv.oninput = function () {
            dtcnv.innerHTML = dgtcnv.value;
        };

        dgndct.oninput = function () {
            dndct.innerHTML = dgndct.value;
        };

        dgbocuctg.oninput = function () {
            dbocuctg.innerHTML = dgbocuctg.value;
        };

        const dvgioithieu = document.querySelector(".dvgioithieu");
        const dvdanhgia = document.querySelector(".dvdanhgia");
        const dvdschuong = document.querySelector(".dvdschuong");

        const sxtangdan = document.querySelector(".sx-icon1");
        const sxgiamdan = document.querySelector(".sx-icon2");
        btnGioithieutruyen.addEventListener("click", function () {
            dvgioithieu.style.display = "block";
            dvdanhgia.style.display = "none";
            dvdschuong.style.display = "none";
            btnGioithieutruyen.style.color = "#a6b3b3";
            btndgTruyen.style.color = "#000";
            btnDschuong.style.color = "#000";
            btnGioithieutruyen.style.borderBottom = "3px solid #a6b3b3";
            btndgTruyen.style.borderBottom = "0";
            btnDschuong.style.borderBottom = "0";
        });

        btndgTruyen.addEventListener("click", function () {
            dvgioithieu.style.display = "none";
            dvdanhgia.style.display = "block";
            dvdschuong.style.display = "none";
            btndgTruyen.style.color = "#a6b3b3";
            btnGioithieutruyen.style.color = "#000";
            btnDschuong.style.color = "#000";
            btnGioithieutruyen.style.borderBottom = "0";
            btndgTruyen.style.borderBottom = "3px solid #a6b3b3";
            btnDschuong.style.borderBottom = "0";
        });

        btnDschuong.addEventListener("click", function () {
            dvgioithieu.style.display = "none";
            dvdanhgia.style.display = "none";
            dvdschuong.style.display = "block";
            btndgTruyen.style.color = "#000";
            btnGioithieutruyen.style.color = "#000";
            btnDschuong.style.color = "#a6b3b3";
            btnGioithieutruyen.style.borderBottom = "0";
            btndgTruyen.style.borderBottom = "0";
            btnDschuong.style.borderBottom = "3px solid #a6b3b3";
        });

        
    </script>
</asp:Content>

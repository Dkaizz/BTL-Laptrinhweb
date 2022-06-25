<%@ Page Title="" Language="C#" MasterPageFile="~/header-footer-home.Master" AutoEventWireup="true" CodeBehind="doctruyen.aspx.cs" Inherits="Btl_LTW.doctruyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đọc truyện</title>
    <link rel="stylesheet" href="./assets/css/doctruyen.css" />

    <style>
        .slider{
            display:none
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="truyen">
        <div class="menutruyen">
          <ul>
            <li id="dschuong">
              <button href="#" id="btndschuong" type="button">
                <i class="fas fa-bars"></i>
              </button>
              <div class="dvdschuong" style="display: none">
                <div class="menu-item-close js-close-dsc">
                  <i class="fas fa-times"></i>
                </div>
                <div class="nddschuong">
                  <div class="hdschuong">
                    <h2>Danh sách chương</h2>
                    <div class="sxdschuong">
                      <i class="fas fa-sort-amount-up-alt sx-icon1"></i>
                      <i
                        class="fas fa-sort-amount-up sx-icon2"
                        style="display: none"
                      ></i>
                    </div>
                  </div>
                  <div class="dschuong" id="dschuongtruyen" runat="server">
                    
                  
                  </div>
                </div>
              </div>
            </li>
            <li id="setting">
              <button href="#" id="btnsetting" type="button">
                <i class="fas fa-cog"></i>
              </button>
              <div class="setting">
                <div class="menu-item-close js-close-setting">
                  <i class="fas fa-times"></i>
                </div>
                <table>
                  <tr>
                    <td><i class="fas fa-palette"></i> Màu nền</td>
                    <td>
                      <ul>
                        <li><a href="#" class="item1 item"></a></li>
                        <li><a href="#" class="item2 item"></a></li>
                        <li><a href="#" class="item3 item"></a></li>
                        <li><a href="#" class="item4 item"></a></li>
                      </ul>
                    </td>
                  </tr>

                  <tr>
                    <td><i class="fas fa-font"></i> Font chữ</td>
                    <td>
                      <select id="js-font-chu" class="custom-select">
                        <option value="'Palatino Linotype', sans-serif">
                          Palatino Linotype
                        </option>
                        <option value="'Source Sans Pro', sans-serif">
                          Source Sans Pro
                        </option>
                        <option value="'Segoe UI', sans-serif">Segoe UI</option>
                        <option value="Roboto, sans-serif">Roboto</option>
                        <option value="'Patrick Hand', sans-serif">
                          Patrick Hand
                        </option>
                        <option value="'Noticia Text', sans-serif">
                          Noticia Text
                        </option>
                        <option value="'Times New Roman', sans-serif">
                          Times New Roman
                        </option>
                        <option value="Verdana, sans-serif">Verdana</option>
                        <option value="Tahoma, sans-serif">Tahoma</option>
                        <option value="Arial, sans-serif">Arial</option>
                      </select>
                    </td>
                  </tr>
                  <tr>
                    <td><i class="fas fa-text-height"></i> Cỡ chữ</td>
                    <td>
                      <div
                        data-unit="px"
                        data-type="font-size"
                        data-max="30"
                        data-min="14"
                        data-step="1"
                        class="setting-font-size"
                      >
                        <button class="btn btngiam col-3" type="button">
                          <i class="fas fa-minus-circle"></i>
                        </button>
                        <div class="font-size col-6">26px</div>
                        <button class="btn btntang col-3" type="button">
                          <i class="fas fa-plus-circle"></i>
                        </button>
                        <div class="clear" style="clear: both"></div>
                      </div>
                    </td>
                  </tr>
                </table>
              </div>
            </li>
            <li>
              <a id="vethongtintruyen" runat="server"><i class="fas fa-arrow-left"></i></a>
            </li>
            <li>
              <a href="index.aspx" id="vehome"><i class="fas fa-home"></i></a>
            </li>
          </ul>
        </div>
        <div class="ndtruyen" id="ndtruyen" runat="server" style="white-space:pre-wrap">
          
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
    <script>
    // Chống copy
    function killCopy(e) {
      return false;
    }
    function reEnable() {
      return true;
    }
    document.onselectstart = new Function("return false");
    if (window.sidebar) {
      document.onmousedown = killCopy;
      document.onclick = reEnable;
    }

    // window.onload = function () {
    //   document.addEventListener(
    //     "contextmenu",
    //     function (e) {
    //       e.preventDefault();
    //     },
    //     false
    //   );
    //   document.addEventListener(
    //     "keydown",
    //     function (e) {
    //       //document.onkeydown = function(e) {
    //       // "I" key
    //       if (e.ctrlKey && e.shiftKey && e.keyCode == 73) {
    //         disabledEvent(e);
    //       }
    //       // "J" key
    //       if (e.ctrlKey && e.shiftKey && e.keyCode == 74) {
    //         disabledEvent(e);
    //       }
    //       // "S" key + macOS
    //       if (
    //         e.keyCode == 83 &&
    //         (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey)
    //       ) {
    //         disabledEvent(e);
    //       }
    //       // "U" key
    //       if (e.ctrlKey && e.keyCode == 85) {
    //         disabledEvent(e);
    //       }
    //       // "F12" key
    //       if (event.keyCode == 123) {
    //         disabledEvent(e);
    //       }
    //     },
    //     false
    //   );

    //   function disabledEvent(e) {
    //     if (e.stopPropagation) {
    //       e.stopPropagation();
    //     } else if (window.event) {
    //       window.event.cancelBubble = true;
    //     }
    //     e.preventDefault();
    //     return false;
    //   }
    // };
    // chống copy

    var header = document.getElementById("header");
    var btndschuong = document.getElementById("btndschuong");
    var btnsetting = document.getElementById("btnsetting");
    var fontchu = document.getElementById("js-font-chu");

    var sochutrongchuong = document.getElementById("sochu");

    const bodytruyen = document.querySelector(".truyen");
    const ndtruyen = document.querySelector(".ndtruyen");
    const tenchuong = document.querySelector(".tenchuong");
    const thongtinchuong = document.querySelector(".thongtinchuong");

    const menutruyen = document.querySelector(".menutruyen");
    const dvdschuong = document.querySelector(".dvdschuong");
    const setting = document.querySelector(".setting");
    const btngiam = document.querySelector(".btngiam");
    const btntang = document.querySelector(".btntang");

    const ndchuong = document.querySelector(".ndchuong");
    const fontsize = document.querySelector(".font-size");

    var size = parseInt(fontsize.innerHTML);

    var chuoichu = ndchuong.innerText;
    var sochu = 0;
    var arrchu = chuoichu.split(" ");
    for (var i = 0; i < arrchu.length; i++) {
      if (arrchu[i].trim() != 0) {
        sochu++;
      }
    }

    sochutrongchuong.innerHTML =
      '<i class="fas fa-book-open icontt"></i>' + sochu + " chữ";

    const closedsc = document.querySelector(".js-close-dsc");
    const closesetting = document.querySelector(".js-close-setting");

    const sxtangdan = document.querySelector(".sx-icon1");
    const sxgiamdan = document.querySelector(".sx-icon2");

    const main = document.querySelector(".main");

    // mở ds chương
    btndschuong.onclick = function () {
      dvdschuong.style.display = "block";
      setting.style.display = "none";
    };

    // đóng ds chương

    closedsc.onclick = function () {
      dvdschuong.style.display = "none";
    };

    // mở setting

    btnsetting.onclick = function () {
      setting.style.display = "block";
      dvdschuong.style.display = "none";
    };

    // đóng setting

    closesetting.onclick = function () {
      setting.style.display = "none";
    };

    // tăng fontsize

    btntang.onclick = function () {
      if (size < 50) {
        size++;
        ndchuong.style.fontSize = size + "px";
        fontsize.innerHTML = size + "px";
      }
    };

    // giảm fontsize

    btngiam.onclick = function () {
      if (size > 10) {
        size--;
        ndchuong.style.fontSize = size + "px";
        fontsize.innerHTML = size + "px";
      }
    };

    // đổi font chữ


    

    fontchu.onchange = function () {
      ndchuong.style.fontFamily = fontchu.value;
    };

    // đổi background đọc truyện

    const item1 = document.querySelector(".item1");
    const item2 = document.querySelector(".item2");
    const item3 = document.querySelector(".item3");
    const item4 = document.querySelector(".item4");

    item1.onclick = function () {
      header.style.backgroundColor = "#ebcaca";
      bodytruyen.style.backgroundColor = "rgb(155, 155, 155)";
      ndtruyen.style.backgroundColor = "#f5e4e4";
      menutruyen.style.backgroundColor = "#f5e4e4";

      ndchuong.style.color = null;
      tenchuong.style.color = null;
      thongtinchuong.style.color = null;
      document.getElementById("tentruyen").style.color = null;
    };

    item2.onclick = function () {
      header.style.backgroundColor = "#eae9c9";
      bodytruyen.style.backgroundColor = "#eae0c3";
      ndtruyen.style.backgroundColor = "#eae9c9";
      menutruyen.style.backgroundColor = "#eae9c9";

      ndchuong.style.color = null;
      tenchuong.style.color = null;
      thongtinchuong.style.color = null;
      document.getElementById("tentruyen").style.color = null;
    };

    item3.onclick = function () {
      header.style.backgroundColor = null;
      bodytruyen.style.backgroundColor = "#111";
      ndtruyen.style.backgroundColor = "#222222";
      menutruyen.style.backgroundColor = null;

      ndchuong.style.color = "#ccc";
      tenchuong.style.color = "#ccc";
      thongtinchuong.style.color = "#ccc";
      document.getElementById("tentruyen").style.color = "#ccc";
    };

    item4.onclick = function () {
      header.style.backgroundColor = null;
      bodytruyen.style.backgroundColor = null;
      ndtruyen.style.backgroundColor = null;
      menutruyen.style.backgroundColor = null;

      ndchuong.style.color = null;
      tenchuong.style.color = null;
      thongtinchuong.style.color = null;
      document.getElementById("tentruyen").style.color = null;
    };

    sxtangdan.onclick = function () {
      sxgiamdan.style.display = "block";
      sxtangdan.style.display = "none";
    };
    sxgiamdan.onclick = function () {
      sxgiamdan.style.display = "none";
      sxtangdan.style.display = "block";
    };
    </script>
</asp:Content>

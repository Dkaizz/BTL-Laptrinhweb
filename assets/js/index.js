// Mở menu
var header = document.getElementById("header");
var menumobile = document.getElementById("mobile-menu");
var theader = header.clientHeight;

menumobile.addEventListener("click", function () {
  var iscloss = header.clientHeight === theader;
  if (iscloss) {
    header.style.height = "auto";
    header.style.overflow = "visible";
  } else {
      header.style.height = null;
      header.style.overflow = null;

  }
});

//mở ô đăng nhập và đăng ký


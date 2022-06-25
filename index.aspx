<%@ Page Title="" Language="C#" MasterPageFile="~/header-footer-home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Btl_LTW.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
    <link rel="stylesheet" href="./assets/css/bodyindex.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
        <div class="main_container">
        <!-- container -->
        <div class="container">
            
              <!-- Biên tập viên đề cử -->
          <div class="btvdc">
            <div class="btvdc_header">
              <h2>Biên tập viên đề cử:</h2>
            </div>
            <div class="btvdc_body grid" id="btvdc" runat="server">
                
              
            </div>
          </div>

          <!-- Truyện mới cập nhật -->
          <div class="btvdc dstruyen">
            <div class="btvdc_header">
              <h2>Truyện mới cập nhật:</h2>
            </div>
            <div class="dstruyenmoi" id="truyenmoi" runat="server">
              
            </div>
              <div class="dstruyenmoi-mobile" id="dschuongmobible" runat ="server">
                
              </div>
          </div>

          <!-- truyện đã hoàn thành -->
          <div class="btvdc dstruyen">
            <div class="btvdc_header">
              <h2>Truyện đã hoàn thành:</h2>
            </div>
            <div class="btvdc_body grid2" id="dstruyenht" runat="server">
              
            </div>
          </div>

          <!-- Rank king -->
          
            
          
        </div>

        <!-- end container -->
      </div>
   </form>
          
        
</asp:Content>

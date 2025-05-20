<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StudentCrud.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <%--<form id="form1" runat="server">--%>
            <div>
                <asp:DropDownList runat="server" AutoPostBack="True" id="DropDownList1">
                    <asp:ListItem Value="USA">USA</asp:ListItem>
                    <asp:ListItem Value="UK">UK</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cboMonth" runat="server" DataTextField="text" DataValueField="value" >

        </asp:DropDownList>
                <%--<asp:DataGrid
                    runat="server"
                    id="DataGrid1" />  --%>  
            </div>
        <%--</form>--%>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStudent.aspx.cs" Inherits="StudentCrud.ListStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView 
        ID="GHotels" 
        runat="server" 
        CssClass="table" 
        AutoGenerateColumns="False" 
        OnRowEditing="gdview_RowEditing"
        OnRowDeleting="CustomersGridView_RowDeleting"
        DataKeyNames="Student_Id" >
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField ReadOnly="true" DataField="First_Name" HeaderText="FirstName"/>
                <asp:BoundField ReadOnly="true" DataField="Middle_Name" HeaderText="MiddleName"/>
                <asp:BoundField ReadOnly="true" DataField="Last_Name" HeaderText="Last_Name"/>
                <asp:BoundField ReadOnly="true" DataField="GenderType.Gender_Type" HeaderText="Gender"/>
                <asp:BoundField ReadOnly="true" DataField="Address.Address_Line" HeaderText="Address"/>
                <asp:BoundField ReadOnly="true" DataField="Address.City" HeaderText="City"/>
                <asp:BoundField ReadOnly="true" DataField="Address.Zip_Codepost" HeaderText="Zip_Codepost"/>
                <asp:BoundField ReadOnly="true" DataField="Address.State" HeaderText="State"/>
                <asp:BoundField ReadOnly="true" DataField="Email.Email_Name" HeaderText="Email"/>
                <asp:BoundField ReadOnly="true" DataField="Email.EmailType.Email_Type" HeaderText="Email Type"/>
                <asp:BoundField ReadOnly="true" DataField="Phone.Phone_Number" HeaderText="Phone Number"/>
                <asp:BoundField ReadOnly="true" DataField="Phone.PhoneType.Phone_Type" HeaderText="Phone Type"/>
                <asp:BoundField ReadOnly="true" DataField="Phone.Country_Code" HeaderText="Country Code"/>
                <asp:BoundField ReadOnly="true" DataField="Phone.Area_Code" HeaderText="Area Code"/>
            </Columns>
        </asp:GridView>
</asp:Content>
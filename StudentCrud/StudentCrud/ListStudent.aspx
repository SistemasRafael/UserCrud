<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStudent.aspx.cs" Inherits="StudentCrud.ListStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-content">
      <thead>
        <tr>
            <th >First Name</th>
            <th >Last Name</th>
            <th >Middle Name</th>
            <th >Gender</th>
            <th >Email</th>
            <th >Email_Type</th>
            <th >Address_Line</th>
            <th >City</th>
            <th >State</th>
            <th >Zip_Codepost</th>
            <th >Area_Code</th>
            <th >Country_Code</th>
            <th >Phone_Number</th>
            <th >Phone_Type</th>
            <th >Actions</th>
        </tr>
      </thead>
      <tbody id="List-Student-Body-Id" class="table-body">
      </tbody>
    </table>

  <%--  
<div id="myModal" class="modal" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>Modal body text goes here.</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary">Save changes</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>--%>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="StudentCrud.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <main>
         <div class="card" style="width: 100%;">
             <div class="card-body">
                 <h5 class="card-title">
                     <asp:Label id="TituloId" Text="Add Student" runat="server"/>
                 </h5>
                 <div class="container">
                     <div class="row">
                         <div class="col-md-4">
                             <label class="form-label">First Name*</label>
                             <asp:TextBox id="FirstNameId" class="form-control" MaxLength="45" Text="" runat="server"/>
                             <div class="invalid-feedback-validation">
                                 <asp:RequiredFieldValidator ID="Value1RequiredValidator" ControlToValidate="FirstNameId" ErrorMessage="This field is required" Display="Dynamic" runat="server"/>
                             </div>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Last Name</label>
                             <asp:TextBox id="LastNameId" class="form-control" MaxLength="45" Text="" runat="server"/>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Middle Name</label>
                             <asp:TextBox id="MiddleNameId" class="form-control" MaxLength="45" Text="" runat="server"/>
                         </div>
                         <div class="col-md-4">
                           <label class="form-label">Gender*</label>
                            <asp:dropdownlist class="form-select" id="GenderId" runat="server"></asp:dropdownlist>
                           <div class="invalid-feedback-validation">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="GenderId" InitialValue="0"  ErrorMessage="Please select a value" Display="Dynamic" runat="server"/>
                            </div>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">State</label>
                             <asp:dropdownlist class="form-select" id="StateId" runat="server"></asp:dropdownlist>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">City</label>
                             <asp:dropdownlist class="form-select" id="CityId" runat="server"></asp:dropdownlist>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Zip Code</label>
                             <asp:TextBox id="ZipCodeId" class="form-control" MaxLength="45" Text="" runat="server"/>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Address</label>
                             <asp:TextBox id="AddressId" class="form-control" MaxLength="10" Text="" runat="server"/>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Email*</label>
                             <asp:TextBox id="EmailId" class="form-control" MaxLength="100" Text="" runat="server"/>
                             <div class="invalid-feedback-validation">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="EmailId" ErrorMessage="This field is required" Display="Dynamic" runat="server"/>
                                 <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailId" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                             </div>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Type Email*</label>
                             <asp:dropdownlist class="form-select" id="TypeEmailId" runat="server"></asp:dropdownlist>
                             <div class="invalid-feedback-validation">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TypeEmailId" InitialValue="0"  ErrorMessage="Please select a value" Display="Dynamic" runat="server"/>
                            </div>
                         </div>
                         <div class="col-md-4">
                             <label  class="form-label">Phone Number*</label>
                             <asp:TextBox id="PhoneNumberId" class="form-control" MaxLength="30" Text="" runat="server"/>
                             <div class="invalid-feedback-validation">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PhoneNumberId" ErrorMessage="This field is required" Display="Dynamic" runat="server"/>
                            </div>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Phone Type*</label>
                             <asp:dropdownlist class="form-select" id="PhoneTypeId" runat="server"></asp:dropdownlist>
                             <div class="invalid-feedback-validation">
                                 <asp:RequiredFieldValidator 
                                     ID="RequiredFieldValidator4" 
                                     ControlToValidate="PhoneTypeId" 
                                     InitialValue="0"  
                                     ErrorMessage="Please select a value" 
                                     Display="Dynamic" 
                                     runat="server"/>
                             </div>
                         </div>
                         <div class="col-md-4">
                             <label class="form-label">Country Code</label>
                             <asp:TextBox id="CountryCodeId" class="form-control" MaxLength="5" Text="" runat="server"/>
                             <div class="invalid-feedback-validation">
                                <asp:RangeValidator 
                                    ID="RangeValidator1" 
                                    ControlToValidate="CountryCodeId" 
                                    Type="Integer"
                                    MinimumValue="1" 
                                    MaximumValue="99999" 
                                    Display="Dynamic" 
                                    ErrorMessage="Please enter an integer between than 1 and 99999.<br />" runat="server"/>
                                 </div>

                         </div>
                          <div class="col-md-4">
                              <label class="form-label">Area Code</label>
                              <asp:TextBox id="AreaCodeId" class="form-control" MaxLength="5" Text="" runat="server"/>
                              <div class="invalid-feedback-validation">
                                  <asp:RangeValidator 
                                      ID="Value1RangeValidator" 
                                      ControlToValidate="AreaCodeId" 
                                      Type="Integer"
                                      MinimumValue="1" 
                                      MaximumValue="99999" 
                                      Display="Dynamic" 
                                      ErrorMessage="Please enter an integer between than 1 and 99999.<br />" 
                                      runat="server"/>
                            </div>
                          </div>
                     </div>
                 </div>
                <div class="alert alert-success alert-dismissible fade d-none" id="Success-Message-Id" role="alert">
                    Update Success!
                </div>
             </div>
             <div class="card-footer">
                 <div class="col-12">
                     <asp:Button runat="server" id="BtnAdd" class="btn btn-primary" text="Add" onclick="BtnAddClick"/>
                     <asp:Button runat="server" id="BtnUpdate" class="btn btn-warning" Visible="false" text="Update" onclick="BtnUpdateClick"/>
                     <asp:Button runat="server" id="BtnAddNew" class="btn btn-primary" Visible="false" text="Add New Student" onclick="BtnAddNewClick"/>
                     <asp:Button runat="server" id="BtnCancel" class="btn btn-danger" text="Cancel" onclick="BtnCancelClick"/>
                 </div>
             </div>
         </div>
     </main>
</asp:Content>

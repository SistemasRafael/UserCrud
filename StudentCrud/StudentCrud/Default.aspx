<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentCrud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="card" style="width: 100%;">
            <div class="card-body">
                <h5 class="card-title">Add Student</h5>
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">First Name</label>
                            <input type="text" class="form-control is-invalid" id="First-Name-Id" value="">
                            <div class="invalid-feedback">
                                Please provide first Name.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Last Name</label>
                            <input type="text" class="form-control" id="Last-Name-Id" value="">
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Middle Name</label>
                            <input type="text" class="form-control" id="Middle-Name-Id" value="">
                        </div>
                        <div class="col-md-4">
                          <label for="validationCustom04" class="form-label">Gender</label>
                          <select class="form-select is-invalid" id="Gender-Id">
                            <option selected value="0">Choose Option</option>
                            <option value="1">Male</option>
                            <option value="2">Female</option>
                          </select>
                          <div class="invalid-feedback">
                            Please select a gender.
                          </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">State</label>
                            <select class="form-select" id="State-Id">
                                    <option selected value="0">Choose state</option>
                                    <option value="1">Sonora</option>
                                    <option value="2">Sinaloa</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">City</label>
                            <select class="form-select" id="City-Id">
                                  <option selected value="0">Choose City</option>
                                  <option value="1">Hermosillo</option>
                                  <option value="2">Obregon</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Zip Code</label>
                            <input type="text" class="form-control" id="Zip-Code-Id" value="">
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Address</label>
                            <input type="text" class="form-control" id="Address-Id" value="">
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Email</label>
                            <input type="text" class="form-control is-invalid" id="Email-Id" value="">
                            <div class="invalid-feedback">
                                Please provide email.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Type Email</label>
                            <select class="form-select is-invalid" id="Type-Email-Id">
                                  <option selected value="0">Choose option</option>
                                  <option value="1">Gmail</option>
                                  <option value="2">Hotmail</option>
                            </select>
                            <div class="invalid-feedback">
                                Please select email.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Phone Number</label>
                            <input type="text" class="form-control is-invalid" id="Phone-Number-Id" value="">
                            <div class="invalid-feedback">
                                Please provide phone number.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Phone Type</label>
                            <select class="form-select is-invalid" id="Phone-Type-Id">
                                  <option selected value="0">Choose option</option>
                                  <option value="1">Phone</option>
                                  <option value="2">Cell Phone</option>
                            </select>
                            <div class="invalid-feedback">
                                Please select phone type.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="validationCustom01" class="form-label">Country Code</label>
                            <input type="text" class="form-control" id="Country-Code-Id" value="">
                        </div>
                         <div class="col-md-4">
                             <label for="validationCustom01" class="form-label">Area Code</label>
                             <input type="text" class="form-control" id="Area-Code-Id" value="">
                         </div>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <div class="col-12">
                    <button type="button" id="btn-save" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-danger">Cancel</button>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

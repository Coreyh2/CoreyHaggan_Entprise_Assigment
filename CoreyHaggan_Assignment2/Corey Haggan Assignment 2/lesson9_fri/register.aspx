<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="CoreyHaggan_Assignment2.register" %>
<asp:content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
    <asp:label id="lblError" runat="server" cssclass="failureNotification"></asp:label>
</div>
<div>
    <label for="txtUsername">Username: *</label>
    <asp:textbox id="txtUsername" runat="server"></asp:textbox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="A User name is required" ControlToValidate="txtUsername" 
        Display="Dynamic"></asp:RequiredFieldValidator>
</div>
<div>
    <label for="txtPassword">Password: *</label>
    <asp:textbox id="txtPassword" runat="server" textmode="password"></asp:textbox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Please Enter a password" ControlToValidate="txtPassword" 
        Display="Dynamic"></asp:RequiredFieldValidator>
</div>
<div>
    <label for="txtPasswordConf">Confirm Password: *</label>
    <asp:textbox id="txtPasswordConf" runat="server" textmode="password"></asp:textbox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Please Enter a password" Display="Dynamic" 
        ControlToValidate="txtPasswordConf"></asp:RequiredFieldValidator>
 <asp:CompareValidator id="comparePasswords" runat="server" ControlToCompare="txtPassword"
      ControlToValidate="txtPasswordConf"
      ErrorMessage="Your passwords do not match"
      Display="Dynamic" />

</div>
<div>
    <label for="rblRole">Role: *</label>
    <asp:radiobuttonlist id="rblRole" runat="server" repeatdirection="Horizontal">
        <asp:listitem value="User" text="User" selected="True"></asp:listitem>
        <asp:listitem value="Admin" text="Admin"></asp:listitem>
    </asp:radiobuttonlist>
</div>

<asp:button id="btnRegister" runat="server" Text="Register" 
        onclick="btnRegister_Click" />

</asp:content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CoreyHaggan_Assignment2.login" %>
<asp:content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
    <asp:label id="lblError" runat="server" cssclass="failureNotification"></asp:label>
</div>
<div>
    <label for="txtUsername" 
        style="font-family: Arial; font-size: large; font-weight: bolder; font-style: normal">Username: *</label>
    <asp:textbox id="txtUsername" runat="server"></asp:textbox>
</div>
<div>
    <label for="txtPassword" 
        style="font-family: Arial; font-size: large; font-weight: bolder; font-style: normal">Password: *</label>
    <asp:textbox id="txtPassword" runat="server" textmode="password"></asp:textbox>
</div>

<asp:button id="btnLogin" runat="server" text="Login" onclick="btnLogin_Click" />

</asp:content>

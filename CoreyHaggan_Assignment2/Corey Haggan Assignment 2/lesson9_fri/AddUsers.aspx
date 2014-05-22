<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="CoreyHaggan_Assignment2.AddUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<h2>Students</h2>

<div>
    <label for="txtStudentName">StudentName:  *</label>
    <asp:textbox id="txtStudentName" runat="server"></asp:textbox>
    <asp:requiredfieldvalidator id="val1" controltovalidate="txtStudentName"
         errormessage="Required" display="Dynamic" runat="server"></asp:requiredfieldvalidator>
    <label for="txtCourseName">CourseName:  *</label>
    <asp:textbox id="txtCourseName" runat="server"></asp:textbox>
    <asp:requiredfieldvalidator id="Requiredfieldvalidator1" controltovalidate="txtCourseName"
         errormessage="Required" display="Dynamic" runat="server"></asp:requiredfieldvalidator>
    <label for="txtCourseTime">CourseTime:  *</label>
    <asp:textbox id="txtCourseTime" runat="server"></asp:textbox>
    <asp:requiredfieldvalidator id="Requiredfieldvalidator2" controltovalidate="txtCourseTime"
         errormessage="Required" display="Dynamic" runat="server"></asp:requiredfieldvalidator>
</div>

<asp:button id="btnSave" runat="server" text="Save" onclick="btnSave_Click" />

</asp:Content>
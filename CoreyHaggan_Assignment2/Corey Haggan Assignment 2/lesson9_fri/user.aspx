<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="CoreyHaggan_Assignment2.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:sqldatasource id="SqlDataSource1" runat="server" 
        connectionstring="<%$ ConnectionStrings:strConn %>" 
        providername="<%$ ConnectionStrings:strConn.ProviderName %>" 
        selectcommand="SELECT * FROM Courses"></asp:sqldatasource>





    <asp:gridview runat="server" id="gvCourses" autogeneratecolumns="false"
    DataKeyNames="CourseID">
    <columns>
        <asp:boundfield headertext="Student Name" datafield="StudentName" />
        <asp:boundfield headertext="Course Title" datafield="CourseName" />
        <asp:boundfield headertext="Course Time" datafield="CourseTime" />
    </columns>
</asp:gridview>
</asp:Content>

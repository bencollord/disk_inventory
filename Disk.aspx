<%--
    Form for myDisk Inventory Disk tracker
    
    Author: Ben Collord
    Last Modified:  11/13/2015 
--%>

<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Disk.aspx.cs" Inherits="DiskPage" %>

<asp:Content ID="Main" ContentPlaceHolderId="MainContent" runat="server">
    <h1>Disk</h1>

    <asp:Label ID="lblMessage" runat="server" Visible="false" />

    <div>
        <asp:Label ID="lblDiskName" runat="server" AssociatedControlID="txtDiskName">Title</asp:Label>
        <asp:TextBox runat="server" ID="txtDiskName"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvDiskName" 
            runat="server" 
            ControlToValidate="txtDiskName"
            ErrorMessage="Title is a required field" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblGenre" runat="server" AssociatedControlID="txtGenre" >Genre</asp:Label>
        <asp:TextBox runat="server" ID="txtGenre"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvGenre" 
            runat="server" 
            ControlToValidate="txtGenre"
            ErrorMessage="Genre is a required field" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblReleaseDate" runat="server" AssociatedControlID="txtReleaseDate" >Release Date</asp:Label>
        <asp:TextBox runat="server" ID="txtReleaseDate" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblDiskType" runat="server" AssociatedControlID="ddlDiskType">Disk Type</asp:Label>
        <asp:DropDownList runat="server" ID="ddlDiskType">
            <asp:ListItem>CD</asp:ListItem>
            <asp:ListItem>DVD</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="lblIsBorrowed" runat="server" AssociatedControlID="cbIsBorrowed" >Is Borrowed</asp:Label>
        <asp:CheckBox runat="server" ID="cbIsBorrowed"></asp:CheckBox>
    </div>

    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" />

</asp:Content>


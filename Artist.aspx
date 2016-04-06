<%--
    Form for myDisk Inventory Artist tracker
    
    Author: Ben Collord
    Last Modified:  11/13/2015 
--%>

<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Artist.aspx.cs" Inherits="ArtistPage" %>

<asp:Content ID="Main" ContentPlaceHolderId="MainContent" runat="server">
    <h1>Artist</h1>

    <asp:Label ID="lblMessage" runat="server" Visible="false" />

    <div>
        <asp:Label ID="lblArtistName" runat="server" AssociatedControlID="txtArtistName">Artist Name</asp:Label>
        <asp:TextBox runat="server" ID="txtArtistName"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvArtistName" 
            runat="server" 
            ControlToValidate="txtArtistName"
            ErrorMessage="Please enter a value" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:CustomValidator
            ID="cvArtistNotDuplicate"
            runat="server"
            ControlToValidate="txtArtistName"
            CssClass="error"
            ErrorMessage="Artist already exists in database"
            OnServerValidate="cvArtistNotDuplicate_Validate">
        </asp:CustomValidator>

        
    </div>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" />

</asp:Content>


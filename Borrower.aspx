<%--
    Form for myDisk Inventory Borrowers tracker
    
    Author: Ben Collord
    Last Modified:  11/13/2015 
--%>

<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Borrower.aspx.cs" Inherits="BorrowerPage" %>

<asp:Content ID="Main" ContentPlaceHolderId="MainContent" runat="server">
    <h1>Borrower</h1>

    <asp:Label ID="lblMessage" runat="server" Visible="false" />

    <div>
        <asp:Label ID="lblFName" runat="server" AssociatedControlID="txtFName">First Name</asp:Label>
        <asp:TextBox runat="server" ID="txtFName"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvFName" 
            runat="server" 
            ControlToValidate="txtFName"
            ErrorMessage="First name is a required field" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblLName" runat="server" AssociatedControlID="txtLName">Last Name</asp:Label>
        <asp:TextBox runat="server" ID="txtLName"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvLName" 
            runat="server" 
            ControlToValidate="txtLName"
            ErrorMessage="Last name is a required field" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblPhoneNum" runat="server" AssociatedControlID="txtPhoneNum">Phone Number</asp:Label>
        <asp:TextBox runat="server" ID="txtPhoneNum"></asp:TextBox>

        <asp:RequiredFieldValidator 
            ID="rfvPhoneNum" 
            runat="server" 
            ControlToValidate="txtPhoneNum"
            ErrorMessage="Phone number is a required field" 
            CssClass="error" 
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="revPhoneNum"
            runat="server"
            ControlToValidate="txtPhoneNum"
            ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$|^([0-9]{10})$"
            ErrorMessage="Please enter a valid US phone number"
            CssClass="error"
            Display="Dynamic">
        </asp:RegularExpressionValidator>
    </div>

    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" />

</asp:Content>


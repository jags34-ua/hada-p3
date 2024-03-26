<%@ Page Title="Hada P3" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="titleProducts" runat="server" Text="Products Management" style="font-size: 140%; font-weight: bold;"></asp:Label>

    <br /><br />

    <asp:Label ID="codeLabel" runat="server" Text="Code " />
    <asp:TextBox ID="codeProduct" runat="server" />

    <br /><br />

    <asp:Label ID="nameLabel" runat="server" Text="Name " />
    <asp:TextBox ID="nameProduct" runat="server" />

    <br /><br />

    <asp:Label ID="amountLabel" runat="server" Text="Amount " />
    <asp:TextBox ID="amountProduct" runat="server" />

    <br /><br />

    <asp:Label ID="categoryLabel" runat="server" Text="Category " />
    <asp:DropDownList ID="categoryListProduct" runat="server" >
        <asp:ListItem Value="0">Computing</asp:ListItem>
        <asp:ListItem Value="1">Telephony</asp:ListItem>
        <asp:ListItem Value="2">Gaming</asp:ListItem>
        <asp:ListItem Value="3">Home appliances</asp:ListItem>
    </asp:DropDownList>

    <br /><br />

    <asp:Label ID="priceLabel" runat="server" Text="Price " />
    <asp:TextBox ID="priceProduct" runat="server" />

    <br /><br />

    <asp:Label ID="cdateLabel" runat="server" Text="Creation Date " />
    <asp:TextBox ID="cdateProduct" runat="server" />

    <br /><br />
    <asp:Label ID="msgToShow" runat="server"></asp:Label>
    <br /><br />

    <asp:Button text="Create" onClick="toCreate" ID="createButton" runat="server" />
    <asp:Button text="Update" onClick="toUpdate" ID="updateButton" runat="server" />
    <asp:Button text="Delete" onClick="toDelete" ID="deleteButton" runat="server" />
    <asp:Button text="Read" onClick="toRead" ID="readButton" runat="server"  />
    <asp:Button text="Read First" onClick="toReadFirst" ID="firstButton" runat="server" />
    <asp:Button text="Read Prev" onClick="toReadPrev" ID="previousButton" runat="server" />
    <asp:Button text="Read Next" onClick="toReadNext" ID="nextButton" runat="server" />
    
</asp:Content>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RSSReaderControl.ascx.cs" Inherits="RSSReaderControl" %>
<asp:ListView runat="server" ID="PostList">
  <LayoutTemplate>
    <ul>
      <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </ul>
  </LayoutTemplate>
  <ItemTemplate>
    <li><a href='<%# Eval("Link") %>'><%# Eval("Title") %></a><br />
      <%# Eval("Description") %>          
    </li>
  </ItemTemplate>
</asp:ListView>
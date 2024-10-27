<%@ Control Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="global_border">
    <div>
        <x:ProductViewSelector Text="Normal" Value="normal" runat="server" />
        <x:ProductViewSelector Text="Grid" Value="grid" runat="server" />
        <x:ProductViewSelector Text="Large" Value="large" runat="server" />
    </div>
    <x:Pager runat="server" />
</div>

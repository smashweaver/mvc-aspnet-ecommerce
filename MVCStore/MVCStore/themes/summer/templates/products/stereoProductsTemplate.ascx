<%@ Control Inherits="System.Web.Mvc.ViewUserControl" %>
<h1 style=" background-color:Yellow">Stereo Products Template </h1>
<div class="border">
    [sitemap here]
</div>
<x:GlobalTemplate Src="productsHeaderTemplate" runat="server"/>
<br />
<div class="border">
    [news ticker]
</div>
<br />
<div style="width: 100%">
    <x:ProductList runat="server" />
</div>
<br />
[pagerbottom] 

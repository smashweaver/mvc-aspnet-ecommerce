<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h1>Shopping Cart</h1>
    <form action="/cart" method="post">
        <input type="hidden" name="mode" value="update" />
        <table width="100%">
            <thead>
            <tr>
                <th style="text-align: left">
                Description
                </th>
                <th style="text-align: right">
                Quantity
                </th>
                <th style="text-align: right">
                Price
                </th>
                <th style="text-align: right">
                Extended
                </th>
                <th>
                &nbsp;
                </th>
            </tr>
            </thead>
            <tbody>
                <x:CartItems runat="server">
                <ItemTemplate>
                    <tr>
                    <td>
                        <%# Eval("Description") %>
                    </td>
                    <td style="text-align: right">
                        <input name="<%# Eval("VarSKU") %>" type="text" value="<%# Eval("Qty") %>" style="width: 30px;text-align: right" />
                    </td>
                    <td style="text-align: right">
                        <%# Eval("Price") %>
                    </td>
                    <td style="text-align: right">
                        <%# Eval("Extended") %>
                    </td>
                    <td style="text-align: right">
                        <!-- encapsulate this in DeleteCartItem control -->
                        <input type="button" value="-" onclick="deleteSku('<%# Eval("SKU") %>')" />
                    </td>
                    </tr>
                </ItemTemplate>
                </x:CartItems>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align: right">
                        <b><%# Eval("Total") %></b>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
        <input type="submit" value="Update" onclick="this.Enabled=false" />
    </form>
    <br />
    <hr />
    <img src="/images/PPCheckout.gif" alt="" onclick="location.href='/checkout'" />
    <form id="cartDeleteForm" action="/cart" method="post">
        <input name="sku" id="sku" type="hidden" />
        <input name="mode" type="hidden" value="delete" />
    </form>
    <script type="text/javascript">
        function deleteSku(sku) {
            cartDeleteForm.elements["sku"].value = sku;            
            cartDeleteForm.submit();
        }       
        //flex.killpart("cartwidget");                
    </script>
</asp:Content>

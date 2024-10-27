<%@ Control Inherits="FlexMerchant.Web.UI.Controls.BaseProductTemplate" %>

<form action="/cart/addsku" method="post" onsubmit="flex.submitForm(this);return false;">
    <input type="hidden" name="qty" value="1" />     
    <div style="margin-bottom: 2px; width: 517px;">
        <div class="border">
            <div style="padding-left: 0px; padding-right: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" align="left" width="25%">
                            <img alt="" src="" />
                            
                        </td>
                        <td valign="top" width="45%">
                            <div style="padding-left: 2px;">
                                <div class="tahoma-pink" style="margin-top: 5px;">
                                    <strong>
                                        <%=ViewData.Name%></strong>
                                </div>
                                <div style="margin-top: 5px;">
                                    [item desciption here]<br />
                                    <a href="#" class="tahoma-pink">More info</a>
                                </div>
                                <div style="margin-top: 10px; margin-bottom: 5px;">
                                    [Rating Widget Goes Here]
                                </div>
                            </div>
                        </td>
                        <td valign="bottom" width="30%">
                            <div style="text-align: right; padding-left: 2px; padding-right: 2px;">
                                <div class="tahoma-12bold" style="margin-bottom: 4px;">
                                    [regular price]
                                </div>
                                <div class="tahoma-12bold" style="margin-bottom: 4px;">
                                    [sale price]
                                </div>
                                <div class="tahoma-12bold" style="margin-bottom: 4px;">
                                    [amount of savings]
                                </div>
                                <div style="margin-bottom:4px;">
                                <select name="sku">
                                <option value="volvo">Volvo</option>
                                <option value="saab">Saab</option>
                                <option value="opel">Opel</option>
                                <option value="audi">Audi</option>
                                </select>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="height: 31px; background-color: orange; width: 100%;">
            <table width="100%">
                <tr>
                    <td valign="middle" align="center" width="25%">
                        <table>
                            <tr>
                                   <td>
                                    <span id="viewLargeSpan" runat="server" class="white-link" style="cursor: pointer;">Enlarge</span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="middle" width="45%" align="left">
                        <table>
                            <tr>
                                 <td>
                                   <span class="white-link" onclick="__callProduct(<%=ViewData.Id %>)">View Details</span>  
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="middle" align="right" style="width: 30%">                        
                        <input type="submit" value="Add to Cart" />&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</form>

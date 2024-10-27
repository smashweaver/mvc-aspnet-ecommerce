<%@ Control Inherits="FlexMerchant.Web.UI.Controls.BaseProductTemplate" %>

<form action="/cart/addsku" method="post" onsubmit="flex.submitForm(this);return false;">
<div style="margin-bottom: 15px;width:519px;">
   <div class="border" >
     <div style="padding-left:0px;padding-right:0px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" align="left" width="25%" >
                    <img src="" alt="" />
                    
                </td>
                <td valign="bottom" width="30%" >
                    <div style="text-align:right; padding-left:2px;padding-right:2px; ">
                        
                        <div class="tahoma-12bold" style="margin-bottom:4px;">
                            [regular price]
                        </div>
                        <div class="tahoma-12bold" style="margin-bottom:4px;">
                            [sale price]
                        </div>
                        <div class="tahoma-12bold" style="margin-bottom:4px;">
                            [amount saved]
                        </div>
                        <div style="margin-bottom:4px;">
                           <select name="sku">
                                        <option value="volvo">Volvo</option>
                                        <option value="saab">Saab</option>
                                        <option value="opel">Opel</option>
                                        <option value="audi">Audi</option>
                                    </select>
                           <input type="hidden" value="1" name="qty" />        
                        </div>
                    </div>
                </td>
            </tr>
        </table>       
      </div> 

    </div>
   <div style="height: 31px; background-color: #D12960; width:100%;">
        <table width="100%">
            <tr>
                <td valign="middle" align="center" width="25%">
                    <table>
                        <tr>
                            <td>
                                <img ID='viewLarge' src="/images/enlarge.gif" alt="" style="cursor:pointer" width="22" height="17" />                                
                            </td>
                            <td>
                                <span id="viewLargeSpan" class="white-link" style="cursor:pointer;">[Enlarge]</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="middle" align="right" style="width:30%">
                     <input type="image" src="/images/add-to-cart-2.gif" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
</div>
</form>
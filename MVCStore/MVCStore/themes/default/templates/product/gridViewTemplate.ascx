<%@ Control Inherits="FlexMerchant.Web.UI.Controls.BaseProductTemplate" %>

<form action="/cart/addsku" method="post" onsubmit="flex.submitForm(this);return false;">
<div class="feature" style="width:255px;">
  <div class="border">
  	<table width="255px" border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td align="left" valign="top" width="50%">
			    <div style="padding:2px;">
				  <img alt="" src="" />
				</div>
			</td>
			<td width="50%" valign="bottom">
				<div style="text-align:right;padding-left:2px;padding-right:6px;">
					<div class="tahoma-14bold" style="margin-bottom:6px;">
					    <%= ViewData.Name %>
					</div>
					<div class="tahoma-12bold" style="margin-bottom:6px;">
					   [regular price]
					</div>
					<div class="tahoma-12bold" style="margin-bottom:6px;">
					    [sale price]
					</div>
					<div class="tahoma-12bold" style="margin-bottom:6px;">
					    [amount saved]
					</div>
				</div>				
			</td>			
		</tr>
	</table>
  </div>
  <div style="width:255px;height:31px;background-color:#D12960;">
	<table width="100%" >
	<tr>
		<td valign="middle" align="center"  width="50%">
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
		<td valign="middle" width="50%" align="center">
			<table>
				<tr>
					<td>
					    <a id="a1" href=""><img src="/images/view-detail.gif" alt=""/></a>
					  
					</td>
					<td>
					  <span class="white-link" onclick="__callProduct(<%=ViewData.Id %>)">View Details</span>  
						</td>
				</tr>
			</table>
		</td>		
	</tr>
	</table>
  </div>
</div>
</form>
<%@ Control Inherits="FlexMerchant.Web.UI.Controls.CartTemplate" %>
<div class="sex-group-pink">
    <div class="sex-group-header">
        <img src="/images/shopping-bag.gif" alt="" class="sex-shopping-img" />
    </div>
    <div class="sex-group-content">
        <div class="sex-group-content-hdr-img">
            <img src="/images/bucket.jpg" alt="" style="cursor:pointer" onclick="location.href='/cart'" />
        </div>
        <div class="sex-group-subcontent" style="text-align: center;">
            <%=GetResponse()%>
        </div>
    </div>
    <div class="sex-group-content">
        <div class="sex-group-subcontent">
            <div class="sex-basket-row-dotted">
                <img src="/images/bullet.jpg" alt="" />
                Wish List
            </div>
            <div class="sex-basket-row-dotted">
                <img src="/images/bullet.jpg" alt="" />
                Feedback
            </div>
            <div class="sex-basket-row-dotted">
                <img src="/images/bullet.jpg" alt="" />
                Buyer Guide
            </div>
        </div>
    </div>
</div>

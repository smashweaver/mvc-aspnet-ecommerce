<%@ Control Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="search">
    <form action="/search" method="get">
    <div>
        <div class="search-content" style="width: 20%; float: left;">
            $[SEARCH]
        </div>
        <div style="width: 75%; float: right; padding: 0; margin: 7px 2px 4px 2px; overflow: hidden;">
            <input type="text" name="query" class="search-input-txt" />
            <input type="image" src="/images/search-lense.jpg" />
        </div>
    </div>
    <div style="clear:both"></div>
    </form>
</div>

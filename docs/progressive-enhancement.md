
# Progressive Enhancement (2008)

FlexMerchant implemented a progressive enhancement pattern in 2008 that mirrors approaches now popular in HTMX and Hotwire. The system was built on the principle "works without JavaScript, better with it."

## Core Implementation

### Client Framework (flex.js)
```javascript
flex = new function() {
    this.parts = new Array();
    this.scripts = new Array();
    this.callbacks = new Array();
    this.forms = new Array();
}

// Form Enhancement
flex.submitForm = function(form, returnUrl) {
    var _success = function(){
        if(returnUrl) location.href=returnUrl;
        flex.refresh();
    };
    var _request = flex.ajax(form.action, form.method, _success, null);
    _request.setHeader("Ajax","flex");
    _request.send(flex.getData(form));
}

// Partial Updates
flex.partCall = function(part, target) {
    var success = function(data) {
        var el = document.getElementById(target);
        el.innerHTML = data;
    }
    var req = flex.ajax("/@getpart", "post", success);
    req.setHeader("AjaxPart", part);
    req.send("");
}
```

### Server-Side Support
```csharp
public abstract class FlexController : Controller
{
    private bool isAjaxRequest = false;
    protected internal virtual bool IsAjaxRequest
    {
        get { return isAjaxRequest; }
    }

    protected override void Execute(ControllerContext controllerContext)
    {
        // Detect AJAX capabilities
        if (!String.IsNullOrEmpty(controllerContext.HttpContext.Request.Headers["Ajax"]))
        {
            isAjaxRequest = true;
        }

        // Handle appropriately
        if (isAjaxRequest)
        {
            // AJAX path
        }
        else
        {
            // Traditional path
        }
    }
}
```

## Usage Examples

### Form Handling
```html
<!-- Works with or without JavaScript -->
<form action="/cart" method="post" onsubmit="flex.submitForm(this);return false;">
    <input type="text" name="qty" />
    <input type="submit" value="Update" />
</form>
```

### Partial Updates
```aspx
<x:Part
    Src="cartwidget"
    IsUpdatable="true"
    TargetID="cartWidget1"
    runat="server"
/>
```

## Modern Parallels

### HTMX (2023)
```html
<!-- HTMX approach -->
<form hx-post="/cart" hx-target="#cart-total">
    <input type="text" name="qty" />
    <button type="submit">Update</button>
</form>

<!-- FlexMerchant (2008) -->
<form onsubmit="flex.submitForm(this);return false;">
    <input type="text" name="qty" />
    <input type="submit" value="Update" />
</form>
```

### Hotwire/Turbo (2023)
```ruby
# Turbo Frame
<%= turbo_frame_tag "cart" do %>
  <%= render "cart" %>
<% end %>

# FlexMerchant Part (2008)
<x:Part Src="cart" TargetID="cartWidget1" IsUpdatable="true" />
```

## Key Features

### 1. Form Enhancement
```javascript
// FlexMerchant (2008)
flex.submitForm = function(form, returnUrl) {
    var _request = flex.ajax(form.action, form.method, _success, null);
    _request.send(flex.getData(form));
}

// Modern HTMX
<form hx-post="/cart">
```

### 2. Partial Updates
```javascript
// FlexMerchant (2008)
flex.partCall = function(part, target) {
    var el = document.getElementById(target);
    el.innerHTML = data;
}

// Modern Turbo
Turbo.visit('/cart', { frame: 'cart_section' })
```

### 3. State Management
```javascript
// FlexMerchant (2008)
flex.refresh = function() {
    flex.loadParts();
}

// Modern frameworks use similar refresh patterns
```

## Technical Benefits

1. **SEO Excellence**
   - Full functionality without JavaScript
   - Clean URLs
   - Semantic HTML
   - Server-side rendering

2. **Performance**
   - Minimal initial JavaScript
   - Progressive loading
   - Efficient updates
   - Resource optimization

3. **Accessibility**
   - Works with JavaScript disabled
   - Standard HTML controls
   - Progressive disclosure
   - Keyboard navigation

4. **Maintainability**
   - Clear enhancement patterns
   - Predictable behavior
   - Separation of concerns
   - Testable components

## Historical Impact

FlexMerchant's progressive enhancement approach in 2008 demonstrated several patterns that are now considered best practices:

1. **Enhancement Pattern**
   - JavaScript as enhancement
   - Server-first approach
   - Graceful degradation
   - Feature detection

2. **User Experience**
   - No-JavaScript support
   - Enhanced interaction
   - Fast feedback
   - Reliable operation

3. **Developer Experience**
   - Clear patterns
   - Predictable behavior
   - Easy debugging
   - Maintainable code

## Modern Relevance

The patterns implemented in FlexMerchant's progressive enhancement system continue to influence modern development:

1. **Framework Approaches**
   - HTMX patterns
   - Hotwire/Turbo
   - Remix approach
   - Next.js patterns

2. **Best Practices**
   - Progressive enhancement
   - Graceful degradation
   - Server-first design
   - Accessibility focus

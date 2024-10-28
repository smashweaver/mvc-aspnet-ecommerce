
# FlexMerchant E-Commerce Platform (2008)

A pioneering e-commerce platform that implemented component islands, progressive enhancement, and theme systems years before they became mainstream web development patterns.

## Historical Context

Built in 2008 using ASP.NET MVC Preview 2, FlexMerchant implemented several architectural patterns that wouldn't become mainstream until years later:

- Islands of interactivity (predating Astro)
- Progressive enhancement (similar to modern HTMX)
- Virtual theme system (predating modern design systems)

## Key Innovations

### 1. Component Islands (2008)
```csharp
public class Part : ViewUserControl
{
    public string Src { get; set; }
    public string TargetID { get; set; }
    public bool IsUpdatable { get; set; }
}

// Usage
<x:Part Src="cartwidget" IsUpdatable="true" TargetID="cartWidget1" runat="server" />
```
[Deep Dive: Islands Architecture](docs/islands-2008.md)

### 2. Progressive Enhancement Framework
```javascript
flex.submitForm = function(form, returnUrl) {
    var _request = flex.ajax(form.action, form.method, _success, null);
    _request.setHeader("Ajax","flex");
    _request.send(flex.getData(form));
}

// Works without JavaScript, enhances with AJAX when available
<form action="/cart" method="post" onsubmit="flex.submitForm(this);return false;">
```
[Deep Dive: Progressive Enhancement](docs/progressive-enhancement.md)

### 3. Theme Virtual Provider
```csharp
public class FlexVirtualPathProvider : VirtualPathProvider
{
    public override VirtualFile GetFile(string virtualPath)
    {
        // Dynamic theme resolution
        string themedFile = string.Format("/themes/{0}/{1}", themeName, fileName);
    }
}
```
[Deep Dive: Theme System](docs/theme-system.md)

## Modern Framework Parallels

### Astro (2023)
```astro
---
// Modern islands architecture
---
<Layout>
  <Cart client:idle />
</Layout>

<!-- FlexMerchant (2008) -->
<x:Part Src="cart" IsUpdatable="true" TargetID="cartWidget" />
```

### HTMX (2023)
```html
<!-- HTMX -->
<div hx-post="/cart" hx-trigger="submit">

<!-- FlexMerchant (2008) -->
<form onsubmit="flex.submitForm(this);return false;">
```

### Fresh/Deno (2023)
```tsx
// Fresh island component
<Cart islands:load />

// FlexMerchant part (2008)
<x:Part Src="cart" IsUpdatable="true" />
```

## Technical Stack

- ASP.NET MVC Preview 2
- .NET Framework 3.5
- Custom JavaScript framework (flex.js)
- Virtual path provider for theming

## Project Structure

```
FlexMerchant/
├── FlexMerchant.Core/         # Core framework
│   ├── Controllers/           # Base controllers
│   ├── Controls/             # Component system
│   ├── Scripts/              # flex.js framework
│   └── Services/            # Business logic
└── MVCStore/                # Sample implementation
    ├── themes/              # Theme system
    ├── views/               # MVC views
    └── global/              # Shared resources
```

## Historical Impact

FlexMerchant demonstrated remarkable foresight in implementing patterns that would become standard in web development:

1. **Component Islands**
   - Isolated, updatable sections
   - Server-first rendering
   - Progressive enhancement
   - SEO-friendly approach

2. **Progressive Enhancement**
   - Works without JavaScript
   - AJAX enhancements when available
   - Form handling with fallbacks
   - Accessibility focus

3. **Theme System**
   - Virtual path resolution
   - Runtime theme switching
   - Resource management
   - Component-level theming

## License

Copyright © 2008 FlexMerchant (defunct)

This software was originally developed as proprietary software by FlexMerchant. With the company now defunct, this code is shared for historical/educational purposes only.

## Author

Originally developed by Jason Jimenez while at FlexMerchant (2008)


# Islands Architecture (2008)

FlexMerchant implemented a component islands pattern in 2008 that remarkably parallels modern approaches like Astro, Fresh, and others.

## Core Implementation

### Part Control System
```csharp
public class Part : ViewUserControl
{
    public string Src { get; set; }
    public string TargetID { get; set; }
    public bool IsUpdatable { get; set; }

    protected override void OnLoad(EventArgs e)
    {
        if (Src != null)
        {
            string path = string.Format("{1}/{0}.ascx", Src, ThemeService.Current.TemplatePath);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", TargetID);
            div.Controls.Add(Page.LoadControl(path));
            this.Controls.Add(div);
        }
    }
}
```

### Client-Side Enhancement
```javascript
// flex.js partial update system
flex.partCall = function(part, target) {
    var success = function(data) {
        var el = document.getElementById(target);
        el.innerHTML = data;
    }
    var req = flex.ajax("/@getpart", "post", success);
    req.setHeader("AjaxPart", part);
    req.send("");
}

// Part management
flex.addPart = function(thePart, theTarget) {
    flex.parts.push({Part:thePart, Target:theTarget});
}
```

## Usage in FlexMerchant (2008)

### Cart Widget Example
```aspx
<!-- Cart as an isolated island -->
<div id="sidebar-right">
    <x:Part
        Src="cartwidget"
        IsUpdatable="true"
        TargetID="cartWidget1"
        runat="server"
    />
</div>
```

### Master Page Integration
```aspx
<x:Part
    Src="bannerwidget"
    runat="server"
/>
<br />
<div id="sidebar-left">
    <x:Part
        Src="searchwidget"
        runat="server"
    />
    <x:Part
        Src="catalogmenuwidget"
        runat="server"
    />
</div>
```

## Modern Parallels

### Astro (2023)
```astro
---
// Modern Astro islands
---
<Layout>
  <StaticHeader />
  <Cart client:idle />
  <StaticFooter />
</Layout>
```

### Fresh/Deno (2023)
```tsx
// Fresh component island
<Cart islands:load />
```

### Key Similarities

1. **Isolated Components**
   ```csharp
   // FlexMerchant (2008)
   public class Part : ViewUserControl
   {
       public bool IsUpdatable { get; set; }
   }
   ```
   ```typescript
   // Astro (2023)
   const Cart = ({ client: 'idle' }) => {
     // Similar isolation concept
   }
   ```

2. **Selective Hydration**
   ```javascript
   // FlexMerchant (2008)
   flex.partCall = function(part, target) {
       // Selective update
   }
   ```
   ```javascript
   // Modern partial hydration
   hydrate(component, { strategy: 'idle' });
   ```

3. **Server-First Rendering**
   ```csharp
   // FlexMerchant (2008)
   protected override void OnLoad(EventArgs e)
   {
       // Server-side rendering
       div.Controls.Add(Page.LoadControl(path));
   }
   ```
   ```javascript
   // Modern SSR
   export async function getServerSideProps() {
     // Similar server-first approach
   }
   ```

## Historical Significance

FlexMerchant's Part system in 2008 pioneered several concepts that are now standard in modern web development:

1. **Component Isolation**
   - Self-contained units
   - Independent lifecycle
   - Scoped functionality

2. **Progressive Loading**
   - Server-first rendering
   - Selective client updates
   - Resource optimization

3. **SEO Benefits**
   - Full functionality without JavaScript
   - Clean markup
   - Semantic structure

## Modern Impact

The patterns implemented in FlexMerchant's Part system continue to be relevant:

1. **Islands Architecture**
   - Astro's component islands
   - Fresh's island components
   - Partial hydration strategies

2. **Performance Patterns**
   - Selective updates
   - Resource management
   - Load optimization

3. **Development Patterns**
   - Component isolation
   - Declarative updates
   - Server/client balance

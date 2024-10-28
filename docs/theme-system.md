
# Theme System (2008)

FlexMerchant implemented a sophisticated theme system in 2008 using ASP.NET's virtual path provider, creating a dynamic theming approach that parallels modern design systems.

## Core Implementation

### Virtual Path Provider
```csharp
public class FlexVirtualPathProvider : VirtualPathProvider
{
    public override VirtualFile GetFile(string virtualPath)
    {
        string path = virtualPath;
        string ext = Path.GetExtension(virtualPath);
        string fileName = Path.GetFileName(virtualPath);

        if (ext.Equals(".master", StringComparison.CurrentCultureIgnoreCase))
        {
            string themeName = ThemeService.Current.Name;
            if (string.IsNullOrEmpty(themeName))
            {
                string themedFile = string.Format("/themes/{0}/{1}", themeName, fileName);
                if (base.FileExists(themedFile))
                {
                    path = VirtualPathUtility.ToAppRelative(themedFile);
                    return new FlexVirtualFile(path, virtualPath);
                }
            }
        }
        return base.GetFile(path);
    }
}
```

### Theme Service
```csharp
public class ThemeService
{
    static readonly string THEMEKEY = "__themekey__";

    public static Theme Current
    {
        get
        {
            if (HttpRuntime.Cache[THEMEKEY] == null) {
                Call().Initialize();
            }
            return (Theme)HttpRuntime.Cache[THEMEKEY];
        }
    }

    private void Initialize()
    {
        Shop shop = ShopService.Current;
        Theme theme = new Theme(shop.Theme);
        HttpRuntime.Cache.Add(
            THEMEKEY,
            theme,
            null,
            DateTime.Now.AddMinutes(10),
            Cache.NoSlidingExpiration,
            CacheItemPriority.NotRemovable,
            null
        );
    }
}
```

### Theme Structure
```csharp
public class Theme
{
    private string _name;
    public string Name { get { return _name; } }

    public Theme(string name)
    {
        _name = name;
    }

    public string MasterPage
    {
        get { return string.Format("/themes/{0}/site.master", Name); }
    }

    public string ThemePath
    {
        get { return string.Format("/themes/{0}", Name); }
    }

    public string TemplatePath
    {
        get { return string.Format("/themes/{0}/templates", Name); }
    }

    public string ImagePath
    {
        get { return string.Format("/themes/{0}/images", Name); }
    }
}
```

## Theme Organization

### Directory Structure
```
themes/
├── default/
│   ├── Site.Master
│   ├── Site.css
│   └── templates/
│       ├── product/
│       │   ├── defaultProductTemplate.ascx
│       │   └── gridViewTemplate.ascx
│       └── widgets/
│           ├── cartwidget.ascx
│           └── searchwidget.ascx
└── summer/
    ├── Site.Master
    ├── Site.css
    └── templates/
```

### Token Replacement System
```csharp
public class FilteringModule : IHttpModule
{
    void ReplaceTokens(StringBuilder pageSource)
    {
        Regex parser = new Regex(@"\$\[\w+\]");
        MatchCollection matches = parser.Matches(pageSource.ToString());

        // Replace theme tokens
        foreach (Match match in matches)
        {
            string key = GetKey(match.Value);
            string value = GetResource(key);
            // Replace token with themed value
        }
    }
}
```

## Modern Parallels

### CSS-in-JS Theme Systems (2023)
```typescript
// Modern styled-components
const theme = {
  colors: {
    primary: '#007bff',
    secondary: '#6c757d'
  }
}

// FlexMerchant (2008)
public class Theme
{
    public string ThemePath
    {
        get { return string.Format("/themes/{0}", Name); }
    }
}
```

### Design Systems (like Chakra UI)
```javascript
// Modern theme provider
const theme = {
  components: {
    Button: {
      variants: {
        solid: {
          bg: 'primary.500'
        }
      }
    }
  }
}

// FlexMerchant templates (2008)
/themes/default/templates/product/gridViewTemplate.ascx
/themes/summer/templates/product/gridViewTemplate.ascx
```

## Key Features

### 1. Theme Resolution
```csharp
// Virtual path resolution
public override VirtualFile GetFile(string virtualPath)
{
    string themedFile = string.Format("/themes/{0}/{1}", themeName, fileName);
    if (base.FileExists(themedFile))
    {
        return new FlexVirtualFile(path, virtualPath);
    }
}
```

### 2. Resource Management
```csharp
public sealed class Manager
{
    public static void RegisterScript(string key, string script)
    {
        // Theme-aware script registration
    }
}
```

### 3. Token System
```html
<!-- Theme tokens in templates -->
<img src="$[IMAGEPATH]/logo.png" alt="$[WEBSITE_TITLE]" />
```

## Historical Impact

FlexMerchant's theme system pioneered several concepts now common in modern web development:

1. **Dynamic Themes**
   - Runtime theme switching
   - Resource resolution
   - Template overrides
   - Token replacement

2. **Resource Organization**
   - Structured theme hierarchy
   - Component templates
   - Asset management
   - Cache optimization

3. **Development Patterns**
   - Theme inheritance
   - Component theming
   - Resource bundling
   - Cache strategies

## Modern Relevance

The patterns implemented in FlexMerchant's theme system parallel modern approaches:

1. **Design Systems**
   - Component libraries
   - Theme providers
   - Style inheritance
   - Token systems

2. **Resource Management**
   - Asset resolution
   - Dynamic loading
   - Cache strategies
   - Build optimization

3. **Multi-tenant Support**
   - Theme switching
   - Resource isolation
   - Cache management
   - State preservation

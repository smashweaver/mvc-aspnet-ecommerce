# FlexMerchant E-Commerce Platform

A legacy e-commerce platform built with ASP.NET MVC Preview 2 (circa 2008). The solution consists of a core library (FlexMerchant.Core) and a sample store implementation (MVCStore).

## Architecture

### Core Library (FlexMerchant.Core)

The core library provides the foundation for building themed e-commerce stores:

- **Service Layer**
  - Cart management
  - Product catalog
  - Theme management
  - Store configuration

- **MVC Components**
  - Base controllers
  - Custom view controls
  - HTML/URL helpers
  - View page extensions

- **Theme Engine**
  - Virtual path provider for themes
  - Template controls
  - Page filtering/token replacement
  - Theme switching support

### Sample Store (MVCStore)

The sample implementation demonstrates the core library's capabilities:

- **Theme Implementation**
  - Default theme
  - Summer theme variant
  - Global templates
  - Product templates

- **Store Features**
  - Product browsing by category
  - Shopping cart
  - Product search
  - Multiple view modes (grid/list/large)

## Technical Details

### Theme System

- Themes are stored in `/themes/{theme-name}`
- Each theme contains:
  - Site.Master
  - Site.css
  - Templates folder
  - Images folder

- Template Types:
  - Product templates (grid/list/large views)
  - Category templates
  - Widget templates (cart/search/menu)

### Routing

The application uses explicit routes for:
- Home/index
- Product categories
- Cart operations
- Search functionality
- AJAX partial views

### Client-Side Framework

Custom JavaScript framework (flex.js) providing:
- AJAX form submissions
- Partial view loading
- Dynamic content updates
- Theme token replacement

### Server Controls

Custom controls inheriting from ViewUserControl:
- CartItems
- ProductList
- Template
- Part
- Pager

## Project Organization

```
FlexMerchant/
├── FlexMerchant.Core/         # Core e-commerce library
│   ├── Controllers/           # Base controllers
│   ├── Controls/             # Custom server controls
│   ├── Extensions/           # MVC extensions
│   ├── Models/              # Domain models
│   └── Services/            # Business logic
│
└── MVCStore/                # Sample store implementation
    ├── themes/              # Store themes
    │   ├── default/        # Default theme
    │   └── summer/         # Summer theme variant
    ├── views/              # MVC views
    └── global/             # Shared resources
```

## Theme Development

To create a new theme:

1. Create theme folder in `/themes/{theme-name}`
2. Create Site.Master and Site.css
3. Add required templates:
   - Product templates
   - Category templates
   - Widget templates
4. Configure theme in web.config

## Dependencies

### Framework
- .NET Framework 3.5

### Core Dependencies
- System.Web.Mvc (ASP.NET MVC Preview 2)
- System.Web.Abstractions
- System.Web.Routing
- System.Web.Extensions
- System.Core
- System.Data.DataSetExtensions
- System.Xml.Linq
- System.Data.Linq

### Development Environment
- Visual Studio 2008
- ASP.NET MVC Preview 2 SDK

## Historical Context

Built during the early preview days of ASP.NET MVC (Preview 2), this application demonstrates:

- Early MVC patterns before conventions were established
- Hybrid WebForms/MVC approach with custom controls
- Theme/template system predating Razor views
- Custom JavaScript before jQuery dominance

While not representative of modern practices, it serves as an interesting example of early ASP.NET MVC architecture and e-commerce patterns.

## License

Copyright © 2008 FlexMerchant (defunct)

This software was originally developed as proprietary software by FlexMerchant. With the company now defunct, this code is shared for historical/educational purposes only. All rights and ownership belonged to FlexMerchant at the time of development.

**Historical Note:** This codebase represents a point-in-time snapshot of early ASP.NET MVC e-commerce development and should be viewed as an educational resource rather than production-ready software.

## Author

Originally developed by Jason Jimenez while at FlexMerchant (2008)

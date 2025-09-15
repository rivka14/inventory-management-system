# 🏪 Inventory Management System

A comprehensive retail inventory management system built with C# .NET, featuring a clean 3-layer architecture designed for small to medium retail stores. The system provides robust inventory tracking, customer management, and sales promotion capabilities with XML-based data persistence and extensive logging.

## 📋 Table of Contents

- [🏗️ Architecture Overview](#️-architecture-overview)
- [✨ Features](#-features)
- [🛠️ Technology Stack](#️-technology-stack)
- [📁 Project Structure](#-project-structure)
- [⚙️ Setup & Installation](#️-setup--installation)
- [🚀 Usage](#-usage)
- [🧪 Testing](#-testing)
- [📊 Logging](#-logging)
- [🤝 Contributing](#-contributing)

## 🏗️ Architecture Overview

The system follows a clean **3-layer architecture pattern** ensuring separation of concerns, maintainability, and testability:

```
┌─────────────────────────────────────────┐
│              Presentation Layer          │
│           (Console Test App)             │
├─────────────────────────────────────────┤
│            Business Logic Layer         │
│     (BL - Business Rules & Logic)       │
├─────────────────────────────────────────┤
│          Data Access Layer              │
│    (DAL - Configurable Storage)         │
└─────────────────────────────────────────┘
```

### Layer Details:

- **📊 Data Access Layer (DAL)**: 
  - Configurable data persistence (currently XML-based)
  - Generic CRUD operations with filtering capabilities
  - Factory pattern for DAL provider selection
  - Extensible design for future database implementations

- **💼 Business Logic Layer (BL)**:
  - Domain-specific business rules and validations
  - Entity management and relationships
  - Business object transformations
  - Exception handling and logging integration

- **🖥️ Presentation Layer**:
  - Console-based testing and demonstration application
  - Interactive menus for all system operations
  - User-friendly input validation and error handling

## ✨ Features

### 📦 Product Management
- **CRUD Operations**: Create, Read, Update, Delete products
- **Categories**: Organize products by categories (Plants, Boxes, KnickKnack, Pictures, Pillows)
- **Inventory Tracking**: Monitor stock levels and pricing
- **Product Relationships**: Link products with sales and promotions

### 👥 Customer Management
- **Customer Profiles**: Comprehensive customer information management
- **Contact Details**: Name, address, phone number tracking
- **Customer History**: Link customers with their purchase history
- **Customer Segmentation**: Support for preferred customer status

### 🏷️ Sales & Promotions
- **Flexible Sales**: Create and manage product sales/promotions
- **Discount Management**: Configure percentage-based or fixed-amount discounts
- **Time-based Promotions**: Set start and end dates for sales
- **Club Member Specials**: Exclusive promotions for club members
- **Inventory Integration**: Automatic stock level adjustments

### 📈 Advanced Features
- **Configurable Data Storage**: XML-based with extensible architecture
- **Comprehensive Logging**: Detailed operation logging with monthly organization
- **Error Handling**: Robust exception management throughout all layers
- **Generic CRUD Interface**: Consistent data operations across all entities
- **Factory Pattern**: Flexible component instantiation and configuration

## 🛠️ Technology Stack

- **Framework**: .NET 8.0
- **Language**: C# 12.0
- **Architecture**: 3-Layer Clean Architecture
- **Data Storage**: XML files (configurable via dal-config.xml)
- **Logging**: Custom file-based logging system
- **Testing**: Console-based integration testing
- **Build System**: MSBuild/.NET CLI

## 📁 Project Structure

```
inventory-management-system/
├── 📁 BL/                          # Business Logic Layer
│   ├── 📁 BlApi/                   # BL Interfaces
│   │   ├── IBl.cs                  # Main BL interface
│   │   ├── ICustomer.cs            # Customer operations
│   │   ├── IProduct.cs             # Product operations
│   │   └── ISale.cs                # Sales operations
│   ├── 📁 BO/                      # Business Objects
│   │   ├── Customer.cs             # Customer entity
│   │   ├── Product.cs              # Product entity
│   │   ├── Sale.cs                 # Sale entity
│   │   └── Enums.cs                # Domain enumerations
│   └── 📁 BlImplementation/        # BL Implementations
├── 📁 DalFacade/                   # Data Access Layer
│   ├── 📁 DalApi/                  # DAL Interfaces
│   │   ├── IDal.cs                 # Main DAL interface
│   │   ├── ICrud.cs                # Generic CRUD operations
│   │   ├── ICustomer.cs            # Customer data operations
│   │   ├── IProduct.cs             # Product data operations
│   │   ├── ISale.cs                # Sale data operations
│   │   ├── Factory.cs              # DAL factory
│   │   └── Config.cs               # Configuration handler
│   └── 📁 DO/                      # Data Objects
├── 📁 DalList/                     # DAL Implementation (In-Memory Lists)
├── 📁 Tools/                       # Utilities & Logging
│   └── LogManager.cs               # Logging system
├── 📁 DalTest/                     # Console Test Application
├── 📁 BlTest/                      # Business Logic Tests
├── 📁 xml/                         # Configuration Files
│   └── dal-config.xml              # DAL configuration
└── 📄 README.md                    # This file
```

## ⚙️ Setup & Installation

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- IDE: Visual Studio 2022, VS Code, or JetBrains Rider

### Installation Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/rivka14/inventory-management-system.git
   cd inventory-management-system
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the solution**:
   ```bash
   dotnet build
   ```

4. **Run the test application**:
   ```bash
   dotnet run --project DalTest
   ```

### Configuration

The system uses `xml/dal-config.xml` to configure the data access layer:

```xml
<?xml version="1.0" encoding="utf-8"?>
<config>
  <dal>list</dal>  <!-- Current: in-memory lists -->
  <dal-packages>
    <list>DalList</list>
    <xml>DalXml</xml>  <!-- Future: XML file storage -->
  </dal-packages>
</config>
```

## 🚀 Usage

### Running the Console Application

The `DalTest` project provides an interactive console interface:

```bash
dotnet run --project DalTest
```

### Menu System

```
Main Menu:
For exit type 0
For product type 1
For customer type 2  
For sale type 3

Sub-Menu (for each entity):
You are in {Product/Customer/Sale}
For backing to main menu type 0
For create new {entity} type 1
For read 1 item from {entity} type 2
For readAll from {entity} type 3
For update {entity} type 4
For delete {entity} type 5
```

### Example Operations

**Creating a Product**:
```
Enter ProductId, ProductName, CategoryProduct, Price, Amount
> 1001
> Decorative Plant
> 0  (Plants category)
> 25
> 50
```

**Creating a Customer**:
```  
Enter CustomerTz ,CustomerName,CustomerAdress, CustomerPhone 
> 123456789
> John Doe
> 123 Main St
> 555-0123
```

**Creating a Sale**:
```
Enter ProdectId,AmountForSale, UniqueIdAuto,PriceForSale , IsForClab, LastTime, EndTime 
> 1001
> 10
> 2001
> 20
> true
> 1       (day)
> 9       (month)
> 2024    (year)
> 30      (day)
> 9       (month)
> 2024    (year)
```

## 🧪 Testing

### Console Testing
The primary testing approach uses the interactive console application in `DalTest`:

```bash
# Run the test application
dotnet run --project DalTest

# Or run the business logic tests
dotnet run --project BlTest
```

### Integration Testing
- Test all CRUD operations for each entity
- Validate business rules and constraints
- Test error handling and edge cases
- Verify logging functionality

## 📊 Logging

The system includes a comprehensive logging mechanism:

### Features
- **Monthly Organization**: Logs organized by month
- **Daily Files**: Separate log file for each day
- **Automatic Cleanup**: Old logs automatically deleted
- **Structured Format**: Timestamp, project, function, and message
- **Operation Tracking**: All CRUD operations are logged

### Log Location
```
bin/Log/
├── [Month]/
│   ├── 1.txt      # Day 1 logs
│   ├── 2.txt      # Day 2 logs
│   └── ...
```

### Log Format
```
2024-09-14 15:30:45    DalList.CreateProduct:    Product created successfully with ID: 1001
```

## 🤝 Contributing

### Development Guidelines
1. **Follow the 3-layer architecture** - maintain clear separation of concerns
2. **Implement proper error handling** - use try-catch blocks and meaningful exceptions
3. **Add logging** - log all significant operations
4. **Maintain consistency** - follow existing coding patterns and naming conventions
5. **Test thoroughly** - test all CRUD operations and edge cases

### Code Style
- Use meaningful variable and method names
- Follow C# naming conventions (PascalCase for public members, camelCase for private)
- Add XML documentation comments for public APIs
- Keep methods focused and single-purpose

### Adding New Features
1. **Define interfaces first** in the appropriate API layer
2. **Implement business objects** in the BO layer if needed
3. **Add business logic implementation** in the BL layer
4. **Implement data access** in the DAL layer
5. **Add tests** in the console application
6. **Update documentation**

---

## 📞 Support & Contact

For questions, suggestions, or issues, please create an issue in the GitHub repository.

**Happy Inventory Managing! 🚀**


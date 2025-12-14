# Inventory Sales Management System

A comprehensive desktop application for managing inventory, processing sales, and generating reports with role-based access control.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=flat-square&logo=microsoftsqlserver)

## 📋 Table of Contents

- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [Database Schema](#-database-schema)
- [API Endpoints](#-api-endpoints)
- [User Roles](#-user-roles)
- [Screenshots](#-screenshots)
- [Contributing](#-contributing)
- [License](#-license)

## ✨ Features

### Core Functionality
- 🔐 **Secure Authentication** - Username/password login with role-based access
- 📦 **Inventory Management** - Track products, categories, and stock levels
- 💰 **Point of Sale (POS)** - Process sales with automatic tax calculation (15%)
- 📊 **Reports & Analytics** - Generate sales reports with filtering options
- 👥 **User Management** - Admin can create and manage user accounts
- 🏷️ **Dynamic Categories** - Add product categories on-the-fly
- 🔍 **Smart Product Search** - Search by product name or ID
- ⚠️ **Low Stock Alerts** - Dashboard notifications for products below reorder level

### User Experience
- ✅ Show/Hide password toggle
- ✅ Real-time cart totals with tax breakdown
- ✅ Automatic stock validation
- ✅ Export reports to text files
- ✅ Separate Exit and Logout functionality

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core Web API (.NET 9)
- **ORM**: Entity Framework Core
- **Database**: SQL Server (LocalDB)
- **Mapping**: AutoMapper

### Frontend
- **Framework**: Windows Forms (.NET 9)
- **HTTP Client**: HttpClient for API communication
- **JSON**: Newtonsoft.Json

### Architecture
- **Pattern**: Three-tier architecture
- **Layers**: Data Access, Business Logic (API), Presentation (Desktop)

## 📦 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or later)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (included with Visual Studio)

## 🚀 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/inventory-sales.git
cd inventory-sales
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Setup Database

Open Package Manager Console in Visual Studio and run:

```powershell
# Set InventorySales.Api as startup project
Update-Database
```

This will create the database and seed initial data.

### 4. Configure API URL

Ensure the API URL in `InventorySales.Desktop/ApiService.cs` matches your API endpoint:

```csharp
private const string BaseUrl = "https://localhost:7069/api";
```

### 5. Run the Application

**Option A: Visual Studio**
1. Set `InventorySales.Api` as startup project
2. Press F5 to start the API
3. Set `InventorySales.Desktop` as startup project
4. Press F5 to start the desktop app

**Option B: Command Line**

```bash
# Terminal 1 - Start API
cd InventorySales.Api
dotnet run

# Terminal 2 - Start Desktop App
cd InventorySales.Desktop
dotnet run
```

## 📖 Usage

### Default Login Credentials

```
Username: admin
Password: admin123
Role: Admin
```

### Basic Workflow

#### 1. **Adding Products**
- Navigate to **Products** tab
- Click **Add Product**
- Fill in product details (Name, Category, Price, Stock, Reorder Level)
- Click **+** next to Category to add new categories
- Click **SAVE**

#### 2. **Processing Sales**
- Navigate to **Sales POS** tab
- Enter product name or ID in search box
- Click **Add** to add to cart
- Review SubTotal, Tax (15%), and Total
- Click **CHECKOUT** to complete sale

#### 3. **Generating Reports**
- Navigate to **Reports** tab
- Filter by date or sale ID
- Click **Filter** to view results
- Click **Generate Report** to export to file

#### 4. **Managing Users** (Admin Only)
- Navigate to **Registration Mgmt** tab
- Click **Add User**
- Enter username, password, and select role
- Click **SAVE**

### Understanding Reorder Level

The **Reorder Level** is a critical inventory threshold:

- When `Stock Quantity` falls below `Reorder Level`, the product appears in the "Low Stock" dashboard alert
- **Example**: If Reorder Level = 20 and Stock = 15, you'll see a low stock warning
- **Best Practice**: Set to 20-30% of typical stock based on sales velocity

## 📁 Project Structure

```
InventorySales/
├── InventorySales.Api/              # Web API Backend
│   ├── Controllers/                 # API endpoints
│   │   ├── AuthController.cs
│   │   ├── ProductsController.cs
│   │   ├── SalesController.cs
│   │   └── ReportsController.cs
│   ├── DTOs/                        # Data Transfer Objects
│   └── Mappings/                    # AutoMapper profiles
│
├── InventorySales.Data/             # Data Access Layer
│   ├── Entities/                    # Database models
│   │   ├── User.cs
│   │   ├── Category.cs
│   │   ├── Product.cs
│   │   ├── Sale.cs
│   │   └── SalesDetail.cs
│   ├── Repositories/                # Repository pattern
│   └── InventoryDbContext.cs        # EF Core context
│
└── InventorySales.Desktop/          # Windows Forms UI
    ├── LoginForm.cs                 # Authentication
    ├── DashboardForm.cs             # Main container
    ├── ProductsUserControl.cs       # Product management
    ├── SalesUserControl.cs          # POS system
    ├── ReportsUserControl.cs        # Report generation
    ├── UsersUserControl.cs          # User management
    └── ApiService.cs                # API communication
```

## 🗄️ Database Schema

### Tables

#### Users
| Column   | Type         | Description           |
|----------|--------------|-----------------------|
| Id       | int (PK)     | User ID               |
| Username | nvarchar(50) | Login username        |
| Password | nvarchar(255)| Hashed password       |
| Role     | nvarchar(20) | Admin or User         |

#### Categories
| Column | Type          | Description      |
|--------|---------------|------------------|
| Id     | int (PK)      | Category ID      |
| Name   | nvarchar(100) | Category name    |

#### Products
| Column        | Type           | Description                    |
|---------------|----------------|--------------------------------|
| Id            | int (PK)       | Product ID                     |
| Name          | nvarchar(200)  | Product name                   |
| CategoryId    | int (FK)       | Category reference             |
| UnitPrice     | decimal(18,2)  | Price per unit                 |
| StockQuantity | int            | Current stock                  |
| ReorderLevel  | int            | Low stock threshold            |
| Description   | nvarchar(500)  | Product description (optional) |
| ImageUrl      | nvarchar(500)  | Image URL (optional)           |

#### Sales
| Column      | Type           | Description                |
|-------------|----------------|----------------------------|
| Id          | int (PK)       | Sale ID                    |
| Date        | datetime       | Sale timestamp             |
| TotalAmount | decimal(18,2)  | Grand total (inc. tax)     |
| Tax         | decimal(18,2)  | Tax amount (15%)           |
| UserId      | int (FK)       | User who processed sale    |

#### SalesDetails
| Column    | Type           | Description              |
|-----------|----------------|--------------------------|
| Id        | int (PK)       | Detail ID                |
| SaleId    | int (FK)       | Sale reference           |
| ProductId | int (FK)       | Product reference        |
| Quantity  | int            | Units sold               |
| UnitPrice | decimal(18,2)  | Price at time of sale    |
| SubTotal  | decimal(18,2)  | Quantity × UnitPrice     |

## 🔌 API Endpoints

### Authentication
```http
POST /api/auth/login
POST /api/auth/register
```

### Products
```http
GET    /api/products?search={query}
GET    /api/products/{id}
POST   /api/products
PUT    /api/products/{id}
DELETE /api/products/{id}
GET    /api/products/categories
POST   /api/products/categories
```

### Sales
```http
POST /api/sales
GET  /api/sales/{id}
GET  /api/sales/report?date={date}&id={id}
```

### Reports
```http
GET /api/reports/dashboard
```

## 👤 User Roles

### Admin
- ✅ Full system access
- ✅ Manage products, sales, reports, and users
- ✅ View all features

### User
- ✅ View dashboard
- ✅ Manage products
- ✅ Process sales
- ❌ Cannot view reports
- ❌ Cannot manage users

## 🖼️ Screenshots

### Login Screen
- Secure authentication with show/hide password toggle

### Dashboard
- Daily sales summary
- Low stock alerts
- Total product count

### Sales POS
- Product search by name or ID
- Shopping cart with real-time totals
- Tax breakdown (SubTotal, Tax 15%, Total)

### Products Management
- Grid view of all products
- Add/Delete functionality
- Dynamic category creation

### Reports
- Filter by date or sale ID
- Export to text file
- Tax breakdown per sale

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🐛 Troubleshooting

### API Connection Issues
- Ensure API is running on `https://localhost:7069`
- Check firewall settings
- Verify SSL certificate is trusted

### Database Issues
- Run `Update-Database` in Package Manager Console
- Check SQL Server LocalDB is running
- Verify connection string in `appsettings.json`

### Login Fails
- Verify default credentials: `admin` / `admin123`
- Check database has user data
- Review API logs for errors

## 📞 Support

For issues and questions:
- Create an issue in the repository
- Contact: your.email@example.com

## 🎯 Future Enhancements

- [ ] Barcode scanning support
- [ ] Receipt printing
- [ ] Multi-currency support
- [ ] Advanced analytics with charts
- [ ] Email notifications for low stock
- [ ] Backup and restore functionality
- [ ] Product images in UI
- [ ] Supplier management

---

**Version**: 1.0  
**Last Updated**: December 2025  
**Tax Rate**: 15%

Made with ❤️ using .NET 9

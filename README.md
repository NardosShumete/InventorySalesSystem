# Inventory HQ - Sales Management System

A premium desktop application for managing inventory, processing sales, and generating detailed reports with role-based access control and advanced security.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)
![Security](https://img.shields.io/badge/Security-BCrypt-blue?style=flat-square)

## 📋 Table of Contents

- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [User Roles](#-user-roles)
- [Security](#-security)

## ✨ Features

### Premium Enhancements (v1.5)
- 🎨 **Premium UI Modernization** - Modern "Ghost White & Deep Teal" theme with card-based layouts and Segoe UI typography.
- 🔐 **BCrypt Password Hashing** - Industry-standard secure hashing for all user credentials.
- 👤 **Salesperson Attribution** - Every sale is now linked to the specific user who processed it, with detailed ID and Username tracking.
- 📈 **Performance Tracking** - Monthly "Performance Points" system to track active salesperson volume.
- 🚀 **Optimized POS** - Fluid sidebar navigation and real-time stock-guarded checkout process.

### Core Functionality
- 📦 **Inventory Management** - Track products, categories, and stock levels.
- 💰 **Point of Sale (POS)** - Process sales with automatic tax calculation (15%).
- 📊 **Intelligent Reporting** - Generate sales reports filtered by **Daily**, **Weekly**, or **Monthly** ranges.
- 👥 **User Management** - Admin can create, update, and manage accounts with role-based visibility.
- ⚠️ **Low Stock Alerts** - Dashboard notifications for products below reorder level.

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core Web API (.NET 9)
- **Security**: BCrypt.Net-Next (Hashed & Salted storage)
- **ORM**: Entity Framework Core
- **Database**: SQL Server (LocalDB)
- **Mapping**: AutoMapper

### Frontend
- **Framework**: Windows Forms (.NET 9)
- **Design System**: Custom Premium Theme (Ghost White & Deep Teal)
- **HTTP Client**: HttpClient for API communication
- **JSON**: Newtonsoft.Json

## 🚀 Installation

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/inventory-sales.git
cd inventory-sales
```

### 2. Setup Database
Open Package Manager Console and run:
```powershell
# Set InventorySales.Api as startup project
Update-Database
```

### 3. Run the Application
```bash
# Terminal 1 - Start API
cd InventorySales.Api && dotnet run

# Terminal 2 - Start Desktop App
cd InventorySales.Desktop && dotnet run
```

## 📖 Usage

### Default Login Credentials
| Username | Password | Role |
| :-- | :-- | :-- |
| `admin` | `12345678` | Administrator |

### Core Workflow
1. **Sales POS**: Search products by name (e.g., "M") or ID. Check stock availability before adding to cart.
2. **Reports**: Use the **Period** selector (Daily/Weekly/Monthly) to fetch sales trends automatically.
3. **Users**: Manage staff and monitor their **Performance Points** (Points = Sales processed this month).

## 🗄️ Security
- **Irreversible Hashing**: Passwords are never stored as plain text. 
- **Auto-Migration**: The system automatically detects legacy password formats and upgrades them to BCrypt on first successful login.
- **Role Isolation**: Sensitive actions (Reports, User Management, Product Editing) are strictly restricted to Admin/Manager roles.

---

**Version**: 1.5.0  
**Last Updated**: December 2025  
**Tax Rate**: 15%

Made with ❤️ using .NET 9

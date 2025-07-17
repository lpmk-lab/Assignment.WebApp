# 🛒 Product Management System

This is an ASP.NET Core MVC application using **Entity Framework Core (Database-First)**. It allows users to manage products through a web interface, backed by stored procedures in SQL Server.

---

## 🧰 Prerequisites

- [.NET SDK 7+](https://dotnet.microsoft.com/en-us/download)
- SQL Server or SQL Server Express
- Visual Studio 2022 or later (or VS Code)
- Existing database (or follow instructions below to create)

---

## 🚀 How to Set Up the Project

### 1. Clone the Repository

```bash
git clone https://github.com/lpmk-lab/Assignment.WebApp.git
cd Assignment.WebApp
```

---

### 2. Open the Project in Visual Studio

- Open `Assignment.sln`
- Set `Assignment.UI` as the **Startup Project**

---

### 3. Create the Database in SQL Server

Run the following script in SQL Server Management Studio (SSMS) or Azure Data Studio:

```sql
CREATE DATABASE Assignment;
GO
USE Assignment;
```

---

### 4. Create Table and Stored Procedures

```sql
-- Create Product table
CREATE TABLE [dbo].[Product](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(1000) NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [Active] BIT NOT NULL
);
GO

-- sp_create_product
CREATE PROCEDURE [dbo].[sp_create_product]
    @Name NVARCHAR(100),
    @Description NVARCHAR(1000),
    @CreatedDate DATETIME
AS
BEGIN
    INSERT INTO Product (Name, Description, CreatedDate, Active)
    VALUES (@Name, @Description, @CreatedDate, 1)
END;
GO

-- sp_get_product
CREATE PROCEDURE [dbo].[sp_get_product]
    @Id INT = NULL,
    @Name NVARCHAR(100) = NULL
AS
BEGIN
    SELECT Id, Name, Description, CreatedDate
    FROM Product
    WHERE Active = 1
      AND (@Id IS NULL OR Id = @Id)
      AND (@Name IS NULL OR Name = @Name)
END;
GO

-- sp_update_product
CREATE PROCEDURE [dbo].[sp_update_product]
    @Id INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(1000),
    @CreatedDate DATETIME
AS
BEGIN
    UPDATE Product
    SET Name = @Name,
        Description = @Description
    WHERE Id = @Id
END;
GO

-- sp_delete_product
CREATE PROCEDURE [dbo].[sp_delete_product]
    @Id INT
AS
BEGIN
    UPDATE Product
    SET Active = 0
    WHERE Id = @Id
END;
GO
```

---

### 5. Update Database Connection

Open the config file and update your SQL Server credentials:

```bash
Assignment\Assignment.Infrastructure\Assignment.UI\appsettings.json
```

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Assignment;Trusted_Connection=True;"
}
```

> Replace `localhost` and `Trusted_Connection` as needed for your environment.

---

### 6. Set Startup Project

In **Visual Studio**:
- Right-click `Assignment.UI` → **Set as Startup Project**

---

### 7. Run the Project

✅ Option 1: From Visual Studio  
- Press `Ctrl + F5` to run without debugger

✅ Option 2: From Command Line

```bash
cd Assignment\Assignment.Infrastructure\Assignment.UI
dotnet run
```

Then open the browser:

```
https://localhost:5001
```

---

## ✅ Features

- Add / Edit / Delete products using stored procedures
- Soft delete using `Active` flag
- Bootstrap-based responsive UI
- Clean architecture with MediatR, Layered Solution

---

## 📝 Notes

- This project uses **stored procedures only** for all database interactions.
- No EF Migrations are used (Database-First approach).
- Make sure SQL Server is running before running the app.

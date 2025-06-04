Here is the full and properly formatted `README.md` file for your **Student Portal - ASP.NET Core MVC Application** project:

---

```markdown
# 📘 Student Portal - ASP.NET Core MVC Application

This is a simple Student Portal web application built using ASP.NET Core MVC.

The app allows users to:

- ❤ View all students  
- ❤ Add a new student  
- ❤ Edit student details  
- ❤ Delete a student  

---

## 📁 Project Structure

```

StudentPortal/
│
├── Controllers/
│   └── StudentController.cs
├── Models/
│   └── Entities/
│       └── Student.cs
├── Views/
│   └── Student/
│       ├── Index.cshtml
│       ├── Add.cshtml
│       └── Edit.cshtml
├── wwwroot/
├── appsettings.json
├── Program.cs
└── Startup.cs (for .NET Core 3.x or earlier)

````

---

## 🛠️ Installation and Setup

### 1. Clone the Repository

**Option A (Using GitHub):**
```bash
git clone https://github.com/Jathursi/studentportal.git
cd studentportal
````

**Option B (Create a New Project):**

```bash
dotnet new mvc -n StudentPortal
```

---

### 2. Install Required NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

### 3. Run the Application

**Option A (Basic Run):**

```bash
dotnet run
```

> Note: If changes don’t reflect, stop the process (`Ctrl+C`) and run again.

**Option B (With Hot Reload):**

```bash
dotnet tool install --global dotnet-watch
dotnet watch run
```

> Use `Ctrl+R` in the browser to manually reload or let it auto-refresh.

---

### 4. Set Up the Database

Install Entity Framework CLI tools:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add "Initial Migration"
```

---

### 5. Install SQL Server and SSMS

* [Download SQL Server Express (Lightweight)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [Download SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

---

### 6. Apply Database Migrations

```bash
dotnet ef database update
```

---

## ✅ Done!

You can now run the application and manage student records through the web interface.

---


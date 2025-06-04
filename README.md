📘 Student Portal - ASP.NET Core MVC Application
This is a simple Student Portal web application built using ASP.NET Core MVC. The app allows users to:
❤ View all students
❤ Add a new student
❤ Edit student details
❤ Delete a student

🛠️ Installation and Setup
1. Clone the repository
Option A:
git clone https://github.com/Jathursi/studentportal.git
cd studentportal
Option B
Creating new application
Terminal: dotnet new mvc -n StudentPortal
Install Tools
Terminal:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

Run the Web
Option A:
Terminal: dotnet run (it may need to end by pressing ctrl+c and rerun to see the changes every time)
Option B:
Terminal: dotnet tool install --global dotnet-watch (install it once)
Terminal: dotnet watch run (in the browser click ctrl+R to reload the apllication to see the changes or it will automatically reload)

2. Set up the database
Terminal:
dotnet tool install --global dotnet-ef
dotnet ef migrations add "Initial Migration"

Install Microsoft SOL Server Management Studio (for database)
Link to install 
Install SQL Server Express (Lightweight)
https://www.microsoft.com/en-us/sql-server/sql-server-downloads
install SQL Server Management Studio (SSMS)
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms

After Installation
Terminal: dotnet ef database update





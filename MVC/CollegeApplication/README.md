# 🎓 College Application Management System

An **ASP.NET Core MVC** web application for managing college admission applicants. Built with **.NET 10**, it provides a complete CRUD interface backed by a **Microsoft SQL Server** database — with no Entity Framework; all data access is done via raw ADO.NET.

---

## 🚀 Features

- **Register Applicants** — Submit a new college application with full details and optional profile photo
- **View All Applicants** — Browse all submitted applications in a tabular list, ordered by latest registration
- **Edit Applicant** — Update an existing applicant's details
- **Delete Applicant** — Remove an applicant record with a confirmation step
- **Auto-generated Registration Number** — Assigned automatically by the database upon successful submission
- **Success Notification** — Displays the registration number after successful form submission via `TempData`

---

## ✅ Validations

The `Applicant` model enforces the following rules:

| Field | Validation |
|---|---|
| Full Name | Required |
| Email | Required, valid email format, unique per record |
| Date of Birth | Required, must be a past date, age ≥ 14 years (custom `[PastDate]` attribute) |
| Course | Required |
| Phone Number | Required, must be exactly 10 digits starting with 6–9 |
| Gender | Required |
| Address | Required, max 500 characters |
| Profile Photo | Optional; if provided: max 2 MB, only `.jpg`/`.jpeg`/`.png`, MIME type validated |

---

## 🗂️ Project Structure

```
CollegeApplication/
├── Controllers/
│   ├── HomeController.cs          # Default home page
│   └── ApplicantController.cs     # Full CRUD for applicants
├── Models/
│   ├── Applicant.cs               # Applicant model + custom PastDate validator
│   └── ErrorViewModel.cs
├── Data/
│   └── ApplicantRepository.cs     # Raw ADO.NET data access layer
├── Views/
│   ├── Applicant/
│   │   ├── Index.cshtml           # List all applicants
│   │   ├── Create.cshtml          # New applicant form
│   │   ├── Edit.cshtml            # Edit applicant form
│   │   └── Delete.cshtml          # Delete confirmation
│   └── Shared/
├── Program.cs                     # App startup & DI configuration
├── appsettings.json               # Connection string configuration
└── CollegeApplication.csproj      # Project file (.NET 10)
```

---

## 🛠️ Tech Stack

| Technology | Details |
|---|---|
| Framework | ASP.NET Core MVC (.NET 10) |
| Language | C# |
| Database | Microsoft SQL Server (Express) |
| Data Access | ADO.NET (`Microsoft.Data.SqlClient` v6.1.4) |
| ORM | None — raw SQL queries |
| Frontend | Razor Views (`.cshtml`) |

---

## 🗃️ Database Setup

The application uses a SQL Server database named **`MVC`** with the following table:

```sql
CREATE TABLE CollegeApplicants (
    RegistrationNo INT PRIMARY KEY IDENTITY(1,1),
    FullName       NVARCHAR(100)  NOT NULL,
    Email          NVARCHAR(100)  NOT NULL UNIQUE,
    DateOfBirth    DATE           NOT NULL,
    Course         NVARCHAR(100)  NOT NULL,
    PhoneNo        NVARCHAR(15)   NOT NULL,
    Gender         NVARCHAR(10)   NOT NULL,
    Address        NVARCHAR(500)  NOT NULL
);
```

---

## ⚙️ Configuration

Update the connection string in `appsettings.json` to match your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=YOUR_SERVER\\SQLEXPRESS;initial catalog=MVC;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

---

## ▶️ Running the Project

1. **Clone the repository**

   ```bash
   git clone <repo-url>
   cd CollegeApplication
   ```

2. **Create the database** using the SQL script above in SQL Server Management Studio (SSMS)

3. **Update the connection string** in `appsettings.json`

4. **Run the application**

   ```bash
   dotnet run
   ```

5. Open your browser and navigate to `https://localhost:<port>/Applicant`

---

## 📌 Key Design Decisions

- **Repository Pattern** — `ApplicantRepository` encapsulates all SQL operations, keeping controllers clean
- **No EF Core** — Uses raw ADO.NET for direct SQL control and learning purposes
- **Custom Validation** — `PastDateAttribute` validates both past date and minimum age (14+) in one attribute
- **Duplicate Email Check** — Email uniqueness is verified both at the application layer and enforced at the database level (`UNIQUE` constraint)

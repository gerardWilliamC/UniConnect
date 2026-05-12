# UniConnect

A C# WinForms desktop student portal built for LPU (Lyceum of the Philippines University) as a final project. Provides separate experiences for students (view grades, announcements, GWA) and administrators (encode grades, post announcements, view audit logs), all backed by MS SQL Server.

## Tech Stack

- **C# WinForms** (.NET) — desktop UI
- **MS SQL Server Express** — database
- **ADO.NET** via `Microsoft.Data.SqlClient` — data access layer
- **OOP architecture** — Models / Database (DAL) / Forms (UI) separation

## Project Structure

```
UniConnect/
├── Models/                 POCO data classes
│   ├── Student.cs
│   ├── Admin.cs
│   ├── Subject.cs
│   ├── Grade.cs
│   ├── Announcement.cs
│   └── AuditLog.cs
├── Database/               Data access layer
│   ├── DatabaseHelper.cs   All SQL queries
│   └── Session.cs          Static current-user holder
├── DatabaseScripts/        SQL setup files (run in order)
│   ├── 01_create_database.sql
│   ├── 02_create_tables.sql
│   ├── 03_seed_data.sql
│   └── 04_announcement_reads.sql
├── Properties/
├── Resources/              Logos
├── App.config              Connection string config
└── frm*.cs                 8 form files (Login, Dashboard, etc.)
```

## Setup

### 1. Install prerequisites

- **Visual Studio 2022** (Community is fine) with .NET Desktop Development workload
- **MS SQL Server 2022 Express** — [Download here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **SQL Server Management Studio (SSMS)** — [Download here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

### 2. Set up the database

1. Open **SSMS** and connect to your local SQL Server (usually `localhost\SQLEXPRESS`)
2. Run the scripts in `/DatabaseScripts/` **in this exact order**:
   - `01_create_database.sql`
   - `02_create_tables.sql`
   - `03_seed_data.sql`
   - `04_announcement_reads.sql`

   For each: open in SSMS, press **F5** to execute.

### 3. Configure the connection

Open `App.config` in the project root. By default the connection string is:

```
Server=localhost\SQLEXPRESS;Database=UniConnectDB;Integrated Security=True;TrustServerCertificate=True;
```

If your SQL Server uses a different instance name (e.g., `YOUR-PC\SQLEXPRESS`), edit the `Server=` portion. **Do not edit any C# source files for this.**

### 4. Build and run

1. Open `UniConnect.sln` in Visual Studio
2. Restore NuGet packages (Visual Studio usually prompts automatically)
3. Press **F5** to run

## Default Test Credentials

### Student
- Email: `juan.delacruz@lpu.edu.ph`
- Password: `student123`

(Other student emails: `maria.clara@lpu.edu.ph`, `padre.damaso@lpu.edu.ph`, etc.)

### Admin
- Email: `admin@lpu.edu.ph` (Juan Santos, ICT Admin)
- Password: `admin123`

(Other admin emails: `registrar@lpu.edu.ph`, `encoder@lpu.edu.ph`)

## Features

### Student-side
- Login with database validation
- Dashboard: GWA, enrolled units, year level, recent grades preview, latest announcements
- My Grades: full grade history with semester tabs (newest first), color-coded status, CSV export
- Announcements: full list with expand-on-click, read tracking, color-coded audience badges, search

### Admin-side
- Login with database validation
- Admin Dashboard: total students / courses / pending grades / announcement counts, recent grade entries table, recent audit logs sidebar
- Encode Grades: search students, edit grades, transactional save with automatic audit logging
- Post Announcement: create + archive announcements (transactional), live posted-announcements panel, search

### Cross-cutting
- All write operations use SQL transactions (atomic update + audit log)
- All queries are parameterized (SQL injection-safe)
- Soft delete for announcements (`is_archived` flag preserves audit trail)
- Foreign key constraints enforce referential integrity

## Team

Project group of 5, LPU-C.

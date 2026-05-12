# UniConnect

A C# WinForms desktop student portal built for LPU (Lyceum of the Philippines University) as a final project. Provides separate experiences for students (view grades, announcements, GWA) and administrators (encode grades, post announcements, view audit logs), all backed by MS SQL Server.

## Tech Stack

- **C# WinForms** (.NET) — desktop UI
- **MS SQL Server Express** — database
- **ADO.NET** via `Microsoft.Data.SqlClient` — data access layer
- **OOP architecture** — Models / Database (DAL) / Forms (UI) separation

## Project Structure

```text
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
├── Properties/
├── Resources/              Logos
├── App.config              Connection string config
└── frm*.cs                 8 form files (Login, Dashboard, etc.)

Setup

To get this project running on your local machine, you need the "engine" to run the database and the "steering wheel" to manage it.
1. Install prerequisites

    Visual Studio 2026 (Community is fine) with the .NET Desktop Development workload.

    MS SQL Server Express (The Engine):

        Go to the official Microsoft SQL Server downloads page.

        Scroll down to the "Free editions" section.

        Under Express, click the Download now button.

        Run the installer file that downloads (SQL2022-SSEI-Expr.exe or similar).

        Select the Basic installation type, accept the terms, and hit Install.

    SQL Server Management Studio / SSMS (The Steering Wheel):

        When the SQL Server Express installation finishes, click the "Install SSMS" button right on the success screen. (Alternatively, search "Download SSMS" on Google and click the "Free Download for SQL Server Management Studio" link).

        Run the downloaded installer (SSMS-Setup-ENU.exe).

        Click Install and let it run (it may ask you to restart your computer afterward).

2. Set up the local database

    Open SQL Server Management Studio (SSMS) from your Windows Start menu.

    A "Connect to Server" window will pop up. The Server Name should automatically be filled in (usually localhost\SQLEXPRESS or YourComputerName\SQLEXPRESS). Hit Connect.

    Go to File > Open > File... and open the scripts in /DatabaseScripts/. Run them in this exact order by pressing F5 (or clicking Execute at the top) for each one:

        01_create_database.sql

        02_create_tables.sql

        03_seed_data.sql


3. Configure the connection

Open App.config in the project root. By default the connection string is:
XML

Server=localhost\SQLEXPRESS;Database=UniConnectDB;Integrated Security=True;TrustServerCertificate=True;

If your local SQL Server uses a different instance name (e.g., YOUR-PC\SQLEXPRESS), edit the Server= portion. Do not edit any C# source files to change the connection string.
4. Build and run

    Open UniConnect.sln in Visual Studio.

    Restore NuGet packages (Visual Studio usually prompts automatically).

    Press F5 to run the application.


Default Test Credentials
Student

    Email: juan.delacruz@lpu.edu.ph

    Password: student123

(Other student emails: maria.clara@lpu.edu.ph, padre.damaso@lpu.edu.ph, etc.)
Admin

    Email: admin@lpu.edu.ph (Juan Santos, ICT Admin)

    Password: admin123

(Other admin emails: registrar@lpu.edu.ph, encoder@lpu.edu.ph)
Features
Student-side

    Login with database validation

    Dashboard: GWA, enrolled units, year level, recent grades preview, latest announcements

    My Grades: full grade history with semester tabs (newest first), color-coded status, CSV export

    Announcements: full list with expand-on-click, read tracking, color-coded audience badges, search

Admin-side

    Login with database validation

    Admin Dashboard: total students / courses / pending grades / announcement counts, recent grade entries table, recent audit logs sidebar

    Encode Grades: search students, edit grades, transactional save with automatic audit logging

    Post Announcement: create + archive announcements (transactional), live posted-announcements panel, search

Cross-cutting

    All write operations use SQL transactions (atomic update + audit log)

    All queries are parameterized (SQL injection-safe)

    Soft delete for announcements (is_archived flag preserves audit trail)

    Foreign key constraints enforce referential integrity

Team

Project group of 5, LPU-C.

# UniConnect

A comprehensive, cross-platform student portal built for LPU (Lyceum of the Philippines University) as a final capstone project. 

UniConnect provides a unified experience across a **C# WinForms Desktop Application** and a **Web Companion Portal**. It offers separate interfaces for students (viewing grades, tracking GWA, reading announcements) and administrators (encoding grades, posting announcements, reviewing audit logs), all synchronized in real-time through a PHP REST API and backed by MS SQL Server.

## Tech Stack

**Desktop Application:**
- **C# WinForms** (.NET Framework) — Desktop UI
- **ADO.NET** (`Microsoft.Data.SqlClient`) — Direct data access layer

**Web Companion & API:**
- **PHP 7/8 (PDO)** — Backend RESTful API endpoints
- **HTML5, CSS3, Vanilla JavaScript** — Responsive web frontend using the Fetch API
- **XAMPP** — Local web server environment (Apache)

**Database:**
- **MS SQL Server Express** — Relational database

## Project Structure

```text
UniConnect-Repo/
├── UniConnect/                 # C# Desktop Application
│   ├── Models/                 # POCO data classes
│   ├── Database/               # Data access layer & Session state
│   ├── Resources/              # App imagery
│   └── frm*.cs                 # Windows Forms (Login, Dashboard, etc.)
│
├── UniConnectAPI/              # PHP REST API Backend
│   ├── config/                 # database.php connection string
│   └── api/                    # Endpoint folders (auth, students, grades, admin, announcements)
│
├── UniConnectWeb/              # Web Portal Frontend
│   ├── index.html              # Student Web Login
│   ├── admin_login.html        # Admin Web Login
│   └── *.html                  # Web Dashboards, Grades, and Announcement pages
│
├── DatabaseScripts/            # SQL setup files (run in order)
│   ├── 01_create_database.sql
│   ├── 02_create_tables.sql
│   ├── 03_seed_data.sql
│   └── 04_announcement_reads.sql
│
├── .gitignore
├── .gitattributes
└── README.md
```



## Setup Instructions

To run this full-stack project locally, you need to set up the Database, the Web/API Server, and the Desktop Application.

**1. Install Prerequisites**

    Visual Studio (Community edition is fine) with the .NET Desktop Development workload.

    MS SQL Server Express: Download from Microsoft, select "Basic" installation.

    SQL Server Management Studio (SSMS): Download and install to manage the database.

    XAMPP: Download and install to run the Apache web server and PHP.

**2. Set up the Local Database**

    Open SQL Server Management Studio (SSMS) and connect to your local server (usually localhost\SQLEXPRESS or YourComputerName\SQLEXPRESS).

    Go to File > Open > File... and open the scripts inside the DatabaseScripts/ folder.

    Execute them in this exact order (press F5):

        01_create_database.sql

        02_create_tables.sql

        03_seed_data.sql

        04_announcement_reads.sql

**3. Set up the Web Portal and API**

    Open your XAMPP installation folder (usually C:\xampp\htdocs\).

    Copy the UniConnectAPI and UniConnectWeb folders from this repository and paste them directly into the htdocs folder.

    Open the XAMPP Control Panel and click Start next to Apache.

    To access the web portal, open your browser and go to: http://localhost/UniConnectWeb/index.html

**4. Configure and Run the Desktop App**

    Open UniConnect.slnx in Visual Studio.

    Open App.config in the UniConnect project root.

    Verify the connection string. By default, it is:
    XML

    Server=localhost\SQLEXPRESS;Database=UniConnectDB;Integrated Security=True;TrustServerCertificate=True;

    (If your local SQL Server uses a different instance name, edit the Server= portion).

    Do the same for the API: Open C:\xampp\htdocs\UniConnectAPI\config\database.php and ensure $serverName matches your SQL Server instance.

    Press F5 in Visual Studio to run the desktop application.

## Default Test Credentials

**Student**

    Email: juan.delacruz@lpu.edu.ph

    Password: student123
    (Other seeded student emails: maria.clara@lpu.edu.ph, padre.damaso@lpu.edu.ph, etc.)

**Admin**

    Email: admin@lpu.edu.ph (Juan Santos, ICT Admin)

    Password: admin123
    (Other seeded admin emails: registrar@lpu.edu.ph, encoder@lpu.edu.ph)

## Features
**Student Portal (Desktop & Web)**

    Secure Login: Database-validated authentication.

    Dashboard: Unified notifications feed (Web), GWA tracking, enrolled units, year level, and recent grades preview.

    My Grades: Full grade history with dynamic semester filtering (newest first), color-coded status badges, and CSV Grade Report export.

    Announcements: Full list with read-receipt tracking, expand-on-click details, audience badges, and search functionality.

**Admin Portal (Desktop & Web)**

    Admin Dashboard: High-level metrics (total students, pending grades), recent grade entries table, and a live audit log feed.

    Encode Grades: Search students by ID/Name, dynamically edit or remove grades with smart validation.

    Post Announcements: Compose announcements with audience targeting, archive old announcements, and view posting history.

**Advanced System Architecture**

    API Synchronization: The Web Portal and Database communicate exclusively through a custom-built PHP REST API.

    Atomic Transactions: All database writes (encoding grades, posting/archiving announcements) use SQL transactions ensuring updates and audit logs are saved simultaneously.

    Automated Audit Logging: Every administrative action is permanently logged in the audit_logs table.

    Data Integrity: Soft deletion for announcements (is_archived flag) and strict foreign key constraints.

    Query Optimization: Parameterized queries to prevent SQL injection and indexed primary keys (student_id, subject_code) for rapid retrieval.

## Team

Developed by a project group of 5 at LPU-Cavite.

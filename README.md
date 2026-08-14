SlothSec Risk Analysis Suite
CVSS + OWASP Risk Calculator • ASP.NET Web API • Console Client • Automated Tests
The SlothSec Risk Analysis Suite is a multi‑project .NET solution that calculates, stores, and manages cybersecurity risk scores using both CVSS (Common Vulnerability Scoring System) and OWASP Risk Rating methodologies.
This project demonstrates full‑stack C# development, API design, CRUD operations, automated testing, and clean architecture — built as my final project for the Code:You Software Development Program.

Project Structure

1. SlothSec.WebAPI (ASP.NET Core Web API)
Provides REST endpoints for:

CVSS scoring

OWASP scoring

Combined risk scoring

Full CRUD operations using in‑memory storage

Includes:

Controllers

Models

A static RiskStore class acting as an in‑memory database

2. SlothSec.ConsoleApp (API Consumer)
A C# console application that:

Collects validated numeric input

Sends data to the WebAPI

Displays CVSS, OWASP, and combined risk scores

Shows severity classification

Demonstrates clean input validation and user interaction

3. SlothSec.RiskCore.Test (Automated Tests)
An xUnit test suite that validates:

CVSS calculator logic

OWASP risk engine

Input validation helpers

Edge cases and expected behavior

All tests pass successfully.

                    How Scoring Works
CVSS (Common Vulnerability Scoring System)
Your app uses four base metrics:

Attack Vector (AV)

Attack Complexity (AC)

Privileges Required (PR)

User Interaction (UI)

Each metric is scored 0–10.
The CvssCalculator converts these into a Base Score using weighted math inside the RiskCore library. 

Example:

Code
AV = 5  
AC = 5  
PR = 5  
UI = 5  
CVSS Score = 5.00
OWASP Risk Rating
OWASP uses two values:

Likelihood (1–9)

Impact (1–9)

Your app calculates:

Code
OWASP Score = Likelihood × Impact
Example:

Code
Likelihood = 5  
Impact = 5  
OWASP Score = 25
Combined Risk Score
Your app blends both scoring systems:

Code
Combined Score = (CVSS × 0.6) + (OWASP × 0.4)
Example:

Code
CVSS = 5  
OWASP = 25  
Combined = 13
Severity Levels
Score Range	Severity
≥ 8.0	CRITICAL
≥ 6.0	HIGH
≥ 4.0	MEDIUM
< 4.0	LOW


                 CRUD Operations (In‑Memory Storage)
The WebAPI includes full CRUD support using a static in‑memory store:

POST /api/risk → Create a new risk record

GET /api/risk → Retrieve all records

GET /api/risk/{id} → Retrieve a single record

PUT /api/risk/{id} → Update a record

DELETE /api/risk/{id} → Delete a record

This satisfies the final project requirement for persistent in‑memory data.

                 How to Build & Run
Prerequisites
.NET 8 or .NET 10 SDK

Visual Studio Code or Visual Studio

Git

Clone the Repository
bash
git clone https://github.com/<your-username>/CVSS-OWASP.git
cd CVSS-OWASP
Run the WebAPI
bash
cd SlothSec.WebAPI
dotnet run
Swagger UI will be available at:

Code
https://localhost:<port>/swagger
Run the Console App
bash
cd SlothSec.ConsoleApp
dotnet run
Run Automated Tests
bash
dotnet test
Expected output:

Code
total: 7, failed: 0, succeeded: 7
                      What I Learned
This project brought together everything from the course:

 Building APIs
Controllers, routing, models, and in‑memory storage.

 Consuming APIs
Sending requests from a console app and handling responses.

 CRUD Operations
Create, read, update, and delete risk records.

 Automated Testing
Using xUnit to validate logic and ensure reliability.

 Clean Architecture
Separating UI, API, business logic, and tests.

 Real‑World Development Workflow
GitHub repo structure, debugging, refactoring, documentation.

 If I Had More Time…
I would add:

 Database Integration
Replace in‑memory storage with SQL Server or PostgreSQL using EF Core.

 Full UI Dashboard
Expand the Blazor or WPF client into a full risk analysis dashboard.

 Authentication
Add API key or JWT authentication.

 Reporting
Generate PDF or HTML risk reports.

 More Tests
Add integration tests for the WebAPI and UI tests for Blazor.

The SlothSec Risk Analysis Suite represents the full journey through the Code:You program — from basic C# syntax to full API development, testing, and multi‑project architecture.
It also serves as a strong portfolio piece demonstrating real‑world software engineering skills.

Thank you for reviewing this project.

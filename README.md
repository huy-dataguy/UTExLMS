# 🎓 UTExLMS – University of Technology e-Learning Management System

## 📌 Project Overview

**UTExLMS** is a database-driven e-learning management system designed to support online teaching and learning activities. It enables lecturers to manage courses and teaching content, students to track progress and complete assignments/tests, and administrators to control user accounts and oversee learning operations. The system is built with **SQL Server**, **Entity Framework**, and follows the **MVVM design pattern** in its application layer.

---

## 🎯 Objectives

* Build a **relational database schema** for a full-featured LMS.
* Implement triggers, procedures, and functions to automate business logic.
* Provide student, lecturer, and admin roles with role-based functionality.
* Ensure accurate progress tracking and academic performance assessment.

---

## 👥 Target Users

* **Students**: Access course content, submit assignments, take tests, track progress, and participate in discussions.
* **Lecturers**: Manage content, assignments, quizzes, and student performance.
* **Admins**: Manage user accounts and course structures, ensure system stability.

---

## 🧠 Technologies Used

| Technology                  | Purpose                                             |
| --------------------------- | --------------------------------------------------- |
| **SQL Server**              | Relational database system                          |
| **Entity Framework (EF)**   | ORM for database access via C# in MVVM projects     |
| **C# (WinForms/WPF)**       | Build application with data-binding features        |
| **LINQ**                    | Query abstraction for accessing EF data             |
| **Triggers & Stored Procs** | Automate database logic                             |
| **MVVM Pattern**            | Maintain clear data flow and separation of concerns |

---

## 🏗️ Database Schema Overview

* Entity Relationship Model designed based on educational workflows.
* Tables: `Person`, `Roles`, `Course`, `Section`, `Test`, `Material`, `Assignment`, `Discussion`, `Comment`, etc.
* Core concepts include:

  * **Modular Course Structure** (Course → Section → Element)
  * **Test & Assignment Management** with automated grading and submission tracking
  * **User Roles** with permission-based access and operations

---

## 🔄 Key Functionalities

### 🔐 Authentication & Role Management

* Login via email and password
* Roles: Admin, Lecturer, Student

### 📚 Course Management

* Create, update, delete courses and assign lecturers
* Add sections and elements (tests, materials, assignments)

### 🧑‍🏫 Lecturer Tools

* Upload materials, create tests & questions
* View student submissions and test scores
* Monitor class performance

### 👨‍🎓 Student Tools

* View courses and learning progress
* Submit assignments and answer tests
* Join discussions and comment threads
* Receive deadline notifications (assignments & tests)

### 🧠 Smart Features

* **Triggers** to auto-calculate progress and scores
* **Stored procedures** for course element creation
* **Functions** for retrieving course data and deadlines dynamically

---

## 🛠️ Database Logic

* **Triggers**: Auto-update progress, delete related student data, validate deadlines
* **Stored Procedures**: CRUD operations for courses, assignments, materials, tests
* **Functions**: Retrieve user/course data, student answers, comments, and deadlines

---

## 🖥️ Application Features (via EF + MVVM)

* Use **Entity Framework** for object-relational mapping
* **DbContext configuration** for secure SQL Server connection
* Support for `ObservableCollection`, `DataBinding`, and rich UI interactions

---

## 🔧 Project Structure

```
├── Models/                # Entity classes generated via EF
├── Services/              # Logic for interacting with DB via EF
├── Views/                 # User interface components (MVVM Views)
├── Triggers/              # SQL triggers for automation
├── StoredProcedures/      # SQL scripts for business logic
├── Functions/             # SQL functions for queries and retrieval
```

---

## 🚀 Future Improvements

* Web-based frontend for cross-platform access
* Integration with cloud-based storage (e.g., Azure Blob for file uploads)
* Real-time notifications using SignalR or similar technologies
* AI-enhanced features (personalized learning paths, plagiarism detection)

---

## 📚 Sample Use Cases

* 🧑 Student logs in → joins courses → views materials → submits assignments → sees deadline reminders
* 👩‍🏫 Lecturer creates quiz → monitors submissions → updates grades → views class progress
* 👨‍💼 Admin adds new users → assigns roles → monitors system-wide activities


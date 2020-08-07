# DrSneuss

#### Latest version date 2020/08/07

#### By Erich Richter

## Description
This application uses MySQL and Entity to create a webpage that allows Dr. Sneuss to keep track of what engineers and machines he has and what engineer can use what machines.

## Specifications

1. **Behavior:** The user is welcomed with a splash page and given the option to view Courses or view Students.
* **Input Example:** "View Stylists" or "View Clients"
* **Output Example:** / or / 

2. **Behavior:** The user can add a new Student with their name and date of enrollment.
* **Input Example:** "Add a Student"
* **Output Example:** //

3. **Behavior:** The user can add a new Course with the course name and course number.
* **Input Example:** "Add new Course"
* **Output Example:** //

4. **Behavior:** The user can assign students to a course (a single course can have many students and a single student can have many courses).
* **Input Example:** "Add Student to Course"
* **Output Example:** ///{}

5. **Behavior:** The program will allow the user to delete a Course.
* **Input Example:** "Delete Course"
* **Output Example:** ///{}

5. **Behavior:** The program will allow the user to delete a Student.
* **Input Example:** "Delete Student"
* **Output Example:** ///{}

4. **Behavior:** The user can edit existing Courses and Student information
* **Input Example:** "Edit Course Info" or "Edit Student Info"
* **Output Example:** ///{}

## Setup and Installation

Software Requirements
1. .NET framework
2. A code editor (Visual Studio Code, Atom, etc.)

Acquire The Repo:
1. Click the 'Clone or Download Button
2. Alternately, Clone via Bash/GitBash: `git clone {repo}`

Editting the Code Base:
1. Open the project in your code editor; with Bash, this is done by navigating to the project directory, then `code .`
2. If you wish to run testing, you'll need the testing packages: navigate into the .Tests folder, and run `dotnet restore`

Running the program:
1. To run the program, you'll need to compile the code: `dotnet build`. This will create a compiled application in the bin/ folder.
2. Alternately, you can run the program directly with `dotnet run`.

## MySQL Installation and Setup

1. Download the MySQL Web Installer from the [MySQL Downloads](https://dev.mysql.com/downloads/file/?id=484914) with the "No thanks, just start my download" link.
2. Follow along with the installer:
* Click "Yes" if prompted to update.
* Accept license terms.
* Choose Custom setup type.
* When prompted to Select Products and Features, choose the following:
  * MySQL Server 8.0.19 (This will be under "MySQL Servers > MySQL Server > MySQL Server 8.0")
  * MySQL Workbench 8.0.19 (This will be under "Applications > MySQL Workbench > MySQL Workbench 8.0")
* Select "Next", then "Execute". Wait for download and installation. (This can take a few minutes.)
* Advance through Configuration as follows:
  * High Availability set to "Standalone".
  * "Defaults are OK" under Type and Networking.
  * Authentication Method set to Use Legacy Authentication Method.
  * Set password to epicodus. You can use your own if you want but epicodus will be assumed in the lessons.
  * Defaults are OK under Windows Service. Make sure that checkboxes are checked for the options "Configure MySQL Server as a Windows Service" and "Start the MySQL Server at System Startup". Under Run Windows Service as..., the "Standard System Account" should be selected.
* Complete Installation process.

Create a local database:
1. Open MySQL WorkBench and the click on Local Insstance 3306.
2. Click the plus symbol in the top left corner of the window "Create a new SQL tab for executing queries"
3. Then copy and pase the following code into the window to create your database.

```
DROP DATABASE IF EXISTS `spencer_moody`;
CREATE DATABASE `spencer_moody`;

DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `ClientId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `ContactInfo` varchar(255) DEFAULT NULL,
  `StylistId` int DEFAULT '0',
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `stylists`;
CREATE TABLE `stylists` (
  `StylistId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Specialty` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`StylistId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```

4. Once the following code has been added to the window click "Execute the selected portion of the script or everything, if there is no selection" (it is the lightning bolt icon).

## Bugs

No bugs

## Tech used

* C#
* .NET Core
* Entity Framework
* MySQL

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

Copyright (c) 2020 Spencer Moody
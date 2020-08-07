# DrSneuss

#### Latest version date 2020/08/07

#### By Erich Richter

## Description
This application uses MySQL and Entity to create a webpage that allows Dr. Sneuss to keep track of what engineers and machines he has and what engineer can use what machines.

## Specifications

1. **Behavior:** The user is welcomed with a splash page and given the option to view Machines or view Engineers.
* **Input Example:** "view Machines " or "view Engineers"
* **Output Example:** / or / 

2. **Behavior:** The user can add a new engineer with their name and date of hire.
* **Input Example:** "add engineer"
* **Output Example:** //

3. **Behavior:** The user can add a new machine with the machine name and machine number.
* **Input Example:** "Add new machine"
* **Output Example:** //

4. **Behavior:** The user can assign engineers to a tool (a single engineer can have many machines and a single machine can have many engineers).
* **Input Example:** "Add engineer to machine"
* **Output Example:** ///{}

5. **Behavior:** The program will allow the user to delete a machine.
* **Input Example:** "Delete machine"
* **Output Example:** ///{}

5. **Behavior:** The program will allow the user to delete an engineer.
* **Input Example:** "Delete engineer"
* **Output Example:** ///{}

4. **Behavior:** The user can edit existing machines and engineer information
* **Input Example:** "Edit machineInfo" or "Edit engineer Info"
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
3. Run a command in the root directory of the project that looks like this: > `dotnet ef migrations add Initial`.
4. Then run the following command: > `dotnet ef database update`.


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

Copyright (c) 2020 Erich Richter
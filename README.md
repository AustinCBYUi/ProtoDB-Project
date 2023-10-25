# ProtoDB Project | CSE210 CSharp Class Final
## Programmed by Austin Campbell, Founder of RipTide Interactive.

*FUTURE* This project is a WIP for my school's final project. The CLI will feature local logging to a database, and contains commands ranging from project/field starting assistance, to class notes that can be configurated to add as entries / fields or all as one with multi-line returns, and bill pay reminder / paycheck logging tools for financial benefit. Possibly, this CLI will be a tool to enhance my own workflow depending on other commands I choose to add.

*Due to time constraints and SQLite issues, I decided to scrap the database and return to it at another time. This also includes Policies.cs as I didn't have time to continue researching the decrypt/encrypt.*
*All commands are functional, ProgramPlanner|ProgramClass|ProgramFields|PlannerParent are the only classes that actively practice polymorphism and major inheritance*


Project currently writes text data to the ProtoDB Project/src/data/Debug/net6.0/ folders, so any commands you utilize will deliver there for the time being.

**Working Commands**
* `-pd` - Opens Program/Product Designer Module
* `-cde` - Opens Class Editor Module
* `-fd` - Opens Fields Designer Module
* `exportpd` - Exports Program Design to a formatted text file
* `-notes` - Opens the Notepad Module
* `-help`/`-h`/`/?` - Displays all commands
* `-help (cmd)` - Displays information for command usage
* `-createbp` - Creates a Simple Bill Pay Reminder
* `-savebp` - Saves Bill Pay Reminder to a text file
* `-viewbp` - Views all Bill Pay Reminders in format and color coded.
* `-quit` - Exits entire program

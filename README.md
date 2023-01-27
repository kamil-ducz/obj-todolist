BACKEND:

1. Clone the repository to your local machine. To do this, click on green button "Code" when on repository view and copy the URL. 
   Use Git Bash command git clone https://github.com/kamil-ducz/obj-todolist.git or Tortoise Git to easily clone the repository. 
   Also, any other program you prefer can be a good choice for this.
2. Checkout to the preferred branch. Main branch of the application is master, working branch is development.
3. Launch the .sln file in Visual Studio. Set startup project to WebApi if not set already.
4. Restore the database backup in your SSMS locally.
Database .bak file here: https://drive.google.com/file/d/1ycSpMGQandUM6nLN1Y_4FHR8l1nKKJe8/view?usp=sharing
Database file contains creation date in its name, so please make sure that after restoration in SSMS name of local db is "ToDoList"(you can also modify connection string in backend project accordingly if required).
5. Launch the application in Visual Studio.

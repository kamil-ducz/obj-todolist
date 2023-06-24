Local setup

1. Clone the repository to your local machine. To do this, click on green button "Code" when on repository view and copy the URL. 
   Use Git Bash command git clone https://github.com/kamil-ducz/obj-todolist.git or Tortoise Git to easily clone the repository. 
   Also, any other program you prefer can be a good choice for this.
2. Checkout to the preferred branch. Main branch of the application is master, working branch is development. Both are fine choice.
3. Launch the .sln file in Visual Studio. Set startup project to WebApi if not set already.
4. Use Visual Studio PackageManager to use backend migrations by command "UpdateDatabase". This should create and seed database locally.
5. Go to frontend folder of the project.
6. Assuming you have NodeJS installed on your computer, use command "npm install" and then "npm start" inside the folder.
7. When backend and frontend are running together, access URL in your browser. Typically it is localhost:4200 but you can always find active port for frontend server at the end of "npm start" command in command line.
8. Make sure on what port is working backend API after running. Then check envrionment.ts file in Angular project if URLs match with each other.
9. Test the app.

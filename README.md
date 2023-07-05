Local setup

1. Clone the repository to your local machine.
2. Checkout to the development branch.
3. Open backend project
4. Use Visual Studio PackageManager to use backend migrations by command "UpdateDatabase". This should create and seed database locally.
5. Go to frontend folder of the project.
6. Assuming you have NodeJS installed on your computer, use command "npm install" and then "npm start"
7. When backend and frontend are running together, access URL in your browser. Typically it is localhost:4200 but you can always find active port for frontend server at the end of "npm start" command in command line.
8. Make sure on what port is working backend API after running. Then check envrionment.ts file in Angular project if URLs match with each other.
9. Test the app.

## Intro
We can use this project as the foundation for our capstone. We will build off of this using Asp.net Core backend and an Angular front end. Both client and server code are in the same project to keep things as simple as possible. We will use our skills to build MVC controllers to provide the data to our front end Angular web app. The data will be stored using Entity Framework with SQL, and the database will be built with EF data migrations. To interact with the data, we will build Angular components to provide the functionality of being able to view and create data through a web browser.

## Prerequisites
* Installed:
	* Visual Studio 2019
	* donet core 3.0
	* node
	* dotnet-ef 3.0
* Knowledge of: 
	* Asp.net core with MVC
	* Entity Framework
  * Angular	 
* For production
  * Azure account

## Setup
* Fork
* Clone
* Open in Visual Studio 2019 and push play


## /ClientApp
We are used to working on an Angular app that is based on the root level. In this project, because its both client and server, the Angular things are in the ClientApp folder. In this folder is the same folder structure we are used to from using a typical ng new project or stack blitz. When you need to create your angular components, services, etc.,  work out of this folder

## Deploy
* Remember to upload the certificate `capstone.pfx`
* The certificate password is `capstone`
* Make sure to add the application setting `WEBSITE_LOAD_CERTIFICATES` with the value of the certificate thumbprint

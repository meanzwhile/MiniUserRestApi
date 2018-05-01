# MiniUserRestApi
Mini api for storing and retreiving data about users.

Api Secret key: SuperSecretKey1234

Api endpoints:

  [GET]    api/user      -> get all users in an array
  
  [GET]    api/user/{id} -> get specific user by its id
  
  [POST]   api/user      -> create new record with data from the body
  
  [DELETE] api/user/{id} -> delete user by its id
  

To run the project:

-In Startup.cs at the ConfigureServices() func, change the connection string for your server, and to the desired database.(Choose a Database name that not exists yet.)

-Build the project.

-Navigate in command prompt to the folder where the Project! is (eg: C:\SomeFolder\SomeOtherFolder\MiniUserRestApi\MiniUserRestApi)
 then run:
 
 dotnet ef database update
 
 (this should create the db from the migration files)
 
-The Project should run after these.

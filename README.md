# OpenWeatherMapAPI

Steps to configure the API
--------------------------
1) Go to the project root directory and find weatherdata.txt file.
2) Copy the file to your desired local directory.
3) Go to the application host project and find appsetting.json file.
4) Go to the InMemoryDatabase of appsetting section and set DatabasePath which is the file you copied in step 2. Please see the example below.

  "InMemoryDatabase": {
    "DatabasePath": "C:\\weatherdata.txt"
  }
  
5) Run the application.

6) Good Luck.



The application is structured in to
------------------------------------
1) Application layer
2) Application Contract

3) Domain Layer
4) Repository Layer
5) Unit Test
Note:- you can also run the test to see how the application reacts with a mock data





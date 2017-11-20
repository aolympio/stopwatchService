#Stopwatch service

This solution itends to invoke REST API methods in order to handle Stopwatch infos such as retrieving stopwatches by an atuthenticated user or create/reset stopwatches.
The stopwatch source code can be found in [GitHub]: https://github.com/aolympio/stopwatchService
The deployed stopwatch service can be found in http://stopwatchservice.azurewebsites.net

#API available URIs
Those URIs are available into this solution:
- POST /api/token (Creates the OAuth token for Accredited users):
	- http://stopwatchservice.azurewebsites.net/api/token
- GET /api/stopwatch (Retrieves stopwatches you own):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 
- GET /api/stopwatch/[stopwatch name] (Retrieves stopwatches you own whith the desired search name):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 
- POST /api/stopwatch (Create stopwatch or, in case it already exists, Reset this one):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 


## Architecture
The tecnologies used in this solution were:

- OWIN (Katana)
- Web API 2
- .NET Framework 4.6.1
- Windows Azure Table Storage 


## Tasks done
- [x] Implement OWIN Authentication
- [X] Implement OAuth Authentication to secure the API
- [X] Implement /api/token URI including all Backend stuff (Business Rules and Data Access)
- [x] Implement POST /api/stopwatch including all Backend stuff (Business Rules and Data Access)
- [x] Implement GET /api/stopwatch including all Backend stuff (Business Rules and Data Access)
- [x] Implement GET /api/stopwatch/[stopwatch name] including all Backend stuff (Business Rules and Data Access)
- [X] Create Azure App Service Plan and App Service
- [x] Store data in Azure Table Storage


### Improvements

Usage of:
- TDD(Unit and Integration) in order to enhance code coverage:
	- When will be necessary perform unit tests whose would need to access DB, create a Mock whcih implements an interface IDataAccess and make BaseDataAccess implemetn this one also.
	- This way, the tests won't be better without needness to access DB. 
- Swagger in order to enhances the documetation and take approvement on the in o code and instructions.
- Change the system to vastly use Async Calls in order to enhance peformance.



# STOPWATCH SERVICE

This solution intends to invoke REST API methods in order to handle Stopwatch info such as retrieving stopwatches by an authenticated user or create/reset stopwatches.

The stopwatch source code can be found in [GitHub]:
- https://github.com/aolympio/stopwatchService

The deployed stopwatch service can be found in:
- http://stopwatchservice.azurewebsites.net

## Architecture
The tecnologies used in this solution were:

- OWIN (Katana)
- Web API 2
- .NET Framework 4.6.1
- Windows Azure Table Storage 
- POSTMAN as client API testing

## Nuget dependecies-packages to be installed

- WindowsAzure.Storage
- WindowsAzure.ConfigurationManager
- Microsoft.Azure.KyVault.Core
- Microsoft.Owin
- Microsoft.AspNet.WebApi.Owin
- Microsoft.Owin.Security.Oauth
- Microsoft.Owin.Cors
- Microsoft.Owin.Host.SystemWeb
- Microsoft.AspNet.Cors -Version 5.0.0
- Microsoft.AspNet.WebApi

## API available URIs
Those URIs are available into this solution and working ok in POSTMAN:
- POST /api/token (Creates the OAuth token for Accredited users):
	- http://stopwatchservice.azurewebsites.net/api/token
		- Header:
			- Content-Type = application/x-www-form-urlencoded
		- Body:
			- username = [some username]
			- password = [some password]
			- grant_type = password
- GET /api/stopwatch (Retrieves stopwatches you own):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 
		- Header:
			- Authorization = [token obtained at api/token]
- GET /api/stopwatch/[stopwatch name] (Retrieves stopwatches you own with the desired search name):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 
		- Header:
			- Authorization = [token obtained at api/token]
- POST /api/stopwatch (Create stopwatch or, in case it already exists, Reset this one):
	- http://stopwatchservice.azurewebsites.net/api/stopwatch 
		- Header:
			- Authorization = [token obtained at api/token]
		- Body (at POSTMAN, set raw radio option)
			- Enter stopwatch name value: "[stopwatch name value]"


## Tasks done
- [x] Implement OWIN Authentication
- [X] Implement OAuth Authentication to secure the API
- [X] Implement /api/token URI including all Backend stuff (Business Rules and Data Access)
- [x] Implement POST /api/stopwatch including all Backend stuff (Business Rules and Data Access)
- [x] Implement GET /api/stopwatch including all Backend stuff (Business Rules and Data Access)
- [x] Implement GET /api/stopwatch/[stopwatch name] including all Backend stuff (Business Rules and Data Access)
- [X] Create Azure App Service Plan and App Service
- [x] Store data in Azure Table Storage


## Improvements

Usage of:
- TDD(Unit and Integration) in order to enhance code coverage:
	- When will be necessary perform unit tests whose would need to access DB, create a Mock which implements an interface IDataAccess and make BaseDataAccess implement this one also.
	- This way, the tests won't be better without necessity to access DB. 
- Swagger in order to enhances the documentation and take approvement on the in o code and instructions.
- Change the system to vastly use Async Calls in order to enhance performance.

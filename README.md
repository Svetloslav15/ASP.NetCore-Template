# 💻 Extended Clean Architecture Solution Template
Template for building ASP Net Core MVC apps. This is a solution template for creating Enterprise projects with ASP.NET Core.
</br>
***
### If you like this template, give me a star ⭐.
***
## Overview
### Core
The Application Core holds the business model, which includes entities, services, and interfaces. These interfaces include abstractions for operations that will be performed using Infrastructure, such as data access, file system access, network calls, etc. Sometimes services or interfaces defined at this layer will need to work with non-entity types that have no dependencies on UI or Infrastructure. These can be defined as simple Data Transfer Objects (DTOs).
### Infrastructure
The Infrastructure project typically includes data access implementations. In a typical ASP.NET Core web application, these implementations include the Entity Framework (EF) DbContext, any EF Core Migration objects that have been defined, and data access implementation classes. The most common way to abstract data access implementation code is through the use of the Repository design pattern.
### Web
The user interface layer in an ASP.NET Core MVC application is the entry point for the application. This project should reference the Application Core project, and its types should interact with infrastructure strictly through interfaces defined in Application Core. No direct instantiation of or static calls to the Infrastructure layer types should be allowed in the UI layer.
### Tests
This layer is for tests, you can write both unit tests and integrational tests.
### Common
This layer is for global constants or files that are used in others layers.

 ## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* AutoMapper
* Selenium
* XUnit 2.2.4

## Support
If you are having problems, please let us know by https://github.com/Svetloslav15/ASP.NetCore-Template/issues/new
## License
This project is licensed with the [MIT license](LICENSE).

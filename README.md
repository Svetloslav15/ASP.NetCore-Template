# Extended Clean Architecture Solution Template
Template for building ASP Net Core MVC apps. This is a solution template for creating Enterprise projects with ASP.NET Core.
</br>
## Overview
### Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Core
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
### Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
### Web
This layer is a single page application based on Angular 8 and ASP.NET Core 3. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.
### Tests
This layer is for tests, you can write both unit tests and integrational tests.
### Common
This layer is for global constants or files that are used in others layers.

 ## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* AutoMapper
## Support
If you are having problems, please let us know by [raising a new issue]https://github.com/Svetloslav15/ASP.NetCore-Template/issues/new
## License
This project is licensed with the [MIT license](LICENSE).

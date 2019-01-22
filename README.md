# Yaringa

Yaringa project is based on mobile app project inside eShopOnContainer (https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Mobile) from Microsoft.

The mobile app project in eShopOnContainer provides a good demo project for building cross-platform enterprise apps using Xamarin.Forms. But it has the drawbacks below from my personal point of view:

1 The infrastructure part is mixed with app business logic part.
2 The project C# class files are organzied by the class's duty instead of the module the class belongs to.
3 Unit test just covers the app business logic part.

Project Yaringa tries to solve these issues by:

1 Separate the infrastructure part into a separate project (Yaringa) and publish it as nuget for sharing.
2 Organize the app with app's fuctions (modules).
3 Separate unit test project to cover the unit tests for infrastructure part.
3 Create a project template for creating new app projects.
4 Keep the whole project (Yaringa) simple.

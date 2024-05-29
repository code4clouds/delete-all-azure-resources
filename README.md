# Delete All Azure Resources

## Description

This is a .NET 8.0 console application that is designed to manage Azure resources. It uses the Azure.Identity and Azure.ResourceManager.Resources packages to interact with Azure services.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Azure account

### Installation

Clone the repository:

```sh
git clone https://github.com/code4clouds/delete-resources.git
```

Navigate to the project directory:

```sh
cd delete-resources
```

Restore the packages:

```sh
dotnet restore
```

## Usage

To run the application, use the following command:

```sh
dotnet run --project delete-resources.csproj
```

## Build

To build the project, you can use the `build` task defined in the [tasks.json](.vscode/tasks.json) file:

```sh
dotnet build delete-resources.csproj
```

## Publish

To publish the project, you can use the `publish` task defined in the [tasks.json](.vscode/tasks.json) file:

```sh
dotnet publish delete-resources.csproj
```

## Watch

To watch the project for changes and automatically run it, you can use the `watch` task defined in the [tasks.json](.vscode/tasks.json) file:

```sh
dotnet watch run --project delete-resources.csproj
```

## Contributing

If you want to contribute to this project, please submit a pull request.

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.

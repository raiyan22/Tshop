# Tshop

### A simple Web Application featuring a newly created Online T Shirt Store  built on ASP.NET Core MVC architecture
This application was implemented as the Web Development Project for the Course CSE 3100 in my undergraduation level at 2022

#### Prerequisites

- [Microsoft SQL Server Management Studio 18](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [Visual Studio 2019 version with .NET Core SDK 3.1](https://www.microsoft.com/net/download/all)

#### Steps to run

- Update the connection string in **appsettings.json** in Tshop.WebHost
- Build the entire solution.
- In Solution Explorer, make sure that Tshop.WebHost is selected as the Startup Project
- Open Package Manager Console Window and make sure that Tshop.WebHost is selected as Default project. Then type "**Update-Database**" then press "**Enter**". This action will create database schema.
- In Visual Studio, press "**Control + F5**" or simply *run* the project using **IIS Express** pressing the **green play button**
- Admin section can be accessed using the email : raiyan@gmail *.* com with password *1qw2!QW@*

## Technologies and Frameworks used:

- ASP.NET MVC Core 3.1
- Entity Framework Core 3.1.12
- ASP.NET Identity Core 3.1.12

## Programming Languages used:

- C#
- Javascript
- HTML, CSS and Bootstrap

## Features

- Users can register and sign in with their credentials 
- Users can browse available T Shirts, add them to cart and proceed to checkout without signing in into the website 
- Admin can assign or transfer his roles to another user
- Admin can add or modify type of T Shirts
- Admin can add new or edit existing T Shirts or modify their properties
- Admin has the option to lockout or delete a user
- Site specific cookies can be deleted on the go 

## How to contribute

- Star this project on GitHub.
- Report bugs or suggest features by create new issues or add comments to issues
- Submit pull requests

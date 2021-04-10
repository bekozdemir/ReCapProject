# Rent A Car System
> This is an example of rent a car system for todays online websites. Aim of this project is improving my skills and learn new design patterns.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Status](#status)
* [Inspiration](#inspiration)
* [Contact](#contact)

## Technologies
* .NET
* ASP.NET for Restfull API
* EntityFramework
* Autofac
* FluentValidation
* MsSql
* [Angular](https://github.com/bekozdemir/rentacar-frontend)

## Techniques
* AOP
* Layered Architecture
* Autofac DependencyResolver
* JWT
* IOC
* DTO
* Cross Cutting Concerns

## Nuget Packages
* Autofac - v6.1.0
* Autofac.Extensions.DependencyInjection - v7.1.0
* Autofac.Extras.DynamicProxy - v6.0.0
* FluentValidation - v9.5.1
* Microsoft.AspNetCore.Authentication.JwtBearer - v3.1.12
* Microsoft.AspNetCore.Hosting.Abstractions - v2.2.0
* Microsoft.AspNetCore.Http - v2.2.2
* Microsoft.AspNetCore.Http.Features - v5.0.3
* Microsoft.EntityFrameworkCore.SqlServer - v3.1.11
* Microsoft.Extensions.DependencyInjection - v5.0.1
* Microsoft.IdentityModel.Tokens - v6.8.0
* NETStandard.Library - v2.0.3
* Newtonsoft.Json - v13.0.1
* System.IdentityModel.Tokens.Jwt v6.8.0

## Setup
First of all, you need to download the files and open the solution. After that, you have to do some essential configurations.
<ul> 
  <li>Create the sql tables. You can check my sql query from here.</li>
  <li>You should connect your tables with your Entities from CarsCompanyContext.cs</li>
  <li>At CarsCompanyContext.cs you should change the server name with your server name in SQL Server Object Explorer.</li>
</ul>

## Features
List of features ready 
* Login/Register
* Car/Brand/Color Add/Update
* Car/Brand/Color filter options
* Looking details of cars
* Creating rental

## Screenshots
You can see screen shots of the website from [here](https://github.com/bekozdemir/rentacar-frontend/blob/master/README.md).

## Status
Project is: _struggling wtih some bugs and still developing the project_

## Inspiration
This project started to develop paralel with [Engin DEMİROG](https://github.com/engindemirog)'s online developers education camp. I need to thank to engindemirog for his great online course and big heart. Also, I need to thank to this community who helped me with the questions and bugs.

[kodlama.io](https://www.kodlama.io/)

## Contact
Created by [@bekozdemir](https://github.com/bekozdemir/) - feel free to contact with me!

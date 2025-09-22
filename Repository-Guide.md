# Backend Fork Repository Setup Guide

## Step 1
Right Click **CW.Basecode.WebAPI** then **Set as Startup Project**

## Step 2
Press **F5** / Run Project

## Step 3
Install the following in Package Manager Console (set the **Default Project** dropdown to `CW.Basecode.Data`):

```bash
dotnet add ./CW.Basecode.Data package Npgsql.EntityFrameworkCore.PostgreSQL 
dotnet add ./CW.Basecode.Data package Microsoft.EntityFrameworkCore.Design
dotnet add ./CW.Basecode.WebAPI package Microsoft.EntityFrameworkCore.Tools
```

## Step 4
Restart the IDE

## Step 5
Run this command in Package Manager Console (set the **Default Project** dropdown to `CW.Basecode.Data`):

```powershell
Scaffold-DbContext "Host=154.38.160.115;Port=5432;Username=postgres;Password=u75VEbn>^959eun;Database=MiChoisesDevCW" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -ContextDir Context -Context ApplicationDbContext -StartupProject CW.Basecode.WebAPI -Force
```

⚠️ **Note:** Change the DB credentials. The command above is an example for the `MiChoisesDevCW` setup.

## Step 6
Remove the explicit declaration of DB Credentials in `ApplicationDbContext.cs`

## Step 7
In `Program.cs`, add:

```csharp
using CW.Basecode.Data.Context;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## Step 8
Add this in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=154.38.160.115;Port=5432;Username=postgres;Password=u75VEbn>^959eun;Database=MiChoisesDevCW"
}
```

## Step 9
dotnet ./CW.Basecode restore

🏀 Social Sports Hub

Social Sports Hub is a cross-platform mobile app built with .NET MAUI that makes it easy to host, discover, and join local pickup sports games. Whether you’re looking for a quick soccer match, basketball run, or simply want to connect with nearby players — Social Sports Hub helps you find and create games in minutes.

⚙️ Project Setup
🧩 1. Adding the Existing Data Project

Open the Social_Sport_Hub.sln solution in Visual Studio.

In the Solution Explorer, right-click on the solution → Add → Existing Project...

Navigate to the Social_Sport_Hub.Data folder and select the file:

Social_Sport_Hub.Data.csproj


Ensure the project now appears under the solution with the main app project.

🔗 2. Add a Project Reference

To allow the main MAUI project to access data layer components:

In Solution Explorer, right-click the Social_Sport_Hub project → Add → Project Reference...

Check the box next to Social_Sport_Hub.Data and click OK.

If the reference fails to load, manually edit your .csproj file and include the full path:

<ItemGroup>
  <ProjectReference Include="C:\FullPath\To\Social_Sport_Hub.Data\Social_Sport_Hub.Data.csproj" />
</ItemGroup>

💡 Project Overview
🎯 Purpose

Finding people to play casual sports with is often difficult — chat groups get messy, and schedules rarely align. Social Sports Hub centralizes this process, letting players view nearby games, host new ones, and track participation easily.

🧱 Core Features

Map Integration: Displays local games and player locations using Google Maps.

Event Management: Users can create, join, update, or cancel sports events.

Weather API: Shows real-time weather for the selected game day.

Profile System: Displays honor score, player streaks, and basic statistics.

NUnit Testing: Ensures backend logic and data integrity.

Entity Framework Core: Manages database access and LINQ queries.

Responsive UI: Resizable and consistent across Android, iOS, Windows, and macOS.

🧩 Technical Highlights
Category	Implementation
Framework	.NET MAUI
Architecture	MVC Pattern with separate Data Layer
Database	Entity Framework Core (Local SQLite)
APIs Used	Weather API, Google Maps
Testing	NUnit
Language	C#
UI Design	Resizable Forms, Clean Layout, Multiple Unique UI Elements
🧠 Code Structure
Social_Sport_Hub/
│
├── Models/
│   ├── SportEvent.cs
│   ├── User.cs
│   └── WeatherInfo.cs
│
├── Views/
│   ├── MainPage.xaml
│   ├── ProfilePage.xaml
│   ├── MapPage.xaml
│   └── CreateEventPage.xaml
│
├── ViewModels/
│   ├── MainViewModel.cs
│   ├── ProfileViewModel.cs
│   └── EventViewModel.cs
│
├── Data/  <-- separate project
│   ├── Social_Sport_Hub.Data.csproj
│   ├── ApplicationDbContext.cs
│   └── Migrations/
│
└── Tests/
    └── NUnit tests for data and logic

🧪 Bonus Features Implemented

✅ External API (Weather)
✅ Entity Framework Core with LINQ
✅ External Database Integration
✅ MAUI (cross-platform UI instead of WinForms)

# GroceryApp sprint4 Studentversie  

## De GroceryApp is een .NET MAUI applicatie voor het beheren van boodschappenlijsten en producten.

De architectuur volgt MVVM en Single Responsibility Principle (SRP):

Models → domeinobjecten (Product, GroceryList, Client, …)

Repositories → data-opslag

Services → businesslogica (bijv. BoughtProductsService)

ViewModels → UI state en commands

Views → XAML-schermen met databinding

TestCore → unittests voor helpers, models en services

## Code structuur

Core/Models – domeinobjecten

Core/Interfaces – contracten voor repositories en services

Core/Data – implementaties van repositories

Core/Services – businesslogica

App/ViewModels – logica voor binding en state

App/Views – XAML-pagina’s

TestCore – NUnit tests

## Conventies
PascalCase: classes, properties, methods

camelCase: private velden en variabelen

Dependency Injection: voor services en repositories (geregistreerd in MauiProgram.cs)

CommunityToolkit.Mvvm: [ObservableProperty] en [RelayCommand]

LINQ: queries, sortering en filtering

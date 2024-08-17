# Blackjack Game with Windows Forms and Entity Framework Core

## Overview

This repository hosts a C# implementation of the classic Blackjack card game. The game features a very simple Windows Form-based graphical user interface (GUI) and utilizes Entity Framework Core for data persistence. 

## Features

- **Classic Blackjack Gameplay:** Enjoy the traditional Blackjack experience, complete with player vs. dealer scenarios, card shuffling.
- **Windows Forms User Interface:** The game is built using Windows Forms, offering a familiar and easy-to-use interface for players.
- **Data Persistence:** Player information and game results are stored in a local SQL Server database managed by Entity Framework Core, using the Code First approach.
- **Entity Relationships:** The database schema efficiently manages relationships between players and their game outcomes, allowing for detailed tracking of game histories.
- **LINQ Integration:** All database interactions, including data retrieval and manipulation, are performed using LINQ, ensuring efficient and readable code.

## Technology Stack

- **Language:** C#
- **Framework:** .NET 6
- **UI:** Windows Forms
- **Database:** Local MSSQL Server instance
- **ORM:** Entity Framework Core 6
- **Query Language:** LINQ

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- Local MSSQL Server (e.g., SQL Server Express or SQL Server LocalDB)



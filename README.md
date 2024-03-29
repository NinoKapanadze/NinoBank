# NinoBank

NinoBank is a modern banking application built with ASP.NET 8 and Entity Framework. It provides a suite of financial services such as user registration, secure login, balance inquiries, and peer-to-peer money transfers. Utilizing the latest security practices, NinoBank ensures that user data is protected while offering a seamless banking experience.

## Features

- **User Registration**: Secure sign-up process to create a new user account.
- **Authentication**: Login with JWT Bearer Token for a secure session.
- **Account Management**: Functionality to delete the currently logged-in user.
- **Transactions**: Capability to send money to other users within the NinoBank system.
- **User Information**: Access to detailed user profiles, including balance, ID, and transaction history.

## Architecture

NinoBank adopts a layered architecture pattern with a clear separation of concerns:

- **Presentation Layer**: Handles HTTP requests, user authentication, and responses.
- **Application Layer**: Implements the application's use cases and business logic using the CQRS pattern.
- **Domain Layer**: Contains the core domain models and business rules of the application.
- **Infrastructure Layer**: Manages data persistence using Entity Framework and implements the Repository and Unit of Work patterns for database access.

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server 
- Visual Studio

### Installation

1. Clone the repository:
```bash
git clone https://github.com/NinoKapanadze/NinoBank.git

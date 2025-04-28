# User Microservice

A .NET 9.0 implementation following Hexagonal Architecture for user management and authentication.

## Project Structure
```
User/
├── Application/      # Business logic
│   ├── DTOs/         # Data Transfer Objects
│   ├── Interfaces/   # Service contracts
│   └── Services/     # Service implementations
│
├── Domain/           # Core domain models
│   └── Models/       # User, Role, Profile entities
│
├── Infrastructure/   # External implementations
│   ├── Configurations/ # JWT, Email settings
│   ├── Repositories/ # Data access
│   └── Services/     # External services
│
├── Presentation/     # API layer
│   ├── Controllers/  # REST endpoints
│   └── Middlewares/  # JWT authentication
│
└── Startup.cs        # Service configuration
```

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SMTP server (for email functionality)
- Database (implementation pending)

### Installation
```bash
git clone https://github.com/your-repo/users-prototype.git
cd users-prototype/User
dotnet restore
```

### Configuration
Create `appsettings.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Jwt": {
    "Secret": "your-256-bit-secret-key",
    "Issuer": "user-service",
    "Audience": "user-service",
    "ExpiryMinutes": 60
  },
  "Email": {
    "SmtpServer": "smtp.example.com",
    "Port": 587,
    "Username": "user@example.com",
    "Password": "password",
    "UseSSL": true
  }
}
```

### Running the Service
```bash
dotnet run --project User
```

## API Examples

### Register User
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "P@ssw0rd!",
  "firstName": "John",
  "lastName": "Doe"
}
```

### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "P@ssw0rd!"
}
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Forgot Password
```http
POST /api/auth/forgot-password
Content-Type: application/json

{
  "email": "user@example.com"
}
```

## Architecture
![Hexagonal Architecture Diagram](https://miro.medium.com/v2/resize:fit:1400/1*X8h5T8qiKX7OUq_7GyV7Jg.png)

Key Features:
- Clear separation of concerns
- Dependency inversion principle
- Testable components
- JWT-based authentication
- Configurable services

# Usage example:

```
# Check service status
curl http://localhost:5138

# Verify health check
curl -k https://localhost:7138/health

# Test registration (example)
curl -k -X POST https://localhost:7138/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"P@ssw0rd!","firstName":"Test","lastName":"User"}'
```

## Future Improvements
- Add database integration
- Implement password reset flow
- Add role-based authorization
- Add unit/integration tests
- Containerize with Docker
- Add OpenAPI documentation

## License
MIT License

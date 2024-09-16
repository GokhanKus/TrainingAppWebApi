# Training App Web API

This project is a web API designed to manage and track workout routines, body measurements, exercises, and related data. It utilizes various features like filtering, pagination, caching, and more to provide a robust system for fitness tracking.

## Features

### 1. **Sorting**
- Sort workout, exercise, and body measurement data based on any property.
- Generic `OrderQueryBuilder.cs` with `CreateOrderQuery` method is used to dynamically build sort queries.

### 2. **Filtering**
- Filter by different criteria for workout, body measurement, and exercise.
- Supports filtering by duration, calories burned, exercise name, description, difficulty level, and weight features.

### 3. **Rate Limiting**
- Rate limiting is implemented to control the number of API requests a client can make within a time period.

### 4. **Pagination**
- Pagination implemented for all major data models: workout, exercise, and body measurements.
- `PagedList<T>` and `MetaData` classes are used to handle pagination details.

### 5. **Caching**
- Redis caching is implemented for Exercise, ExerciseCategory, Workout, and BodyMeasurement.
- Memory caching is also utilized for repository classes.
- Caching optimizes repeated API calls by reducing the need for database queries.

### 6. **Data Shaping**
- Data shaping allows clients to specify which fields they want in the API response.
- Supported for models such as workout, body measurement, and exercise.

### 7. **Global Error Handling**
- A centralized exception handler ensures consistent error responses across the API.
- Custom exception classes are used for different error scenarios.

### 8. **Authentication & Authorization**
- JWT-based authentication is used to secure the API.
- Supports token refresh and authentication-related operations like user registration and login.
- Protected endpoints with `[Authorize]` attribute.

### 9. **Unit of Work Pattern**
- The Unit of Work design pattern is implemented to manage transactions across repositories.

### 10. **Rate Limiting**
- Configured to prevent excessive requests by a client within a specific period.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/gokhankus/trainingappwebapi.git
2. Navigate to the project directory:
   ```bash
   cd your-repo
3. Install dependencies:
   ```bash
   dotnet restore
4. Configure appsettings.json with the necessary connection strings and JWT secret.
5. Run the project:
   ```bash
   dotnet run

## Usage

You can use this API to:

- **Track Body Measurements**  
  Manage body measurements such as weight, body fat percentage, muscle mass, and waist circumference.
  
  Example:  
  Users can record, update, and retrieve their body measurements via the API, filtering or sorting based on criteria like weight or body fat percentage.

- **Manage Workout Routines**  
  Create, track, and update workouts, including details for each exercise (e.g., sets, reps, weight lifted, or distance).

  Example:  
  Users can create workout plans with exercises, specifying parameters such as sets, reps, weight, or calories burned.

- **Filter and Sort Data**  
  Filter and sort workouts or body measurements based on various criteria like duration, calories burned, or difficulty level of exercises.
  
  Example:  
  Users can sort exercises by difficulty level or filter workouts based on duration or calories burned.

- **Pagination and Caching**  
  Use pagination to handle large datasets and improve performance by caching results using Redis and memory cache mechanisms.
  
  Example:  
  Large result sets from body measurement or workout data can be paginated and cached to optimize API response times.

## Branches

This repository contains several branches, each implementing specific features or functionalities. Below is a list of the available branches:

- **Development**: Main development branch where all features are integrated.
- **Identity**: User authentication and authorization using ASP.NET Identity.
- **UnitOfWork**: Implementation of Unit of Work and repository patterns.
- **Pagination**: Implementation of pagination for large data sets.
- **Filtering**: Filtering capabilities for various entities such as workouts and exercises.
- **Sorting**: Sorting capabilities for workouts, body measurements, and exercises.
- **Redis**: Caching implementation using Redis for improved performance.
- **MemoryCache**: In-memory caching for repositories.
- **RateLimiting**: Rate limiting configuration to manage API request limits.
- **DataShaping**: Dynamic data shaping for returning only selected fields from API responses.
- **GlobalErrorHandling**: Centralized error handling to manage exceptions.
- **ActionFilters**: Custom filters to validate requests and log actions.
- **Logger**: Logging implementation using NLog for tracking API activity.
- **HEAD & OPTIONS**: Support for HEAD and OPTIONS HTTP verbs in controllers.
- **RootDocumentation**: Documentation-related branch.

To switch to a specific branch, use the following command:

```bash
git checkout branch-name
   



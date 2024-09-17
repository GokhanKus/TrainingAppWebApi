# Training App Web API

This project is a web API designed to manage and track workout routines, body measurements, exercises, and related data. It utilizes various features like filtering, pagination, caching, and more to provide a robust system for fitness tracking.

## **Screenshots**
<table>
   <tr>
      <td>
          <img src="https://github.com/user-attachments/assets/5adad337-a988-429f-87ce-a87d124ed13a" alt="Screenshot 1" width="350"/>
      </td>
      <td>
         <img src="https://github.com/user-attachments/assets/5a458573-fe50-4d6f-8834-9ab5a4f5619c" alt="Screenshot 2" width="350"/>
      </td>
   </tr>   
</table>

<table>
  <tr>
      <td>
      <img src="https://github.com/user-attachments/assets/95fab809-42a9-416a-aa8e-215041f7795c" alt="Screenshot 1" width="350"/>
         <br />
      <img src="https://github.com/user-attachments/assets/24531ee1-c887-4791-bf76-5d7b89553b0b" alt="Screenshot 3" width="350"/>
    </td>
    <td>
      <img src="https://github.com/user-attachments/assets/05556f5a-27cf-43af-a084-fb94f0a6247b" alt="Screenshot 2" width="350"/>
      <br />
      <img src="https://github.com/user-attachments/assets/b819e508-11a9-452f-b0a7-8ef0131a518f" alt="Screenshot 3" width="350"/>
    </td>
  </tr>
</table>

## **Screenshots Class Diagram (Repositories) (UoW)**
![image](https://github.com/user-attachments/assets/682a871c-d4be-48f7-8c3a-e0bdad984374)
![image](https://github.com/user-attachments/assets/b3ae2bd0-0e73-4064-a4a5-70997ee7d1b0)

## **Screenshots Class Diagram (Services)**
![image](https://github.com/user-attachments/assets/5ee1824c-6bdd-488b-851f-1d4b5556fe62)

## **Screenshots Class Diagram Entity (Relational Database Diagram)**
![image](https://github.com/user-attachments/assets/7939528f-cff1-4b79-bb47-4818e74b1306)


## Screenshots for BodyMeasurement;
![image](https://github.com/user-attachments/assets/1a4716e7-0361-4d5d-bf4a-10c911b62369)
<table>
   <tr>
      <td>
         <img src= "https://github.com/user-attachments/assets/6990f07c-8272-436b-a4d5-69b22e7b54c1" alt="Screenshot 4" width = "400" />
      </td>
      <td>
         <img src= "https://github.com/user-attachments/assets/950fe92d-e600-460a-9d91-be9fd05f1dd0" alt="Screenshot 4" width = "300" />
      </td>
   </tr>
</table>

## Screenshots for Exercise Category;
![image](https://github.com/user-attachments/assets/c710a99b-2fdf-4b87-bfa4-56efd760a5aa)
![image](https://github.com/user-attachments/assets/90907cc2-faae-4732-a5a4-248c0b06cc76)

## Screenshots for Exercise;
![image](https://github.com/user-attachments/assets/b2193a00-1738-4902-94e4-0c12ab89be87)
<table>
   <tr>
      <td>
         <img src= "https://github.com/user-attachments/assets/d22d64bc-6b58-47ba-a5b1-5dcdb300ab96" alt="Screenshot 4" width = "400" />
      </td>
      <td>
         <img src= "https://github.com/user-attachments/assets/6edae2cc-83a9-438a-a67b-1aec62911598" alt="Screenshot 4" width = "400" />
      </td>
   </tr>
</table>

## Screenshots for Workout;
![image](https://github.com/user-attachments/assets/f3cecbcc-b739-4b2d-8f3b-2c4f9a421124)

<table>
   <tr>
      <td>
         <img src= "https://github.com/user-attachments/assets/c330b503-a26e-4b87-9d76-bd421d25aab8" alt="Screenshot 4" width = "420" />
      </td>
      <td>
         <img src= "https://github.com/user-attachments/assets/c75feef4-df29-4ee4-aeb9-72ab5597a8eb" alt="Screenshot 4" width = "380" />
      </td>
   </tr>
</table>

## Screenshots for Account;
![image](https://github.com/user-attachments/assets/d98ccffc-3d0d-43c2-a6c3-123f85f440ec)
![image](https://github.com/user-attachments/assets/bbd78f4a-4385-4b30-b402-a89b6d010cb9)


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
   



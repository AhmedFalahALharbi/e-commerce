# E-commerce Application with Angular and ASP.NET Core

## Overview
This project is a simple e-commerce application built using Angular for the frontend and ASP.NET Core for the backend. The application allows users to browse products, view product details, and add items to a shopping cart. The backend provides API endpoints for product data and cart operations.

## Features
- **Product List Page**: Displays available products with names, prices, and a "View Details" button.
- **Product Details Page**: Shows detailed information about a selected product.
- **Shopping Cart**: Users can add products to their cart and manage cart items.
- **Routing**: Angular routing is used for navigation between components.
- **Backend API**: ASP.NET Core Web API serves product data and handles cart operations.
- **Error Handling**: Manages API request errors gracefully.
- **Bonus Features** (Optional): Backend API for cart persistence 


## Setup and Installation
### Prerequisites
Ensure you have the following installed:
- **Node.js** (for Angular development)
- **Angular CLI**
- **.NET SDK** (for ASP.NET Core API development)


### Frontend (Angular) Setup
1. Navigate to the frontend folder:
   ```sh
   cd frontend
   ```
2. Install dependencies:
   ```sh
   npm install
   ```
3. Start the Angular development server:
   ```sh
   ng serve
   ```
   The app will be available at `http://localhost:4200/`.

### Backend (ASP.NET Core) Setup
1. Navigate to the backend folder:
   ```sh
   cd ECommerceApp.API
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Run the ASP.NET Core API:
   ```sh
   dotnet run
   ```
   The API will be available at `http://localhost:5174/api/products`.

## API Endpoints
### Product API
- `GET /api/products` - Fetch all products.
- `GET /api/products/{id}` - Fetch a specific product by ID.

### Cart API (Bonus Feature)
- `POST /api/cart/add` - Add a product to the cart.
- `GET /api/cart` - Get all cart items.
- `DELETE /api/cart/{id}` - Remove an item from the cart.


## Submission Guidelines
- Push your complete project to a **GitHub repository**.
- Include all relevant Angular and ASP.NET Core files.
- Ensure that the `README.md` file provides clear setup instructions.


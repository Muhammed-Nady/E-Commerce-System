# E-Commerce Console Application

A comprehensive console-based e-commerce system built in C# to demonstrate advanced Object-Oriented Programming principles and clean code architecture.

## Overview

This project simulates a real e-commerce platform with user authentication, product catalog management, shopping cart functionality, and order processing. I developed this to practice complex OOP concepts and explore how inheritance hierarchies work in practical applications.

The system handles multiple user types, dynamic pricing strategies, and different product categories while maintaining clean, extensible code architecture.

## Features

### Core Functionality
- **Multi-tier user system** with customers (Regular/Premium/VIP) and administrators
- **Product catalog** with 25+ items across electronics, furniture, sports, and digital categories
- **Dynamic pricing engine** that calculates different costs based on product type
- **Smart shopping cart** with customer-specific discounts and real-time totals
- **Inventory management** with stock tracking and availability validation
- **Order processing** with automatic stock updates

### Advanced Features
- **Polymorphic product behavior** - physical products add shipping costs, digital products get automatic discounts
- **Customer tier benefits** - Premium (5% off) and VIP (10% off) automatic discounts
- **Interface-based discount system** allowing flexible discount implementations
- **Brand markup for premium products** with warranty tracking
- **Administrative tools** for different department roles

## Technical Implementation

### Project Structure
```
ECommerceApp/
├── Abstract/
│   ├── Person.cs          # Abstract base class for all users
│   └── Product.cs         # Abstract base class for all products
├── Interfaces/
│   └── IDiscountable.cs   # Contract for discount implementations
├── Entities/
│   ├── Customer.cs        # Customer implementation with tiers
│   ├── Admin.cs           # Administrator with departments
│   ├── PhysicalProduct.cs # Products with shipping costs
│   ├── DigitalProduct.cs  # Downloadable products with discounts
│   └── PremiumProduct.cs  # High-end branded products
├── Core/
│   ├── CartItem.cs        # Shopping cart item wrapper
│   ├── ShoppingCart.cs    # Cart management and calculations
│   └── ECommerceSystem.cs # Main business logic coordinator
└── Program.cs             # Console interface and entry point
```

### OOP Architecture
```
Abstract Classes:
- Person (base for Customer/Admin with abstract GetRole() method)
- Product (base for all products with abstract pricing methods)

Inheritance Chain:
Person → Customer, Admin
Product → PhysicalProduct → PremiumProduct
Product → DigitalProduct

Interfaces:
- IDiscountable (implemented by DigitalProduct and PremiumProduct)
```

### Key OOP Concepts Demonstrated

**Inheritance & Polymorphism**
- Multi-level inheritance with specialized behavior at each level
- Method overriding for `ToString()`, `GetFinalPrice()`, `GetContactInfo()`
- Runtime polymorphism where products calculate prices differently

**Abstract Classes**
- `Person` class enforces `GetRole()` implementation in derived classes
- `Product` class defines contract for pricing and display methods

**Interfaces**
- `IDiscountable` interface allows different discount strategies
- Enables polymorphic discount application across product types

**Encapsulation**
- Private fields with controlled access through public methods
- Protected members in base classes for derived class access
- Proper namespace organization separating concerns

**Composition**
- `ShoppingCart` contains `CartItem` objects and references `Customer`
- `ECommerceSystem` orchestrates all components
- Clear separation between data and behavior



## Design Decisions

**Why Abstract Classes?**
I used abstract classes for `Person` and `Product` because they share common properties but require different implementations of key methods. This enforces consistency while allowing specialization.

**Why Interfaces for Discounts?**
The `IDiscountable` interface allows different products to implement discounts in their own way - digital products get percentage discounts while premium products have markup strategies.

**Why Organized Folder Structure?**
Separating classes into logical folders (`Abstract`, `Interfaces`, `Entities`, `Core`) makes the codebase more maintainable and clearly shows the architectural layers.



## What I Learned

This project deepened my understanding of:
- How inheritance hierarchies work in practice
- When to use abstract classes vs interfaces
- The power of polymorphism for flexible design
- Importance of proper project structure and namespaces
- LINQ for data manipulation and querying

The most challenging part was designing the product hierarchy to handle different pricing strategies while keeping the code maintainable and well-organized.

## Technologies Used

- **Language**: C# with .NET
- **Concepts**: Advanced OOP, LINQ, Collections, Namespaces
- **Patterns**: Abstract Factory (for products), Strategy (for discounts)
- **Architecture**: Layered folder structure with clear separation of concerns

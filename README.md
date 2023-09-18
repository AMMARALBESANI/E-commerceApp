# E-Commerce Application README

Welcome to the E-Commerce Application README! This document provides an overview of the E-Commerce Application, how to use it, and highlights the challenges we faced while applying validation and passing data between views.


## 1. Introduction

The E-Commerce Application is a web-based platform for buying various products, including houseware, kitchen items, and food products. This README provides an overview of the application's controllers, usage, user stories, and the challenges faced in validation and data passing.

## 2. Controllers 

The application is divided into three main controllers, each responsible for managing different aspects of the e-commerce platform.

### 2.1 CategoryController 

The `CategoryController` handles operations related to product categories.

#### Actions:

- **Index**: Displays a list of all product categories.
- **CategoryDetails**: Shows details of a specific category.
- **EditCategory**: Allows authorized users to edit a category's information.
- **AddCategory**: Allows administrators to add new product categories.
- **DeleteCategory**: Allows administrators to delete a category.

### 2.2 DepartmentController 

The `DepartmentController` manages product departments within categories.

#### Actions:

- **Departments**: Lists all departments within a category.
- **DepartmentDetails**: Displays details of a specific department.
- **EditDepartment**: Allows authorized users to edit department information.
- **AddDepartment**: Enables administrators to add new departments.
- **DeleteDepartment**: Allows administrators to delete a department.

### 2.3 ProductController 
The `ProductController` is responsible for managing individual products.

#### Actions:

- **product**: Lists all products within a department.
- **AddProduct**: Allows administrators to add new products.
- **CreateProduct**: Handles product creation.
- **DeleteProduct**: Allows administrators to delete a product.
- **ProductDetails**: Displays details of a specific product.
- **EditProduct**: Allows authorized users to edit product information.
- **GetSuggestions**: Retrieves product suggestions based on user input.
- **GetProductsList**: Lists all products.
- **Search**: Provides a search interface for finding products.

## 3. User Stories 


1. **As a shopper**, I want to browse product categories and see a list of available departments within each category, so I can find the items I'm interested in.

2. **As a shopper**, I want to view product details, including descriptions, prices, and images, so I can make informed purchase decisions.

3. **As a shopper**, I want to search for products by name or keyword, so I can quickly find specific items.

4. **As an administrator**, I want to add new product categories and departments, so I can organize the inventory effectively.

5. **As an administrator**, I want to add new products to the system, including uploading product images, so shoppers can see what's available.

6. **As an administrator**, I want to edit product details, including images, so I can keep product information up to date.

7. **As an administrator**, I want to delete products that are no longer available, so shoppers don't see outdated listings.

8. **As an administrator**, I want to manage categories and departments, including editing their details and deleting them if necessary.

9. **As an authorized user (admin or user with specific roles)**, I want to have proper authentication and authorization to access and perform actions based on my role and permissions.

## 4. Challenges in Validation and Data Passing <a name="challenges"></a>

While developing the E-Commerce Application, we encountered challenges related to validation and data passing between views. Here's how we addressed these difficulties:

# Addressing the Validation Challenge

One of the significant challenges we encountered during the development of the E-Commerce Application was implementing robust and user-friendly validation for the login and registration processes. Ensuring that user data meets specific criteria while providing meaningful error messages presented a complex problem. Here's how we effectively addressed this challenge:

## Complex Data Validation

**Challenge:**
Validating complex data structures, such as user registration details (username, password, email, phone number), was challenging. We needed to enforce various requirements, including minimum and maximum lengths, strong password criteria, and email format validation.

**Solution:**
To tackle this challenge, we made use of data annotations and custom validation attributes provided by ASP.NET Core. Here's how we handled it:

- **Data Annotations:**
  - We utilized `[Required]` attributes to ensure that essential fields, such as `UserName`, `Password`, `Email`, and `PhoneNumber`, were not left empty. This ensured that users provided all the necessary information during registration and login.

- **Custom Validation Attribute - `StrongPasswordAttribute`:**
  - For the `Password` field, we created a custom validation attribute called `StrongPasswordAttribute`. This attribute was designed to enforce strong password requirements, including:
     - Minimum password length (at least 8 characters).
     - Presence of both upper and lower-case characters.
     - Inclusion of digits.
     - Inclusion of special characters (e.g., @, !, #, $, %, ^, &, *).

  This custom attribute allowed us to define and apply strong password criteria and seamlessly integrate it into our validation process.

- **Email Format Validation:**
  - For email validation, we used the `[EmailAddress]` attribute to ensure that the email provided by the user was in a valid format. This attribute checked for the correct email format and returned an error message if the format was incorrect.

- **Phone Number Validation:**
  - To validate phone numbers, we used the `[RegularExpression]` attribute with a regular expression pattern to check for a valid phone number format. This ensured that users entered phone numbers correctly.


### Data Passing Between Views Challenges:

1. **Redirecting with Data**:
   - **Challenge**: Redirecting from one view to another while preserving data, such as form input or success messages, can be challenging.
   - **Solution**: We efficiently passed data between views and actions by using the `include` method to load related data when querying the database. This approach reduced the need for additional requests and improved performance when displaying complex data structures in views.

ess the application through a web browser.



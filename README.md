
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

# E-Commerce Sprint 2 - Milestone 1: Storefront

Consumer Site (The Storefront)
We’ll now switch our attention to the consumer side of our online storefront, building out a system whereby our potential customers can register for an account

, login, and view our current inventory.

User Stories and Tasks
Divide your work evenly amongst your team members.

As a user, I would like to view a list of product categories on the homepage, so I can quickly find the type of product I'm interested in.

As a user, I would like to click on a category to view the products within that category, so I can browse products more effectively.

As a user, I would like to view detailed information about a product, including its name, description, price, and an image, so I can make an informed decision about whether to purchase it.

As a user, I would like to create an account on the website by providing my email and a password, so I can access additional features and save my preferences.

As a user, I would like to log in to my account using my email and password, so I can access my saved preferences and make purchases.

As a user, I would like to see a list of featured products on the homepage, so I can quickly find popular items.

As a user, I would like to search for products by entering keywords or product names, so I can easily find the items I want.



# E-Commerce Sprint 2 - Milestone 2: Shopping Cart

Consumer Site (The Storefront)
Now that we have valid users, and the ability to browse the inventory, it’s time to allow our registered customers the ability to add items to their “Shopping Cart”

This is going to require both a shopping cart page where they can view the full contents of what they’re about to purchase as well as a mini-cart component that can be used on any page.

User Stories and Tasks
Divide your work evenly amongst your team members.

As a user, I would like a way to store the items I wish to purchase in a cart within the application.

As a user, I would like the ability to view my desired purchases while browsing the other products on the site.

As a user I would like a dedicated page where I can view all the products I wish to purpose all in one location.


# E-Commerce Sprint 2 - Milestone 3: Notifications

For this milestone, our goal is simply to create the final 2 pages in the workflow (order and receipt) and execute the communications process … not to accept payment and process the order.

User Stories and Tasks
Divide your work evenly amongst your team members.

As a user, I would like to see a summary of my purchase after completing my checkout process.

As a user, I would like a summary of my purchase to be emailed to me so that I can store the receipt for my records.

As a user, I would like to be thanked for my purchase following completion of order processing.

As an administrator, I would like a copy of all purchases emailed to our sales department so that they can update our accounting system.

As an administrator, I would like a copy of all purchases emailed to our warehouse so that they can begin the fulfillment process.


E-Commerce Sprint 2 - Milestone 4: Payment Processing

User Stories and Tasks

As a user, I would like to see a summary of my purchase after completing my checkout process with a successful transaction.
To achieve this, we will create a "checkout" page that appears after the user selects "Checkout" on their cart/basket page. We will integrate payment processing with Authorize.net using the repository design pattern and have it injected into our razor page. During order completion, we will capture the following user information:

First Name
Last Name
Billing/Shipping Address
Billing/Shipping City
Billing/Shipping State
Billing/Shipping Zip
As a user, following a successful transaction, I would like a summary of my purchase to be emailed to me so that I can store the receipt for my records.
After a successful transaction, we will redirect the user to a "receipt" page. This page will display a summary of the items they purchased, including the order number, shipping/billing information, and other relevant details. We will also send an email confirmation to the user with the same information. We encourage the use of SendGrid design templates for the email, although it's not mandatory. We will also consider using StringBuilder for efficient email content generation.

As a user, I would like to be thanked for my purchase following the completion of order processing.
Upon successful order processing, we will display a thank-you message to the user to express our appreciation for their purchase.

As a user, I would like to be notified if my payment failed so that I can try again.
If the payment fails for any reason, we will implement error handling to provide clear notifications to the user. This will guide them on how to proceed and attempt payment again.

As an administrator, I would like to see a listing of all paid/processed orders.
We will create an admin dashboard that allows administrators to view a list of all successfully paid and processed orders. This will help the admin team track and manage orders effectively.

Guidance
To address these user stories and tasks, we will follow the guidance provided for each:

User Story 1: Checkout Page and Payment Integration
Create a "checkout" page for order processing.
Integrate payment processing using Authorize.net (sandbox account for testing).
Implement the repository design pattern for payment processing.
Capture user information during order completion.
User Story 2: Receipt Page and Email Confirmation
Redirect the user to a "receipt" page after order completion.
Display a summary of the purchased items, order number, and shipping/billing information on the receipt page.
Send an email confirmation to the user with the same information.
Encourage the use of SendGrid design templates for email content.
User Story 3: Thank-You Message
Display a thank-you message to the user after the order is successfully processed.

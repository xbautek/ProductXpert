![](/productxpert.png)

# ProductXpert
ProductXpert is a simple desktop application created using WPF (Windows Presentation Foundation). The main goal of this project is to provide efficient management of products, materials, customers, and production processes. The application is still in progress.

# Features
- Product Management: Add, delete products, including details such as product name, unit price, amount, and minimal amount.
- Material Management: Manage materials used in the production of products, including material name and related details.
- Customer Management: Maintain customer information, such as name, address, and contact details.
- Production Tracking: Track and monitor the production processes, including the ability to assign materials and track progress.

# Prerequisites
To ensure smooth operation of the ProductXpert application, make sure you have the following:

- Microsoft SQL Server: ProductXpert relies on a SQL database to store and manage data. Install Microsoft SQL Server or have access to an existing SQL server. You can download Microsoft SQL Server from here.

# Database Setup
To set up the database for ProductXpert, follow these steps:

- Open Microsoft SQL Server Management Studio (SSMS).
- Execute the ProductXpert.sql script provided in the repository. This script will create the necessary tables and populate them with initial data.

# Running the Application
1. Clone the ProductXpert repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages and ensure all dependencies are resolved.
4. Go to View --> Sql Server Object Explorer --> add connection to local server with created database.
5. Find your database in Object Explorer, go to properties and copy connection string.
6. Modify the database connection string in the ProductXpertContext.cs file at line 30 to match your SQL server configuration.
7. Run the application from Visual Studio, and the ProductXpert application will launch.

# Contributing
Contributions to ProductXpert are welcome! If you encounter any issues or have suggestions for improvements, please open an issue in the repository. Additionally, feel free to fork the repository and submit pull requests to contribute code changes.

# License
ProductXpert is licensed under the MIT License.

This project is a web application designed to allow patients to book appointments with doctors online. The application is built to streamline the process of scheduling medical appointments by providing an easy-to-use interface for both patients and doctors.

Features:

	•	Patients can view available doctors and their schedules.
	•	Booking appointments based on available time slots.
	•	Doctors can manage their appointment schedules.

Note on Development:

Please note that this project is still under development, and as such, there may be incomplete features or occasional bugs. The primary functionality of the app is working, but certain aspects are still being built, and the codebase may be subject to frequent updates.

Technologies Used:

	•	C# / .NET Core for the backend.
	•	Entity Framework Core for database management.
	•	PostgreSQL as the database.
	•	Bootstrap / HTML / CSS for the frontend.
	•	jQuery / JavaScript for interactivity.

Project Setup:

	1.	Install Dependencies
Ensure that all required dependencies are installed via NuGet. To do so, follow these steps:
	•	Open the project in your IDE (e.g., Visual Studio).
	•	Restore NuGet packages automatically, or manually by right-clicking the solution and selecting Restore NuGet Packages.
Alternatively, from the command line:

dotnet restore 


	Configure Database
The application uses PostgreSQL as its database. You’ll need to set up the database and apply migrations:
	•	Set up the PostgreSQL database and update the connection string in the appsettings.json file.
	•	Run the following command to apply migrations:

dotnet ef database update


Run the Application
Once the dependencies and the database are set up, you can run the application:
	•	In Visual Studio, press F5 or use the Run button.
	•	Alternatively, from the terminal:


 dotnet run 




 

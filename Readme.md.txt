### FrontEnd Setup(Project name: whoisweb)

This project is a React.js frontend application built with React JS, designed to interact with the WhoIsAPI backend..

🛠️ Tech Stack
- React JS
- JavaScript
- Tailwind CSS
- Axios (for API requests)


🚀 Getting Started
1. Clone the repository
   ```sh
    git clone https://github.com/jhonerApp/WhoisApp.git
   ```   
2. Install dependencies (using below command)
   ```sh
   npm install
   ```
3. Start the development server
    ```sh
   npm start
   ```
5. 🔐 Backend Env File
  PORT=5000

-----

### BankEnd Setup (Project name: whoisAPI)

WhoIsAPI is the backend API built with .NET 8 and ASP.NET Core Web API to handle domain whois requests.

🛠️ Tech Stack
- .NET 8
- ASP.NET Core Web API
- Swagger / Swashbuckle
- CORS for frontend integration
  
🚀 Getting Started

✅ Prerequisites
.NET 8 SDK


How to Run the Application

1. Install Prerequisites
 Make sure you have the following installed:
  .NET 8 SDK
    ```sh
     https://dotnet.microsoft.com/en-us/download/dotnet/8.0
   ``` 
3. Run the Compiled Application
  If the project is already built: Navigate to the output folder:
    ### \whoisAPI\bin\Debug\net8.0
   
Double-click whoisAPI.exe to run the application.
This will launch the API server on the configured ports (e.g., http://localhost:5133).

3) Try to access the web url to access API:
    ```sh
     http://localhost:5133/swagger/index.html
   ```

    
🔐 API Key Configuration
You can update your WhoisXML API key directly in the appsettings.json file:

{
  "WhoisApi": {
    "ApiKey": "your_api_key_here"
  }
}

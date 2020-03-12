# AspForStrapi
Task overview:
Implement authentication flow for ASP .NET Core 3.1 project with Strapi (https://strapi.io) as an external Identity/JWT provider
Expected output:
- Complete ASP .NET Core 3.1 web application (hereinafter referred to as “the App”). You can use MVC or Razor Pages technology for minimal front-end development (preferably Razor Pages).
- The App owns no database or data store.
- No front-end development framework is used (Angular, React, Vue etc.).
- The App has login page that:
    a) Allows to authenticate users via username/e-mail and password
    b) Authenticates user by sending request to Strapi and handling Strapi response (https://strapi.io/documentation/3.0.0-beta.x/plugins/users-permissions.html#authentication)
    c) Stores authenticated user’s data under http context
- The App has one public route (in addition to login page) – ex. Home Page
- The App has protected route that - available only for authenticated user
- The App has another protected route  - available only for user having certain role
- All of these routes should display current user basic data (ex. Username, e-mail and – preferably – one custom claim value) if user is authenticated
- The App has implemented an interface allowing it to send authenticated request to Strapi (no development on strapi-side needed)
- The App has “logout” option implemented.
- Please, follow clean architecture and SOLID principles
- DDD architecture will be appreciated (but it’s not required)
- The source code has to be delivered as GitHub code repository
Architecture overview:
- There is a Strapi application serving as data store and API, as well as external identity and JWT provider. for multiple clients (https://strapi.io ver 3.0.0-beta-x)
- We need to set up an ASP .NET Core 3.1 Web Application that will serve as Stapi’s API consumer/client
- The ASP .NET Core 3.1 Web App (the App) will have no database. All required data will be provided by Strapi app via REST API
Tips and hints:
- Follow the official Strapi documentation to setup sample Strapi app locally (https://strapi.io/documentation/3.0.0-beta.x/getting-started/quick-start.html)
- Use Strapi admin panel to create sample model (keep it simple as possible)
- Use Strapi admin panel to create sample users and one role. Then assign one of users to the new role.
- Use “Users & Permissions” Strapi plugin to restrict accress to one of available routes only to:  
    a) Authenticated users
    b) Authenticated users assigned for the role
- Your API is ready. Now you can start developing the App 
- NOTE: Local Strapi app is only needed for you to develop the requested feature. You don’t need to deliver your Strapi app as part of your solution. Only “the App” is required.
- Do not worry about front-end development. No styling or front-end behavior is required.
- Do not worry about business naming conventions inside the app. Just make it clear and self-describing.
- Do not worry about proper exception handling. Just throw an Exception where it’s needed.
- The only concern is to provide proper, clean and secure Strapi authentication handling in ASP .NET Core 3.1 Web App
- No deployment is required. Just the App. Working locally.
- No password recovery/email confirmation/password change flow implementation is needed. Just “login – display account data – logout” flow.
- No Unit or Integration tests are required.
Estimated complexity: 3 (out of 0-13 fibonacci scale)
Estimated time for development: 2-3 Man Days
BUDGET STARTS FROM 100$
I'm willing to pay more and extend our cooperation for further features development if delivered feature will meet all quality and functional requirements.

# Tickets Shop
## Introduction
## Goal
The goal of this project was to implement a functional, extensible application, where one can sign in as:
- Admin: is able to create an event
- Regular User: is able to buy tickets to events created by admins
 (and potentially trade them, this functionality was not implemented at all due to unexpected complexity of the design of a simple application)
And then the application persists the information about a user using a database.
## Users section
For trying out this application, clone this repository and then:
`cd tickets-shop`, `dotnet restore`, `dotnet build` and finaly `dotnet run --project tickets-shop.UI`. This should sucessfully download
all dependency packages and start the application. You should see the authentication menu with sign up, log in and exit options, there you can play with the
application, which should be pretty straight forward, if not, use the help options for advices. For selecting an option from the menu just type the symbol and click enter
(e.g. 1 - Sing Up, just press 1 and enter, or e - exit, just press e and enter).
# Other
For more information please see the doxy generated [documentation](docs/html/index.html) of the project (and more programming-related text from me in the title page).
Also I had some troubles creating a github page for that so open that file locally after cloning the repo please.

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
## Programming section
The whole solution is divided into four projects: UI, Domain, Application and Infrastructure. 
We will discuss what each project has to do and what are its responsibilites. Also the dependency graph of this project looks like:

Infrastructure -> Application -> Domain

then

UI -> Application and UI -> Domain

Where A -> B means that project A has reference for project B.
Let us start with the easiest - Domain.
### Domain
This is a very simple dll project. Its job is to define entities of the application, such as abstract User and then its concrete classes: Admin and Regular User,
or classes such as Ticket or Event. Its responsibility is to gather information about a specific entity and provide API for other projects to use when
working with such entity.
### Application
Another dll project, which is responsible for defining interfaces for the communication with database (later implmeneted in infrastructure project) such as an interface for 
communicating with users repository or an interface for signing up/ logging in a user. And also handling
the business logic of the application such as adding money to a user, or the logic that has to happen when an event is created (create tickets for that event, save it to db,...).
### Infrastructure
Dll library where the implementation of interfaces defined by Application project is stored. Important part is choosing DbContext for simplicity of the whole database communication
and working with entites stored in tables, which can be seen in the repositories in the same folder (e.g. UsersRepository). We also set up the dependencies of entities (meaning the relationships 
between entities, e.g. one-to-many relationship between user and owned tickets).
### UI
This is the most complex project (which makes sense since it is console application). Whenever there is some communication between the program user and the application,
such as taking input from user or printing output to user, its this projects responsibility. Also it is the starting point of the whole application, meaning its the only exe project in the solution.
Lets talk about the structure a little bit. The main logic of the application is as follows. Menu gets printed out, user chooses an item from that menu (such as exit, log out or routing to another menu),
the action gets executed and that repeats until the users exits. The main problem I encountered here is to get rid of the insanity of switch(input) statements, which sounds really inextensible and unsustainable.
So I used a different approach. Each menu option is an executable item which either executes some end point service (such as displaying detail, creating an event, buying a ticket) or it routes to a different menu.
This is implemented by many different MenuBuilders, and their responsibility is only to build the menu with its items. Than there is the Main MenuService, which provides the API for outputting (formatting) the menu
and for choosing an option from the menu. 
#### Services
There are UI services for endpoints of the application. I would recommend checking out the TicketsPurchaseService which is the most complex one. Really important is that the UI services are really responsible as little 
for the logic as possible, meaning they only take the input (or just display output in case of same help providing services), take care of parsing exceptions and send the value to the handler of the given problematics
in Application project (e.g. TicketsPurchaseHandler).
## Conclusion
I tried to implement an application which would be not that hard to extend with a given functionality because there is a lot that could be done... selling tickets, trading tickets with other users and many more.
Altough I wanted to implement the functionality of begin able to safely trade tickets with other users there was not time for that and I am finding the project being complex enough. The flow of extending my project would
be: adding option to a specific menu builder where we want to add the extension, creating an UI service for the endpoint (which only takes care of the input) and creating a handler which is the business logic. Also the documentation
of the code is rather proper thanks to AI. 


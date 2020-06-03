# CanteenMenuInterface

The application is divided between sections on one screen, which should be divided on seperate user controls (TO-DO)

MENU 

Here user who has Operator user role (UserRoleKey 1) can add, edit and delete menus to the database. Operator user must be selected
for buttons to be available to him.

USERS

Creation, editing and deleting of users is made here. For now everybody can add\edit\delete users. TO-DO - only Operator can edit, delete, ...

SELECTED USER

When a user is selected on User list, here his data is shown. Also selected user can pick the weekly menus on a user panel, which are then
here next to his data. With submit order, all the selected menus are added to database.

OPERATOR PANEL

Here Operator can select which of the available menus are to be used on selected day. With previous and next week buttons we navigate
through weeks. Buttons are toggle type. There is a bug, if you try to de-toggle previously selected menu from which orders were made
(you cant change how menu should be, for days that are already gone ... )

TO-DO - when you change week the status of toggle buttons should change acording to the status of 
each meal at each day. TO-DO2 - limit max\min number of possible menus per day.

USER PANEL

Here selected user can select one menu meal per day, which are then shown in Selected User Weekly order and to be submited to database.
TO-DO - better visualisation

ORDERS

Here we can look for orders by day, week or month. The displayed properties are Date, FirstName, LastName, MenuName and OrderStatusName
TO-DO: Week and Month insert fields should be limited to (number of possible weeks and number of possible months/dropdown menu with months)

EDIT ORDERS

Here selected order will be shown with its properties. On the bottom you can edit selected orders add comment and new Menu Key TO-DO: Dropdown menu or more suitable selection option. Edit button only appears if a user with Operator Key is selected.

DATABASE

Database connection string is in App.config, connectionString - Server

TO-DOs:

-Improve UI

-User Role options set in backend (not just hidding UI controls)


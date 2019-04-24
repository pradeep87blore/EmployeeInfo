This repo is for creating an Employee Info app. The intent is to demonstrate the use of PostGreSQL, XUnit, .NET Core and C#, JMeter, REST APIs, etc.

Planned projects:

1. Project to interact with PostgreSQL
2. Project to interact with MongoDB (maybe in Python?)
3. Controller project (that can make use of the DB)
4. API provider that calls the Controller functions
5. Init project that can create the DBs, tables, etc
6. Init project that populates the data into the tables. (read from a CSV?)
7. Unit test project to test the APIs (by directly calling the Controller project functions) using XUnit
8. WPF UI for this, that works via the same REST calls?

APIs:
Employee DB? 
GET api/employee  -> Fetch all the employee info
GET api/employee{id} -> Fetch a specific employee info
POST api/employee -> Add a new employee if the same email ID doesnt already exist. Assign a emp id and return the same
PUT api/employee -> Update the employee info. Create the employee if they dont already exist?
DELETE api/employee{id} -> Delete the employee if they exist. 404 if the employee doesnt exist


Similar set of queries for Departments, Salaries, Peers / Supervisors / Reportees?


jMeter test plan for:
1. CRUD operations on the APIs
2. Performance testing
3. Endurance testing
4. ?
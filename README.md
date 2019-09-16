UserManagement APIs


The solution is divided into 3 parts.
a. UserManagementAPI-Includes the API endpoints
b. BAL- Includes Db Operation followed by repository model
c. DAL- Includes the ORM(entity framework- Database approach)
d. UnitTest- Contain few test cases to test the APIs(Positive and Negative Scenarios)


The solution contains following endpoints 
1. AddUser- OnBoard new user if email and phone number are not registered with us.
2. UpdateUser-Update user if data is present.
3. AddKid- Add kid against user(n:1 relationship)
4. UpdateKid-Update kid against userid
5. AddHome- Add Home against User(n:1 relationship)
6. UpdateHome-Update home against userid
7. GetUser-Get All active users
8. GetUser/id-Get specific user
9. DeleteUser- Delete(inactivate) user
10. Search- Search user list based on following criteria
      	Age=1,
        States=2,
        HomeType=3,
        HomeZipCode=4,
        NumberOfKids=5

Log is been added to monitore the exception cases, so that in next build we can take care of the issue raised in previous build
Relation database(local mdf file) is used to maintain data and have necessary operations


Run UserManagementAPI module, 
Postman collection is shared to test the APIs
Postman online documentation: #https://documenter.getpostman.com/view/6095216/SVmtyKSN


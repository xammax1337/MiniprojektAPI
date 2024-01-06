## [GET] List Persons
https://localhost/person

## [GET] View Links and Interests for specific Person
https://localhost/person/ (Persons ID)

## [POST] Create Person
https://localhost/person/create
```
{
	"firstName": "",
	"lastName": "",
	"number": 
}
```
## [POST] Create Interest
https://localhost/interest/create
```
{
	"title": "",
	"description": ""
}
```
## [POST] Connect Person to Interest, Enter PersonId and InterestsTitle to make a connection.
https://localhost/person/connect
```
{
  "personId": ,
  "interestTitle": ""
}
```
# UML Diagram

![uml1 drawio](https://github.com/xammax1337/MiniprojektAPI/assets/146171534/b0df70ea-e75e-40ba-b6ef-91bd2a7a9698)

# ER Diagram
![erdiagram drawio](https://github.com/xammax1337/MiniprojektAPI/assets/146171534/7fbe39bc-0181-4570-9c9a-b311112909e4)

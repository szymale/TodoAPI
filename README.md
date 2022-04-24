## TODO API
___

Simple Todo API with possibility of tracking todos by specific date.

Used technology:
+ .Net 6.0
+ Entity Framework Core
+ PostgreSQL
+ Docker

___
### Github client:
`gh repo clone szymale/TodoAPI`
___
### HTTPS:
`https://github.com/szymale/TodoAPI.git`
___

After cloning this repo you can run this API using Visual Studio, or by running terminal command in project directory (Docker is required):
`docker-compose up`

Default port is mapped to *localhost:4444*
___
### Fearutes:

- [x] Get List of all Todos
- [x] Get Specific Todo by Id
- [x] Get List of Upcoming Todos by entering day
- [x] Create new Todo
- [x] Update Todo
- [x] Partial update of Todo
- [x] Marking Todo as "Finished"
- [x] Changing Todo Progress %
- [X] Deleting specific todo


___
### Sample Request:

Get All request:

Curl:
```
curl -X 'GET' \
  'https://localhost:4444/GetAllTodos' \
  -H 'accept: text/plain'
  ```
Request URL:  
  ```
  https://localhost:4444/GetAllTodos
  ```

To check rest request visit: `https://localhost:4444/swagger/index.html` while running this API.
 
	

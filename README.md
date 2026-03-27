# SimpleInnApp
### To run the project:
```
Recommended: dotnet watch
Or: dotnet run
```

### To run migrations:
```
dotnet ef migrations add [migrations name]
```

### To create initial database:
```
dotnet ef database update
```

# Test
### Using Postman
```
Software: https://www.postman.com/
Exported file located in Project Root/src/Test/Inn.postman-collection.json
```

### To import
#### Click ●●● → import
<img width="1580" height="1078" alt="image" src="https://github.com/user-attachments/assets/6be47fcf-a43d-4db1-bda8-3707f4db49ba" />

#### Drag the exported file to it or open the file
<img width="1580" height="1078" alt="image" src="https://github.com/user-attachments/assets/567b440d-1309-4bdb-bc65-54024e453ad5" />

#### Expand the side "Inn" to expose different test folders, click/expand Booking Test for example
<img width="1565" height="1046" alt="image" src="https://github.com/user-attachments/assets/209a8b4f-ce1b-4f93-a431-74d827c1e1c8" />

#### 1) Click one of the test file, "GET http://localhost:5423/bookings" for example.
#### 2) Change GET method to other method, if necessary.
#### 3) Preview JSON body by clicking top nav bar "Body".
#### 4) Edit JSON body for testing.
#### 5) click Send to send the request.
#### 6) Bottom will show the request result.
#### Other test file can do the same.
<img width="1572" height="1074" alt="image" src="https://github.com/user-attachments/assets/e681dd83-ea2e-41cd-823b-d6992fcdcba3" />

#### Have fun testing!

# Design explanation
## Table design
#### From examinations booking table has roomId, which state it is in relation with Room table. Create ForeignKey relation between the two to resolve this problem.
#### Room Type can be "Single", "Double", "Suite". Assumption was made to declare it as enum instead of string type.
#### Room name can be “101”, “102”, “103”, “201”, “202”. But later can post again with the same name, which interpert as weird behaviour. Add uniqueness to fix the issue.
#### Each table should consist of at least one primary key, so two tables Ids are becoming keys. Assumption to be more convinent, added auto increament to the primary key upon adding new row.

## Architecture design (mainly follow https://github.com/jasontaylordev/CleanArchitecture)
#### Domain layer: From my knowledge, the files that do not contribute in provide any logical processing. e.g. Services
#### Infrastructure layer: Mainly structuring databases and customize its table relation, indexing and other properties.
#### Application layer: Handles use cases and application logic. This includes request handling, validation, etc.
#### Web layer: Defines the endpoints and handles incoming HTTP requests.
#### Test layer: Test files for each endpoints or services.

## Endpoints design
#### Validation is performed at the beginning of each request to ensure that input data is complete and valid before proceeding with any processing or database queries.
#### If query was reused, it is wrapped into the relevent etity query folder, for reusability.
#### Eventhough some fields have required contraint, it doesnt prevent them to be empty or logically invalid. To resolve the issues Dependency Injection custom made validation services, to validate incoming body request.
#### Patch Room / Room available are not a required endpoints. But from a client prespective showing all rooms instead of available once, seems to be more valuable. For patching, specifically when client check out we need to update Room IsAvailable status.







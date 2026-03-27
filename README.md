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









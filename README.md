# Photo Upload System

## SPEC

`!` means required

- User

  - id
  - role (Enums: admin/manager/staff)
  - username (String!)
  - password (String!)
  - createdAt
  - updatedAt

- Project

  - id
  - name (String!)
  - owner (String!)
  - description (String)
  - status (Enums: working/completed/closed)
  - createdAt
  - updatedAt

- Photo

  - id
  - title (String!)
  - author (String!)
  - description (String)
  - createdAt
  - updatedAt

User hasMany Projects

User hasMany Photos

Project hasMany Photos

Photo belongsTo User

---
## Usage

dotnet build --build the project 

dotnet run -- run the project 

server url http://localhost:4000


### API
- login 

  - Authenticate(Post)

    http://localhost:4000/login
    ```
    {
      "Username": "test01",
      "Password": "123qwe"
    }
    ```

- User
 - Get 
   http://localhost:4000/user

 - Get by Id
   http://localhost:4000/user/1
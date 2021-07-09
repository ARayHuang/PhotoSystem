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

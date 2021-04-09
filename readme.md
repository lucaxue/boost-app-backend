# Events API

## An RESTful API made for an exercise focused event making app

<em>Checkout the frontend React app source code [here](https://github.com/lucaxue/boost-app-frontend).</em>

- Built with ASP.NET Core
- Using Dapper ORM
- Made for a Postgres database

Testing:

- Unit testing done with xUnit
- NSubstitute mocking library
- FluentAssertions for easier assertion syntax

## Routes
<em>Checkout the database design [here](https://drawsql.app/wedontbyte/diagrams/events-api#).</em>

<details>
  <summary>/users</summary>

- ### Methods:
  - Get all users
  - Get user by user id
  - Post user
  - Update user
  - Delete user
  - Get users by group id (query string)
    - `/users?groupId=1`
  - Get users by username (query string) - `/users?username=JimBob`
  </details>

<details>
  <summary>/groups</summary>

- ### Methods:
  - Get all groups
  - Get group by group id
  - Post group
  - Update group
  - Delete group
  - Get group by name (query string) - `/groups?name=Weekend Warriors`
  </details>

<details>
  <summary>/events</summary>

- ### Methods:
  - Get all events
  - Get event by events id
  - Post event
  - Update event
  - Delete event
  - Get events by group id (query string) - `/events?groupId=1`
  </details>
  <br/>

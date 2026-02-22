Task Management API
Time Spent

Approximate time spent: 6 hours

Approach

Built using ASP.NET Core Web API (.NET 6+)

Used layered architecture (Controller, Application, Domain, Infrastructure)

Business rules for task status transitions implemented inside the domain entity

Used in-memory repository via abstraction to keep persistence replaceable

Used Result pattern for clean and predictable error handling

Controllers kept thin and focused on HTTP concerns only

Implemented JWT-based authentication and protected all task endpoints

Added filtering by status and priority, and sorting by priority

Integrated Swagger with Bearer token support for easy testing

Trade-offs

In-memory storage instead of database persistence

Authentication uses a simple in-memory user store (demo purpose only)

Passwords are not hashed (demo only)

Limited unit tests due to time constraints

No pagination, caching, or advanced logging

With more time, I would add database persistence, proper password hashing, more tests, and better error handling/logging
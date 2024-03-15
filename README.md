
SahadanBackend
Football Squad Listing Project with Layered Architecture

This project provides a platform to record and list football fields, games, teams, and leagues. Users can add, edit, and delete leagues, teams, and players. Additionally, users can navigate between different leagues and countries.

Usage
On the home page, view existing leagues and countries.
Navigate to pages to add, edit, or delete leagues, teams, and players.
API Guide
You can interact with the backend using the API routes. Note that token-based authentication is required.

/api/leagues: Get all leagues.
/api/leagues/{id}: Get a specific league.
/api/leagues/add: Add a new league.
/api/leagues/edit/{id}: Update a specific league.
/api/leagues/delete/{id}: Delete a specific league.
/api/teams: Get all teams.
/api/teams/{id}: Get a specific team.
/api/teams/add: Add a new team.
/api/teams/edit/{id}: Update a specific team.
/api/teams/delete/{id}: Delete a specific team.
/api/players: Get all players.
/api/players/{id}: Get a specific player.
/api/players/add: Add a new player.
/api/players/edit/{id}: Update a specific player.
/api/players/delete/{id}: Delete a specific player.
Layered Architecture
The project follows the following layered architecture:

Presentation Layer: User interface created with Angular.
Business Logic Layer: Backend created with .NET Core, handling business logic and database interaction.
Data Access Layer: Data access code on the .NET Core side, interacting directly with the database.
Contribution
If you would like to contribute, please create a pull request. Before making significant changes, consider opening an issue to discuss your proposal.

# EssentialAlbumsViewer API

This API stores information on albums regarding critical success, commercial success, and award recognition. The purpose was to implement the backend features of an album viewer web application. I decided to build the API because of the lack of accessible API from sites: Billboard, Rolling Stone, Grammys, etc. The project uses SQL Server to save information to a database and to implement a relational database design. I took the liberty of adding a dockerfile and docker-compose to containerize the API and for potential deployment.  

# Implementation 
The project uses a relational database to store both albums and the artists. The design is a one-to-many connection as one band or artist can have many albums. Thus, the Album table will have to carry the id of the artist. The Artist table stores a collection that points to the Album database. 

Since the Albums table has a dependency on the Artist table, if a row gets deleted on the Artist table, the Albums table consequently deletes every album pointing to that row.


## GET Requests

A user can make GET requests to review all the artists stored in the database. The project follows the CRUD design to operating an API. 

### /api/EssentialArtists
<img width="1680" alt="Screen Shot 2021-10-13 at 11 36 23 AM" src="https://user-images.githubusercontent.com/27907086/137206356-22204d28-9809-48ab-80f2-b3a946bb7712.png">

When retrieving all artists in a GET request, the essential albums collection will output: "null." The GET call must specify the id of the artist/band to have access to the albums collection. 

### /api/EssentialArtists/{id}
<img width="1680" alt="Screen Shot 2021-10-13 at 11 36 56 AM" src="https://user-images.githubusercontent.com/27907086/137206795-c3975a4f-ff95-4acd-a938-cd8961690788.png">

For the web application, I wanted to include the feature of getting artists specific to a genre. So I added a query parameter to the GET call, which returns artists with that same genre.

### /api/EsstentialArtists?genre={genre_var}
<img width="1680" alt="Screen Shot 2021-10-13 at 11 41 50 AM" src="https://user-images.githubusercontent.com/27907086/137207023-2339a00e-43b3-449d-b506-9b78738e1d79.png">


A user can make GET requests to review just the albums stored in the database. The project follows the CRUD design to operating an API.

### /api/EssentialAlbums
<img width="1680" alt="Screen Shot 2021-10-13 at 11 38 51 AM" src="https://user-images.githubusercontent.com/27907086/137206687-3217c6b2-2545-45b4-8195-3caf63dca68b.png">

### /api/EssentialAlbums/{id}
<img width="1680" alt="Screen Shot 2021-10-13 at 11 40 30 AM" src="https://user-images.githubusercontent.com/27907086/137207119-41213068-744b-4a41-9ca2-5eaa8c18946d.png">

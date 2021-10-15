# Essential Albums Viewer (website & API)

This website allows users to view essential albums of any artist/band of a selected genre. An "essential album" usually means any work that has critical, commercial, or public acclaim. The best metric to compare an album is through ratings (profession or personal), how much it charted (and for how long), and award wins or nominations.

Unfortunately, there are no readily accessible public APIs to gather all the information I wanted on an album or the artists/bands. So I decided to create an API to carry the information and pass it to my website. 

# Implementation 
The API carries information on an artist(s) and their essential albums. For each album, the API stores information needed to compare its acclaim. Such acclaim includes critical ratings, chart information, RIAA certification (units sold), and the number of Grammy nominations and wins. A user can request to view, create, edit, or delete information collectively or by a selected album or artist(s).  

The web app makes a GET request to access information on an artist(s) or album. The website passes information from its Controller to the respected View. Users have the option to view and modify details on any album or artist. The website Controller makes POST/PUT requests to the API when handling modification or creation by a user.


## Website Home Page (top part)

The home page displays each genre of the artist currently available. Users can orderly navigate through various artists.

<img width="1680" alt="Screen Shot 2021-10-13 at 1 33 59 PM" src="https://user-images.githubusercontent.com/27907086/137192986-105c4db5-30d0-4919-823f-4f88e461113e.png">

## Home Page (bottom part)

<img width="1680" alt="Screen Shot 2021-10-13 at 1 35 42 PM" src="https://user-images.githubusercontent.com/27907086/137193026-ba04c425-70ef-4ae8-981c-6782b2b33149.png">


## Genre Page

By clicking one of the genre buttons, the user views the artists of that particular genre. The user can now choose to view each artist separately and access a list of their essential albums. A user can create another artist to add to the website or modify information from one's present. 

<img width="1680" alt="Screen Shot 2021-10-12 at 11 36 23 AM" src="https://user-images.githubusercontent.com/27907086/137213821-637a698d-c1f6-4d62-8125-01b2f43df360.png">

<img width="1678" alt="Screen Shot 2021-10-12 at 11 47 56 AM" src="https://user-images.githubusercontent.com/27907086/137231556-aa3c0d1e-f7fe-4783-adfe-82a8ac13ca14.png">

<img width="1680" alt="Screen Shot 2021-10-12 at 11 37 26 AM" src="https://user-images.githubusercontent.com/27907086/137231583-61907213-0d8f-400a-a6b3-2ed81aa647dd.png">



## Essential Albums Display

The page displays the albums in a list format from top to bottom. Users have access to view all information gathered on a specific album.

<img width="1680" alt="Screen Shot 2021-10-12 at 11 41 46 AM" src="https://user-images.githubusercontent.com/27907086/137213914-51f68f07-809e-4e4a-be90-5faaef47a5a2.png">

The page provides a sorting feature where a user can organize albums by popularity, critical acclaim, public acclaim (measured through public polling websites), and award recognition.

<p align="center">
  <img width="900" src="https://user-images.githubusercontent.com/27907086/137213527-584e4376-10b8-40aa-b41c-8dd44e970970.gif">
</p>

# EssentialAlbumsViewer Website

The website allows users to read, write, modify information from the essentials API. 

## Adding a new Band or Artist
If a user want's to add another artist/band to the website (and API) they can click link in the header. 

<img width="1680" alt="Screen Shot 2021-10-12 at 4 31 20 PM" src="https://user-images.githubusercontent.com/27907086/137232236-fa75547f-0147-4f2a-bae7-0553e85f09f2.png">

The API stores the name of the music act, their preferred genre, and an image. When the user submits their input the website handles a post request to the API. If the API accepts (returns a 200 status code), the website redirects the user back to the artist page. If API returns an error (usually 400 code), the website stays on the form page. 

<img width="1680" alt="Screen Shot 2021-10-12 at 4 35 36 PM" src="https://user-images.githubusercontent.com/27907086/137232254-7482021a-364e-4579-a07e-3b3512183c84.png">

<img width="1680" alt="Screen Shot 2021-10-12 at 4 36 50 PM" src="https://user-images.githubusercontent.com/27907086/137232267-4bf7d0d6-564d-4f07-9944-c1461ceb46c5.png">

## Edit Band or Artist information

The user can update information simply as it was to create new ones.

<img width="1680" alt="Screen Shot 2021-10-12 at 4 37 24 PM" src="https://user-images.githubusercontent.com/27907086/137232278-8e482ed3-1e6b-4abb-bdc2-e06023fa6e94.png">


<img width="1680" alt="Screen Shot 2021-10-12 at 4 37 37 PM" src="https://user-images.githubusercontent.com/27907086/137232283-6d11c2c5-5acc-4fe2-ba8a-dff142d2f06a.png">


## Adding a new Album

Users can add new albums to the list page in the same way as adding artists to the genre page. The only difference is the amount of information as our API stores more about an album regarding critical, commercial, and awards accolades.

<img width="1680" alt="Screen Shot 2021-10-12 at 4 38 00 PM" src="https://user-images.githubusercontent.com/27907086/137232425-888b2903-e61e-4bd2-ba56-1bd7cbacb3ff.png">

<img width="1680" alt="Screen Shot 2021-10-12 at 5 17 04 PM" src="https://user-images.githubusercontent.com/27907086/137232457-63919c0c-d3df-4744-804b-dbd15f0af505.png">

<img width="1680" alt="Screen Shot 2021-10-12 at 5 20 13 PM" src="https://user-images.githubusercontent.com/27907086/137232476-fe029e7f-df84-4276-afc0-4be0732d225f.png">

Notice users can omit inputs as we expect not every medium would have reviewed a specific album. 

<img width="1680" alt="Screen Shot 2021-10-12 at 5 20 51 PM" src="https://user-images.githubusercontent.com/27907086/137232486-cc494574-8757-49b2-b18a-ae833bdf6dd1.png">

# AllAboutGames

Web application that i made as a project defence for the Asp.Net Core module at Software University. The site consists of forum where users can talk about everything that interests them, adding rating to games and also reviews.

## Technology stack:
* .NET 5.0
* Entity Framework Core 5.0
* SendGrid -> for email validation on register.
* MSSQL
* JavaScript
* jQuery
* Bootstrap

## Screenshots:
| ![Screenshot 2020-12-20 141544](https://user-images.githubusercontent.com/57861356/102718613-bc61a700-42f1-11eb-8cbf-170f37a5dc2b.png)| ![Screenshot 2020-12-20 142542](https://user-images.githubusercontent.com/57861356/102718630-ce434a00-42f1-11eb-9a5c-2221942db9c5.png) | ![Screenshot 2020-12-20 183423](https://user-images.githubusercontent.com/57861356/102718687-14001280-42f2-11eb-9736-9dc88abf8761.png) |
| :---: | :----:  | :----: |
| Home page | Home page | Home page | 
#### Description for "Home" page: 
When the user goes to the home page, he sees a slider with information about the site functionality - being able to add rating for a game, also if the user is in role of "Reviewer", to give the game a review, visit the forum and talk about averything that interests them. Under the slider is visualized the top rated game on the site with count of the total ratings and average score. When the user click on the "View details" button, it leads them to the page with full information about the game. Next to it is a table with the recent reviews. At the bottom of the page the user can read about the newest console.

| ![Screenshot 2020-12-20 144139](https://user-images.githubusercontent.com/57861356/102718752-64777000-42f2-11eb-8d7a-3112e2fb8305.png)| ![Screenshot 2020-12-20 144234](https://user-images.githubusercontent.com/57861356/102718755-7527e600-42f2-11eb-897a-e236909bbea5.png) |
| :---: | :----:  |
| Game details page | Game details page |
#### Description for "Game details" page:
Only users that are in role of "Administrator" can edit a game or delete it. To do that, at the start of the page are visualized the two buttons - "Edit" and "Delete". Below we have again the average rating of the game, total votes and, if the game has any reviews, the "Check reviews" button leads them to the reviews page. After that we have the full information about the game with the game poster on the left and trailer on youtube to the right. Users can visit the official website for the game when they click on "Click here to visit the official site" button. Only logged in users can give the game a rating and if the user is in role of "Reviewer", after giving the game star rating, a form pops up that allows them to write they'r review. Only one rating and review can be added by the users. At the bottom there is summary for the game.

| ![Screenshot 2020-12-20 144720](https://user-images.githubusercontent.com/57861356/102718785-b15b4680-42f2-11eb-87e6-12a8db7f3358.png)| ![Screenshot 2020-12-20 144751](https://user-images.githubusercontent.com/57861356/102718789-bddf9f00-42f2-11eb-97ce-9e47fad872e1.png) |
| :---: | :----:  |
| All games page | All reviews page |
#### Description for "All games" and "All reviews" page:
From the dropdown menu "Games" the user can click on the platform name and see all the games for it. A pagination has been added here that shows 8 games per page and when the user clicks on the game, it leads them to the game details page. The same is said for the all reviews page.

| ![Screenshot 2020-12-20 145033](https://user-images.githubusercontent.com/57861356/102718814-f1bac480-42f2-11eb-8f06-7589100727bd.png)| ![Screenshot 2020-12-20 145101](https://user-images.githubusercontent.com/57861356/102718818-fb442c80-42f2-11eb-8290-7bd4de14a6b1.png) | ![Screenshot 2020-12-20 145137](https://user-images.githubusercontent.com/57861356/102718821-0434fe00-42f3-11eb-9909-e7cd4347a25a.png)|
| :---: | :----:  | :----: |
| Review details page | Contacts page | User profile page | 
#### Description for "Review details" page:
Here the user can see the average rating and parcentage for all star ratings it has recieved. A pagination has been added to the page that shows 5 reviews per page. Only the creator of the review and the administrator can delete it.
#### Description for "User profile" page:
Here the user can change they'r profile picture and see they'r activity on the site - how many reviews, forum comments and forum posts they have.

| ![Screenshot 2020-12-20 145556](https://user-images.githubusercontent.com/57861356/102718851-3c3c4100-42f3-11eb-93d3-3051d52b763a.png)| ![Screenshot 2020-12-20 145639](https://user-images.githubusercontent.com/57861356/102718863-478f6c80-42f3-11eb-92fb-6df6eeadcff7.png) |
| :---: | :----:  |
| Forum home page | Forum post page |
creator of the review and the administrator can delete it.
#### Description for the forum:
Here the user can see the total posts on the forum and post count for every category.
They can see the forum categories and add a post to any of it. A post can have likes and comments from the users. 

## Database diagram:
![Screenshot 2020-12-20 160015](https://user-images.githubusercontent.com/57861356/102792821-b03d1e80-43b1-11eb-8aa4-e9ac7eaa9fd7.png)

# Link to the website:
https://allaboutgames.azurewebsites.net/

## Contacts:
* Facebook: [@Hristo Trendafilov](https://www.facebook.com/hristo.trendafilov.31)
* Linkedin: [@Hristo Trendafilov](https://www.linkedin.com/in/hristo-trendafilov-7a310a186/)
* Gmail: hristo.trendafilov93@gmail.com

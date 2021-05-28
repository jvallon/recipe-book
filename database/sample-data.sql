insert into users
values 
(1,"Josh","Vallon","jvallon","password","joshua.vallon@gmail.com"),
(2,"Luke","Skywalker","jedi69","password","jedimaster69@gmail.com"),
(3,"Darth","Vader","iamyourfather","password","whosyourdaddy@theempire.com"),
(4,"Obi-wan","Kenobi","oldben","password","oldben13@jediorder.com");
insert into recipes(RecipeId,Title,Description,PrepTime,CookTime,UserId)
values 
(1,"Mashed Potatoes","Squish squish","00:30:00","00:30:00",1),
(2,"Hashbrowns","Golden goodness","00:30:00","00:15:00",1),
(3,"French Fries","Crispy and salty","00:25:00","00:10:00",2),
(4,"Au Gratin Potatoes","So Cheesy","00:30:00","00:45:00",3);
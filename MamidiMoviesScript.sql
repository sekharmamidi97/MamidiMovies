Create Table Login
(
	loginId int identity(1,1) not null primary key,
	username varchar(100) not null,
	password varchar(100) not null

);

Create table Movie
(
	movieId int identity(1,1) not null primary key,
	loginId int not null,
	title varchar(1000) not null,
	year varchar(10) not null, 
	isAction bit not null,
	isAdventure bit not null,
	isComedy bit not null,
	isDocumentary bit not null,
	isDrama bit not null,
	isFamily bit not null,
	isHistorical bit not null,
	isHorror bit not null,
	isMystery bit not null,
	isScienceFiction bit not null,
	isCartoon bit not null,
	isTelevisionShow bit not null,
	isOther bit not null
);

Alter table Movie Add Foreign Key(loginId) References Login(loginId);
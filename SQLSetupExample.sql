create table Goal
(
 ID integer auto_increment,
 Title varchar(50),
 Description varchar(250),
 PointsCurrent numeric(7),
 PointsToUnlock numeric(7),
 constraint PK_ID primary key (ID)
);

create table GoalTree
(
 ID integer auto_increment,
 Title varchar(50),
 Description varchar(250),
 constraint PK_ID primary key (ID)
);

create table GoalOccurence
(
 GoalTreeID integer,
 GoalID integer,
 Position numeric(5),
 constraint PK_GoalOccurence primary key (GoalTreeID,GoalID),
 constraint FK_GoalTreeID foreign key (GoalTreeID) references GoalTree(ID),
 constraint FK_GoalID foreign key (GoalID) references Goal(ID)
);
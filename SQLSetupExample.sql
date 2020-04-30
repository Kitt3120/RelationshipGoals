-- Execute the following script AS A PRIVILEGED USER. You may also modify it to fit your needs under the GNU General Public License v3.0.

-- Create User
create user 'YOUR_USER'@'localhost' identified by 'YOUR_PASSWORD';

-- Create Database and use it
create schema YOUR_DATABASE_NAME;
use YOUR_DATABASE_NAME;

-- Grant Privileges
grant select, insert, update, delete on YOUR_DATABASE_NAME.* TO 'YOUR_USER'@'localhost';
flush privileges;

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
 Position numeric(3),
 constraint PK_GoalOccurence primary key (GoalTreeID,GoalID),
 constraint FK_GoalTreeID foreign key (GoalTreeID) references GoalTree(ID),
 constraint FK_GoalID foreign key (GoalID) references Goal(ID)
);

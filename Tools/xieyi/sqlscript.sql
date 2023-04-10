drop database if exists lolgame;
Create Database If Not Exists lolgame;
use lolgame;
drop table if exists userinfo_a;
create table userinfo_a(
ID int auto_increment  primary key ,
Account varchar(255),
Password varchar(255)
)default charset=utf8;use lolgame;
drop table if exists rolesinfo_a;
create table rolesinfo_a(
ID int,
RolesID int,
NickName varchar(255),
Level int,
State int,
VictoryPoint int,
GoldCoin int,
Diamonds int,
RoomID int,
SeatID int
)default charset=utf8;
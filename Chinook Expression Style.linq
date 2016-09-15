<Query Kind="Expression">
  <Connection>
    <ID>39b68d42-00e1-4cb7-8ca6-a5cfc1a8ffde</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/*
Linq expressions, statements, programs are written using c# syntax
*/

// query syntax list all records from entity
from x in Artists
select x 

//method syntax list all records from entity
Artists.Select(x => x)

//sort albums by title
from x in Albums
orderby x.Title
select x

//sort albums by releasedate (most current) by title
from x in Albums
orderby x.ReleaseYear descending, x.Title
select x

//list all albums belonging to artists
//the select is obtatining a subset of attributes from 
//the choosen table
//the new {} is called an anonymous date set
//anonymous datasets are IOrderedQueryable<>
from x in Albums
select new{
			x.Artist.Name,
			x.Title
// list all albums belonging to artists where a condition exists
//find albums released in a particualr year
from x in Albums
where x.ReleaseYear == 2008
orderby x.Artist.Name, x.Title
select new{
			x.Artist.Name, 
			x.Title
}
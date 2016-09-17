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

// query syntax list all records from entity
from x in Artists
Linq expressions, statements, programs are written using c# syntax
*/
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
}
// list all albums belonging to artists where a condition exists
//find albums released in a particualr year
from x in Albums
where x.ReleaseYear == 2008
orderby x.Artist.Name, x.Title
select new{
			x.Artist.Name, 
			x.Title
}

//this sample requires a subset of the entity record
//the date needs to be filter for specific select thus a where is needed
//using the navigation name on Customer, one can access the associated employee record
//reminder: this is C# syntax an thus appropriate methods can be used .Equal
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane")
	  && x.SupportRepIdEmployee.LastName.Equals("Peacock")
orderby x.LastName, x.FirstName
select new{
			Name = x.LastName+", " + x.FirstName,
			City = x.City,
			State = x.State,
			Phone = x.Phone,
			Email = x.Email
}

//List all the Albums and the total number of tracks for that album.
// List albums alph
//find the total price for each set of album tracks
// for aggregrate it is best to consider doing parent child direction

//aggregrates are used against collections(multiple records)
//count() count the number of instances of the collection referenced
//null error could occur if a collection is empty for specific aggregrate(s) such as sum thus 
//you may need to filter(where)certain records from your query
//find the avarage length of the album tracks in seconds

//Sum()totals a specific field/expression, thus you will likely need to use a 
//delegate to indicate the collection instance attribute to be used

//Average()Average a specific field/expression, thus you will likely need to use a 
//delegate to indicate the collection instance attribute to be used
from x in Albums
where x.Tracks.Count() > 0
orderby x.Title
select new {
		    Title =x.Title,
		    TotalTracksforAlbum =x.Tracks.Count(),
			TotalPricesforAlbum = x.Tracks.Sum(y => y.UnitPrice),
			AverageTrackLength = x.Tracks.Average(y => y.Milliseconds/1000)
}
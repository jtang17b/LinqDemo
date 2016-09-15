<Query Kind="Statements">
  <Connection>
    <ID>39b68d42-00e1-4cb7-8ca6-a5cfc1a8ffde</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//use of the statement environment allows for c# type commands
//you can have local variables\
//you can have multiple statements in your execution
// to display the content of a variable you will use
// the LinqPad method .Dump()
var theresults = from x in Albums
where x.ReleaseYear == 2008
orderby x.Artist.Name, x.Title
select new{
			x.Artist.Name, 
			x.Title
           };
theresults.Dump();

//list all albums which contains the string "son"
//consider using the method .contains()

var theList = from x in Albums
where x.Title.Contains("son")
select x;
theList.Dump();

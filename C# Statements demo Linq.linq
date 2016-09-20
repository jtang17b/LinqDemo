<Query Kind="Statements">
  <Connection>
    <ID>285b59c4-ba48-4182-b267-4171442776cd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//a statement has a receiving variable which is set
//by the result of a query

//when you need to use multiple steps to solve a problem
// switch your language choice to either statement(s0 or program

var maxcount = (from x in MediaTypes
				select x.Tracks.Count()).Max();
//to display the contents of a variable in LinqPad
//you use the method .Dump()
maxcount.Dump();

//tp filter data you can use the Where clause
//uses a previously create variable value in
//a following statement 
var mediatypecounts = from x in MediaTypes
				where x.Tracks.Count() == maxcount
				select new{
					Name = x.Name,
					TrackCount = x.Tracks.Count()
				};
mediatypecounts.Dump();

//Can this set of statements be written as one complete query?
// the answer: possibly; and in this case yes
//in this example maxcount could be exchanged for the query that
//actually created the value in the first place
//this subsitution query is a nesty query(subquery)
//the nested query needs its on instance indentifer
var mediatypecounts = from x in MediaTypes
				where x.Tracks.Count() == (from y in MediaTypes select y.Tracks.Count()).Max()
				select new{
					Name = x.Name,
					TrackCount = x.Tracks.Count()
				};
mediatypecounts.Dump();

//using a method syntax to determine the count value for the where express
//this demonstrates that queries can be constructed using
//both query syntax and method syntax
var mediatypecountsMethod = from x in MediaTypes
				where x.Tracks.Count() == 
				      MediaTypes.Select(y => y.Tracks.Count()).Max()
				select new{
					Name = x.Name,
					TrackCount = x.Tracks.Count()
				};
mediatypecountsMethod.Dump();

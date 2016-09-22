<Query Kind="Expression">
  <Connection>
    <ID>285b59c4-ba48-4182-b267-4171442776cd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// syntax style for .union() is
//(query).Union(query2).Union(queryn).OrderBy(firstsortfield).ThenBy(anothersortfield)

//to get both albums with tracks and without tracks, ---> use .Union

//rules
//number of columns the same
//colum datatype is the same
//for ordering the unioned queries us the name of the anonymous data files 
(from x in Albums
where x.Tracks.Count() > 0
orderby x.Title
select new {
		    Title =x.Title,
		    TotalTracksforAlbum =x.Tracks.Count(),
			TotalPricesforAlbum = x.Tracks.Sum(y => y.UnitPrice),
			AverageTrackLength = x.Tracks.Average(y => y.Milliseconds/1000.0),
			AverageTrackLength2 = (int)x.Tracks.Average(y => y.Milliseconds/1000)
	}
).Union(


from x in Albums
where x.Tracks.Count() == 0
select new {
		    Title =x.Title,
		    TotalTracksforAlbum = 0,
			TotalPricesforAlbum = 0.00m,
			AverageTrackLength = 0.00,
			AverageTrackLength2 = 0
	}
).OrderBy(y => y.TotalTracksforAlbum).ThenBy(y => y.Title)
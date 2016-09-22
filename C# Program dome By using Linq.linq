<Query Kind="Program">
  <Connection>
    <ID>285b59c4-ba48-4182-b267-4171442776cd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	// a list of bill counts for all waiters
	//this query will create a flat dataset
	//the colums are native datatype (ie int, string, double etc)
	// one is not concerned with repeated data in a column
	//instead of using an anonymous datatype (new{...})
	// we wish to use a defined class definition
	var maxbillcount = (from x in Waiters
						select x.Bills.Count()).Max();
	

	var BestWaiter = from x in Waiters
					where x.Bills.Count() == maxbillcount
					select new WaiterBillCounts{
						Name = x.FirstName + " " + x.LastName,
						Tcount = x.Bills.Count()
					};
	BestWaiter.Dump();
	
	var parmMonth = 5;
	var parmYear = 2014; 

	var waiterbills = from x in Waiters 
						where x.LastName.Contains("k")
						orderby x.LastName, x.FirstName
						select new WaiterBills{
								Name = x.LastName + "," + x.FirstName,
								TotalBillCount = x.Bills.Count(),
								BillInfo = (from y in x.Bills
											where y.BillItems.Count() > 0 &&
											y.BillDate.Month == parmMonth &&
											y.BillDate.Year == parmYear
											select new BillItemSummary{
											     BillId = y.BillID,
												 BillDate = y.BillDate,
												 TableID = y.TableID,
												 Total = y.BillItems.Sum(b => b.SalePrice)
											   }
											).ToList()
							
						};
	waiterbills.Dump();
}
//Define other methods and classes here
//an example of a poco class(flat)
public class WaiterBillCounts
{
	//whatever the recieving field on your query in your select
	//there appears a property of that name in this class
	public string Name{get; set;}
	public int Tcount{get; set;}
}
public class BillItemSummary
{
	public int BillId{get;set;}
	public DateTime BillDate{get;set;}
	public int? TableID{get;set;}
	public decimal Total{get;set;}	
}

//all example of a DTO class(structure/collection)
public class WaiterBills
{
	public string 	Name {get;set;}
	public int TotalBillCount{get;set;}
	public List<BillItemSummary> BillInfo{get;set;}
}

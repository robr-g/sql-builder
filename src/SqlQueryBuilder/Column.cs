namespace SqlQueryBuilder;

public class Column
{
    required public string Name { get; set; }
    required public string Table {get; set;}
    public string? Alias { get; set; }
}

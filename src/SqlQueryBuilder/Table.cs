namespace SqlQueryBuilder;

public class Table
{
    required public string Name { get; set; }
    public string? Alias { get; set; }
    required public string IdColumn { get; set; }
}

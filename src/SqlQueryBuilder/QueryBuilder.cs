namespace SqlQueryBuilder;

public class QueryBuilder
{
    required public Table Table { get; set; }
    public List<Column>? Columns { get; set; }
    required public bool SelectAll { get; set; }


    public string ToSql()
    {
        if (SelectAll)
        {
            return $"SELECT * FROM {Table.Name};";
        }
        else if (Columns != null)
        {
            List<string> columns = new List<string>();
            foreach (Column column in Columns)
            {
                switch (column.Alias)
                {
                    case null:
                        columns.Add($"{column.Name}");
                        break;
                    default:
                        columns.Add($"{column.Name} AS {column.Alias}");
                        break;
                }
            }
            
            return $"SELECT {string.Join(", ", columns)} FROM {Table.Name};";
        }
        else
        {
            return "No columns to be selected.";
        }
    }
}
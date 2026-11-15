namespace SqlQueryBuilder;

public class QueryBuilder
{
    required public Table Table { get; set; }
    public List<Column>? Columns { get; set; }
    public List<Join>? Joins { get; set; }
    required public bool SelectAll { get; set; }


    public string ToSql()
    {
        string select = "";
        string from = "";
        string where = "";

        //build the select columns
        if (SelectAll)
        {
            select = $"SELECT *";
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
            
            select = $"SELECT {string.Join(", ", columns)}";
        }
        else
        {
            return "No columns to be selected.";
        }


        //build the from tables
        if (Joins == null)
        {
            from = $"FROM {Table.Name}";
        }
        else
        {
            List<string> joins = new List<string>();
            foreach(Join join in Joins)
            {
                string joinType;
                switch (join.joinType)
                {
                    case JoinType.InnerJoin:
                        joinType = "INNER JOIN";
                        break;
                    case JoinType.FullJoin:
                        joinType = "OUTER JOIN";
                        break;
                    case JoinType.LeftJoin:
                        joinType = "LEFT JOIN";
                        break;
                    case JoinType.RightJoin:
                        joinType = "RIGHT JOIN";
                        break;
                    default:
                        joinType = "MISSING JOIN TYPE";
                        break;
                }

                joins.Add($"{joinType} {join.RightTable} {join.TableAlias} ON {Table.Alias}.{Table.IdColumn} = {join.TableAlias}.{join.JoinColumn}");
            }
            
            from = $"FROM {Table.Name} {string.Join(" ", joins)}";
        }   

        return $"{select} {from} {where};";
    }
}
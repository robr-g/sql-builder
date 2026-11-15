namespace SqlQueryBuilder;

public class QueryBuilder
{
    //select
    public List<Column>? SelectColumns { get; set; } = new();
    required public bool SelectAll { get; set; }

    //from
    required public Table Table { get; set; }
    public List<Join>? Joins { get; set; } = new();

    //where
    public WhereClause? Clause { get; set; }

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
        else if (SelectColumns != null)
        {
            List<string> columns = new List<string>();
            foreach (Column column in SelectColumns)
            {
                string selectColumn;
            
                switch (column.Alias)
                {
                    case null:
                        selectColumn = $"{column.Name}";
                        break;
                    default:
                        selectColumn = $"{column.Name} AS {column.Alias}";
                        break;
                }

                switch (Joins)
                {
                    case null:
                        columns.Add(selectColumn);
                        break;
                    default:
                        columns.Add($"{column.Table.Alias}.{selectColumn}");
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
        if (Joins is null)
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
                        joinType = "FULL OUTER JOIN";
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

                joins.Add($"{joinType} {join.RightTable.Name} {join.RightTable.Alias} ON {join.LeftTable.Alias}.{join.LeftJoinColumn} = {join.RightTable.Alias}.{join.RightJoinColumn}");
            }
            
            from = $"\nFROM {Table.Name} {Table.Alias}\n{string.Join("\n", joins)}";
        }   

        //build where clause
        if (Clause != null)
        {
            where = $"\nWHERE {Clause.GetClause()}";
            return $"{select} {from} {where};";
        }

        return $"{select} {from};";
    }
}
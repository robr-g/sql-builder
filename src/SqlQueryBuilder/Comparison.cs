namespace SqlQueryBuilder;

public class Comparison : WhereClause
{
    required public Column Left { get; set; }
    required public ComparativeOperator ComparativeOperator { get; set; }
    required public string Right { get; set; }


    public override string GetClause()
    {
        switch (ComparativeOperator)
        {
            case ComparativeOperator.Equal:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} = {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} = {Right}";
                }
            case ComparativeOperator.NotEqual:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} != {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} != {Right}";
                }
            case ComparativeOperator.GreaterThan:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} > {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} > {Right}";
                }
            case ComparativeOperator.GreaterThanOrEqual:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} >= {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} >= {Right}";
                }
            case ComparativeOperator.LessThan:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} < {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} < {Right}";
                }
            case ComparativeOperator.LessThanOrEqual:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} <= {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} <= {Right}";
                }
            case ComparativeOperator.Like:
                switch (Left.Table.Alias)
                {
                    case null:
                        return $"{Left.Name} LIKE {Right}";
                    default:
                        return $"{Left.Table.Alias}.{Left.Name} LIKE {Right}";
                }
            default:
                return "COMPARISION TYPED INCORRECTLY";
        }
    }
}
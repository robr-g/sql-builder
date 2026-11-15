using System.ComponentModel.Design;

namespace SqlQueryBuilder;

public class Connect : WhereClause
{
    required public WhereClause Left { get; set; }
    required public LogicalOperator LogicalOperator { get; set; }
    required public WhereClause Right { get; set; }


    public override string GetClause()
    { 
        switch (LogicalOperator)
        {
            case LogicalOperator.AND:
                return $"({Left.GetClause()} AND {Right.GetClause()})";
            case LogicalOperator.OR:
                return $"({Left.GetClause()} OR {Right.GetClause()})";
            default:
                return "CONNECTION FAILED";
        }
    }
}
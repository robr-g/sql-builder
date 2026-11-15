namespace SqlQueryBuilder;

public class Join
{
    required public JoinType joinType { get; set; }
    required public Table RightTable { get; set; }
    required public string RightJoinColumn { get; set; }
    required public Table LeftTable { get; set; }
    required public string LeftJoinColumn { get; set; }
}
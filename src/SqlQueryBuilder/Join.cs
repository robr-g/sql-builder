namespace SqlQueryBuilder;

public class Join
{
    required public JoinType joinType { get; set; }
    required public string RightTable { get; set; }
    required public string RightTableAlias { get; set; }
    required public string RightJoinColumn { get; set; }
}
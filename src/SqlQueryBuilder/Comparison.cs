namespace SqlQueryBuilder;

public class Comparison
{
    required public string LeftCondition { get; set; }
    required public ComparativeOperator ComparativeOperator { get; set; }
    required public string RightCondition { get; set; }
}
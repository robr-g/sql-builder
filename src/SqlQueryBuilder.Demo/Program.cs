// See https://aka.ms/new-console-template for more information
using SqlQueryBuilder;


//this is the most basic idea. a simple select all from a table.
QueryBuilder QOne = new QueryBuilder
{
    Table = new Table
    {
        Name = "Employees",
        Alias = "emp",
        IdColumn = "empId"
    },
    SelectAll = true
};

System.Console.WriteLine(QOne.ToSql());


//a slightly more complicated version of a select with multiple columns with some having alias's.
QueryBuilder QTwo = new QueryBuilder
{
    Table = new Table
    {
        Name = "Books",
        IdColumn = "id"
    },
    Columns = new List<Column>
    {
      new Column
      {
          Name = "Dune",
          Table = "Books"
      },
      new Column
      {
          Name = "Lord of the rings",
          Alias = "LOTR",
          Table = "Books"
      }
    },
    SelectAll = false
};

System.Console.WriteLine(QTwo.ToSql());



QueryBuilder QThree = new QueryBuilder
{
    Table = new Table
    {
        Name = "Employees",
        Alias = "emp",
        IdColumn = "empId"
    },
    Joins = new List<Join>
    {
        new Join
        {
            joinType = JoinType.InnerJoin,
            RightTable = "Department",
            RightTableAlias = "dept",
            RightJoinColumn = "deptId"
        }
    },
    SelectAll = true
};

Console.WriteLine(QThree.ToSql());
// See https://aka.ms/new-console-template for more information
using SqlQueryBuilder;

QueryBuilder QOne = new QueryBuilder
{
    Table = new Table
    {
        Name = "Employees",
        Alias = "emp"
    },
    SelectAll = true
};

QueryBuilder QTwo = new QueryBuilder
{
    Table = new Table
    {
        Name = "Books",
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

System.Console.WriteLine(QOne.ToSql());
System.Console.WriteLine(QTwo.ToSql());
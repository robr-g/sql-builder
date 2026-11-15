// See https://aka.ms/new-console-template for more information
using SqlQueryBuilder;

Table Employees = new Table {
	Name = "Employees",
	Alias = "emp",
    IdColumn = "empId"
};

Table Department = new Table {
	Name = "Department",
	Alias = "dept",
    IdColumn = "deptId"	
};

Table Location = new Table {
	Name = "Location",
	Alias = "loc",
    IdColumn = "LocId"
};


QueryBuilder QOne = new QueryBuilder 
{
    //choose columns to select with their alisas if desired.
	SelectColumns = new List<Column> {
		new Column {
			Name = "employee_name",
			Alias = "name",
			Table = Employees
		},
		new Column {
			Name = "department_name",
			Alias = "department",
			Table = Department
		},
		new Column {
			Name = "city",
			Table = Location
		}
	},

    //begin with a table, then add joins if desired.
    Table =	Employees,
    Joins = new List<Join> {
        new Join {
            joinType = JoinType.InnerJoin,
            LeftTable = Employees,
            LeftJoinColumn = "deptId",
            RightTable = Department,
            RightJoinColumn = Department.IdColumn
        },
        new Join {
            joinType = JoinType.InnerJoin,
            LeftTable = Department,
            LeftJoinColumn = "locId",
            RightTable = Location,
            RightJoinColumn = Location.IdColumn
        },
	},

    //building the whereclause through comparisons and connections.
    Clause = new Connect
    {
        Left = new Connect
        {
            Left = new Comparison
            {
                Left = new Column
                {
                    Name = "department_name",
                    Table = Department
                },
                ComparativeOperator = ComparativeOperator.Like,
                Right = "'C%'"
            },
            LogicalOperator = LogicalOperator.OR,
            Right = new Comparison
            {
                Left = new Column
                {
                    Name = "department_name",
                    Table = Department
                },
                ComparativeOperator = ComparativeOperator.Like,
                Right = "'A___'"
            },
        },
        LogicalOperator = LogicalOperator.AND,
        Right = new Comparison
        {
            Left = new Column
            {
                Name = "Salary",
                Table = Employees
            },
            ComparativeOperator = ComparativeOperator.LessThan,
            Right = "35000"
        }
    },
    SelectAll = false
};

Console.WriteLine(QOne.ToSql());

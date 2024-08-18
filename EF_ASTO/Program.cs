using EF_ASTO.DAL.DbContexts;
using EF_ASTO.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_ASTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            var connectionString = config.GetConnectionString("DefaultConnection");
            //Console.WriteLine(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<AstoDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AstoDbContext db = new AstoDbContext(options))
            {
                Row row1 = new() { RowName = "Row_01" };
                Row row2 = new Row() { RowName = "Row_02" };
                Row row3 = new Row() { RowName = "Row_03" };
                Row row4 = new Row() { RowName = "Row_04" };

                Column column1 = new Column() { ColumnName = "Column_01" };
                Column column2 = new Column() { ColumnName = "Column_02" };
                Column column3 = new Column() { ColumnName = "Column_03" };
                Column column4 = new Column() { ColumnName = "Column_04" };
                Column column5 = new Column() { ColumnName = "Column_05" };

                //row1.

                db.Rows.AddRange(row1, row2, row3, row4);
                db.Columns.AddRange(column1, column2, column3, column4);

                Cell cell1 = new Cell() { Row = row1, Column = column1, Value = 11 };
                Cell cell2 = new Cell() { Row = row1, Column = column2, Value = 12 };
                Cell cell3 = new Cell() { Row = row1, Column = column3, Value = 13 };
                Cell cell4 = new Cell() { Row = row2, Column = column4, Value = 24 };
                Cell cell5 = new Cell() { Row = row2, Column = column5, Value = 25 };
                Cell cell6 = new Cell() { Row = row3, Column = column1, Value = 31 };
                Cell cell7 = new Cell() { Row = row3, Column = column2, Value = 32 };
                Cell cell8 = new Cell() { Row = row3, Column = column3, Value = 33 };

                db.Cells.AddRange(cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8);

                db.SaveChanges();

                Console.WriteLine("----------------------------------------------------------------------------------------");
                var rows = db.Rows.ToList();
                foreach (Row row in rows)
                    Console.WriteLine($"{row.RowId}.{row.RowName}");

                Console.WriteLine("----------------------------------------------------------------------------------------");
                var columns = db.Columns.ToList();
                foreach (Column column in columns)
                    Console.WriteLine($"{column.ColumnId}.{column.ColumnName}");

                Console.WriteLine("----------------------------------------------------------------------------------------");
                var cells = db.Cells.ToList();
                foreach (Cell cell in cells)
                    Console.WriteLine($"{cell.RowId}({cell.Row.RowName}).{cell.ColumnId}({cell.Column.ColumnName}) -- Value={cell.Value}");
            }
        }
    }
}

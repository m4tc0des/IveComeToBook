using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace IveComeToBook.Infrastructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected FluentMigrator.Builders.Create.Table.ICreateTableColumnOptionOrWithColumnSyntax CreateTableWithDefaultColumns(string table)
        {
            return Create.Table(table)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable();
        }
    }
}

using FluentMigrator;

namespace IveComeToBook.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table to save user's information")]
    public class Version0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}

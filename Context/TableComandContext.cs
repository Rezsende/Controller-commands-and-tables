using Microsoft.EntityFrameworkCore;
using TableandCommandControl.Entity;


namespace TableandCommandControl.Context
{
    public class TableComandContext : DbContext
    {
        public TableComandContext(DbContextOptions<TableComandContext> options) : base(options)
        {

        }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCommands> ProductCommands { get; set; }
        public DbSet<TableCommand> TableCommands { get; set; }
        public DbSet<Dependents> Dependents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
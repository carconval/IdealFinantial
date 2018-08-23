namespace Borrower.Dal
{
    public class BorrowerDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }

        public BorrowerDbSettings()
        {
            ConnectionString = "mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true";
            Database = "BorrowerDB";
        }
    }
}
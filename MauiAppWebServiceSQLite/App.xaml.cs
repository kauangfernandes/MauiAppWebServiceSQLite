using MauiAppWebServiceSQLite.Helpers;
namespace MauiAppWebServiceSQLite
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper database;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                        ), "slqite.db3"
                    );

                    database = new SQLiteDataBaseHelper(path);
                }

                return database;
            }
        }
    }
}

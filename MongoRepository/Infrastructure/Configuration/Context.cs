using System.Configuration;
using System.Diagnostics;
using System.IO;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure.Configuration
{
    public interface IContext
    {
        MongoDB.Driver.IMongoDatabase database { get; set; }
    }

    public class Context : IContext
    {
        public BackupRestore Local { get { return new BackupRestore(); } }

        public Context()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            var mongoUrl = new MongoUrl(connectionString);
            this.database = new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName);
            //  Init();
        }

        public void Init()
        {
            var obj = new DBInitializer(this);
            obj.CreateIndex();
            obj.Seed();
        }

        public IMongoDatabase database { get; set; }
    }

    public class BackupRestore : BackupRestoreConfig
    {
        public BackupRestore()
        {
        }
    }

    public abstract class BackupRestoreConfig
    {
        public string FullDatabae(string mongodbPath, string databaseName, string backupPath)
        {
            if (!File.Exists(mongodbPath + "/mongodump.exe"))
            {
                return "invalid mongodnPath";
            }
            var proc1 = new ProcessStartInfo();
            string anyCommand = string.Format("mongodump --db {0}  --out {1}", databaseName, backupPath);
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = mongodbPath;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

            return "imported successfully";
        }

        public string BackupCollection(string mongodbPath, string databaseName, string collectionName, string backupPath)
        {
            if (!File.Exists(mongodbPath + "/mongodump.exe"))
            {
                return "invalid mongodnPath";
            }

            var proc1 = new ProcessStartInfo();
            string anyCommand = string.Format("mongodump --db {0} --collection {1}  -o {2}", databaseName, collectionName, backupPath);
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = mongodbPath;

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
            return "imported successfully";
        }

        public void Restore(string mongodbPath, string databaseName, string backupPath)
        {
            if (!File.Exists(mongodbPath + "/mongodump.exe"))
            {
                // return "invalid mongodnPath";
            }
            var proc1 = new ProcessStartInfo();

            string anyCommand = string.Format("mongorestore --db {0} {1}", databaseName, backupPath);
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = mongodbPath;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }
    }
}
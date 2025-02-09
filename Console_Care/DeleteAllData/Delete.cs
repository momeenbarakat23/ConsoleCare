using Console_Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.DeleteAllData
{
    public class Delete : IDelete
    {
        private readonly Appdbcontext appdbcontext;

        public Delete(Appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public async Task<bool> Deleteasync(string NameTable)
        {
           await appdbcontext.Database.BeginTransactionAsync();
            try
            {

                await appdbcontext.Database.ExecuteSqlRawAsync($"delete from {NameTable}");
                await appdbcontext.Database.ExecuteSqlRawAsync($"dbcc checkident('{NameTable}',reseed,0)");
                await appdbcontext.Database.CommitTransactionAsync();
                return true;
            }
            catch (Exception)
            {

                await appdbcontext.Database.RollbackTransactionAsync();
                return false;
            }
           
        }
    }
}

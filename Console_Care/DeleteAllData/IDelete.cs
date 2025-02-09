namespace Console_Care.DeleteAllData
{
    public interface IDelete
    {
        public Task<bool> Deleteasync(string NameTable);
    }
}

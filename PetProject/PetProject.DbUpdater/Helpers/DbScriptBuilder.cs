namespace PetProject.DbUpdater.Helpers
{
    /// <summary>
    /// Билдер скриптов
    /// </summary>
    public static class DbScriptBuilder
    {
        public static string EnableSnapshot()
        {
            return "ALTER DATABASE [petproject_db] SET ALLOW_SNAPSHOT_ISOLATION ON " +
                "ALTER DATABASE [petproject_db] SET READ_COMMITTED_SNAPSHOT ON";
        }
    }
}
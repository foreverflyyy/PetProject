using CommandLine;

namespace PetProject.DbUpdater.Helpers
{
    public class UpdateOptions
    {
        [Option('m', "migrate", Default = false, HelpText = "Попытаться провести миграцию")]
        public bool Migrate { get; set; }

        [Option('d', "develop", Default = false, HelpText = "Пересоздать базу данных. (Удалить и потом создать)")]
        public bool Develop { get; set; }

        [Option('r', "recreate", Default = false, HelpText = "Пересоздать базу данных при помощи миграций. (Удалить и потом создать)")]
        public bool Recreate { get; set; }

        [Option('f', "force", Default = false, HelpText = "Не запрашивать подтверждения")]
        public bool Force { get; set; }
    }
}

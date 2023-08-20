using IGDB.Models;
using IGDB;

namespace GameStore.Models.IGDB
{

    public class PlatformDetailsViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Summary { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string? AlternativeName { get; set; }

        public int? Generation { get; set; }

        public string? Url { get; set; }

        public PlatformCategory Category { get; set; }

        public int PlatformFamily { get; set; }
        public string PlatformFamilyInfo { get; set; }

        public string PlatformLogo { get; set; }
        public string PlatformLogoImageId { get; set; }

        public List<int> Versions { get; set; }
        public string PlatformVersionSummary { get; set; }
    }

    public class PlatformFamilyViewModel
    {
        public string Name { get; set; }
    }

    public class VersionViewModel
    {
        public string Summary { get; set; }
    }

    public class PlatformLogoViewModel
    {
        public string imageId { get; set; }
    }

    public enum PlatformCategory
    {
        Console = 1,
        Arcade = 2,
        Platform = 3,
        OperatingSystem = 4,
        PortableConsole = 5,
        Computer = 6
    }
}

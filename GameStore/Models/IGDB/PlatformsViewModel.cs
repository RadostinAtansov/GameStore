using Microsoft.EntityFrameworkCore;

namespace GameStore.Models.IGDB
{

    public class PlatformsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlternativeName { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public string PlatformLogo { get; set; }
        public PlatformLogo PlatformLogoInfo = new();

        public DateTimeOffset? UpdatedAt { get; set; }
    }

    [Keyless]
    public class PlatformLogo
    {
        public string Id { get; set; }

        public string ImageId { get; set; }

    }
}
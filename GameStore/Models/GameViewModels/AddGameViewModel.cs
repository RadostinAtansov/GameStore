namespace GameStore.Models.GameViewModels
{
    public class AddGameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Company { get; set; }

        public string VideoURL { get; set; }
    }
}
namespace PremierLeagueApp.Data.Models
{
    using PremierLeagueApp.Data.Common.Models;

    public class News : BaseModel<int>
    {
        public byte[] Image { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}

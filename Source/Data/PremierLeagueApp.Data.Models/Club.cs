namespace PremierLeagueApp.Data.Models
{
    using System.Collections.Generic;

    using PremierLeagueApp.Data.Common.Models;

    public class Club : BaseModel<int>
    {
        public Club()
        {
            this.News = new HashSet<News>();
        }

        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}

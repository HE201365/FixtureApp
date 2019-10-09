using System;
namespace FixtureApp.Data
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }

        public int TeamLeftId { get; set; }
        public Team TeamLeft { get; set; }

        public int TeamRightId { get; set; }
        public Team TeamRight { get; set; }
    }
}

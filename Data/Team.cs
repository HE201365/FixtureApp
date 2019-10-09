using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureApp.Data
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Match> MatchsL { get; set; }
        public ICollection<Match> MatchsR { get; set; }
    }
}

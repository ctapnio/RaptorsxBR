/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MTChristianTapnio
{
    class Player : Person
    {
        public Player(int matchesPlayed, int won, int lost, int goalsScored, int id, string name) : base(id, name) 
        {
            Id = id;
            Name = name;
            MatchesPlayed = matchesPlayed;
            Won = won;
            Lost = lost;
            GoalsScored = goalsScored;
        }
        private int _matchesPlayed;
        private int _won;
        private int _lost;
        private int _goalsScored;
        public int MatchesPlayed
        {
            get { return _matchesPlayed; }
            set { _matchesPlayed = value; }
        }
       
        public int Won
        {
            get { return _won; }
            set { _won = value; }
        }
        
        public int Lost
        {
            get { return _lost; }
            set { _lost = value; }
        }
       
        public int GoalsScored
        {
            get { return _goalsScored; }
            set { _goalsScored = value; }
        }

        public static int id { get; }
        public static string name { get; }
    }
}

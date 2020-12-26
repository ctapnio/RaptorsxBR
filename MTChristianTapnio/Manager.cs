/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MTChristianTapnio
{
    class Manager : Person
    {
        public Manager(int playersRecruited, double availableBudget, string strength, int id, string name) : base(id, name)
        {
            Id = id;
            Name = name;
            PlayersRecruited = playersRecruited;
            AvailableBudget = availableBudget;
            Strength = strength;
        }
        private int _playersRecruited;
        private double _availableBudget;
        private string _strength;
        public int PlayersRecruited
        {
            get { return _playersRecruited; }
            set { _playersRecruited = value; }
        }
        

        public double AvailableBudget
        {
            get { return _availableBudget; }
            set { _availableBudget = value; }
        }
        

        public string Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

    }
}

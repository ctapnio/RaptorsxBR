/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MTChristianTapnio
{
    class Coach : Person
    {
        public Coach(int numberOfTeamsCoached, int playersTrained, double winPercentage, int yearsOfExperience, int id, string name): base(id, name)
        {
            NumberOfTeamsCoached = numberOfTeamsCoached;
            PlayersTrained = playersTrained;
            WinPercentage = winPercentage;
            YearsOfExperience = yearsOfExperience;
            Id = id;
            Name = name;
        }
        private int _numberOfTeamsCoached;
        private int _playersTrained;
        private double _winPercentage;
        private int _yearsOfExperience;

        public int NumberOfTeamsCoached
        {
            get { return _numberOfTeamsCoached; }
            set { _numberOfTeamsCoached = value; }
        }
        

        public int PlayersTrained
        {
            get { return _playersTrained; }
            set { _playersTrained = value; }
        }
        

        public double WinPercentage
        {
            get { return _winPercentage; }
            set { _winPercentage = value; }
        }
       

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }

    }
}

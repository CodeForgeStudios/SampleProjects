using System.Collections.Generic;

namespace RobotSimApp.Models
{
    public class Table
    {
        private static int GRIDSIZE = 4;    //0 index based, default to 5 units
        private int dimensions;

        public Table()
        {
            dimensions = GRIDSIZE; // default table dimensions
        }

        public int Dimensions { get => dimensions; }
        public List<Robot> Robots { get; set; }

        public bool ValidCoordinates(int x, int y){

            //check if numbers are within accepted range
            if ((x < 0 || y < 0) || (x > dimensions || y > dimensions)) return false;

            return true;
        }
    }
}
using RobotSimApp.Models;

namespace RobotSimApp.Controllers
{
    public class RobotSimController
    {

        private Table _table;
        private Robot _robot;
        private const int TURN = 90;
        private const int MOVEUNIT = 1;

        public RobotSimController(Table table, Robot robot)
        {
            _table = table;
            _robot = robot;

        }

        public void Place(int x, int y, string face)
        {

            // verify we have valid coordinates
            if (_table.ValidCoordinates(x, y) == false) return;

            // position robot at desired coordinates
            _robot.X = x;
            _robot.Y = y;
            _robot.F = OrientationToAngle(face);

        }

        //Moves robot by 1 unit in direction its facing
        public void Move()
        {
            if (_robot.IsPlaced == false) return;

            switch (_robot.F)
            {
                case 0:
                    if (_robot.X < _table.Dimensions)
                        _robot.X += MOVEUNIT;
                    break;
                
                case 90:
                    if (_robot.Y < _table.Dimensions)
                        _robot.Y += MOVEUNIT;

                    break;
                case 180:
                    if (_robot.X > 0)
                        _robot.X -= MOVEUNIT;
                    break;
                case 270:
                    if (_robot.Y > 0)
                        _robot.Y -= MOVEUNIT;
                    break;
            }

        }

        //Rotates robot left by 90 degrees
        public void Left()
        {
            if (_robot.IsPlaced == false) return;

            if (_robot.F == 270)
                _robot.F = 0;
            else
                _robot.F += TURN;

        }

        //Rotates robot right by 90 degrees
        public void Right()
        {
            if (_robot.IsPlaced == false) return;

            if (_robot.F == 0)
                _robot.F = 270;
            else
                _robot.F -= TURN;

        }

        //Displays current position and orientation
        public string Report()
        {
            if (_robot.IsPlaced == false)
                return "Robot not placed!";

            return $"{_robot.X}, {_robot.Y}, {AngleToOrientation(_robot.F)} ";
        }

        #region "Helper Methods"

        private int OrientationToAngle(string orientation)
        {
            int retval = 0;
            switch (orientation.ToLower())
            {
                
                case "east":
                    retval = 0;
                    break;
                case "north":
                    retval = 90;
                    break;
                case "west":
                    retval = 180;
                    break;
                case "south":
                    retval = 270;
                    break;
                
            }
            return retval;
        }

        private string AngleToOrientation(int a)
        {
            string retval = string.Empty;
            switch (a)
            {
                case 0:
                    retval = "East";
                    break;
                case 90:
                    retval = "North";
                    break;
                case 180:
                    retval = "West";
                    break;
                case 270:
                    retval = "South";
                    break;
            }

            return retval;
        }

        #endregion
    }
}
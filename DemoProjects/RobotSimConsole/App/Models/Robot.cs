namespace RobotSimApp.Models
{

    public class Robot {

        public int? X { get;  set; } 
        public int? Y { get;  set; }
        public int F { get;  set; }

        
        #region "Private Members"

        public bool IsPlaced { 
            get {
                return X.HasValue && Y.HasValue;
            } 
        }

        

        #endregion
    }
}
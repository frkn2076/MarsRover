using MarsRover.DefinedExceptions;
using System;

namespace MarsRover.Models {
    public class Rover {
        public long xCoordinate;
        public long yCoordinate;
        public Compass compass;
        public string order;
        public Rover(long xCoordinate, long yCoordinate, char compass, string order) {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;

            if (!Enum.IsDefined(typeof(Compass), char.ToString(compass)))
                throw new UnexpectedInputException();
            this.compass = Enum.Parse<Compass>(char.ToString(compass));

            this.order = order;
        }

        public string getPositon() {
            return $"{xCoordinate} {yCoordinate} {compass}";
        }
    }
}

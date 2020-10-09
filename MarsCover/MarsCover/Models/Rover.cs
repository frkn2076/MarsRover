using MarsRover.DefinedExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Models {
    public class Rover {
        public ulong xCoordinate;
        public ulong yCoordinate;
        public Compass compass;
        public List<Direction> orders;
        public Rover(ulong xCoordinate, ulong yCoordinate, char direction, string order) {
            if (xCoordinate == 0 || yCoordinate == 0)
                throw new InvalidPlateauException();
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;

            if (!Enum.IsDefined(typeof(Compass), char.ToString(direction)))
                throw new UnexpectedInputException();
            this.compass = Enum.Parse<Compass>(char.ToString(direction));

            if(order != null && order.Any(c=> !Enum.IsDefined(typeof(Direction), char.ToString(c))))
                throw new UnexpectedInputException();
            orders = order.Select(c=> Enum.Parse<Direction>(char.ToString(c))).ToList();
        }

        public void printPositons() {
            Console.WriteLine($"{xCoordinate} {yCoordinate} {compass}");
        }
    }
}

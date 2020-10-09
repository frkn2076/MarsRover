using MarsRover;
using MarsRover.DefinedExceptions;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsCover {
    public class ProblemSolving : IProblemSolving {
        private List<Rover> findLocation(KeyValuePair<long, long> sizeOfPlateau, List<Rover> rovers) {

            if (sizeOfPlateau.Key == 0 || sizeOfPlateau.Value == 0)
                throw new InvalidPlateauException();

            var roverList = new List<Rover>();

            foreach (var rover in rovers) {
                if (!string.IsNullOrEmpty(rover.order)) {
                    //Removed repetive inverse operations to increase performance
                    rover.order = rover.order.Replace("RL", "");
                    rover.order = rover.order.Replace("LR", "");

                    var orders = rover.order.Select(c => Enum.Parse<Direction>(char.ToString(c))).ToList();
                    foreach (var order in orders) {
                        if (order == Direction.M) {
                            moveRover(rover);
                        }
                        else {
                            var compassEnumSize = Enum.GetNames(typeof(Compass)).Length;
                            var directedCompass = ((short)rover.compass + (short)order + compassEnumSize) % compassEnumSize;
                            rover.compass = (Compass)directedCompass;
                        }
                    }
                }

                if (rover.xCoordinate < 0 || rover.yCoordinate < 0 || rover.xCoordinate > sizeOfPlateau.Key || rover.yCoordinate > sizeOfPlateau.Value)
                    throw new OutOfPlateauRangeException();

                roverList.Add(rover);
            }

            return roverList;
        }

        private void moveRover(Rover rover) {
            switch (rover.compass) {
                case Compass.N:
                    rover.yCoordinate++;
                    break;
                case Compass.E:
                    rover.xCoordinate++;
                    break;
                case Compass.S:
                    rover.yCoordinate--;
                    break;
                case Compass.W:
                    rover.xCoordinate--;
                    break;
            }
        }

        #region Explicit Interface Definitions

        List<Rover> IProblemSolving.findLocation(KeyValuePair<ulong, ulong> sizeOfPlateau, List<Rover> rovers) => findLocation(new KeyValuePair<long,long>((long)sizeOfPlateau.Key, (long)(sizeOfPlateau.Value)), rovers);
        
        #endregion
    }
}

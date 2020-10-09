using MarsRover;
using MarsRover.DefinedExceptions;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsCover {
    class ProblemSolving : IProblemSolving {
        private void findLocation(KeyValuePair<ulong, ulong> sizeOfPlateau, List<Rover> rovers) {

            foreach (var rover in rovers) {
                foreach (var order in rover.orders) {
                    if(order == Direction.M) {
                        if (rover.compass == Compass.N)
                            rover.yCoordinate++;
                        if (rover.compass == Compass.S)
                            rover.yCoordinate--;
                        if (rover.compass == Compass.E)
                            rover.xCoordinate++;
                        if (rover.compass == Compass.W)
                            rover.xCoordinate--;
                    } 
                    else {
                        var compassEnumSize = Enum.GetNames(typeof(Compass)).Length;
                        var directedCompass = ((short)rover.compass + (short)order + compassEnumSize) % compassEnumSize;
                        rover.compass = (Compass)directedCompass;
                    }

                }

                if (rover.xCoordinate < 0 || rover.yCoordinate < 0 || rover.xCoordinate > sizeOfPlateau.Key || rover.yCoordinate > sizeOfPlateau.Value)
                    throw new OutOfPlateauRangeException();
                    
                rover.printPositons();
            }
        }
        void IProblemSolving.findLocation(KeyValuePair<ulong, ulong> sizeOfPlateau, List<Rover> rovers) => findLocation(sizeOfPlateau, rovers);
    }
}

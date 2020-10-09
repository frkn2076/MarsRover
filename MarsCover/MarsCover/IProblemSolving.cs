using MarsRover.Models;
using System.Collections.Generic;

namespace MarsCover {
    internal interface IProblemSolving {
        void findLocation(KeyValuePair<ulong, ulong> sizeOfPlateau, List<Rover> rovers);
    }
}
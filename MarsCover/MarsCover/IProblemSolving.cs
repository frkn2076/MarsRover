using MarsRover.Models;
using System.Collections.Generic;

namespace MarsCover {
    public interface IProblemSolving {
        List<Rover> findLocation(KeyValuePair<ulong, ulong> sizeOfPlateau, List<Rover> rovers);
    }
}
using MarsRover.DefinedExceptions;
using MarsRover.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRoverTesting {
    [TestClass]
    public class ProblemSolvingTest : BaseTest {
        [TestMethod]
        public void Given_input_parameters__When_problem_solving_called__Returns_expected_result_1() {
            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(5, 5);
            var rover1 = new Rover(1, 2, 'N', "LMLMLMLMM");
            var rover2 = new Rover(3, 3, 'E', "MMRMMRMRRM");
            var rovers = new List<Rover>() { rover1, rover2 };
            
            #endregion

            #region act

            var roverList = problemSolving.findLocation(sizeOfPlateau, rovers);

            #endregion

            #region assert

            Assert.AreEqual(2, roverList.Count);
            Assert.AreEqual("1 3 N", $"{roverList[0].getPositon()}");
            Assert.AreEqual("5 1 E", $"{roverList[1].getPositon()}");

            #endregion
        }

        [TestMethod]
        public void Given_input_parameters__When_problem_solving_called__Returns_expected_result_2() {
            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(15, 15);
            var rover1 = new Rover(7, 3, 'E', "LRLMMRRLMM");
            var rover2 = new Rover(1, 4, 'N', "MMRMMRMRRM");
            var rover3 = new Rover(0, 0, 'E', "MMML");
            var rovers = new List<Rover>() { rover1, rover2, rover3 };

            #endregion

            #region act

            var roverList = problemSolving.findLocation(sizeOfPlateau, rovers);

            #endregion

            #region assert

            Assert.AreEqual(3, roverList.Count);
            Assert.AreEqual("9 5 E", $"{roverList[0].getPositon()}");
            Assert.AreEqual("3 6 N", $"{roverList[1].getPositon()}");
            Assert.AreEqual("3 0 N", $"{roverList[2].getPositon()}");

            #endregion
        }

        [TestMethod]
        public void Given_out_of_plateau_input_parameters__When_problem_solving_called__Throws_user_friendly_exception() {
            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(10, 10);
            var rover1 = new Rover(7, 11, 'E', "LRM");
            //var rover2 = new Rover(7, 7, 'E', "MMMMM");
            var rovers = new List<Rover>() { rover1 };

            #endregion

            #region act && assert

            Assert.ThrowsException<OutOfPlateauRangeException>(() => problemSolving.findLocation(sizeOfPlateau, rovers));

            #endregion
        }

        [TestMethod]
        public void Given_input_parameters_which_moves_rover_out_of_plateau__When_problem_solving_called__Throws_user_friendly_exception() {
            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(10, 10);
            var rover1 = new Rover(7, 7, 'E', "MMMMM");
            var rovers = new List<Rover>() { rover1 };

            #endregion

            #region act && assert

            Assert.ThrowsException<OutOfPlateauRangeException>(() => problemSolving.findLocation(sizeOfPlateau, rovers));

            #endregion
        }

        [TestMethod]
        public void Given_invalid_input_parameters__When_rover_constructor_called__Throws_user_friendly_exception() {

            #region arrange && act && assert

            Assert.ThrowsException<UnexpectedInputException>(() => new Rover(1, 1, 'K', "MLMRL"));

            #endregion
        }

        [TestMethod]
        public void Given_non_2D_plateau_input_parameters__When_rover_constructor_called__Throws_user_friendly_exception() {

            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(0, 5);
            var rover1 = new Rover(2, 1, 'N', "LRM");
            var rovers = new List<Rover>() { rover1 };

            #endregion

            #region act && assert

            Assert.ThrowsException<InvalidPlateauException>(() => problemSolving.findLocation(sizeOfPlateau, rovers));

            #endregion
        }

        [TestMethod]
        public void Given_empty_or_null_order_input_parameters__When_problem_solving_called__Keeps_its_position() {

            #region arrange

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(5, 5);
            var rover1 = new Rover(2, 1, 'N', "");
            var rover2 = new Rover(3, 4, 'W', null);
            var rovers = new List<Rover>() { rover1, rover2 };

            #endregion

            #region act

            var roverList = problemSolving.findLocation(sizeOfPlateau, rovers);

            #endregion

            #region assert

            Assert.AreEqual(2, roverList.Count);
            Assert.AreEqual("2 1 N", $"{roverList[0].getPositon()}");
            Assert.AreEqual("3 4 W", $"{roverList[1].getPositon()}");

            #endregion
        }
    }
}

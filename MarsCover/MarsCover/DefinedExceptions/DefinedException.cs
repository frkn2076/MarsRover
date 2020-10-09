using System;

namespace MarsRover.DefinedExceptions {
    public class DefinedException : Exception {
        public DefinedException(string message, Exception exception) : base(message, exception) {
        }
    }

    public class InvalidPlateauException : DefinedException {
        public InvalidPlateauException() : base(Helper.InvalidPlateauErrorMessage, new Exception()) {
        }
    }

    public class UnexpectedInputException : DefinedException {
        public UnexpectedInputException() : base(Helper.UnexceptedInputErrorMessage, new Exception()) {
        }
    }

    public class OutOfPlateauRangeException : DefinedException {
        public OutOfPlateauRangeException() : base(Helper.OutOfPlateauRangeErrorMessage, new Exception()) {
        }
    }
}

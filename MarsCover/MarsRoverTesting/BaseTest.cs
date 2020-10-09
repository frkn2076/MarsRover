using MarsCover;

namespace MarsRoverTesting {
    public class BaseTest {
        protected internal IProblemSolving problemSolving;
        public BaseTest() {
            problemSolving = new ProblemSolving();
        }
    }
}

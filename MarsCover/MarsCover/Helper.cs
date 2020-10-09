using System.Globalization;

namespace MarsRover {
    public class Helper {
        public static bool isTurkish => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToUpper() == "TR";
        public static string InvalidPlateauErrorMessage => isTurkish ? "Platonun 2 boyutlu olması gerekiyor" : "Plateau needs to be 2-dimensional";
        public static string UnexceptedInputErrorMessage => isTurkish ? "Input değerlerinizi kontrol ediniz." : "Check your input values.";
        public static string OutOfPlateauRangeErrorMessage => isTurkish ? "Gezici, plato sınırları dışına çıktı." : "Rover is beyond the boundaries of the plateau.";
        public static string SomethingWentWrongErrorMessage => isTurkish ? "Beklenmeyen bir hata oluştu." : "Something went wrong.";

    }
}

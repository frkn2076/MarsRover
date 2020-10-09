using MarsRover;
using MarsRover.DefinedExceptions;
using MarsRover.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsCover {
    class Program {
        static void Main(string[] args) {

            //Defined Global Unhandled Exceptions Handler as Middleware
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

            //IOC registration fo DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProblemSolving, ProblemSolving>()
                .BuildServiceProvider();

            var problemSolving = serviceProvider.GetService<IProblemSolving>();

            var sizeOfPlateau = new KeyValuePair<ulong, ulong>(5, 5);
            var rover1 = new Rover(1, 2, 'N', "LMLMLMLMM");
            var rover2 = new Rover(3, 3, 'E', "MMRMMRMRRM");
            var rovers = new List<Rover>() { rover1, rover2 };

            problemSolving.findLocation(sizeOfPlateau, rovers);
        }
        static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e) {
            if (e?.ExceptionObject is DefinedException) {
                var exception = (DefinedException)e.ExceptionObject;
                Console.WriteLine(exception.Message);
            }
            else {
                Console.WriteLine(Helper.SomethingWentWrongErrorMessage);
            }
            Environment.Exit(1);
        }
    }
}

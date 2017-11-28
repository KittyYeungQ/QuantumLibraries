﻿using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.XUnit;
using System;
using System.Diagnostics;

///////////////////////////////////////////////////////////////////////////////////////////////////
// This file makes sure that all Q# operations ending with Test
// in Microsoft.Quantum.Samples.UnitTesting namespace are 
// executed as Tests on QuantumSimulator. 
///////////////////////////////////////////////////////////////////////////////////////////////////

namespace Microsoft.Quantum.Samples.UnitTesting
{
    public class SimulatorTestTargets
    {
        /// <summary>
        /// Interface provided by Xunit framework for logging during test execution.
        /// When the test is selected in Visual Studio Test Explore window 
        /// there is an Output text link available for each test. 
        /// </summary>
        private readonly Xunit.Abstractions.ITestOutputHelper output;

        public SimulatorTestTargets(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>All Q# procedures ending with Test in the same namespace as this class are 
        /// discovered and passed to this function as an argument. 
        /// </summary>
        [OperationDriver]
        public void QuantumSimulatorTarget(TestOperation operationDescription)
        {
            using (var sim = new QuantumSimulator())
            {
                // Frequently tests include measurement and randomness. 
                // To reproduce the failed test it is useful to record seed that has been used 
                // for the random number generator inside the simulator.
                output.WriteLine($"The seed used for this test is {sim.Seed}");
                Debug.WriteLine($"The seed used for this test is {sim.Seed}");

                // This ensures that when the test is run in Debug mode, all message logged in 
                // Q# by calling Microsoft.Quantum.Primitives.Message show-up 
                // in Debug output 
                sim.OnLog += (string message) => { Debug.WriteLine(message); };

                // this ensures that all message logged in Q# by calling
                // Microsoft.Quantum.Primitives.Message show-up 
                // in test output 
                sim.OnLog += (string message) => { output.WriteLine(message); };
                
                // Executes operation described by operationDescription on a QuantumSimulator
                operationDescription.TestOperationRunner(sim);
            }
        }
    }
}
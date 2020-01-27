// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Quantum.Preparation {

    open Microsoft.Quantum.Arithmetic;


    @Deprecated("Microsoft.Quantum.Preparation.PrepareSingleQubitPositivePauliEigenstate")
    operation PrepareQubit(basis : Pauli, qubit : Qubit) : Unit {
        PrepareSingleQubitPositivePauliEigenstate(basis, qubit);
    }

    @Deprecated("Microsoft.Quantum.Preparation.MixedStatePreparation")
    function QuantumROM(targetError: Double, coefficients: Double[])
    : ((Int, (Int, Int)), Double, ((LittleEndian, Qubit[]) => Unit is Adj + Ctl)) {
        let preparation = MixedStatePreparation(targetError, coefficients);
        return (
            preparation::Requirements!,
            preparation::Norm,
            preparation::Prepare
        );
    }

    @Deprecated("Microsoft.Quantum.Preparation.MixedStatePreparationRequirements")
    function QuantumROMQubitCount(targetError: Double, nCoeffs: Int)
    : (Int, (Int, Int)) {
        return (MixedStatePreparationRequirements(targetError, nCoeffs))!;
    }
}

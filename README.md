# OData Experiments

## Usage

1. `dotnet build`
2. Use the generated executable `Run\bin\Debug\net8.0\Run.exe`

## Overview of experiments

### 1. Optional parameters

`Run\bin\Debug\net8.0\Run.exe TestFiles\OptionalParameterWithReference.xml` tests whether the `Org.OData.Core.V1.OptionalParameter` works _with_ using an `edmx: Reference`.

`Run\bin\Debug\net8.0\Run.exe TestFiles\OptionalParameterWithoutReference.xml` tests whether the `Org.OData.Core.V1.OptionalParameter` works _without_ using an `edmx: Reference`.

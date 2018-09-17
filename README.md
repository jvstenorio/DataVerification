# DataVerification [![Build Status](https://travis-ci.org/lfmundim/DataVerification.svg?branch=master)](https://travis-ci.org/lfmundim/DataVerification)
NuGet package responsible for various kinds of verifications. Disclaimer: most of them use Brazil's format (such as Phone number format).

## Index
1. [CPF](#CPF-Validation)
1. [CNPJ](#CNPJ-Validation)
1. [Date]()
1. [Phone number]()

## CPF Validation
This validation service relies on the following class, returned by the method `ICheckCpf.ExtractAndCheckCpf()`:
```cs
    class Cpf
    {
        
        // Full CPF number, unformatted
        public string Identifier { get; }
        
        // Full CPF number using format XXX.XXX.XXX-XX
        public string Formatted { get; }
        
        // Boolean indicating if the CPF string is valid or not
        public bool IsValid { get; }
    }
```

By using this service, you are able to extract and validate a CPF number from a text block.

### Example usage:
> Input: "oi boa noite meu cpf eh 012.345.678-90"
```cs
ICheckCpf checkCpf = new CheckCpf();
Cpf result = checkCpf.ExtractAndCheckCpf(input);
Console.WriteLine($"Extracted: {result.Identifier}. Valid: {result.IsValid}. Formatted: {result.Formatted}.");
```
> Output: "Extracted: 01234567890. Valid: true. Formatted: 012.345.678-90."

### Possible outputs:
1. Valid CPF found:
```cs
Cpf.Identifier: "01234567890"
Cpf.IsValid: true
Cpf.Formatted: "012.345.678-90"
```
2. Invalid CPF found:
```cs
Cpf.Identifier: "01234567891"
Cpf.IsValid: false
Cpf.Formatted: "012.345.678-91"
```
3. No CPF found:
```cs
Cpf.Identifier: ""
Cpf.IsValid: false
Cpf.Formatted: ""
```

## CNPJ Validation
This validation service relies on the following class, returned by the method `ICheckCnpj.ExtractAndCheckCnpj()`:
```cs
    class Cnpj
    {
        
        // Full CNPJ number, unformatted
        public string Identifier { get; }
        
        // Full CNPJ number using format XX.XXX.XXX/XXXX-XX
        public string Formatted { get; }
        
        // Boolean indicating if the CNPJ string is valid or not
        public bool IsValid { get; }
    }
```

By using this service, you are able to extract and validate a CNPJ number from a text block.

### Example usage:
> Input: "Meu Cnpj é 40015389000163"
```cs
ICheckCnpj checkCnpj = new CheckCnpj();
Cnpj result = checkCnpj.ExtractAndCheckCnpj(input);
Console.WriteLine($"Extracted: {result.Identifier}. Valid: {result.IsValid}. Formatted: {result.Formatted}.");
```
> Output: "Extracted: 40015389000163. Valid: true. Formatted: 40.015.389/0001-63."

### Possible outputs:
1. Valid CNPJ found:
```cs
Cnpj.Identifier: "40015389000163"
Cnpj.IsValid: true
Cnpj.Formatted: "40.015.389/0001-63"
```
2. Invalid CNPJ found:
```cs
Cnpj.Identifier: "02526904000181"
Cnpj.IsValid: false
Cnpj.Formatted: "02.526.904/0001-81"
```
3. No CNPJ found:
```cs
Cnpj.Identifier: ""
Cnpj.IsValid: false
Cnpj.Formatted: ""
```

## Date Validation
This validation service relies on the following class, returned by the method `ICheckDate.ValidateAndFormatDate()`:
```cs
    class DateResult
    {
        // Extracted and formatted date using format given
        public string Value { get; set; }

        // Boolean indicating if date is valid or not
        public bool IsValid { get; set; }

        // Age, in years, of the extracted date
        public int? Age { get; set; }

        // Boolean indicating if set date is a weekend or not
        public bool? IsWeekend { get; set; }

        // Boolean indicating if set date is a holiday or not
        public bool? IsHoliday { get; set; }
    }
```

By using this service, you are able to extract, format and check a date from a text block. 
**NOTE:** input *must* be on format `dd/MM/yyyy`

### Example usage:
> Input: "The D-Day happened on 6/6/1944"; Format: "dd/MM/yyyy"
```cs
ICheckDate checkDate = new CheckDate();
DateResult result = checkDate.ValidateAndFormatDate(input, format);
Console.WriteLine($"Extracted: {result.Value}. Valid: {result.IsValid}. Age: {result.Age}. Weekend: {result.IsWeekend}. Holiday: {result.IsHoliday}.");
```
> Output: "Extracted: 06/06/1944. Valid: true. Age: 74. Weekend: false. Holiday: false."

### Sample outputs:
1. Valid Date found:
```cs
// Input: Albert Einstein was born on 14/03/1879; Format: dd/MM/yyyy
DateResult.IsHoliday: false
DateResult.IsWeekend: false
DateResult.Value: "14/03/1879"
DateResult.IsValid: true
DateResult.Age: 139 // Disclaimer: written in 2018
```
2. Invalid Date found:
```cs
// Input: Só vou fazer isso dia 31/02/2019; Format: dd/MM/yyyy
DateResult.IsHoliday: false
DateResult.IsWeekend: false
DateResult.Value: "01/01/0001"
DateResult.IsValid: false
DateResult.Age: null
```
3. No Date found:
```cs
// Input: Não tem data aqui e agora; Format: dd/MM/yyyy
DateResult.IsHoliday: false
DateResult.IsWeekend: false
DateResult.Value: ""
DateResult.IsValid: false
DateResult.Age: null 
```

## Phone Number Validation
This validation service relies on the following class, returned by the method `ICheckPhoneNumber.ValidatePhoneNumber()`:
```cs
    class PhoneNumber
    {
        // Boolean indicating if the phone number is valid or not (considering number of digits only)
        public bool IsValid { get; set; }

        // Phone number extracted (without regional code)
        public string Number { get; set; }

        // Regional code extracted
        public string RegionCode { get; set; }

        // Full phone number, including regional code
        public string FullNumber { get; set; }
    }
```

By using this service, you are able to extract and validate (number count-wise, according to Brazil's pattern) a phone number from a text block.

### Example usage:
> Input: "me liga no +5531991289607 vlw"
```cs
ICheckPhoneNumber checkPhoneNumber = new CheckPhoneNumber();
PhoneNumber result = checkPhoneNumber.ValidatePhoneNumber(input);
Console.WriteLine($"Full number: {result.FullNumber}. Valid: {result.IsValid}. Regional Code: {result.RegionCode}. Number: {result.RegionCode}.");
```
> Output: "Full number: +5531991289607. Valid: true. Regional Code: +5531. Number: 991289607."

### Possible outputs:
1. Valid phone number found:
```cs
PhoneNumber.FullNumber: "+5531991289607"
PhoneNumber.Number: "991289607"
PhoneNumber.RegionCode: "+5531"
PhoneNumber.IsValid: true
```
1. Invalid phone number found:
```cs
PhoneNumber.FullNumber: ""
PhoneNumber.Number: ""
PhoneNumber.RegionCode: ""
PhoneNumber.IsValid: false
```
3. No phone number found:
```cs
PhoneNumber.FullNumber: ""
PhoneNumber.Number: ""
PhoneNumber.RegionCode: ""
PhoneNumber.IsValid: false
```
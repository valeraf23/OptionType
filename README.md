# OptionType
**The option type in C# is used when an actual value might not exist for a named value or variable. An option has an underlying type and can hold a value of that type, or it might not have a value**

[![NuGet.org](https://img.shields.io/nuget/v/VF.OptionType.svg?style=flat-square&label=NuGet.org)](https://www.nuget.org/packages/VF.OptionType/)
[![Build status](https://ci.appveyor.com/api/projects/status/m9yaavsw67h7j5l4/branch/master?svg=true)](https://ci.appveyor.com/project/valeraf23/optiontype/branch/master)

#### Install with NuGet Package Manager Console
```
Install-Package VF.OptionType
```

## Example:

```csharp

var touched = false;
Option<int>.For(5).When(x => x > 3).Do(x => touched = true).Execute();
    
var value = 0;
Option<int>.For(5).When(x => x > 6).Do(x => Assert.Fail()).WhenValue().Do(x => value = x).Execute();
            
var touched = false;
Option<int>.None().When(x => true).Do(x => Assert.Fail()).WhenNone().Do(() => touched = true).Execute();

var result = Option<int>.For(5).When(x => x > 3).MapTo(x => $"{x} > 3").When(x => x > 2).MapTo(x => "error").Map();
  	    
```

For more example, look tests

---
title: "Constraining route parameters"
date: "2019-07-16"
---

[![](images/SourceLink.png)](https://github.com/mrpmorris/blazor-university/tree/master/src/Routing/ConstrainingRouteParameters)

In addition to being able to specify URL templates that include parameters, it is also possible to ensure Blazor will only match a URL to a component if the value of the parameter meets certain criteria.

For example, in an application where purchase order numbers are always integers we would want the parameter in our URL to match our component for displaying purchase orders only if the URL's value for `OrderNumber` is actually a number.

To define a constraint for a parameter it is suffixed with a colon and then the constraint type. For example `:int` will only match the component's URL if it contains a valid integer value in the correct position.

@page "/"
@page "/purchase-order/{OrderNumber:int}"

<h1>
	Order number:
	@if (!OrderNumber.HasValue)
	{
		@:None
	}
	else
	{
		@OrderNumber
	}
</h1>
<h3>Select a purchase order</h3>
<ul>
	<li><a href="/purchase-order/1/">Order 1</a></li>
	<li><a href="/purchase-order/2/">Order 2</a></li>
	<li><a href="/purchase-order/42/">Order 42</a></li>
</ul>

@code {
	\[Parameter\]
	public int? OrderNumber { get; set; }
}

## Constraint types

| Constraint | .NET type | Valid | Invalid |
| --- | --- | --- | --- |
| **:bool** | System.Boolean | 
- true
- false

 | 

- 1
- Hello

 |
| **:datetime** | System.DateTime | 

- 2001-01-01
- 02-29-2000

 | 

- 29-02-2000

 |
| **:decimal** | System.Decimal | 

- 2.34
- 0.234

 | 

- 2,34
- ૦.૨૩૪

 |
| **:double** | System.Double | 

- 2.34
- 0.234

 | 

- 2,34
- ૦.૨૩૪

 |
| **:float** | System.Single | 

- 2.34
- 0.234

 | 

- 2,34
- ૦.૨૩૪

 |
| **:guid** | System.Guid | 

- 99303dc9-8c76-42d9-9430-de3ee1ac25d0

 | 

- {99303dc9-8c76-42d9-9430-de3ee1ac25d0}

 |
| **:int** | System.Int32 | 

- \-1
- 42
- 299792458

 | 

- 12.34
- ૨૩

 |
| **:long** | System.Int64 | 

- \-1
- 42
- 299792458

 | 

- 12.34
- ૨૩

 |

## Localization

Blazor constraints do not currently support localization.

- Numeric digits are only considered valid if they are in the form `0..9`, and not from a non-English language such as `૦..૯` (Gujarati).
- Dates are only valid in the form `MM-dd-yyyy`, `MM-dd-yy`, or in ISO format `yyyy-MM-dd`.
- Boolean values must be `true` or `false`.

## Unsupported constraint types

Blazor constraints do not support the following constraint types, but hopefully will in future:

- **Greedy parameters**  
    In ASP.NET MVC it is possible to provide a parameter name that starts with an asterisk and catches a chunk of the URL including forward slashes.  
    `/articles/{Subject}/{*TheRestOfTheURL}`
- **Regular expressions**  
    Blazor does not currently support the ability to constrain a parameter based on a regular expression.
- **Enums**  
    It's not currently possible to constrain a parameter to match a value of an enum.
- **Custom constraints**  
    It is not possible to define a custom class that determines whether or not a value passed to a parameter is valid.  
    

\[menu\_navigator\]

public partial class EmbeddedOrdinal<T> : EmbeddedValue<T>, IEmbeddedOrdinal<T>
where T : IComparable
>EmbeddedOrdinal.Operators.cs
public partial class EmbeddedOrdinal<T>
>EmbeddedOrdinal.IEmbeddedOrdinal.cs
public partial class EmbeddedOrdinal<T> : IEmbeddedOrdinal<T>
// Repeating interface is not necessary but allowed
**But if you split them without indicating all in the main part it makes the code unclear because it is difficult to know the entire class definition at a glance.**
About the added issue at the end of your question, IB and IA are not the same type even if IB inherits from IA, so you can indicate both but you can't repeat IA.
@KubaOber is right : a class doesn't inherit from interface(s), it implements interface(s). Inheritance is from only one parent class in single inheritance design or several parents in multiple inheritance design. But within an interface hierarchy, there is inheritance behavior.
----------
*Thanks for downvoting a clean code practice advice used by the Visual Studio Designer itself because of loving code obfuscation and disliking partial classes.*

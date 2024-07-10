using System.Text.Json;
using System.Text.Json.Serialization;
using Domain;

namespace UsingTypesFromTheDomainLayer;

/*
 * In this scenario, we want to use the System.Text.Json converters
 * for the domain objects that were generated by Vogen in the Domain project.
 *
 * We create an `Order` which contains value objects, we serialize it to a string,
 * and we deserialize back into an Order.
 *
 * We use the `OrderGenerationContext` below and tell it about `Order`. It then goes through its properties
 * and builds a mapping of converters.
 *
 * **NOTE** - because the value objects were built in another project, they are "fully formed" and hence
 * the System.Text.Json source generator is able to determine that there is a bespoke converter for them
 * (the converter that Vogen generated).
 * If the value objects WERE IN THIS PROJECT, then they wouldn't be fully formed, and we'd need to
 * tell System.Text.Json to use the 'type factory' to get its hints about mapping types to converters.
 */


public static class SystemTextJsonSourceGenerationScenario_UsingTypesFromTheDomainLayer
{
    public static void Run()
    {
        Order order = new()
        {
            CustomerId = CustomerId.From(123),
            OrderId = OrderId.From(321),
            CustomerName = CustomerName.From("Fred")
        };
            
        var json = JsonSerializer.Serialize(order, OrderGenerationContext.Default.Order);

        Order order2 = JsonSerializer.Deserialize(json, OrderGenerationContext.Default.Order)!;

        Console.WriteLine(json);
        Console.WriteLine(order2.CustomerId);
        Console.WriteLine(order2.OrderId);
        Console.WriteLine(order2.CustomerName);

    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Order))]
[JsonSerializable(typeof(int))]
internal partial class OrderGenerationContext : JsonSerializerContext;
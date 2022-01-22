﻿namespace Vogen.IntegrationTests.SerializationAndConversionTests.Types
{
    public record struct Bar(int Age, string Name);

    [ValueObject(conversions: Conversions.None, underlyingType: typeof(Bar))]
    public partial struct FooVo { }

    [ValueObject(conversions: Conversions.None, underlyingType: typeof(Bar))]
    public partial struct NoConverterFooVo { }

    [ValueObject(conversions: Conversions.TypeConverter, underlyingType: typeof(Bar))]
    public partial struct NoJsonFooVo { }

    [ValueObject(conversions: Conversions.NewtonsoftJson, underlyingType: typeof(Bar))]
    public partial struct NewtonsoftJsonFooVo { }

    [ValueObject(conversions: Conversions.SystemTextJson, underlyingType: typeof(Bar))]
    public partial struct SystemTextJsonFooVo { }

    [ValueObject(conversions: Conversions.NewtonsoftJson | Conversions.SystemTextJson, underlyingType: typeof(Bar))]
    public partial struct BothJsonFooVo { }

    [ValueObject(conversions: Conversions.EfCoreValueConverter, underlyingType: typeof(Bar))]
    public partial struct EfCoreFooVo { }
    
    [ValueObject(conversions: Conversions.DapperTypeHandler, underlyingType: typeof(Bar))]
    public partial struct DapperFooVo { }
}

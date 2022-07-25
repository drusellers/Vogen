﻿using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Vogen;

namespace Testbench;

public class Program
{
    public static async Task Main()
    {
        SqlMapper.AddTypeHandler(new Vo.DapperTypeHandler());

        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        Vo? vo = (await connection.QueryAsync<Vo>("SELECT 0")).AsList()[0];

        Console.WriteLine(vo.Value);
    }
}

[ValueObject(typeof(int), Conversions.DapperTypeHandler | Conversions.EfCoreValueConverter | Conversions.NewtonsoftJson | Conversions.SystemTextJson | Conversions.TypeConverter)]
public partial class Vo
{
    private static Validation validate(int value)
    {
        if (value > 0)
            return Validation.Ok;

        return Validation.Invalid("must be greater than zero");
    }
}

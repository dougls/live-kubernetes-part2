using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                          ?? builder.Configuration.GetConnectionString("Default");

            var app = builder.Build();

            app.MapGet("/", () => "Hello from Order API");

            app.MapGet("/orders", async () =>
            {
                await using var conn = new NpgsqlConnection(connStr);
                await conn.OpenAsync();
                using var cmd = new NpgsqlCommand("SELECT id, name FROM orders", conn);
                var reader = await cmd.ExecuteReaderAsync();
                var items = new List<object>();
                while (await reader.ReadAsync())
                    items.Add(new { id = reader.GetInt32(0), name = reader.GetString(1) });
                return Results.Ok(items);
            });

            app.Run();
        }
    }
}
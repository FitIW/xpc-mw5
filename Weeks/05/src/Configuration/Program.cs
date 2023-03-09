using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace Configuration;

class Program
{
    static void Main(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        // Generates a human-readable view of the configuration showing where each value came from
        Console.WriteLine(configuration.GetDebugView());

        // Loading configuration as a string
        var number = configuration["number"];
        var text = configuration["text"];

        PrintConfigValue(number);
        PrintConfigValue(text);
        
        // Loading configuration to strongly-typed object using Bind method
        var s1 = new Settings();
        configuration.GetSection(nameof(Settings)).Bind(s1);
        PrintConfigValue(s1);
        
        // Loading configuration to strongly typed object using Get<T> method
        var s2 = configuration.GetSection(nameof(Settings)).Get<Settings>();
        PrintConfigValue(s2);

        // Retrieve a configuration value of a specific type using Get<T> method
        var n = configuration.GetSection("number").Get<int>();
        PrintConfigValue(n);
        
        // Retrieve a configuration value of a specific type using GetValue<T> method
        var n2 = configuration.GetValue<int>("number");
        PrintConfigValue(n2);

        // Accessing hierarchical data using `:`
        var numericProperty = configuration.GetSection("settings:numericProperty").Get<int>();
        PrintConfigValue(numericProperty);
        var numericPropertyAsString = configuration["settings:numericProperty"];
        PrintConfigValue(numericPropertyAsString);

        // Trying to get non-existing key
        {
            // var v1 = configuration["some-string"];                                       // returns null
            // var v2 = configuration.GetSection("some-string").Get<string>();              // returns default value: null
            // var v3 = configuration.GetRequiredSection("some-string").Get<string>();      // throws an exception
        }
    }

    static void PrintConfigValue(object value, [CallerArgumentExpression(nameof(value))] string argName = null)
    {
        Console.WriteLine($"{argName}: {value ?? "<null>"}");
    }
}

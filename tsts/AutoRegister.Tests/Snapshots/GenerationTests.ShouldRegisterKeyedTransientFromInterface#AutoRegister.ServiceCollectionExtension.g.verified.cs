﻿//HintName: AutoRegister.ServiceCollectionExtension.g.cs
// <auto-generated>
//     Automatically generated by phasTrak.AutoRegister.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Tests;

public static class AutoRegisterServiceCollectionExtensions
{
    public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTests(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        return AutoRegister(serviceCollection);
    }

    internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        serviceCollection.AddKeyedTransient<global::Tests.IFoo, global::Tests.Foo>("BazKey");
        return serviceCollection;
    }
}
namespace AutoRegisterInject.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public async Task ShouldRegisterTryScoped()
   {
      const string input = """
                           [TryRegisterScoped]
                           public class Foo { }
                           """;

      const string expected = """
                              // <auto-generated>
                              //     Automatically generated by AutoRegisterInject.
                              //     Changes made to this file may be lost and may cause undesirable behaviour.
                              // </auto-generated>
                              using Microsoft.Extensions.DependencyInjection;
                              using Microsoft.Extensions.DependencyInjection.Extensions;
                              public static class AutoRegisterInjectServiceCollectionExtension
                              {
                                  public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTestProject(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                  {
                                      return AutoRegister(serviceCollection);
                                  }
                              
                                  internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                  {
                                      serviceCollection.TryAddScoped<Foo>();
                                      return serviceCollection;
                                  }
                              }
                              """;

      await RunGeneratorAsync(input, expected);
   }

   [Fact]
   public async Task ShouldRegisterTryScopedFromInterface()
   {
      const string input = """
                           [TryRegisterScoped]
                           public class Foo : IFoo { }
                           public interface IFoo { }

                           """;

      const string expected = """
                              // <auto-generated>
                              //     Automatically generated by AutoRegisterInject.
                              //     Changes made to this file may be lost and may cause undesirable behaviour.
                              // </auto-generated>
                              using Microsoft.Extensions.DependencyInjection;
                              using Microsoft.Extensions.DependencyInjection.Extensions;
                              public static class AutoRegisterInjectServiceCollectionExtension
                              {
                                  public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTestProject(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                  {
                                      return AutoRegister(serviceCollection);
                                  }
                              
                                  internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                  {
                                      serviceCollection.TryAddScoped<IFoo, Foo>();
                                      return serviceCollection;
                                  }
                              }
                              """;

      await RunGeneratorAsync(input, expected);
   }

   #endregion
}
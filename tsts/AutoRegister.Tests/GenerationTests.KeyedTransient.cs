namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterKeyedTransient() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterKeyedTransient(serviceKey: "BazKey")]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterKeyedTransientFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterKeyedTransient(serviceKey: "BazKey")]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}
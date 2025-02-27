namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldNotRegisterClassesThatInheritRegisteredClasses() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterTransient]
      public class Foo { }
      public class Bar : Foo { }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterClassesThatInheritRegisteredClassesWithTheirOwnRegistration() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterTransient]
      public class Foo { }
      [RegisterScoped]
      public class Bar : Foo { }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterClassesThatInheritRegisteredClassesWithTheirOwnRegistrationWithInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterTransient]
      public class Foo { }
      [RegisterScoped]
      public class Bar : Foo, IBar { }
      public interface IBar { }

      """.VerifyAsync();

   #endregion
}
using HomeWorks.IocContainer;

namespace HomeWorks.Tests.IocContainer
{
    public class Test
    {
        [Fact]
        public void InitialiseScopeBasedIoc_CreatingNewScope_ValueOfNewScoptIsNotNull()
        {
            var a = new InitScopeBasedIocImplementationCommand();
            a.Execute();


            var scope = IoC.Resolve<Scope>(
                "Scopes.NewScope",
                IoC.Resolve<Scope>("Scopes.Root")
                );

            Assert.NotNull(scope);
        }
    }
}
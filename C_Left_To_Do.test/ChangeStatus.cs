using System;
using Xunit;

namespace C_Left_To_Do.test
{
    public class ChangeStatus
    {
        [Fact]
        public void StatusVaerde() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("status ej ändrad");
            var testobj2 = new cUppgift("markerad som klar");
            var testobj3 = new cUppgift("arkiverad");

            // act - test-case
            testobj2.StatusChange();
            testobj3.StatusChange();
            testobj3.StatusArkivera();

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("E", testobj1.Status);
            Assert.Equal("K", testobj2.Status);
            Assert.Equal("A", testobj3.Status);
        }
        [Fact]
        public void ArkiveraUppgifter() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("status Ej klar");
            var testobj2 = new cUppgift("status klar");

            var testobj11 = new cUppgiftTid("status Ej klar", 11);
            var testobj21 = new cUppgiftTid("status klar", 21);

            // act - test-case
            testobj2.StatusChange();
            testobj21.StatusChange();

            testobj1.StatusArkivera();
            testobj2.StatusArkivera();
            testobj11.StatusArkivera();
            testobj21.StatusArkivera();

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("E", testobj1.Status);
            Assert.Equal("A", testobj2.Status);
            Assert.Equal("E", testobj11.Status);
            Assert.Equal("A", testobj21.Status);
        }
    }
}

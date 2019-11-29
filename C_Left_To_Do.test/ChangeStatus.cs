using System;
using Xunit;

namespace C_Left_To_Do.test
{
    public class ChangeStatus
    {

        [Fact]
        public void MarkeradEjKlar() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("status ej ändrad");
            var testobj2 = new cUppgift("markerad som klar");
            var testobj3 = new cUppgift("markerad som klar, och tillbaka");

            // act - test-case
            testobj2.StatusKlar();
            testobj3.StatusKlar();
            testobj3.StatusEjKlar();

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("E", testobj1.Status);
            Assert.Equal("K", testobj2.Status);
            Assert.Equal("E", testobj3.Status);
        }
        [Fact]
        public void MarkeradKlar() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("status ej ändrad");
            var testobj2 = new cUppgift("markerad som klar");
            var testobj3 = new cUppgift("arkiverad");

            // act - test-case
            testobj2.StatusKlar();
            testobj3.StatusKlar();
            testobj3.StatusArkivera();
            testobj3.StatusKlar();

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("E", testobj1.Status);
            Assert.Equal("K", testobj2.Status);
            Assert.Equal("A", testobj3.Status);
        }
        [Fact]
        public void ArkiveraUppgift() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("status Ej klar");

            var testobj2 = new cUppgift("arkiverad");
            testobj2.StatusKlar();

            var testobj3 = new cUppgift("redan arkiverad");
            testobj3.StatusKlar();
            testobj3.StatusArkivera();

            // act - test-case
            testobj1.StatusArkivera();
            testobj2.StatusArkivera();
            testobj3.StatusArkivera();

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("E", testobj1.Status);
            Assert.Equal("A", testobj2.Status);
            Assert.Equal("A", testobj3.Status);
        }
    }
}

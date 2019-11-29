using System;
using Xunit;

namespace C_Left_To_Do.test
{
    public class SkapaKlasser
    {
        [Fact]
        public void InitConstructor() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("");
            int tid = 2;
            var testobj11 = new cUppgiftTid("", tid);

            // act - test-case

            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde
            Assert.NotNull(testobj1);
            Assert.Equal("", testobj1.Text);
            Assert.Equal("E", testobj1.Status);

            Assert.NotNull(testobj11);
            Assert.Equal("", testobj11.Text);
            Assert.Equal("E", testobj11.Status);
            Assert.Equal(tid, testobj11.Tid);
        }
        [Fact]
        public void MetoderAccess() 
        {
            // arrange - testdata 
            var testobj1 = new cUppgift("klass uppgift");
            var testobj2 = new cUppgiftTid("klass uppgiftTid", 3);

            // act - test-case
            testobj1.StatusEjKlar();
            testobj1.StatusKlar();
            testobj1.StatusArkivera();

            testobj2.StatusEjKlar();
            testobj2.StatusKlar();
            testobj2.StatusArkivera();


            // assert - säkerställa resultat
            // förväntat värde, faktiskt värde            
            Assert.Equal("A", testobj1.Status);
            Assert.Equal("A", testobj2.Status);
        }
    }
}

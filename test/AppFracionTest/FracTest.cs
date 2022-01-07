using System;
using Xunit;
using AppFracciones;

namespace AppFracionTest
{
    public class FracTest
    {
        CalcuFrac calcu=new CalcuFrac();
        private void assertEqualFrac(Fracciones frac1,Fracciones frac2){
            Assert.Equal(frac1.num, frac2.num);
            Assert.Equal(frac1.denom, frac2.denom);
        }
        [Fact]
        public void SumaTest()
        {   
            var a=new Fracciones(1, 2);
            var b=new Fracciones(1, 3);
            var res=calcu.sumFrac(a,b);
            var esp=new Fracciones(5,6);

            assertEqualFrac(res,esp);
        }
        [Fact]
        public void MultiTest()
        {
           var a=new Fracciones(2,3);
           var b=new Fracciones(3,4);
           var res=calcu.multiFrac(a,b);
           var esp=new Fracciones(6,12);

           assertEqualFrac(res,esp);
        }
        [Fact]
        public void esProp()
        {
            var a=new Fracciones(2,3);
            var b=new Fracciones(3,2);
            Boolean esp=true;
            Boolean res=calcu.comprobPropia(a,b);

            Assert.Equal(res,esp);

        }
        [Theory]
        [InlineData(2,3, "2/3")]
        [InlineData(3,5,"3/5")]
        public void toStringTest(int num, int denom, string esp){

            var frac1=new Fracciones(num,denom);
            string sfrac1=frac1.ToString();

            Assert.Equal(sfrac1,esp);
        }
    }
}

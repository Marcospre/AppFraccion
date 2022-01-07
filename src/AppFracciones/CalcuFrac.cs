using System;

namespace AppFracciones{

    public class CalcuFrac{
        public int DMC(Fracciones frac1,Fracciones frac2){
            return frac1.denom*frac2.denom;
        }
        public Boolean comprobPropia(Fracciones frac1,Fracciones frac2){
            if(frac1.num<frac1.denom || frac2.num<frac2.denom){
                return true;
            }else{
                return false;
            }
        }
        public Fracciones sumFrac(Fracciones frac1,Fracciones frac2){
            int dmc=DMC(frac1,frac2);
            int num1=(dmc/frac1.denom)*frac1.num;
            int num2=(dmc/frac2.denom)*frac2.num;

            Fracciones fracsum=new Fracciones(num1+num2,dmc);

            return fracsum;

        }
        public Fracciones multiFrac(Fracciones frac1,Fracciones frac2){
            int num=frac1.num*frac2.num;
            int denom=frac1.denom*frac2.denom;

            Fracciones fracmulti=new Fracciones(num,denom);

            return fracmulti;
        }
    }

}
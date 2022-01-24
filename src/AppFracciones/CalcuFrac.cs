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
        public void fracReducida(Fracciones frac){
                if(frac.esPropia()==true){
                    if(frac.denom%frac.num==0){
<<<<<<< HEAD
                            frac.setNum(1);
                            var num=frac.getNum();
                            var denom=frac.getDenom();
                            frac.setDenom(denom/num);
=======
                            frac.setDenom(frac.getDenom()/frac.getNum());
                            frac.setNum(1);
>>>>>>> b22cf058f2ac64ba8e5dbb784647a34a88c6d079
                    }
                }else{
                    if(frac.num%frac.denom==0){
                        frac.setNum(frac.getNum()/frac.getDenom());
                        frac.setDenom(0);
                    }
                }

        }
        public Fracciones dividirFrac (Fracciones frac1, Fracciones frac2){
            int num=frac2.getDenom()*frac1.getNum();
            int denom=frac1.getDenom()*frac2.getNum();

            Fracciones frac_divida=new Fracciones(num,denom);

            return frac_divida;
        }
    }

}
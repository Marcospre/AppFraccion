using System;

namespace AppFracciones
{
    public class Fracciones
    {
        public int num;
        public int denom;

        public Fracciones(int num,int denom){
            if(denom==0)throw new Exception("Denominador es iguall a 0");
            this.num=num;
            this.denom=denom;
        }

        public int getNum(){
            return num;
        }
        public int getDenom(){
            return denom;
        }
        public void setNum(int num){
            this.num=num;
        }
        public void setDenom(int denom){
            this.denom=denom;
        }
        public Boolean esPropia(){
            if(num<denom){
                return true;
            }else{
                return false;
            }
        }
        public override string ToString() => $"{this.num}/{this.denom}";
    }
}

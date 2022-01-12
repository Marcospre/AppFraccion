using System;
using AppFracciones;
using System.Collections.Generic;
using System.Linq;

namespace AppConsole
{
    public class controlador{
        private CalcuFrac calculadora;
        private Vista vista;
        private Dictionary<string,Action> opciones;
        private bool control=true;
        private int cantidad_operaciones=0; 
        private List<Fracciones> memoria = new List<Fracciones>();

        public controlador(Vista vista, CalcuFrac calculadora){
            this.vista=vista;
            this.calculadora=calculadora;
            opciones=new Dictionary<string, Action>(){
                {"Sumar Fracciones (Minimo 1 fraccion propia)", sumarFracciones},
                {"Multiplicar Fracciones (Minimo 1 fraccion propia)", multiplicarFracciones},
                {"Simplificar Fraccion", simplificarFraccion},
                {"Comprobar si una fraccion es propia",comprobarPropia},
                {"Finalizar programa",finalizar}
            };  
        }
        public void Run()
        {
            vista.LimpiarPantalla();
            // Acceso a las Claves del diccionario
            var menu = opciones.Keys.ToList<String>();
            
            
            while (control)
                try
                {
                    //Limpiamos
                    vista.LimpiarPantalla();
                    
                    //Crear string de las fracciones en memoria
                    String mostrar="";
                    foreach(Fracciones a in memoria){
                        mostrar = mostrar + a.ToString() +" | ";
                    }

                    // Menu
                    var key = vista.TryObtenerElementoDeLista("Menu de Usuario", menu, $"Ultimos 5 resultados : {mostrar}\n\nCantidad de operaciones realizadas: {cantidad_operaciones} \n\nSeleciona una opción");
                    vista.Mostrar("");
                    
                    // Ejecución de la opción escogida
                    opciones[key].Invoke();

                    //Maximo 5 elementos en memoria
                    if (memoria.Count==6) {memoria.RemoveAt(5);}
                    
                    // Fin de la operacion
                    if(control){
                        vista.MostrarYReturn("Pulsa <Return> para continuar");
                    }
                    
                }
                catch { return; }
        }
        private void sumarFracciones(){
            Fracciones a = consFrac(1);
            Fracciones b = consFrac(2);
            if (a.esPropia() || b.esPropia()){
                Fracciones suma = calculadora.sumFrac(a,b);
                memoria.Insert(0,suma);
                vista.Mostrar("Resultado "+ suma.ToString(),ConsoleColor.Green);
                cantidad_operaciones++;
            } else{
                vista.Mostrar("Ninguna de las fracciones es propia!",ConsoleColor.Red);
            }    
        }
        private void multiplicarFracciones(){
            Fracciones a=consFrac(1);
            Fracciones b=consFrac(2);

            if (a.esPropia() || b.esPropia()){
                Fracciones res= calculadora.multiFrac(a,b);
                memoria.Insert(0,res);
                vista.Mostrar("Resultado "+ res.ToString(),ConsoleColor.Green);
                cantidad_operaciones++;
            } else {
                vista.Mostrar("¡Ninguna de las fracciones es propia!",ConsoleColor.Red);
            }

        }
        private void simplificarFraccion(){
            Fracciones frac = consFrac(1);
            calculadora.fracReducida(frac);
            /*memoria.Insert(0,frac);*/
            vista.Mostrar("Resultado "+ frac.ToString(),ConsoleColor.Green);
            cantidad_operaciones++;
        }

        public void comprobarPropia(){
            Fracciones frac = consFrac(1);
            String res;
            if(frac.esPropia()==true){
                res="si";
            }else{
                res="no";
            }
            memoria.Insert(0,frac);
            vista.Mostrar($"{frac.ToString()} es propia? : {res}");
            cantidad_operaciones++;
        }

        private Fracciones consFrac(int i){
            var num=vista.TryObtenerDatoDeTipo<int>($"Numerador Fraccion {i}");
            var denom = vista.TryObtenerDatoDeTipo<int>($"Denominador Fraccion {i} ");
            return new Fracciones(num,denom);
        }
        private void finalizar(){
            control=false;
        }
        
       
    }
}

using System;
using AppFracciones;
using AppConsole;

var view = new Vista();
var calculadora= new CalcuFrac();
var controlador=new controlador(view,calculadora);

controlador.Run();

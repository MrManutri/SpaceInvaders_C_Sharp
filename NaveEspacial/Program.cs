using NaveEspacial;
using System.Drawing;

Ventana ventana;
Nave nave;
bool jugar = true;


void Iniciar() 
{
    Ventana ventana = new Ventana(170, 45, ConsoleColor.Black, new Point(5, 3), new Point(165, 43));
    ventana.DibujarMarco();
    nave = new Nave(new Point(80, 30),ConsoleColor.White,ventana);
    nave.Dibujar();
}
void Game()
{
    while (jugar)
    {
        nave.Mover(2);
        nave.Disparar();
        //Thread.Sleep(50);

    }
}
Iniciar();
Game();
Console.ReadKey();
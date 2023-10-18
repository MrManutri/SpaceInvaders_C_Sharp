using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NaveEspacial
{
    internal class Nave
    {
        public float Vida { get; set; }
        public Point Posicion { get; set; }
        public ConsoleColor Color { get; set; }
        public Ventana VentanaC {  get; set; }
        public List<Point> PosicionesNave { get; set; }
        public List<Bala> Balas {  get; set; } 

        public Nave(Point posicion, ConsoleColor color, Ventana ventanaC)
        {
            Vida = 100;
            Posicion = posicion;
            Color = color;
            VentanaC = ventanaC;
            PosicionesNave = new List<Point>();
            Balas = new List<Bala>();
        }
        public void Dibujar()
        {
            Console.ForegroundColor = Color;
            int x = Posicion.X;
            int y = Posicion.Y;

            Console.SetCursorPosition(x+2, y);
            Console.Write("█▀█");
            Console.SetCursorPosition(x, y+1);
            Console.Write("█▄█☻█▄█");
            Console.SetCursorPosition(x, y+2);
            Console.Write("█▀▀█▀▀█");

            PosicionesNave.Clear();

            PosicionesNave.Add(new Point(x + 2, y));
            PosicionesNave.Add(new Point(x + 3, y));
            PosicionesNave.Add(new Point(x + 4, y));


            PosicionesNave.Add(new Point(x, y+1));
            PosicionesNave.Add(new Point(x+1, y+1));
            PosicionesNave.Add(new Point(x + 2, y + 1));
            PosicionesNave.Add(new Point(x + 3, y + 1));
            PosicionesNave.Add(new Point(x + 4, y + 1));
            PosicionesNave.Add(new Point(x + 5, y + 1));
            PosicionesNave.Add(new Point(x + 6, y + 1));

            PosicionesNave.Add(new Point(x, y + 2));
            PosicionesNave.Add(new Point(x + 1, y + 2));
            PosicionesNave.Add(new Point(x + 2, y + 2));
            PosicionesNave.Add(new Point(x + 3, y + 2));
            PosicionesNave.Add(new Point(x + 4, y + 2));
            PosicionesNave.Add(new Point(x + 5, y + 2));
            PosicionesNave.Add(new Point(x + 6, y + 2));
        }
        public void Borrar()
        {
            foreach(Point item in PosicionesNave)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
            }
        }
        public void Teclado(ref Point distancia,int velocidad)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if(tecla.Key == ConsoleKey.W)
                distancia = new Point(0,-1);
            if(tecla.Key == ConsoleKey.S)
                distancia = new Point(0,1);
            if (tecla.Key == ConsoleKey.D)
                distancia = new Point(1,0);
            if( tecla.Key == ConsoleKey.A)
                distancia = new Point(-1,0);

            distancia.X *= velocidad;
            distancia.Y *= velocidad;

            if(tecla.Key == ConsoleKey.RightArrow) 
            {
                Bala bala = new Bala(new Point(Posicion.X + 6, Posicion.Y + 2),
                    ConsoleColor.Cyan, TipoBala.Normal);
                Balas.Add(bala);
            }
            if (tecla.Key== ConsoleKey.LeftArrow) 
            {
                Bala bala = new Bala(new Point(Posicion.X,Posicion.Y+2),
                    ConsoleColor.Green, TipoBala.Normal);
                Balas.Add(bala);
            }
            if(tecla.Key==ConsoleKey.UpArrow)
            {
                Bala bala = new Bala(new Point(Posicion.X+2, Posicion.Y-2),
                    ConsoleColor.Blue,TipoBala.Especial);
                Balas.Add(bala);
            }
            
            
        }
        public void Colisiones(Point distancia)
        {
            Point posicionAux = new Point(Posicion.X + distancia.X, Posicion.Y + distancia.Y);
            if(posicionAux.X <=VentanaC.LimiteSuperior.X)
                posicionAux.X = VentanaC.LimiteSuperior.X+1;
            if (posicionAux.X + 6 >= VentanaC.LimiteInferior.X)
                posicionAux.X = VentanaC.LimiteInferior.X - 7;
            if (posicionAux.Y <= VentanaC.LimiteSuperior.Y)
                posicionAux.Y = VentanaC.LimiteSuperior.Y + 1;
            if (posicionAux.Y + 2 >= VentanaC.LimiteInferior.Y)
                posicionAux.Y = VentanaC.LimiteInferior.Y - 3;

            Posicion = posicionAux;
        }
        public void Mover(int velocidad)
        {
            if(Console.KeyAvailable)
            {
                Borrar();
                Point distancia = new Point();
                Teclado(ref distancia, velocidad);
                Colisiones(distancia);
                Dibujar();
            }
        }
        public void Disparar()
        {
            for (int i = 0; i < Balas.Count; i++)
            {
                if(Balas[i].Mover(1, VentanaC.LimiteSuperior.Y))
                {
                    Balas.Remove(Balas[i]);
                }
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.ParticleSystem
{
    public class Particle
    {
        public int Radius;
        public float X;
        public float Y;
        public float Life;
        public float SpeedX;
        public float SpeedY;
        public static Random rand = new Random();


        public Particle()
        {

            Radius = 2 + rand.Next(10);

        }
        public virtual void Draw(Graphics g, bool debugOn)
        {

            float k = Math.Min(1f, Life / 100);

            int alpha = (int)(k * 255);


            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);



            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);


            b.Dispose();
        }
        public void DrawInfo(Graphics g, int _x, int _y)
        {
            var x = Math.Abs(X - _x);
            var y = Math.Abs(Y - _y);
            var lenght = Math.Sqrt(x * x + y * y);

            if (lenght < Radius)
            {
                var b = new SolidBrush(Color.SkyBlue);
                g.FillRectangle(b, X, Y, 50, 50);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("X: " + (int)X, new Font("Arial", 10), Brushes.Black, X + 25, Y + 10, stringFormat);
                g.DrawString("Y: " + (int)Y, new Font("Arial", 10), Brushes.Black, X + 25, Y + 25, stringFormat);
                g.DrawString("Life: " + (int)Life, new Font("Arial", 10), Brushes.Black, X + 25, Y + 40, stringFormat);
            }
        }
    }
    public class ParticleColorful : Particle
    {

        public Color FromColor;
        public Color ToColor;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        public override void Draw(Graphics g, bool debugOn)
        {
            float k = Math.Min(1f, Life / 100);

            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            if (debugOn)
            {


                g.DrawLine(new Pen(Color.OrangeRed, 2), X, Y, (int)(X + SpeedX), (int)(Y + SpeedY));
            }

            b.Dispose();
        }
    }

}

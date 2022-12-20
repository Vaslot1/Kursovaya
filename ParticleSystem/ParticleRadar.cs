using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.ParticleSystem
{
    public class ParticleRadar
    {
        public float X;
        public float Y;
        public float R=50;
        public int countDetectedParticles;
        public int current_countDetectedParticles;

        public ParticleRadar(float x, float y)
        {
            X = x;
            Y = y;
        }
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Green, 3), X - R, Y - R, R * 2, R * 2);
            g.DrawString(
                $"{countDetectedParticles}",
                new Font("Verdana", 15), // шрифт и его размер
                new SolidBrush(Color.Red), // цвет шрифта
                X - 15, // расположение в пространстве
                Y - 15
                );


        }
        public  GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-R / 2, -R / 2, R, R);
            return path;
        }
        public void ImpactParticle(List<Emitter> emitters)
        {
            countDetectedParticles = 0;
            
                
                foreach (var emitter in emitters) {   
                    for (int i = 0; i < emitter.particles.Count; i++)
                    {
                        float gX = this.X - emitter.particles[i].X;
                        float gY = this.Y - emitter.particles[i].Y;

                        double r = Math.Sqrt(gX * gX + gY * gY);
                        if (r < this.R + emitter.particles[i].Radius)
                        {
                            countDetectedParticles++;
                        }
               } 
            }

        }
    }
}

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
            g.DrawEllipse(new Pen(Color.White, 3), X - R, Y - R, R * 2, R * 2);
            g.DrawString(
                $"{current_countDetectedParticles}",
                new Font("Verdana", 15), 
                new SolidBrush(Color.Red), 
                X - 15, 
                Y - 15
                );


        }
        public  GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-R / 2, -R / 2, R, R);
            return path;
        }
        public void ImpactParticle(List<Emitter> emitters, bool soploChanged)
        {
            countDetectedParticles = 0;
                for (int j = 0;j<emitters.Count;j++) {
                
                    for (int i = 0; i < emitters[j].particles.Count; i++)
                    {
                        float gX = this.X - emitters[j].particles[i].X;
                        float gY = this.Y - emitters[j].particles[i].Y;

                        double r = Math.Sqrt(gX * gX + gY * gY);
                        if (r < this.R + emitters[j].particles[i].Radius)
                        {
                            countDetectedParticles++;
                        emitters[j].particles[i].rendered = true;

                        }
                        else
                        emitters[j].particles[i].rendered = false;
                }
                
            }

        }
    }
}

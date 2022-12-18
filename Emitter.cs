using Kursovaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    public class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0;
        public int ParticlesCount = 100;
        public float X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public float Y; // соответствующая координата Y 
        public float Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 10; // начальная минимальная скорость движения частицы
        public int SpeedMax = 50; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 40; // минимальное время жизни частицы
        public int LifeMax = 60; // максимальное время жизни частицы
        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.Orange; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Red); // конечный цвет частиц
        public virtual void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;
            foreach (var particle in particles)
            {

                particle.Life -= 2;
                if (particle.Life < 0)
                {
                    
                    ResetParticle(particle);
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {


                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;


                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }

        }

        public void Render(Graphics g, bool debugOn)
        {

            foreach (var particle in particles)
            {
                particle.Draw(g,debugOn);
            }
           

        }
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = LifeMin + Particle.rand.Next(LifeMax);
            particle.X = X;
            particle.Y = Y;

            var direction = Direction
        + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor=ColorFrom;
            particle.ToColor=ColorTo;
            

            return particle;
        }
        
       
        }
}

using Kursovaya;
using Kursovaya.Objects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class SoploEmitter : Emitter
    {
        public Rocket rocket;
        public float vX;
        public float vY;
        public float Angle;
        

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);
            var matrix = new Matrix();
            X = rocket.X;
            Y = rocket.Y;
            Direction = Angle;


            particle.SpeedY = -rocket.vY + Particle.rand.Next(3);
            particle.SpeedX = -rocket.vX + Particle.rand.Next(3);
        }
        public void killAllParticles()
        {
            var particlesToCreate = 0;
            for(int i =0; i<particles.Count; i++)
            {
                var particle = particles[i];
                if(particle.Life>0)
                particle.Life -= 1;
                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                    else
                    {
                        particles.Remove(particle);
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
        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }

    }
}

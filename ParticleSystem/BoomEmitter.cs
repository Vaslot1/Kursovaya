using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursovaya.ParticleSystem;

namespace Kursovaya
{
    internal class BoomEmitter:Emitter
    {
        public void CreateParticles(int v)
        {
            for (int i = 0; i < v; i++)
            {
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public override void UpdateState()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                var particle = particles[i];
                if (particle.Life > 0)
                    particle.Life -= 1;
                if (particle.Life <= 0)
                {
                    ParticlesCount--;
                    particles.Remove(particle); 
                }
                else
                {


                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;


                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            
        }
    }
}

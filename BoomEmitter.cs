using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class BoomEmitter:Emitter
    {
        public void CreateParticles()
        {
            for (int i = 0; i < ParticlesCount; i++)
            {
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public override void UpdateState()
        {
            foreach (var particle in particles)
            {

                if (particle.Life > 0)
                    particle.Life -= 1;
                if (particle.Life < 0)
                {
                    ParticlesCount -= 1;
                    if (ParticlesCount > 0)
                    {
                        
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
            
        }
    }
}

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
                
                if (particles[i].Life > 0)
                    particles[i].Life -= 1;
                if (particles[i].Life <= 0)
                {
                    
                    particles.Remove(particles[i]); 
                }
                else
                {


                    particles[i].SpeedX += GravitationX;
                    particles[i].SpeedY += GravitationY;


                    particles[i].X += particles[i].SpeedX;
                    particles[i].Y += particles[i].SpeedY;
                }
            }
            
        }
    }
}

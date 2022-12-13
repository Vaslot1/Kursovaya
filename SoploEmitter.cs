using Kursovaya;
using Kursovaya.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class SoploEmitter : Emitter
    {
        public Rocket rocket;

        

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);


            particle.X = rocket.X-10;
            particle.Y = rocket.Y-20;

            particle.SpeedY = 1;
            particle.SpeedX = Particle.rand.Next(-2, 2);
        }

    }
}

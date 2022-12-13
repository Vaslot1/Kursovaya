using Kursovaya;
using Kursovaya.Objects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class SoploEmitter : Emitter
    {
        public Rocket rocket;
        public float vX;
        public float vY;
        

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);
            var matrix = new Matrix();
 






            particle.SpeedY = 1;
            particle.SpeedX = Particle.rand.Next(-2, 2);
        }

    }
}

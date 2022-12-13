using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Kursovaya.Objects
{
    internal class Planet : BaseObject
    {
       public float size1 = -35;
       public float size2 = 35;
        
        public Planet(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), size1, size1 , size2 , size2);
           
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(size1, size1, size2, size2);
            return path;
        }

       
    }
    

    
}

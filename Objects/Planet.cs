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
       public float size1 = -128;
       public float size2 = 128;
        Brush planetBrush;
        
        public Planet(float x, float y, float angle,Brush brush) : base(x, y, angle)
        {
            planetBrush = brush;
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(planetBrush, size1, size1 , size2 , size2);
           
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(size1, size1, size2, size2);
            return path;
        }

       
    }
    

    
}

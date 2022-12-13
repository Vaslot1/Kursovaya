using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Objects
{
    internal class Rocket : BaseObject
    {
        //Image img;
        public Action<Marker> OnMarkerOverlap;
        public Action<Planet> OnGreenCircleOverlap;
        public Action<RedCircle> OnRedCircleOverlap;
        public float vX, vY;
        public Rocket (float x, float y , float angle/*, Image img*/) : base(x, y, angle)
        {
            
        }
        public override void Render(Graphics g)
        {
            Point[] tri = new Point[3];
            tri[0].X = -10;
            tri[0].Y = 20;
            tri[1].X = 10;
            tri[1].Y = 20;
            tri[2].X = 0;
            tri[2].Y = 30;
           
            Point[] wings1 = new Point[3];
            wings1[0] = new Point(10, -15);
            wings1[1] = new Point(10, -22);
            wings1[2] = new Point(20, -22);
           
            Point[] wings2 = new Point[3];
            wings2[0] = new Point(-10, -15);
            wings2[1] = new Point(-10, -22);
            wings2[2] = new Point(-20, -22);
            
            g.FillPolygon(new SolidBrush(Color.Red), tri);
            g.FillPolygon(new SolidBrush(Color.Red), wings1);
            g.FillPolygon(new SolidBrush(Color.Red), wings2);
            g.FillRectangle(new SolidBrush(Color.Gray), -10, -20, 20, 40);
            g.FillEllipse(new SolidBrush(Color.SkyBlue), 5, 5,-10, -10);
            

        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            
            Point[] tri = new Point[3];
            tri[0].X = -10;
            tri[0].Y = 20;
            tri[1].X = 10;
            tri[1].Y = 20;
            tri[2].X = 0;
            tri[2].Y = 30;
            path.AddPolygon( tri);
            path.AddRectangle(new Rectangle(-10, -20, 20, 40));
            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            if(obj is Planet)
            {
                OnGreenCircleOverlap(obj as Planet);  
            }
            if (obj is RedCircle)
            {
                OnRedCircleOverlap(obj as RedCircle);
            }
        }
        
    }
}

using Kursovaya.Objects;
using System.Numerics;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Rocket player;
        Marker marker;
        Random rnd = new Random();
        int pointsCount = 0;
        SoploEmitter emitter;
        BoomEmitter tempEmitter;
        bool flag=false;
        public Form1()
        {
            InitializeComponent();
            player = new Rocket(pbMain.Width / 2, pbMain.Height / 2, 0);
            emitter = new SoploEmitter
            {
                X = player.X,
                Y = player.Y,
                rocket = player,
                GravitationY = 0
            };
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnGreenCircleOverlap += (m) =>
            {
                objects.Remove(marker);
                marker = null;
                Boom();
                player.X = pbMain.Width / 2;
                player.Y = pbMain.Height / 2;
            };
            player.OnRedCircleOverlap += (m) =>
            {
                objects.Remove(marker);
                marker = null;
                Boom();
                player.X = pbMain.Width / 2;
                player.Y = pbMain.Height / 2;
                objects.Remove(m);
                objects.Add(new RedCircle(rnd.Next(50, pbMain.Width - 50), rnd.Next(50, pbMain.Height - 50), 0, 50));
            };
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            objects.Add(marker);
            objects.Add(player);
            objects.Add(new Planet(rnd.Next(20, pbMain.Width - 20), rnd.Next(20, pbMain.Height - 20), 0));
            objects.Add(new Planet(rnd.Next(20, pbMain.Width - 20), rnd.Next(20, pbMain.Height - 20), 0));
            objects.Add(new Planet(rnd.Next(20, pbMain.Width - 20), rnd.Next(20, pbMain.Height - 20), 0));
            objects.Add(new RedCircle(rnd.Next(50, pbMain.Width - 50), rnd.Next(50, pbMain.Height - 50), 0,50));
            




        }

        private void Boom()
        {
            flag = true;
            tempEmitter = new BoomEmitter
            {
                X = player.X,
                Y = player.Y,
                SpeedMin = 5,
                SpeedMax = 10
        };
            
            tempEmitter.CreateParticles();



        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);
            updatePlayer();
            if (flag) { 
                tempEmitter.UpdateState();
            tempEmitter.Render(g);}
                emitter.Direction = player.Angle;
            if (marker != null)
            {
                
                emitter.UpdateState();
            emitter.Render(g);
                
               
            }
            
                

            else {
                emitter.killAllParticles();
                emitter.Render(g);
            }
                

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            for(int i = 0; i < objects.Count; i++)
            {

                g.Transform = objects[i].GetTransform();
                objects[i].Render(g);
               
                float radius = objects[i].UpdateRadius();
                if (radius == 200)
                {
                    objects[i] = new RedCircle(rnd.Next(50, pbMain.Width - 50), rnd.Next(50, pbMain.Height - 50), 0,50);
                }

            }
            lbScore.Text = "Очки: " + pointsCount;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); 

            }
            marker.X = e.X;
            marker.Y = e.Y;

        }
        private void updatePlayer()
        {
            if (marker != null)
            {

                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float dex= marker.X - emitter.X;
                float dey = marker.Y - emitter.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);
                float lengthE = MathF.Sqrt(dex * dex + dey * dey);
                dx /= length;
                dy /= length;
                dex /= lengthE;
                dey/= lengthE;


                player.vX += dx * 0.9f;
                player.vY += dy * 0.9f;
                emitter.vX += dex * 0.9f;
                emitter.vY += dey * 0.9f;

                player.Angle = 5 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
                emitter.Angle = 5 - MathF.Atan2(emitter.vX, emitter.vY) * 180 / MathF.PI;

            }
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            emitter.vX += -emitter.vX * 0.1f;
            emitter.vY += -emitter.vY * 0.1f;


            player.X += player.vX;
            player.Y += player.vY;
            emitter.X += emitter.vX;
            emitter.Y += emitter.vY;
        }
        

    }

}
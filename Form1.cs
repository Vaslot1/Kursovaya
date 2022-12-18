using Kursovaya.Objects;
using System.Diagnostics;
using System.Numerics;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        float speedrocket=0.4f;
        List<BaseObject> objects = new();
        Rocket player;
        Marker marker;
        Random rnd = new Random();
        int pointsCount = 0;
        SoploEmitter emitter;
        BoomEmitter tempEmitter=new BoomEmitter();
        bool flag=false;
        float timer = 0;
        bool debugOn = false;
        int _ticks = 0, updateSpeed=1;
        public Form1()
        {
            InitializeComponent();
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
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
                player.X = -pbMain.Width / 2;
                player.Y = -pbMain.Height / 2;
                
            };
            player.OnRedCircleOverlap += (m) =>
            {
                objects.Remove(marker);
                marker = null;
                Boom();
                player.X = -pbMain.Width / 2;
                player.Y = -pbMain.Height / 2;
                objects.Remove(m);
                objects.Add(new RedCircle(rnd.Next(50, pbMain.Width - 50), rnd.Next(50, pbMain.Height - 50), 0, 50));
            };
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            objects.Add(marker);
            objects.Add(player);
            objects.Add(new Planet(pbMain.Width/4, pbMain.Height / 2, 0));
            objects.Add(new Planet(pbMain.Width /2, pbMain.Height / 2+200, 0));
            objects.Add(new Planet(pbMain.Width / 1.2f + 50, pbMain.Height / 3+50, 0));
            objects.Add(new RedCircle(rnd.Next(50, pbMain.Width - 50), rnd.Next(50, pbMain.Height - 50), 0,50));
            
            




        }

        private void reviveTime(Graphics g)
        {
            g.DrawString(
    "\tYOU DIED\n"+"Дождитесь возрождения",
    new Font("Impact", 32), 
    new SolidBrush(Color.Red), 
    pbMain.Width/5, 0 
);
            
        }

        private void Boom()
        {
            flag = true;
            tempEmitter = new BoomEmitter
            {
                X = player.X,
                Y = player.Y,
                SpeedMin = 1,
                SpeedMax = 15
            };
            tempEmitter.CreateParticles(tempEmitter.ParticlesCount*speedRocket.Value/2);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            _ticks++;
            if (_ticks / updateSpeed > 0 || sender.Equals(bt_StepDebug))
            {
                _ticks %= updateSpeed;
                updatePlayer();


                using (var g = Graphics.FromImage(pbMain.Image))
                {

                    g.Clear(Color.Black);

                    if (flag)
                    {
                        timer++;
                        reviveTime(g);
                        tempEmitter.UpdateState();
                        tempEmitter.Render(g,debugOn);
                        if (timer > 100)
                        {
                            player.X = pbMain.Width / 2;
                            player.Y = pbMain.Height / 2;
                            timer = 0;
                            flag = false;

                        }
                    }

                    if (marker != null)
                    {

                        emitter.UpdateState();
                        emitter.Render(g,debugOn);


                    }
                    else
                    {
                        emitter.killAllParticles();
                        emitter.Render(g,debugOn);
                    }


                    foreach (var obj in objects.ToList())
                    {
                        if (obj != player && player.Overlaps(obj, g))
                        {
                            player.Overlap(obj);
                            obj.Overlap(player);
                        }
                    }
                    foreach (var obj in objects)
                    {

                        g.Transform = obj.GetTransform();
                        obj.Render(g);

                        float radius = obj.UpdateRadius();
                        if (radius == 200)
                        {
                            obj.X = rnd.Next(50, pbMain.Width - 50);
                            obj.Y = rnd.Next(50, pbMain.Height - 50);
                            obj.R = 50;
                        }

                    }
                    lbScore.Text = "Очки: " + pointsCount;
                }
            }
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if(timer == 0) { 
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); 

            }
            marker.X = e.X;
            marker.Y = e.Y;
            }
            

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


                player.vX += dx * speedrocket;
                player.vY += dy * speedrocket;
                emitter.vX += dex * speedrocket;
                emitter.vY += dey * speedrocket;

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

        private void speedRocket_Scroll(object sender, EventArgs e)
        {
            
            speedrocket = speedRocket.Value/10f;
            emitter.ParticlesPerTick     = speedRocket.Value;

        }

        private void cb_Debug_CheckedChanged(object sender, EventArgs e)
        {
            debugOn = cb_Debug.Checked;
        }

        private void bt_StepDebug_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            
        }

        private void tb_updateSpeed_Scroll(object sender, EventArgs e)
        {
            updateSpeed = tb_updateSpeed.Maximum - tb_updateSpeed.Value;
            if (updateSpeed == tb_updateSpeed.Maximum)
                updateSpeed = -1; 
            else
                updateSpeed = (int)Math.Pow(2, updateSpeed);
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (debugOn)
            {
                int x = e.X, y = e.Y;
                using (var g = Graphics.FromImage(pbMain.Image))
                {
                    foreach (var particle in emitter.particles)
                        particle.DrawInfo(g, x, y);
                }
                    
            }
             
        }
    }

}
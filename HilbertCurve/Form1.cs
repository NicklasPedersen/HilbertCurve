using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace HilbertCurve
{
    public partial class Form1 : Form
    {
        private static Vector2[] qed = new Vector2[0];
        private  static  Vector2[] first = new Vector2[0];
        private static Vector2[] second = new Vector2[0];
        private static bool RGB;
        private static bool Rainbow = false;
        private static bool BetterRainbow = false;
        private static int thickness = 0;
        private static int offset = 0;
        private static int spacing = 0;
        private static Color[] FirstColors = new Color[0];
        private static Color[] SecondColors = new Color[0];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amountOfThreads = trackBar3.Value;
            Refresh();
            Vector2.Change = 1;
            Stopwatch s = Stopwatch.StartNew();
            qed = Vector2.IterateBuildCurve(trackBar4.Value);
            textBox6.Text = s.Elapsed.ToString();
            
            thickness = trackBar2.Value;
            offset = thickness;
            spacing = trackBar1.Value * thickness * thickness;
            first = Vector2.SubArray(qed, 0, qed.Length / 2+1);
            second = Vector2.SubArray(qed, qed.Length / 2, qed.Length / 2);
            RGB = RGBButton.Checked;
            Rainbow = RainbowButton.Checked;
            BetterRainbow = OtherRainbowButton.Checked;
            s.Restart();
            if (qed.Length == 1)
            {
                CreateGraphics().FillRectangle(new SolidBrush(Color.Red),thickness,thickness,thickness,thickness);
                textBox4.Text = s.Elapsed.ToString();
                return;
            }
            Color[] colors = new Color[qed.Length];
            FirstColors = new Color[qed.Length/2+1];
            SecondColors = new Color[qed.Length/2];
            for (int i = 0; i < qed.Length; i++)
            {
                int a = 255;
                int b = 0;
                int c = 0;
                if (RGB) Clamp(ref a, ref b, ref c, i, 255, qed.Length - 2);
                else if (Rainbow) ClampDiff(ref a, ref b, ref c, i, 255, qed.Length - 2);
                else if (BetterRainbow) ClampDiffAgain(ref a, ref b, ref c, i, 255, qed.Length - 2);
                
                colors[i] = Color.FromArgb(255, a, b, c);
            }

            Thread[] threads;
            if (qed.Length<amountOfThreads) threads = new Thread[qed.Length];
            else threads = new Thread[amountOfThreads];
            Graphics[] graphics = new Graphics[threads.Length];
            for(int i = 0; i < graphics.Length; i++) graphics[i] = CreateGraphics();
            threads[0] = new Thread(() => Threading(graphics[0], SubArray(colors, 0, qed.Length/threads.Length), Vector2.SubArray(qed, 0, qed.Length / threads.Length)));
            for (int i = 1; i < threads.Length; i++)
            {
                Color[] col = SubArray(colors, i * qed.Length / threads.Length - 1, qed.Length / threads.Length + 1);
                Vector2[] vec = Vector2.SubArray(qed, i * qed.Length / threads.Length - 1,
                    qed.Length / threads.Length + 1);
                threads[i] = new Thread(() => Threading(CreateGraphics(), col, vec)); 
                
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            textBox4.Text = s.Elapsed.ToString();
        }

        private static void Threading(Graphics g, Color[] colors, Vector2[] points)
        {
            for (int i = 0; i < points.Length-1; i++)
            {
                Vector2 fir = points[i];
                Vector2 sec = points[i + 1];
                g.DrawLine(new Pen(colors[i], thickness), fir[0] * spacing + offset, fir[1] * spacing + offset,
                    sec[0] * spacing + offset, sec[1] * spacing + offset);
            }
        }

        public static Color[] SubArray(Color[] data, int index, int length)
        {
            Color[] result = new Color[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        private static void FirstHalf(Graphics g)
        {
            for (int i = 0; i < first.Length - 1; i++)
            {
                Vector2 fir = first[i];
                Vector2 sec = first[i + 1];
                g.DrawLine(new Pen(FirstColors[i], thickness), fir[0] * spacing + offset, fir[1] * spacing + offset,
                    sec[0] * spacing + offset, sec[1] * spacing + offset);
            }
        }

        private static void SecondHalf(Graphics g)
        {
            for (int i = second.Length-1; i > 0 ; i--)
            {
                Vector2 fir = second[i];
                Vector2 sec = second[i - 1];
                g.DrawLine(new Pen(SecondColors[i], thickness), fir[0] * spacing + offset,
                        fir[1] * spacing + offset,
                        sec[0] * spacing + offset, sec[1] * spacing + offset);
                
                
            }
        }
        private static void ClampDiffAgain(ref int first, ref int second, ref int third, int input, int clamped, int max)
        {
            if (input < max / 3)
            {
                first = clamped;
                second = Clamp(input * 3, clamped, max);
                third = 0;
            }
            else if (input < max / 2)
            {
                second = clamped;
                first = Clamp(max-(input-max/3)*6, clamped, max);
                third = 0;
                if (input + 1 >= max / 2)
                    input++;
            }
            else if(input < max / 3 * 2)
            {
                first = 0;
                second = clamped;
                third = Clamp((input-max/2)*6, clamped, max);
            }
            else
            {
                first = 0;
                second = Clamp((max-(input-max/3*2)*3), clamped, max);
                second = second > clamped ? clamped : second;
                second = second < 0 ? 0 : second;
                third = clamped;
            }
        }
        private static void ClampDiff(ref int first, ref int second, ref int third, int input, int clamped, int max)
        {
            if (input < max / 3)
            {
                first = clamped;
                second = Clamp(input * 3, clamped, max);
                third = 0;
            }
            else if (input < max / 3 * 2)
            {
                first = Clamp(max-(input-max/3)/2*6, clamped, max);
                second = clamped;
                third = Clamp((input-max/3)/2*6, clamped, max);
            }
            else
            {
                first = 0;
                second = Clamp(max-(input-max/3*2)*3, clamped, max);
                second = second > clamped ? clamped : second;
                second = second < 0 ? 0 : second;
                third = clamped;
            }
        }
        private static void Clamp(ref int first, ref int second, ref int third, int input, int clamped, int max)
        {
            if (input < max / 2)
            {
                first = Clamp(max-input*2, clamped, max);
                second = Clamp(input*2, clamped, max);
                third = 0;
            }
            else
            {
                first = 0;
                second = Clamp(max+max/2-input, clamped, max);
                third = Clamp(input-max/2, clamped, max);
            }
        }
        private static int Clamp(int input, int clamped, int max)
        {
            return input * clamped / max;
        }
    }
}

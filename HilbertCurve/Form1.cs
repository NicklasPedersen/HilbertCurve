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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            Stopwatch timer = Stopwatch.StartNew();
            Vector2[] curve = Vector2.IterateBuildCurve(trackBar4.Value);
            textBox6.Text = timer.Elapsed.ToString();
            
            int thickness = trackBar2.Value;
            int spacing = trackBar1.Value * thickness * thickness;
            timer.Restart();
            if (curve.Length == 1)
            {
                CreateGraphics().FillRectangle(new SolidBrush(Color.Red),thickness,thickness,thickness,thickness);
                textBox4.Text = timer.Elapsed.ToString();
                return;
            }
            Color[] colors = new Color[curve.Length];
            for (int i = 0; i < curve.Length; i++)
            {
                int a = 255;
                int b = 0;
                int c = 0;
                if (RGBButton.Checked) Clamp(ref a, ref b, ref c, i, 255, curve.Length - 2);
                else if (RainbowButton.Checked) ClampDiff(ref a, ref b, ref c, i, 255, curve.Length - 2);
                else if (OtherRainbowButton.Checked) ClampDiffAgain(ref a, ref b, ref c, i, 255, curve.Length - 2);
                
                colors[i] = Color.FromArgb(255, a, b, c);
            }

            int amountOfThreads = trackBar3.Value;
            Thread[] threads = new Thread[curve.Length < amountOfThreads ? curve.Length : amountOfThreads];
            Graphics[] graphics = new Graphics[threads.Length];
            for(int i = 0; i < graphics.Length; i++) graphics[i] = CreateGraphics();
            threads[0] = new Thread(() => Threading(graphics[0], SubArray(colors, 0, curve.Length/threads.Length), Vector2.SubArray(curve, 0, curve.Length / threads.Length), thickness, spacing));
            for (int i = 1; i < threads.Length; i++)
            {
                Color[] col = SubArray(colors, i * curve.Length / threads.Length - 1, curve.Length / threads.Length + 1);
                Vector2[] vec = Vector2.SubArray(curve, i * curve.Length / threads.Length - 1,
                    curve.Length / threads.Length + 1);
                threads[i] = new Thread(() => Threading(CreateGraphics(), col, vec, thickness, spacing)); 
                
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            textBox4.Text = timer.Elapsed.ToString();
        }

        private static void Threading(Graphics g, Color[] colors, Vector2[] points, int thickness, int spacing)
        {
            for (int i = 0; i < points.Length-1; i++)
            {
                Vector2 fir = points[i];
                Vector2 sec = points[i + 1];
                g.DrawLine(new Pen(colors[i], thickness), fir[0] * spacing + thickness, fir[1] * spacing + thickness,
                    sec[0] * spacing + thickness, sec[1] * spacing + thickness);
            }
        }

        public static Color[] SubArray(Color[] data, int index, int length)
        {
            Color[] result = new Color[length];
            Array.Copy(data, index, result, 0, length);
            return result;
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

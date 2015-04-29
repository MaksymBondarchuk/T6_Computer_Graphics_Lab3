using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Colorado
{
    public partial class MainForm : Form
    {
        const int sizeX = 1000;
        const int sizeY = 400;
        Bitmap bmp = new Bitmap(sizeX, sizeY);

        Pen pen = new Pen(Color.Black, 50);
        Brush brush = new System.Drawing.SolidBrush(Color.Black);
        bool penSelected = false;
        bool canDraw = false;
        bool canFill = false;
        bool clicked = false;
        const int pointSize = 50;
        const int pointSize2 = (int)(pointSize * 0.5);
        int countInside = 0;
        Color oldColor;
        List<Point> points = new List<Point>();
        List<Point> buttonMovePoints = new List<Point>();

        // 3d
        int pointsNumber;
        List<Point> points3;
        bool canSet = false;
        bool makeFun = false;
        List<Double> angles = new List<Double>();

        Color fillColor = Color.Black;



        public MainForm()
        {
            InitializeComponent();
        }

        void drawPen(Bitmap bmp, Brush brush, Point point)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.FillEllipse(brush, point.X - pointSize2, point.Y - pointSize2, pointSize, pointSize);
        }

        private void bPen_Click(object sender, EventArgs e)
        {
            penSelected = true;
            canFill = false;
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;
            if (penSelected && clicked)
            {
                drawPen(bmp, brush, mouse_events.Location);
                pbox.Image = bmp;
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            canDraw = !canDraw;
            MouseEventArgs mouseEvents = (MouseEventArgs)e;

            //prevPoint = mouseEvents.Location;

            if (canFill)
            {
                oldColor = bmp.GetPixel(mouseEvents.X, mouseEvents.Y);

                DateTime startTime = DateTime.Now, endTime = DateTime.Now;
                if (rbRecursive.Checked)
                {
                    startTime = DateTime.Now;
                    Thread T = new Thread(() => recursiveFill(bmp, mouseEvents.X, mouseEvents.Y, oldColor, fillColor), 100000000);
                    T.Start();
                    T.Join();
                    T.Abort();
                    endTime = DateTime.Now;
                }
                else
                    if (rbLoop.Checked)
                    {
                        startTime = DateTime.Now;
                        loopFill(bmp, mouseEvents.Location, oldColor, fillColor);
                        endTime = DateTime.Now;
                    }
                    else
                        if (rbFigure.Checked)
                        {
                            startTime = DateTime.Now;
                            anglesFill(bmp, points3, oldColor, fillColor);
                            drawFigure();
                            for (int i = 0; i < points3.Count; i++)
                                drawPen(bmp, brush, points3[i]);
                            endTime = DateTime.Now;
                        }

                pbox.Image = bmp;
                lTime.Visible = true;
                tTime.Visible = true;
                tTime.Text = Convert.ToString(endTime - startTime);
                bmp.Save("1.bmp");
            }

            if (canSet)
            {
                drawPen(bmp, brush, mouseEvents.Location);
                points3.Add(mouseEvents.Location);
                pbox.Image = bmp;
                pointsNumber++;
                if (pointsNumber == 3)
                    bDone.Enabled = true;
            }
        }

        void recursiveFill(Bitmap bmp, int X, int Y, Color oldColor, Color newColor)
        {
            countInside++;
            if (0 <= X && X < sizeX && 0 <= Y && Y < sizeY && bmp.GetPixel(X, Y) == oldColor)
            {
                bmp.SetPixel(X, Y, newColor);
                recursiveFill(bmp, X - 1, Y, oldColor, newColor);
                recursiveFill(bmp, X, Y - 1, oldColor, newColor);
                recursiveFill(bmp, X, Y + 1, oldColor, newColor);
                recursiveFill(bmp, X + 1, Y, oldColor, newColor);
            }

        }

        void loopFill(Bitmap bmp, Point startPoint, Color oldColor, Color newColor)
        {
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            X.Add(startPoint.X);
            Y.Add(startPoint.Y);

            while (X.Count != 0)
            {
                if (0 <= X[0] && X[0] < sizeX && 0 <= Y[0] && Y[0] < sizeY && bmp.GetPixel(X[0], Y[0]) == oldColor)
                {
                    bmp.SetPixel(X[0], Y[0], newColor);

                    X.Add(X[0] - 1);
                    Y.Add(Y[0]);

                    X.Add(X[0]);
                    Y.Add(Y[0] - 1);

                    X.Add(X[0]);
                    Y.Add(Y[0] + 1);

                    X.Add(X[0] + 1);
                    Y.Add(Y[0]);
                }
                X.RemoveAt(0);
                Y.RemoveAt(0);
            }
        }

        void anglesFill(Bitmap bmp, List<Point> figure, Color oldColor, Color newColor)
        {
            int XMin = figure[0].X;
            int XMax = figure[0].X;
            int YMin = figure[0].Y;
            int YMax = figure[0].Y;
            for (int i = 1; i < figure.Count; i++)
            {
                if (figure[i].X < XMin)
                    XMin = figure[i].X;
                else
                    if (XMax < figure[i].X)
                        XMax = figure[i].X;
                if (figure[i].Y < YMin)
                    YMin = figure[i].Y;
                else
                    if (YMax < figure[i].Y)
                        YMax = figure[i].Y;
            }

            for (int X = XMin; X <= XMax; X++)
                for (int Y = YMin; Y <= YMax; Y++)
                {
                    Double angle = 0;
                    for (int i = 0; i < figure.Count - 1; i++)
                    {
                        double angleI = Math.Abs((Math.Atan2(Y - figure[i].Y, X - figure[i].X) - Math.Atan2(Y - figure[i + 1].Y, X - figure[i + 1].X)) * 180 / (double)Math.PI);
                        if (angleI > 180)
                            angleI = 360 - angleI;
                        angle += angleI;
                    }
                    double angleJ = Math.Abs((Math.Atan2(Y - figure[figure.Count - 1].Y, X - figure[figure.Count - 1].X) - Math.Atan2(Y - figure[0].Y, X - figure[0].X)) * 180 / (double)Math.PI);
                    if (angleJ > 180)
                        angleJ = 360 - angleJ;
                    angle += angleJ;
                    if (Math.Abs(angle - 360) < 1)
                        bmp.SetPixel(X, Y, newColor);
                }
        }

        private void bFill_Click(object sender, EventArgs e)
        {
            canFill = true;
            penSelected = false;
        }

        private void pbox_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }

        private void pbox_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            MouseEventArgs mouseEvents = (MouseEventArgs)e;
            if (penSelected)
            {
                drawPen(bmp, brush, mouseEvents.Location);
                pbox.Image = bmp;
            }
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            bPen.Enabled = false;
            bFill.Enabled = false;
            bSet.Enabled = false;
            pointsNumber = 0;
            points3 = new List<Point>();
            canSet = true;
        }

        void drawFigure()
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < pointsNumber - 1; i++)
                g.DrawLine(pen, points3[i], points3[i + 1]);
            g.DrawLine(pen, points3[pointsNumber - 1], points3[0]);
            pbox.Image = bmp;
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            bPen.Enabled = true;
            bFill.Enabled = true;
            bSet.Enabled = true;
            bDone.Enabled = false;
            canSet = false;
            drawFigure();
            rbFigure.Enabled = true;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(sizeX, sizeY); 
            pbox.Image = bmp;

            rbFigure.Enabled = false;
            if (rbFigure.Checked)
                rbRecursive.Checked = true;

            bPen.Enabled = true;
            bFill.Enabled = true;
            bSet.Enabled = true;
            bDone.Enabled = false;

            lTime.Visible = false;
            tTime.Visible = false;
        }

        private void bSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialog.Color;
                cbox.BackColor = fillColor;
            }
        }

        private void bSelectColorPen_Click(object sender, EventArgs e)
        {
            if (colorDialogPen.ShowDialog() == DialogResult.OK)
            {
                pen = new Pen(colorDialogPen.Color, 50);
                brush = new System.Drawing.SolidBrush(colorDialogPen.Color);
                cboxPen.BackColor = colorDialogPen.Color;
            }
        }
    }
}

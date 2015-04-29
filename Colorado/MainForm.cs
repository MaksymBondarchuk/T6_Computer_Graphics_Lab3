using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Colorado
{
    public partial class MainForm : Form
    {
        const int SizeX = 1000;
        const int SizeY = 400;
        Bitmap _bmp = new Bitmap(SizeX, SizeY);

        Pen _pen = new Pen(Color.Black, 50);
        Brush _brush = new SolidBrush(Color.Black);
        bool _penSelected;
        bool _canDraw;
        bool _canFill;
        bool _clicked;
        const int PointSize = 50;
        const int PointSize2 = (int)(PointSize * 0.5);
        Color _oldColor;

        // 3d
        int _pointsNumber;
        List<Point> _points3;
        bool _canSet;
        List<Double> _angles = new List<Double>();

        Color _fillColor = Color.Black;



        public MainForm()
        {
            InitializeComponent();
        }

        public List<double> Angles
        {
            get { return _angles; }
            set { _angles = value; }
        }


        void DrawPen(Bitmap bmp, Brush brush, Point point)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.FillEllipse(brush, point.X - PointSize2, point.Y - PointSize2, PointSize, PointSize);
        }

        private void bPen_Click(object sender, EventArgs e)
        {
            _penSelected = true;
            _canFill = false;
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouseEvents = e;
            if (_penSelected && _clicked)
            {
                DrawPen(_bmp, _brush, mouseEvents.Location);
                pbox.Image = _bmp;
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            _canDraw = !_canDraw;
            MouseEventArgs mouseEvents = (MouseEventArgs)e;

            //prevPoint = mouseEvents.Location;

            if (_canFill)
            {
                _oldColor = _bmp.GetPixel(mouseEvents.X, mouseEvents.Y);

                DateTime startTime = DateTime.Now, endTime = DateTime.Now;
                if (rbRecursive.Checked)
                {
                    startTime = DateTime.Now;
                    Thread T = new Thread(() => RecursiveFill(_bmp, mouseEvents.X, mouseEvents.Y, _oldColor, _fillColor), 100000000);
                    T.Start();
                    T.Join();
                    T.Abort();
                    endTime = DateTime.Now;
                }
                else
                    if (rbLoop.Checked)
                    {
                        startTime = DateTime.Now;
                        LoopFill(_bmp, mouseEvents.Location, _oldColor, _fillColor);
                        endTime = DateTime.Now;
                    }
                    else
                        if (rbFigure.Checked)
                        {
                            startTime = DateTime.Now;
                            anglesFill(_bmp, _points3, _fillColor);
                            DrawFigure();
                            for (int i = 0; i < _points3.Count; i++)
                                DrawPen(_bmp, _brush, _points3[i]);
                            endTime = DateTime.Now;
                        }

                pbox.Image = _bmp;
                lTime.Visible = true;
                tTime.Visible = true;
                tTime.Text = Convert.ToString(endTime - startTime);
                _bmp.Save("1.bmp");
            }

            if (_canSet)
            {
                DrawPen(_bmp, _brush, mouseEvents.Location);
                _points3.Add(mouseEvents.Location);
                pbox.Image = _bmp;
                _pointsNumber++;
                if (_pointsNumber == 3)
                    bDone.Enabled = true;
            }
        }

        void RecursiveFill(Bitmap bmp, int x, int y, Color oldColor, Color newColor)
        {
            if (0 <= x && x < SizeX && 0 <= y && y < SizeY && bmp.GetPixel(x, y) == oldColor)
            {
                bmp.SetPixel(x, y, newColor);
                RecursiveFill(bmp, x - 1, y, oldColor, newColor);
                RecursiveFill(bmp, x, y - 1, oldColor, newColor);
                RecursiveFill(bmp, x, y + 1, oldColor, newColor);
                RecursiveFill(bmp, x + 1, y, oldColor, newColor);
            }

        }

        void LoopFill(Bitmap bmp, Point startPoint, Color oldColor, Color newColor)
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            x.Add(startPoint.X);
            y.Add(startPoint.Y);

            while (x.Count != 0)
            {
                if (0 <= x[0] && x[0] < SizeX && 0 <= y[0] && y[0] < SizeY && bmp.GetPixel(x[0], y[0]) == oldColor)
                {
                    bmp.SetPixel(x[0], y[0], newColor);

                    x.Add(x[0] - 1);
                    y.Add(y[0]);

                    x.Add(x[0]);
                    y.Add(y[0] - 1);

                    x.Add(x[0]);
                    y.Add(y[0] + 1);

                    x.Add(x[0] + 1);
                    y.Add(y[0]);
                }
                x.RemoveAt(0);
                y.RemoveAt(0);
            }
        }


        void anglesFill(Bitmap bmp, List<Point> figure, Color newColor)
        {
            int xMin = figure[0].X;
            int xMax = figure[0].X;
            int yMin = figure[0].Y;
            int yMax = figure[0].Y;
            for (int i = 1; i < figure.Count; i++)
            {
                if (figure[i].X < xMin)
                    xMin = figure[i].X;
                else
                    if (xMax < figure[i].X)
                        xMax = figure[i].X;
                if (figure[i].Y < yMin)
                    yMin = figure[i].Y;
                else
                    if (yMax < figure[i].Y)
                        yMax = figure[i].Y;
            }

            for (int x = xMin; x <= xMax; x++)
                for (int y = yMin; y <= yMax; y++)
                {
                    Double angle = 0;
                    for (int i = 0; i < figure.Count - 1; i++)
                    {
                        double angleI = Math.Abs((Math.Atan2(y - figure[i].Y, x - figure[i].X) - Math.Atan2(y - figure[i + 1].Y, x - figure[i + 1].X)) * 180 / Math.PI);
                        if (angleI > 180)
                            angleI = 360 - angleI;
                        angle += angleI;
                    }
                    double angleJ = Math.Abs((Math.Atan2(y - figure[figure.Count - 1].Y, x - figure[figure.Count - 1].X) - Math.Atan2(y - figure[0].Y, x - figure[0].X)) * 180 / Math.PI);
                    if (angleJ > 180)
                        angleJ = 360 - angleJ;
                    angle += angleJ;
                    if (Math.Abs(angle - 360) < 1)
                        bmp.SetPixel(x, y, newColor);
                }
        }

        private void bFill_Click(object sender, EventArgs e)
        {
            _canFill = true;
            _penSelected = false;
        }

        private void pbox_MouseUp(object sender, MouseEventArgs e)
        {
            _clicked = false;
        }

        private void pbox_MouseDown(object sender, MouseEventArgs e)
        {
            _clicked = true;
            MouseEventArgs mouseEvents = e;
            if (_penSelected)
            {
                DrawPen(_bmp, _brush, mouseEvents.Location);
                pbox.Image = _bmp;
            }
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            bPen.Enabled = false;
            bFill.Enabled = false;
            bSet.Enabled = false;
            _pointsNumber = 0;
            _points3 = new List<Point>();
            _canSet = true;
        }

        void DrawFigure()
        {
            Graphics g = Graphics.FromImage(_bmp);
            for (int i = 0; i < _pointsNumber - 1; i++)
                g.DrawLine(_pen, _points3[i], _points3[i + 1]);
            g.DrawLine(_pen, _points3[_pointsNumber - 1], _points3[0]);
            pbox.Image = _bmp;
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            bPen.Enabled = true;
            bFill.Enabled = true;
            bSet.Enabled = true;
            bDone.Enabled = false;
            _canSet = false;
            DrawFigure();
            rbFigure.Enabled = true; 
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            _bmp = new Bitmap(SizeX, SizeY);
            pbox.Image = _bmp;

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
                _fillColor = colorDialog.Color;
                cbox.BackColor = _fillColor;
            }
        }

        private void bSelectColorPen_Click(object sender, EventArgs e)
        {
            if (colorDialogPen.ShowDialog() == DialogResult.OK)
            {
                _pen = new Pen(colorDialogPen.Color, 50);
                _brush = new SolidBrush(colorDialogPen.Color);
                cboxPen.BackColor = colorDialogPen.Color;
            }
        }
    }
}

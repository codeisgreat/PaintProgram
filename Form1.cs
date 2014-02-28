using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace  PaintProgram
{
    public partial class Form1 : Form
    {
        private ArrayList objectsToDraw = new ArrayList();

        public bool firstClick = true;
        public int objectType;
        public Color penColor;
        public Color fillColor;
        public string formInput;
        public float penW;

        public bool fillShape;
        public bool outline;

        public Point p1;
        public Point p2;

        public Form1()
        {
            InitializeComponent();
        }

        public abstract class DrawingObject
        {
            public Point point1;
            public Point point2;

            public bool fill;
            public bool outl;

            public Color outlineColor;
            public Color fillCol;

            public string textToDisplay;
            public float penWidth;

            public abstract void drawObject(Graphics g);

        }

        public class LineShape : DrawingObject
        {

            public LineShape(Point point1, Point point2, Color outlineColor, float penWidth)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.outlineColor = outlineColor;
                this.penWidth = penWidth;
            }

            public override void drawObject(Graphics g)
            {
                Pen p = new Pen(outlineColor, penWidth);
                g.DrawLine(p, point1, point2);
            }
        }

        public class RectangleShape : DrawingObject
        {

            public RectangleShape(Point point1, Point point2, Color outlineColor, Color fillCol, float penWidth, bool fill, bool outl)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.outlineColor = outlineColor;
                this.fillCol = fillCol;
                this.penWidth = penWidth;
                this.fill = fill;
                this.outl = outl;
            }

            public override void drawObject(Graphics g)
            {

                if (outl == true)
                {
                    Pen p = new Pen(outlineColor, penWidth);

                    if (point1.X < point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            g.DrawRectangle(p, point1.X, point1.Y, (point2.X - point1.X), (point2.Y - point1.Y));
                        }

                        else
                        {
                            g.DrawRectangle(p, point1.X, point2.Y, (point2.X - point1.X), (point1.Y - point2.Y));
                        }
                    }

                    else if (point1.X > point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            g.DrawRectangle(p, point2.X, point1.Y, (point1.X - point2.X), (point2.Y - point1.Y));
                        }

                        else
                        {
                            g.DrawRectangle(p, point2.X, point2.Y, (point1.X - point2.X), (point1.Y - point2.Y));
                        }
                    }
                }

                if (fill == true)
                {
                    SolidBrush b = new SolidBrush(fillCol);

                    if (point1.X < point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            if (outl == true)
                            {
                                g.FillRectangle(b, (point1.X + (int)(penWidth / 2)), (point1.Y + (int)(penWidth / 2)), (point2.X - point1.X) - ((int)(penWidth)), (point2.Y - point1.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillRectangle(b, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                            }
                        }

                        else
                        {
                            if (outl == true)
                            {
                                g.FillRectangle(b, point1.X + (int)(penWidth / 2), point2.Y + (int)(penWidth/2), (point2.X - point1.X) - (int)(penWidth), (point1.Y - point2.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillRectangle(b, point1.X, point2.Y, point2.X - point1.X, point1.Y - point2.Y);
                            }
                        }
                    }

                    else if (point1.X > point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            if (outl == true)
                            {
                                g.FillRectangle(b, point2.X + (int)(penWidth/2), point1.Y + (int)(penWidth/2), (point1.X - point2.X) - (int)(penWidth), (point2.Y - point1.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillRectangle(b, point2.X, point1.Y, (point1.X - point2.X), (point2.Y - point1.Y));
                            }
                        }

                        else
                        {
                            if (outl == true)
                            {
                                g.FillRectangle(b, point2.X + (int)(penWidth/2), point2.Y + (int)(penWidth/2), (point1.X - point2.X) - (int)(penWidth), (point1.Y - point2.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillRectangle(b, point2.X, point2.Y, (point1.X - point2.X), (point1.Y - point2.Y));
                            }
                        }
                    }
                }
            }

        }

        public class EllipseShape : DrawingObject
        {
            public EllipseShape(Point point1, Point point2, Color outlineColor, Color fillCol, float penWidth, bool fill, bool outl)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.outlineColor = outlineColor;
                this.fillCol = fillCol;
                this.penWidth = penWidth;
                this.fill = fill;
                this.outl = outl;
            }

            public override void drawObject(Graphics g)
            {
                if (outl == true)
                {
                    Pen p = new Pen(outlineColor, penWidth);

                    if (point1.X < point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            g.DrawEllipse(p, point1.X, point1.Y, (point2.X - point1.X), (point2.Y - point1.Y));
                        }

                        else
                        {
                            g.DrawEllipse(p, point1.X, point2.Y, (point2.X - point1.X), (point1.Y - point2.Y));
                        }
                    }

                    else if (point1.X > point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            g.DrawEllipse(p, point2.X, point1.Y, (point1.X - point2.X), (point2.Y - point1.Y));
                        }

                        else
                        {
                            g.DrawEllipse(p, point2.X, point2.Y, (point1.X - point2.X), (point1.Y - point2.Y));
                        }
                    }
                }

                if (fill == true)
                {
                    SolidBrush b = new SolidBrush(fillCol);
                    if (point1.X < point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            if (outl == true)
                            {
                                g.FillEllipse(b, point1.X + (int)(penWidth/2), point1.Y + (int)(penWidth/2), (point2.X - point1.X) - (int)(penWidth), (point2.Y - point1.Y) - (int)(penWidth));
                            }
                            else
                            {
                                g.FillEllipse(b, point1.X, point1.Y, (point2.X - point1.X), (point2.Y - point1.Y));
                            }
                        }

                        else
                        {
                            if (outl == true)
                            {
                                g.FillEllipse(b, point1.X + (int)(penWidth/2), point2.Y + (int)(penWidth/2), (point2.X - point1.X) - (int)(penWidth), (point1.Y - point2.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillEllipse(b, point1.X, point2.Y, (point2.X - point1.X), (point1.Y - point2.Y));
                            }
                        }
                    }

                    else if (point1.X > point2.X)
                    {
                        if (point1.Y < point2.Y)
                        {
                            if (outl == true)
                            {
                                g.FillEllipse(b, point2.X + (int)(penWidth/2), point1.Y + (int)(penWidth/2), (point1.X - point2.X) - (int)(penWidth), (point2.Y - point1.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillEllipse(b, point2.X, point1.Y, (point1.X - point2.X), (point2.Y - point1.Y));
                            }
                        }

                        else
                        {
                            if (outl == true)
                            {
                                g.FillEllipse(b, point2.X + (int)(penWidth/2), point2.Y + (int)(penWidth/2), (point1.X - point2.X) - (int)(penWidth), (point1.Y - point2.Y) - (int)(penWidth));
                            }

                            else
                            {
                                g.FillEllipse(b, point2.X, point2.Y, (point1.X - point2.X), (point1.Y - point2.Y));
                            }
                        }
                    }
                }
            }

        }

        public class TextShape : DrawingObject
        {
            public TextShape(Point point1, Point point2, string textToDisplay, Color outlineColor)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.textToDisplay = textToDisplay;
                this.outlineColor = outlineColor;
            }

            public override void drawObject(Graphics g)
            {
                SolidBrush brush = new SolidBrush(outlineColor);

                if (point1.X < point2.X)
                {
                    if (point1.Y < point2.Y)
                    {
                        RectangleF rf = new RectangleF(point1.X, point1.Y, (point2.X - point1.X), (point2.Y - point1.Y));
                        g.DrawString(textToDisplay, DefaultFont, brush, rf);
                    }

                    else
                    {
                        RectangleF rf = new RectangleF(point1.X, point2.Y, (point2.X - point1.X), (point1.Y - point2.Y));
                        g.DrawString(textToDisplay, DefaultFont, brush, rf);
                    }
                }

                else if (point1.X > point2.X)
                {
                    if (point1.Y < point2.Y)
                    {
                        RectangleF rf = new RectangleF(point2.X, point1.Y, (point1.X - point2.X), (point2.Y - point1.Y));
                        g.DrawString(textToDisplay, DefaultFont, brush, rf);
                    }

                    else
                    {
                        RectangleF rf = new RectangleF(point2.X, point2.Y, (point1.X - point2.X), (point1.Y - point2.Y));
                        g.DrawString(textToDisplay, DefaultFont, brush, rf);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string penColorString = listBox1.SelectedItem.ToString();
            penColor = Color.FromName(penColorString);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fillColorString = listBox2.SelectedItem.ToString();
            fillColor = Color.FromName(fillColorString);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (firstClick == true)
                {
                    this.p1 = e.Location;
                    firstClick = false;
                }

                else
                {
                    //figure out what kind of shape is selected
                    this.p2 = e.Location;
                    firstClick = true;

                    if (objectType == 1)
                    {
                        LineShape ls = new LineShape(p1, p2, penColor, penW);
                        this.objectsToDraw.Add(ls);
                    }

                    else if (objectType == 2)
                    {
                        if (outline == true || fillShape == true)
                        {
                            RectangleShape rs = new RectangleShape(p1, p2, penColor, fillColor, penW, fillShape, outline);
                            this.objectsToDraw.Add(rs);
                        }
                    }

                    else if (objectType == 3)
                    {
                        if (outline == true || fillShape == true)
                        {
                            EllipseShape es = new EllipseShape(p1, p2, penColor, fillColor, penW, fillShape, outline);
                            this.objectsToDraw.Add(es);
                        }
                    }

                    else if (objectType == 4)
                    {
                        if (formInput != String.Empty)
                        {
                            TextShape ts = new TextShape(p1, p2, formInput, penColor);
                            this.objectsToDraw.Add(ts);
                        }   
                    }

                    panel1.Invalidate();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (DrawingObject drawO in this.objectsToDraw)
            {
                drawO.drawObject(g);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            penW = (float)(listBox3.SelectedIndex + 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            objectType = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            objectType = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            objectType = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            objectType = 4;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                fillShape = true;
            }

            else if (checkBox1.Checked == false)
            {
                fillShape = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                outline = true;
            }

            else if (checkBox2.Checked == false)
            {
                outline = false;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.objectsToDraw.Clear();
            panel1.Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int arrayCount = objectsToDraw.Count;
            if (arrayCount > 0)
            {
                this.objectsToDraw.RemoveAt(arrayCount - 1);
                panel1.Invalidate();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.listBox1.SelectedIndex = 0;
            this.listBox2.SelectedIndex = 0;
            this.listBox3.SelectedIndex = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != String.Empty)
            {
                formInput = richTextBox1.Text;
            }

            else
            {
                formInput = String.Empty;
            }
        }
       
    }
}

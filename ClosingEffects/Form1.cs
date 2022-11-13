using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClosingAForm
{
    public partial class Form1 : Form
    {
        private readonly int _initialHeight;
        private readonly int _initialWidth;

        private Timer _timer = new Timer();
        private Random _random = new Random();
        private int _style = 0;
        private int _lights = 0;

        public Form1()
        {
            InitializeComponent();
            _initialHeight = this.Height;
            _initialWidth = this.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(_random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
            _timer.Tick += new EventHandler(Resize_Tick);
        }


        void StartTimer(int i)
        {
            _style = i;
            BackColor = Color.FromArgb(_random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
            _timer.Interval = 1;
            _timer.Start();
        }


        private void Resize_Tick(object sender, EventArgs e)
        {
            int reduce = 10;
            int limit = reduce + 2;

            switch (_style)
            {
                case 0:
                    _lights++;
                    if (_lights <= 500)
                    {
                        BackColor = Color.FromArgb(_random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
                    }
                    else
                    {
                        WindowState = FormWindowState.Normal;
                        ToggleLabels();
                        ReDraw();
                    }
                    break;

                case 1:
                    if ((Size.Width >= limit) || (Size.Height >= limit))
                    {
                        Size = new Size(Width - reduce, Height = Width);
                        Opacity -= .002;
                        CenterToScreen();
                    }
                    else
                    {
                        ReDraw();
                    }
                    break;

                case 2:
                    if (Size.Width >= limit)
                    {
                        Size = new Size(Width - reduce, Height);
                        Opacity -= .002;
                    }
                    else
                    {
                        ReDraw();
                    }
                    break;

                case 3:
                    if ((Size.Width >= limit) || (Size.Height >= limit))
                    {
                        Size = new Size(Width - reduce, Height = Width);
                        Opacity -= .002;
                    }
                    else
                    {
                        ReDraw();
                    }
                    break;

                case 5:
                    if (Size.Width >= limit)
                    {
                        Size = new Size(Width - reduce, Height);
                        Opacity -= .002;
                        CenterToScreen();
                    }
                    else
                    {
                        ReDraw();
                    }
                    break;

                case 6:
                    if (Size.Height >= limit)
                    {
                        Size = new Size(Width, Height - reduce);
                        Opacity -= .002;
                        CenterToScreen();
                    }
                    else
                    {
                        ReDraw();
                    }
                    break;

                default:
                    break;
            }

        }

        void ReDraw()
        {
            _timer.Stop();
            Opacity = 1;
            Size = new Size(_initialWidth, _initialHeight);
            CenterToScreen();
        }

        private void LabelSeizure_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            ToggleLabels();
            _lights = 0;
            StartTimer(0);
        }

        private void ToggleLabels()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                foreach (var label in Controls.OfType<Label>())
                {
                    label.Hide();
                }
            }
            else
            {
                foreach (var label in Controls.OfType<Label>())
                {
                    label.Show();
                }
            }
        }

        private void labelSeizure_Click_1(object sender, EventArgs e)
        {
            StartTimer(6);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StartTimer(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            StartTimer(2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StartTimer(3);
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            StartTimer(5);
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            StartTimer(6);
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

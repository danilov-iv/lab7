using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_1
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Point prev = Point.Empty;


        public Form()
        {
            InitializeComponent();
            MouseMove += new MouseEventHandler(OnMouseMove);
        }

        private void button_Click(object sender, EventArgs e)
        {
            button.Text = "ААААА";
            MessageBox.Show("поздравляем вы победили");
            var cp = new Point();
            cp.X = 331;
            cp.Y = 187;
            button.Location = cp;
            Random rnd = new Random();
            cp.X = rnd.Next();
            cp.Y = rnd.Next();
            Cursor.Position = cp;
        }

        private void OnMouseMove(object sender, EventArgs e)
        {
            var cp = Cursor.Position;
            cp.X -= Left + 32;
            cp.Y -= Top + 32;

            if (prev != Point.Empty && cp != prev)
            {
                var pos = cp;
                pos.X -= prev.X;
                pos.Y -= prev.Y;
                pos.X += button.Location.X;
                pos.Y += button.Location.Y;
                pos.X = Math.Min(Math.Max(pos.X, 0), Form.ActiveForm.Width - button.Size.Width - 200);
                pos.Y = Math.Min(Math.Max(pos.Y, 0), Form.ActiveForm.Height - button.Size.Height - 200);
                button.Location = pos;
            }
            prev = cp;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniExp
{
    public partial class HelpFrom : Form
    {
        public HelpFrom()
        {
            InitializeComponent();
        }

        private void HelpFrom_Load(object sender, EventArgs e)
        {
            txtBoxInfo.Text = "Новая запись в таблице добавляется автоматически." +
                "Для удаления записи в таблице необходимо выбрать нужноую строку в таблице и нажать клавишу \"Del\". и тд.";
        }

        private void HelpFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

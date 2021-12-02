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
            try
            {
            txtBoxInfo.Text = "Новая запись в таблице добавляется автоматически." + Environment.NewLine +
                "Для удаления записи в таблице необходимо выбрать нужноую строку в таблице и нажать клавишу \"Del\". и тд.";
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("HelpFrom_Load:{0}", ex.Message));
            }
        }

        private void HelpFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("HelpFrom_KeyDown:{0}", ex.Message));
            }
        }
    }
}

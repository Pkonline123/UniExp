using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniExp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            try
            {
                lblVersionName.Text = string.Empty;
                //
                Assembly assembly = Assembly.GetExecutingAssembly();
                if (assembly != null)
                {
                    AssemblyName assemblyName = assembly.GetName();
                    if (assemblyName != null)
                    {
                        lblVersionName.Text = assemblyName.Version.ToString();
                    }
                }
                if (string.IsNullOrEmpty(lblVersionName.Text))
                    lblVersionName.Text = "0.0.0.0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("About_Load: {0}", ex.Message),
                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBackward_MouseHover(object sender, EventArgs e)
        {
            ToolTip btnBackwardToolTip = new ToolTip();
            btnBackwardToolTip.SetToolTip(btnBackward, "Вернуться к окну \"UniExp\"");
        }

        private void About_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

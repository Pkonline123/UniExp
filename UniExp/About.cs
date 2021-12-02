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
                lblLeader.Text = "Руководитель:";
                lblLeaderName.Text = "Сергеев Николай Евгеньевич";
                lblDeveloper.Text = "Выполнили:";
                lblDeveloperName.Text = "Зачитайлов Андрей Сергеевич; " + "Довжанский Давид Юрьевич";
                lblProjectName.Text = "Универсальная экспертная система";
                lblVersion.Text = "Версия:";
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
            try
            {
                ToolTip btnBackwardToolTip = new ToolTip();
                btnBackwardToolTip.SetToolTip(btnBackward, "Вернуться к окну \"UniExp\"");
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("btnBackward_MouseHover:{0}", ex.Message));
            }
        }

        private void About_KeyDown(object sender, KeyEventArgs e)
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
                throw new Exception(string.Format("About_KeyDown:{0}", ex.Message));
            }
        }
    }
}

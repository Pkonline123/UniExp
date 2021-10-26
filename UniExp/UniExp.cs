using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniExpGridViewCriteria;

namespace UniExp
{
    public partial class UniExp : Form
    {

        public UniExp()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                WriteErr(ex.Message);
            }
        }

        private void UniExp_Load(object sender, EventArgs e)
        {
            try
            {
                //dataGridViewCriteria
            }
            catch (Exception ex)
            {
                WriteErr(ex.Message);
            }
        }

        private void dataGridViewCriteria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WriteErr(ex.Message);
            }
        }

        private void SaveCriterias_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog.ShowDialog();
                string filename = saveFileDialog.FileName;
                gridViewCriterias gridView = new gridViewCriterias();
                gridView.Update(dataGridViewCriteria);
            }
            catch (Exception ex)
            {
                WriteErr(ex.Message);
            }
        }

        private void LoadCriterias_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog.ShowDialog();
                gridViewCriterias gridView = new gridViewCriterias();
                gridView.Load(dataGridViewCriteria);
            }
            catch (Exception ex)
            {
                WriteErr(ex.Message);
            }
        }
        private void WriteErr(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

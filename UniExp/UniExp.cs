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
                WriteErrInfo(ex.Message);
            }
        }

        private void UniExp_Load(object sender, EventArgs e)
        {
            try
            {
                GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaName, gridViewRowCriterias.colCriteriaName);
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaValue, gridViewRowCriterias.colCriteriaValue);
                //dataGridViewCriteria.Rows.Add(1);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewCriteria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void SaveCriterias_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GridViewCriterias gridView = new GridViewCriterias();
                    gridView.Save(dataGridViewCriteria, saveFileDialog.FileName);
                }
            }
            catch (ArgumentException aEx)
            {
                WriteErrInfo(aEx.Message, aEx.ParamName);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void LoadCriterias_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GridViewCriterias gridView = new GridViewCriterias();
                    gridView.Load(dataGridViewCriteria, openFileDialog.FileName);
                }
            }
            catch (ArgumentException aEx)
            {
                WriteErrInfo(aEx.Message, aEx.ParamName);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }
        private void WriteErrInfo(string message, string typeErrInfo = "Error")
        {
            switch (typeErrInfo)
            {
                case "Error":
                    {
                        MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "Warning":
                    {
                        MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            
        }
    }
}

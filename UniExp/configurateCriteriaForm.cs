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
    public partial class configurateCriteriaForm : Form
    {
        protected string criteriaName { get; set; }
        protected string criteriaValue { get; set; }

        public configurateCriteriaForm()
        {
            InitializeComponent();
            dataGridViewConfigurateCriteria.Rows.Add(5);
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
        }

        public configurateCriteriaForm(string criteriaName, string criteriaValue) : this()
        {
            this.criteriaName = criteriaName;
            this.criteriaValue = criteriaValue;
        }

        private void configurateCriteriaForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBoxCriteriaName.Text = criteriaName;
                string[] criteriasValues = this.criteriaValue.Split(new char[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (criteriasValues.Length > 0)
                {
                    dataGridViewConfigurateCriteria.Rows.Clear();
                    for (int idx = 0; idx < 5; idx++)
                    {
                        if (idx <= criteriasValues.Length - 1)
                        {
                            dataGridViewConfigurateCriteria.Rows.Add(criteriasValues[idx]);
                        }
                        else
                        {
                            dataGridViewConfigurateCriteria.Rows.Add(1);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        public string getCriteriaName()
        {
            return this.criteriaName;
        }
        public string getCriteriaValue()
        {
            return this.criteriaValue;
        }

        private void btnSaveConfigurateCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.None;
                List<string> lstCriteriaVals = new List<string>();
                List<string> lstUniqCriteriaVals = new List<string>();
                for (int idx = 0; idx < 5; idx++)
                {
                    object criteriaValueObj = dataGridViewConfigurateCriteria.Rows[idx].
                        Cells[0].Value;
                    string criteriaValue = criteriaValueObj == null ? string.Empty : criteriaValueObj.ToString();
                    //
                    if(!string.IsNullOrEmpty(criteriaValue))
                    {
                        lstCriteriaVals.Add(criteriaValue);
                    }
                }
                foreach(string criteriaVal in lstCriteriaVals)
                {
                    if (!lstUniqCriteriaVals.Contains(criteriaVal))
                    {
                        lstUniqCriteriaVals.Add(criteriaVal);
                    }
                }
                if (lstUniqCriteriaVals.Count != lstCriteriaVals.Count)
                {
                    throw new Exception("В пределах одного критерия должны быть уникальные значения");
                }
                else
                {
                    this.criteriaValue = string.Join(";", lstUniqCriteriaVals);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message, "Warning");
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

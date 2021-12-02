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
    public partial class configurateCriteriaForm : Form
    {
        protected string criteriaName { get; set; }
        protected string criteriaValue { get; set; }

        public configurateCriteriaForm()
        {
            InitializeComponent();
            //
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
                //
                GridViewColumns gridViewColumns = new GridViewColumns();
                dataGridViewConfigurateCriteria.Columns.Add(gridViewColumns.colCriteriaValue,
                    gridViewColumns.colCriteriaValue);
                GridViewLimit gridViewLimit = new GridViewLimit();
                dataGridViewConfigurateCriteria.Rows.Add(gridViewLimit.maxCriteriaValueRows);
                //
                this.txtBoxCriteriaName.Text = this.criteriaName;
                //                
                string[] criteriasValues = GridViewRowCriteria.GetSplitValue(this.criteriaValue);
                if (criteriasValues.Length > 0)
                {
                    //GridViewLimit gridViewLimit = new GridViewLimit();
                    dataGridViewConfigurateCriteria.Rows.Clear();
                    for (int idx = 0; idx < gridViewLimit.maxCriteriaValueRows; idx++)
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
                GridViewColumns gridViewColumns = new GridViewColumns();
                GridViewLimit gridViewLimit = new GridViewLimit();
                List<string> lstCriteriaVals = new List<string>();
                List<string> lstUniqCriteriaVals = new List<string>();
                for (int idx = 0; idx < gridViewLimit.maxCriteriaValueRows; idx++)
                {
                    object criteriaValueObj = dataGridViewConfigurateCriteria.Rows[idx].
                        Cells[gridViewColumns.colCriteriaValue].Value;
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
                        if (criteriaVal.Length > gridViewLimit.maxLnCriteriaValue)
                        {
                            WriteErrInfo(string.Format("Наименование значения: '{0}, превышает " +
                                "допустимую длину в {1} символов'", criteriaVal, gridViewLimit.maxLnCriteriaValue),
                                "Warning");
                            return;
                        }
                        lstUniqCriteriaVals.Add(criteriaVal);
                    }
                }
                if (lstUniqCriteriaVals.Count != lstCriteriaVals.Count)
                {
                    WriteErrInfo("В пределах одного критерия должны быть уникальные значения", "Warning");
                    return;
                }
                else
                {
                    this.criteriaValue = GridViewRowCriteria.GetBuildValue(lstUniqCriteriaVals);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                //WriteErrInfo(ex.Message, "Warning");
                WriteErrInfo(ex.Message);
            }
        }

        private void btnSaveConfigurateCriteria_MouseHover(object sender, EventArgs e)
        {
            try
            {
                ToolTip btnSaveConfigurateCriteriaToolTip = new ToolTip();
                btnSaveConfigurateCriteriaToolTip.SetToolTip(btnSaveConfigurateCriteria, "Сохранить введеные значения");
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnCancelConfigurateCriteria_MouseHover(object sender, EventArgs e)
        {
            try
            {
                ToolTip btnCancelConfigurateCriteriaToolTip = new ToolTip();
                btnCancelConfigurateCriteriaToolTip.SetToolTip(btnCancelConfigurateCriteria, "Вернуться к окну \"UniExp\"");
            }
            catch(Exception ex)
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

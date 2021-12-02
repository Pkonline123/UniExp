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
    public partial class configurateRoleFrom : Form
    {
        protected string roleNumber { get; set; }
        protected string roleName { get; set; }
        protected string roleValue { get; set; }
        //protected GridViewRowRole gridViewRowRole { get; set; }
        protected List<GridViewRowCriteria> gridViewRowCriterias { get; set; }

        public configurateRoleFrom()
        {
            /*
             *Добавить кнопки Сохранить/Отменить +
             *Преоброзовать все ячейки таблицы в дропдауны +
             *На глвной форме добавить панели с лабелами по аналогии с этой +
             *Проверить если гдето напрямую указаны наименования + 
             *Проверить везде неименованые контролы +
             *Проверить все экшены на трай/кетч +
             *Метод вывода сообщения об ошибки и предупреждения внести в отдельный класс чтоб не писать его на каждой форме
             *Посидеть потыкать протестирвоать
             *Дописать help
             *В ToolStript добавить с права сылку на хелп (как добавить его с правой стороны) +-
             *
             * После всего
             * Кнтроль данных выписать все которые есть и с преподователем согласовать все это
             */
            InitializeComponent();
            //
            this.roleNumber = string.Empty;
            this.roleName = string.Empty;
            this.roleValue = string.Empty;
            //this.gridViewRowRole = new GridViewRowRole();
            this.gridViewRowCriterias = new List<GridViewRowCriteria>();
        }

        public configurateRoleFrom(string roleNumber, string criteriaName, string criteriaValue,
           List<GridViewRowCriteria> gridViewRowCriterias) : this()
        {
            this.roleNumber = roleNumber;
            this.roleName = criteriaName;
            this.roleValue = criteriaValue;
            //this.gridViewRowRole = gridViewRowRole;
            this.gridViewRowCriterias = gridViewRowCriterias;
        }

        private void configurateRoleFrom_Load(object sender, EventArgs e)
        {
            try
            {
                GridViewColumns gridViewColumns = new GridViewColumns();
                GridViewDelims gridViewDelims = new GridViewDelims();
                //
                lblIf.Text = gridViewColumns.colRoleName;
                lblTo.Text = gridViewColumns.colRoleValue;
                //
                txtBoxNumerRole.Text = roleNumber;
                //
                List<string> criterias = new List<string>();
                foreach (GridViewRowCriteria gridViewRowCriteria in this.gridViewRowCriterias)
                {
                    criterias.Add(gridViewRowCriteria.criteriaName);
                }
                //
                dataGridViewIf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //
                DataGridViewComboBoxColumn dataGridViewComboBoxColumnRoleOperateIf = new DataGridViewComboBoxColumn();
                dataGridViewComboBoxColumnRoleOperateIf.Name = gridViewColumns.colRoleOperate;
                dataGridViewComboBoxColumnRoleOperateIf.HeaderText = gridViewColumns.colRoleOperate;
                dataGridViewComboBoxColumnRoleOperateIf.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dataGridViewComboBoxColumnRoleOperateIf.Items.Add(gridViewDelims.gvOpAndR);
                dataGridViewComboBoxColumnRoleOperateIf.Items.Add(gridViewDelims.gvOpOrR);
                dataGridViewIf.Columns.Add(dataGridViewComboBoxColumnRoleOperateIf);
                //
                DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaNameIf = new DataGridViewComboBoxColumn();
                dataGridViewComboBoxColumnCriteriaNameIf.Name = gridViewColumns.colCriteriaName;
                dataGridViewComboBoxColumnCriteriaNameIf.HeaderText = gridViewColumns.colCriteriaName;
                dataGridViewComboBoxColumnCriteriaNameIf.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                foreach (string criteria in criterias)
                {
                    dataGridViewComboBoxColumnCriteriaNameIf.Items.Add(criteria);
                }
                dataGridViewIf.Columns.Add(dataGridViewComboBoxColumnCriteriaNameIf);
                //
                DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaValueIf = new DataGridViewComboBoxColumn();
                dataGridViewComboBoxColumnCriteriaValueIf.Name = gridViewColumns.colCriteriaValue;
                dataGridViewComboBoxColumnCriteriaValueIf.HeaderText = gridViewColumns.colCriteriaValue;
                dataGridViewComboBoxColumnCriteriaValueIf.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dataGridViewIf.Columns.Add(dataGridViewComboBoxColumnCriteriaValueIf);
               
                GridViewLimit gridViewLimit = new GridViewLimit();
                dataGridViewIf.Rows.Add(gridViewLimit.maxRoleCriteriaRows);
                //
                dataGridViewIf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //
                DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaNameTo = new DataGridViewComboBoxColumn();
                dataGridViewComboBoxColumnCriteriaNameTo.Name = gridViewColumns.colCriteriaName;
                dataGridViewComboBoxColumnCriteriaNameTo.HeaderText = gridViewColumns.colCriteriaName;
                dataGridViewComboBoxColumnCriteriaNameTo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                foreach (string criteria in criterias)
                {
                    dataGridViewComboBoxColumnCriteriaNameTo.Items.Add(criteria);
                }
                dataGridViewTo.Columns.Add(dataGridViewComboBoxColumnCriteriaNameTo);
                //
                DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaValueTo = new DataGridViewComboBoxColumn();
                dataGridViewComboBoxColumnCriteriaValueTo.Name = gridViewColumns.colCriteriaValue;
                dataGridViewComboBoxColumnCriteriaValueTo.HeaderText = gridViewColumns.colCriteriaValue;
                dataGridViewComboBoxColumnCriteriaValueTo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dataGridViewTo.Columns.Add(dataGridViewComboBoxColumnCriteriaValueTo);
                dataGridViewTo.Rows.Add(gridViewLimit.maxRoleValueRows);
                //
                FillGrid();
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewIf_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {
            try
            {
                if (dataGridViewIf.Columns.Count > 0)
                {
                    GridViewColumns gridViewColumns = new GridViewColumns();
                    if (dataGridViewIf.Columns.Contains(gridViewColumns.colRoleOperate))
                    {
                        dataGridViewIf.Columns[gridViewColumns.colRoleOperate].Width = 55;
                        dataGridViewIf.Rows[0].Cells[gridViewColumns.colRoleOperate].ReadOnly = true;
                        dataGridViewIf.Rows[0].Cells[gridViewColumns.colRoleOperate].Style.BackColor = Color.FromName("Control");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void FillGrid()
        {
            //
            GridViewLimit gridViewLimit = new GridViewLimit();
            GridViewColumns gridViewColumns = new GridViewColumns();
            //
            if (!string.IsNullOrEmpty(this.roleName))
            {
                List<GridViewRowCriteria> gridViewRowCriteriasIf = GridViewRowRole.GetSplitName(this.roleName);
                int idxRow = -1;
                foreach (GridViewRowCriteria gridViewRowCriteria in gridViewRowCriteriasIf)
                {
                    //Переделать чтоб шло по строкам
                    if (idxRow <= gridViewLimit.maxRoleCriteriaRows - 1)
                        FillRow(gridViewRowCriteria, ++idxRow);
                    else
                        break;
                }
            }
            if (!string.IsNullOrEmpty(this.roleValue))
            {
                GridViewRowCriteria gridViewRowCriteriaTo = GridViewRowRole.GetSplitValue(this.roleValue);
                int idxRowTo = gridViewLimit.maxRoleValueRows - 1;
                FillColumnName(dataGridViewTo.Rows[idxRowTo].Cells[gridViewColumns.colCriteriaName],
                    gridViewRowCriteriaTo.criteriaName);
                GridViewRowCriteria gridViewRowCriteria = 
                    this.gridViewRowCriterias.FirstOrDefault(cr => cr.criteriaName == gridViewRowCriteriaTo.criteriaName);
                if(gridViewRowCriteria == null)
                    throw new Exception("FillGrid: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
                FillColumnValue(GridViewRowCriteria.GetSplitValue(gridViewRowCriteria.criteriaValue),
                    dataGridViewTo.Rows[idxRowTo].Cells[gridViewColumns.colCriteriaValue],
                    gridViewRowCriteriaTo.criteriaValue);
            }
        }

        private void FillRow(GridViewRowCriteria gridViewRowCriteriaIf, int idxRow)
        {
            if (gridViewRowCriteriaIf == null)
                throw new Exception("FillRow: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
            GridViewLimit gridViewLimit = new GridViewLimit();
            if (idxRow < 0 || idxRow > gridViewLimit.maxRoleCriteriaRows - 1)
                throw new Exception("FillRow: Ожидалось значение (int)idxRow");
            //
            GridViewColumns gridViewColumns = new GridViewColumns();
            if (idxRow > 0)
                FillColumnOperate(dataGridViewIf.Rows[idxRow].Cells[gridViewColumns.colRoleOperate],
                    gridViewRowCriteriaIf.criteriaOperate);
            FillColumnName(dataGridViewIf.Rows[idxRow].Cells[gridViewColumns.colCriteriaName],
                gridViewRowCriteriaIf.criteriaName);
            GridViewRowCriteria gridViewRowCriteria =
                     this.gridViewRowCriterias.FirstOrDefault(cr => cr.criteriaName == gridViewRowCriteriaIf.criteriaName);
            if (gridViewRowCriteria == null)
                throw new Exception("FillRow: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
            FillColumnValue(GridViewRowCriteria.GetSplitValue(gridViewRowCriteria.criteriaValue),
            dataGridViewIf.Rows[idxRow].Cells[gridViewColumns.colCriteriaValue],
                gridViewRowCriteriaIf.criteriaValue);
        }

        private void FillColumnOperate(DataGridViewCell dataGridViewCell, string operate)
        {
            if (dataGridViewCell == null)
                throw new Exception("FillColumnOperate: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (operate == null)
                throw new Exception("FillColumnOperate: Ожидалось значение (string)operate");
            //
            //if (dataGridViewCell is DataGridViewComboBoxCell)
            //{
            //    DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)dataGridViewCell;
            //    if (!dataGridViewComboBoxCell.Items.Contains(operate))
            //    {
            //        dataGridViewComboBoxCell.Items.Add(operate);
            //    }
            //}
            dataGridViewCell.Value = operate;
        }

        private void FillColumnName(DataGridViewCell dataGridViewCell, string name)
        {
            if (dataGridViewCell == null)
                throw new Exception("FillColumnName: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (name == null)
                throw new Exception("FillColumnName: Ожидалось значение (string)name");
            //
            //if (dataGridViewCell is DataGridViewComboBoxCell)
            //{
            //    DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)dataGridViewCell;
            //    if (!dataGridViewComboBoxCell.Items.Contains(name))
            //    {
            //        dataGridViewComboBoxCell.Items.Add(name);
            //    }
            //}
            dataGridViewCell.Value = name;
        }

        private void FillColumnValue(string[] criteriaValues, DataGridViewCell dataGridViewCell, string value)
        {
            if(criteriaValues == null)
                throw new Exception("FillColumnValue: Ожидалось значение (string[])criteriaValues");
            if (dataGridViewCell == null)
                throw new Exception("FillColumnValue: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (value == null)
                throw new Exception("FillColumnValue: Ожидалось значение (string)value");
            //
            if (dataGridViewCell is DataGridViewComboBoxCell)
            {
                DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)dataGridViewCell;
                //if (!dataGridViewComboBoxCell.Items.Contains(value))
                //{
                //    dataGridViewComboBoxCell.Items.Add(value);
                //}
                foreach (string criteriaValue in criteriaValues)
                {
                    dataGridViewComboBoxCell.Items.Add(criteriaValue);
                }
            }
            dataGridViewCell.Value = value;
        }

        public string getRoleName()
        {
            return this.roleName;
        }

        public string getRoleValue()
        {
            return this.roleValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.None;
                //
                //Добавить проверки и переделать
                this.roleName = this.roleName;
                this.roleValue = this.roleValue;
                //
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnExist_MouseHover(object sender, EventArgs e)
        {
            try
            {

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
                default:
                    {
                        MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }

        }
    }
}

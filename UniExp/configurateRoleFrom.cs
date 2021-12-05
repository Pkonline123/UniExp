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
            //!!! Делать билдинг и посмотреть кросс проверки валидности данных
            /*
             *Добавить кнопки Сохранить/Отменить +
             *Преоброзовать все ячейки таблицы в дропдауны +
             *На глвной форме добавить панели с лабелами по аналогии с этой +
             *Проверить если гдето напрямую указаны наименования + 
             *Проверить везде неименованые контролы +
             *Проверить все экшены на трай/кетч +
             *Метод вывода сообщения об ошибки и предупреждения внести в отдельный класс чтоб не писать его на каждой форме
             * Реализовать удаления для этой таблицы и для другого конфигуратора
             *Посидеть потыкать протестирвоать
             *Дописать help
             * Рефакторинг кода
             *В ToolStript добавить с права сылку на хелп +
             *
             * После всего
             * Кнтроль данных выписать все которые есть и с преподователем согласовать все это
             */
            InitializeComponent();
            //
            this.roleNumber = string.Empty;
            this.roleName = string.Empty;
            this.roleValue = string.Empty;
            this.gridViewRowCriterias = new List<GridViewRowCriteria>();
        }

        public configurateRoleFrom(string roleNumber, string criteriaName, string criteriaValue,
           List<GridViewRowCriteria> gridViewRowCriterias) : this()
        {
            this.roleNumber = roleNumber;
            this.roleName = criteriaName;
            this.roleValue = criteriaValue;
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
                if(string.IsNullOrEmpty(roleNumber))
                    txtBoxNumerRole.Text = "Новое";
                else
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

        private void dataGridViewIf_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillCellValue(e.RowIndex, e.ColumnIndex, dataGridViewIf);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }

        }

        private void dataGridViewTo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillCellValue(e.RowIndex, e.ColumnIndex, dataGridViewTo);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        protected void FillCellValue(int rowIdx, int colIdx, DataGridView dataGridView)
        {
            GridViewColumns gridViewColumns = new GridViewColumns();
            if (dataGridView.Columns[colIdx].Name == gridViewColumns.colCriteriaName)
            {
                dataGridView.Rows[rowIdx].Cells[gridViewColumns.colCriteriaValue].Value = null;
                ((DataGridViewComboBoxCell)dataGridView.Rows[rowIdx].
                        Cells[gridViewColumns.colCriteriaValue]).Items.Clear();
                //
                if (dataGridView.Rows[rowIdx].Cells[gridViewColumns.colCriteriaName].Value != null)
                {
                    string criteriaName = dataGridView.Rows[rowIdx].
                        Cells[gridViewColumns.colCriteriaName].Value.ToString();
                    GridViewRowCriteria gridViewRowCriteria =
                    this.gridViewRowCriterias.FirstOrDefault(cr => cr.criteriaName == criteriaName);
                    if (gridViewRowCriteria == null)
                        throw new Exception("FillCellValue: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
                    string[] criteriaValues = GridViewRowCriteria.GetSplitValue(gridViewRowCriteria.criteriaValue);                    
                    foreach (string criteriaValue in criteriaValues)
                    {
                        ((DataGridViewComboBoxCell)dataGridView.Rows[rowIdx].
                        Cells[gridViewColumns.colCriteriaValue]).Items.Add(criteriaValue);
                    }
                    if (((DataGridViewComboBoxCell)dataGridView.Rows[rowIdx].
                        Cells[gridViewColumns.colCriteriaValue]).Items.Count > 0)
                        dataGridView.Rows[rowIdx].Cells[gridViewColumns.colCriteriaValue].Value =
                            ((DataGridViewComboBoxCell)dataGridView.Rows[rowIdx].
                        Cells[gridViewColumns.colCriteriaValue]).Items[0];
                }
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
                FillColumnValue(dataGridViewTo.Rows[idxRowTo].Cells[gridViewColumns.colCriteriaValue],
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
            FillColumnValue(dataGridViewIf.Rows[idxRow].Cells[gridViewColumns.colCriteriaValue], 
                gridViewRowCriteriaIf.criteriaValue);
        }

        private void FillColumnOperate(DataGridViewCell dataGridViewCell, string operate)
        {
            if (dataGridViewCell == null)
                throw new Exception("FillColumnOperate: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (operate == null)
                throw new Exception("FillColumnOperate: Ожидалось значение (string)operate");
            //
            dataGridViewCell.Value = operate;
        }

        private void FillColumnName(DataGridViewCell dataGridViewCell, string name)
        {
            if (dataGridViewCell == null)
                throw new Exception("FillColumnName: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (name == null)
                throw new Exception("FillColumnName: Ожидалось значение (string)name");
            //
            dataGridViewCell.Value = name;
        }

        private void FillColumnValue(DataGridViewCell dataGridViewCell, string value)
        {
            if (dataGridViewCell == null)
                throw new Exception("FillColumnValue: Ожидалось значение (DataGridViewCell)dataGridViewCell");
            if (value == null)
                throw new Exception("FillColumnValue: Ожидалось значение (string)value");
            //
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

        private void dataGridViewIf_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && dataGridViewIf.SelectedRows.Count == 1)
                {
                    GridViewColumns gridViewColumns = new GridViewColumns();
                    foreach (DataGridViewCell dataGridViewCell in dataGridViewIf.SelectedCells)
                    {
                        dataGridViewCell.Value = null;
                        if (dataGridViewCell.ColumnIndex == 2)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCell).Items.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.None;
                //
                GridViewColumns gridViewColumns = new GridViewColumns();
                //
                List<GridViewRowCriteria> roleName = new List<GridViewRowCriteria>();
                GridViewRowCriteria roleValue = new GridViewRowCriteria();
                int cntRows = 0;
                object objOperate = null;
                object objName = null;
                object objValue = null;
                string operate = string.Empty;
                string name = string.Empty;
                string value = string.Empty;
                //
                foreach (DataGridViewRow dataGridViewRow in dataGridViewIf.Rows)
                {
                    objOperate = dataGridViewRow.Cells[gridViewColumns.colRoleOperate].Value;
                    objName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value;
                    objValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value;
                    operate = objOperate == null ? string.Empty : objOperate.ToString();
                    name = objName == null ? string.Empty : objName.ToString();
                    value = objValue == null ? string.Empty : objValue.ToString();
                    //
                    if (objOperate == null && objName == null && objValue == null)
                    {
                        if (dataGridViewRow.Index == 0)
                        {
                            WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поля", dataGridViewRow.Index + 1),
                                "Warning");
                            return;
                        }
                        continue;
                    }
                    else
                    {
                        if (dataGridViewRow.Index > 0)
                        {
                            if (objOperate == null)
                            {
                                WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поле {1}", dataGridViewRow.Index + 1,
                                    gridViewColumns.colRoleOperate), "Warning");
                                return;
                            }
                        }
                        if (objName == null)
                        {
                            WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поле {1}", dataGridViewRow.Index + 1,
                                gridViewColumns.colCriteriaName), "Warning");
                            return;
                        }
                        if (objValue == null)
                        {
                            WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поле {1}", dataGridViewRow.Index + 1,
                                gridViewColumns.colCriteriaValue), "Warning");
                            return;
                        }
                        //
                        cntRows++;
                        //
                        roleName.Add(new GridViewRowCriteria() {
                            criteriaOperate = operate,
                            criteriaName = name,
                            criteriaValue = value
                        });
                    }
                }
                //
                if (cntRows == 0)
                {
                    WriteErrInfo(string.Format("Перед добавлением правил необходимо заполнить таблицу '{0}'",
                        gridViewColumns.colRoleName), "Warning");
                    return;
                }
                //
                this.roleName = GridViewRowRole.GetBuildName(roleName);
                //
                cntRows = 0;
                foreach (DataGridViewRow dataGridViewRow in dataGridViewTo.Rows)
                {
                    objName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value;
                    objValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value;
                    name = objName == null ? string.Empty : objName.ToString();
                    value = objValue == null ? string.Empty : objValue.ToString();
                    //
                    if (objName == null && objValue == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (objName == null)
                        {
                            WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поле {1}", dataGridViewRow.Index + 1,
                                gridViewColumns.colCriteriaName), "Warning");
                            return;
                        }
                        if (objValue == null)
                        {
                            WriteErrInfo(string.Format("Для строки {0} необходимо заполнить поле {1}", dataGridViewRow.Index + 1,
                                gridViewColumns.colCriteriaValue), "Warning");
                            return;
                        }
                        //
                        cntRows++;
                        //
                        roleValue.criteriaName = name;
                        roleValue.criteriaValue = value;
                    }
                }
                //
                if (cntRows == 0)
                {
                    WriteErrInfo(string.Format("Перед добавлением правил необходимо заполнить таблицу '{0}'",
                        gridViewColumns.colRoleValue), "Warning");
                    return;
                }
                //
                this.roleValue = GridViewRowRole.GetBuildValue(roleValue);
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
                ToolTip btnCancelConfigurateCriteriaToolTip = new ToolTip();
                btnCancelConfigurateCriteriaToolTip.SetToolTip(btnSave, "Сохранить введенное правило");
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
                ToolTip btnCancelConfigurateCriteriaToolTip = new ToolTip();
                btnCancelConfigurateCriteriaToolTip.SetToolTip(btnExist, "Вернуться к окну \"UniExp\"");
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

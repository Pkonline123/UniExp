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
    public partial class LogicalOut : Form
    {
        //protected string roleNumber { get; set; }
        //protected string roleName { get; set; }
        //protected string roleValue { get; set; }
        protected List<GridViewRowCriteria> gridViewRowCriterias { get; set; }
        protected DataGridView gridViewRowRole { get; set; }
        protected string roleName { get; set; }

        public LogicalOut()
        {
            /*
             * Если критерия нету при открытие конструктора для правил, выдать ошибка и конструктор закрыть
             * Проверка перед удаление критерия "Есть ли правила которые ссылаются на этот критерий"
             */
            InitializeComponent();
            //
            //this.roleNumber = string.Empty;
            //this.roleName = string.Empty;
            //this.roleValue = string.Empty;
            this.gridViewRowCriterias = new List<GridViewRowCriteria>();
            this.gridViewRowRole = new DataGridView();
        }

        //public LogicalOut(List<GridViewRowCriteria> gridViewRowCriterias, List<GridViewRowRole> gridViewRowRoles) : this()
        public LogicalOut(List<GridViewRowCriteria> gridViewRowCriterias, DataGridView gridViewRowRole) : this()
        {
            //this.roleNumber = roleNumber;
            //this.roleName = criteriaName;
            //this.roleValue = criteriaValue;
            this.gridViewRowCriterias = gridViewRowCriterias;
            this.gridViewRowRole = gridViewRowRole;
        }

        private void logicalOut_Load(object sender, EventArgs e)
        {
            try
            {
                if (gridViewRowRole.RowCount < 2)
                {
                    WriteErrInfo("Необходимо заполнить таблицу с правилами");
                    this.Close();
                }
                //
                btnLogicOut.Enabled = false;
                //
                btnGraph.Enabled = false;
                //
                GridViewColumns gridViewColumns = new GridViewColumns();
                GridViewDelims gridViewDelims = new GridViewDelims();
                //
                //lblIf.Text = gridViewColumns.colRoleName;
                //lblTo.Text = gridViewColumns.colRoleValue;
                //
                //if (string.IsNullOrEmpty(roleNumber))
                //    txtBoxNumerRole.Text = "Новое";
                //else
                //    txtBoxNumerRole.Text = roleNumber;
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
                //DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaNameTo = new DataGridViewComboBoxColumn();
                //dataGridViewComboBoxColumnCriteriaNameTo.Name = gridViewColumns.colCriteriaName;
                //dataGridViewComboBoxColumnCriteriaNameTo.HeaderText = gridViewColumns.colCriteriaName;
                //dataGridViewComboBoxColumnCriteriaNameTo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                //foreach (string criteria in criterias)
                //{
                //    dataGridViewComboBoxColumnCriteriaNameTo.Items.Add(criteria);
                //}
                //dataGridViewTo.Columns.Add(dataGridViewComboBoxColumnCriteriaNameTo);
                ////
                //DataGridViewComboBoxColumn dataGridViewComboBoxColumnCriteriaValueTo = new DataGridViewComboBoxColumn();
                //dataGridViewComboBoxColumnCriteriaValueTo.Name = gridViewColumns.colCriteriaValue;
                //dataGridViewComboBoxColumnCriteriaValueTo.HeaderText = gridViewColumns.colCriteriaValue;
                //dataGridViewComboBoxColumnCriteriaValueTo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                //dataGridViewTo.Columns.Add(dataGridViewComboBoxColumnCriteriaValueTo);
                //dataGridViewTo.Rows.Add(gridViewLimit.maxRoleValueRows);
                //
                FillGrid();
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewIf_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillCellValue(e.RowIndex, e.ColumnIndex, dataGridViewIf);
                if(dataGridViewIf.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    btnLogicOut.Enabled = true;
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

        private void FillGrid()
        {
            //
            GridViewLimit gridViewLimit = new GridViewLimit();
            GridViewColumns gridViewColumns = new GridViewColumns();
            //
            //if (!string.IsNullOrEmpty(this.roleName))
            //{
            List<GridViewRowCriteria> gridViewRowCriteriasIf = new List<GridViewRowCriteria>();
            int idxRow = -1;
            foreach (GridViewRowCriteria gridViewRowCriteria in gridViewRowCriteriasIf)
            {
                if (idxRow <= gridViewLimit.maxRoleCriteriaRows - 1)
                    FillRow(gridViewRowCriteria, ++idxRow);
                else
                    break;
            }
            //if (!string.IsNullOrEmpty(this.roleValue))
            //{
            //    GridViewRowCriteria gridViewRowCriteriaTo = GridViewRowRole.GetSplitValue(this.roleValue);
            //    int idxRowTo = gridViewLimit.maxRoleValueRows - 1;
            //    FillColumnName(dataGridViewTo.Rows[idxRowTo].Cells[gridViewColumns.colCriteriaName],
            //        gridViewRowCriteriaTo.criteriaName);
            //    GridViewRowCriteria gridViewRowCriteria =
            //        this.gridViewRowCriterias.FirstOrDefault(cr => cr.criteriaName == gridViewRowCriteriaTo.criteriaName);
            //    if (gridViewRowCriteria == null)
            //        throw new Exception("FillGrid: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
            //    FillColumnValue(dataGridViewTo.Rows[idxRowTo].Cells[gridViewColumns.colCriteriaValue],
            //        gridViewRowCriteriaTo.criteriaValue);
            //}
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

        /// <summary>
        /// Проработка контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewIf_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu contextMenu = new ContextMenu();
            //    contextMenu.MenuItems.Add(new MenuItem("Очистить"));

            //    int currentMouseOverRow = dataGridViewIf.HitTest(e.X, e.Y).RowIndex;

            //    if (currentMouseOverRow >= 0)
            //    {
            //        contextMenu.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
            //    }

            //    contextMenu.Show(dataGridViewIf, new Point(e.X, e.Y));

            //}
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


        private void btnGraph_Click(object sender, EventArgs e)
        {
            try
            {
                Graph graph = new Graph();
                graph.ShowDialog();
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnLogicOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBoxLogicOut.Items.Count > 10 || lstBoxLogicOut.Items.IndexOf("Правил не найдено") != -1)
                    lstBoxLogicOut.Items.Clear();
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
                        roleName.Add(new GridViewRowCriteria()
                        {
                            criteriaOperate = operate,
                            criteriaName = name,
                            criteriaValue = value
                        });
                    }
                }
                //
                if (cntRows == 0)
                {
                    WriteErrInfo(string.Format("Перед формирование вывода, необходимо заполнить таблицу '{0}'",
                        gridViewColumns.colRoleName), "Warning");
                    return;
                }
                //
                this.roleName = GridViewRowRole.GetBuildName(roleName);
                //
                StringBuilder sB = new StringBuilder();
                StringBuilder sBSergev = new StringBuilder();
                sB.Append("Если");
                sBSergev.Append("В запросе вы произвели ввод критерия ");
                string criteriaName = string.Empty;
                string criteriaVal = string.Empty;
                string criteriaOperate = string.Empty;
                //string findRole = string.Empty;
                string findRoleVal = string.Empty;
                //
                foreach (DataGridViewRow gridViewRow in gridViewRowRole.Rows)
                {
                    if (gridViewRow.Cells[1].Value == null)
                        continue;
                    if (gridViewRow.Cells[1].Value.ToString() == this.roleName)
                    {
                        //findRole = gridViewRow.Cells[1].Value.ToString();
                        findRoleVal = gridViewRow.Cells[2].Value.ToString();
                        //sB.Append("");
                        //sB.Append(criteriaName);
                        //sB.Append("");
                        //sB.Append(criteriaVal);
                        //if (criteriaOperate == string.Empty)
                        //    sB.Append("");
                        //else
                        //    sB.Append(criteriaOperate);

                        //sB.Append("To ");
                        //sB.Append("");
                        //sB.Append(GridViewRowRole.GetSplitValue(gridViewRow.Cells[2].Value.ToString()));
                    }
                }
                //
                if (!string.IsNullOrEmpty(findRoleVal))
                {
                    List<GridViewRowCriteria> gridViewRowCriteriasIf = GridViewRowRole.GetSplitName(this.roleName);
                    GridViewRowCriteria gridViewRowCriteriasTo = GridViewRowRole.GetSplitValue(findRoleVal);
                    //
                    foreach (GridViewRowCriteria gridViewRowCriteria in gridViewRowCriteriasIf)
                    {
                        criteriaOperate = gridViewRowCriteria.criteriaOperate;
                        criteriaName = gridViewRowCriteria.criteriaName;
                        criteriaVal = gridViewRowCriteria.criteriaValue;
                        //
                        if (criteriaOperate == string.Empty)
                        {
                            sB.Append("");
                            sBSergev.Append("");
                        }
                        else
                        {
                            sB.Append(" ");
                            sBSergev.Append("разделили его логической операцией");
                            sB.Append(criteriaOperate);
                            sBSergev.Append(criteriaOperate);
                            sB.Append(" ");
                            sBSergev.Append(",");
                        }
                        sB.Append(" ");
                        sBSergev.Append(" ");
                        sB.Append(criteriaName);
                        sBSergev.Append(criteriaName);
                        sB.Append(" ");
                        sBSergev.Append("который имеет значение ");
                        sB.Append(criteriaVal);
                        sBSergev.Append(criteriaVal);
                        sBSergev.Append(",");
                    }
                    sB.Append(" То ");
                    sB.Append(gridViewRowCriteriasTo.criteriaName);
                    sB.Append(" ");
                    sB.Append(gridViewRowCriteriasTo.criteriaValue);
                    //
                    lstBoxLogicOut.Items.Add(sB);
                    lstBoxLogicOut.Items.Add(sBSergev);
                }
                else
                {
                    lstBoxLogicOut.Items.Add("Правил не найдено");
                }
                //
                //lstBoxLogicOut.Text = "11";
                //
                if (lstBoxLogicOut.Items.Count > 0)
                    btnGraph.Enabled = true;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        //
        #region UniExp Form
        //
        private void UniExp_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), UniExpConst.projectDir)))
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), UniExpConst.projectDir));
                //
                initConrolsGrid();
                dataGridViewCriteria.Enabled = false;
                SetEditTable(false);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void UniExp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnSave.Enabled)
                {
                    e.Cancel = true;
                    WriteErrInfo("Перед закрытием приложения необходимо сохранить или " +
                        "отменить изменения текущего проекта", "Warning");
                }

            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }
        //
        #endregion UniExp Form
        //
        #region dataGridViewCriteria
        //
        private void dataGridViewCriteria_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {
            try
            {
                //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                GridViewColumns gridViewColumns = new GridViewColumns();
                if (dataGridViewCriteria.Columns.Contains(gridViewColumns.colIndex))
                    dataGridViewCriteria.Columns[gridViewColumns.colIndex].Width = 30;
                if (dataGridViewCriteria.Columns.Contains(gridViewColumns.colCriteriaValue))
                    dataGridViewCriteria.Columns[gridViewColumns.colCriteriaValue].Width = 60;
                if (dataGridViewCriteria.Columns.Contains(gridViewColumns.colBtnValue))
                    dataGridViewCriteria.Columns[gridViewColumns.colBtnValue].Width = 100;
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewCriteria_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                GridViewColumns gridViewColumns = new GridViewColumns();
                if (e.ColumnIndex == dataGridViewCriteria.Columns[gridViewColumns.colCriteriaValue].Index)
                {
                    e.Cancel = true;
                }
                if (e.ColumnIndex == dataGridViewCriteria.Columns[gridViewColumns.colIndex].Index)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewCriteria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                    GridViewColumns gridViewColumns = new GridViewColumns();
                    if (e.ColumnIndex == dataGridViewCriteria.Columns[gridViewColumns.colBtnValue].Index)
                    {
                        object criteriaNameObj = dataGridViewCriteria.Rows[e.RowIndex].Cells[gridViewColumns.colCriteriaName].Value;
                        string criteriaName = criteriaNameObj == null ? string.Empty : criteriaNameObj.ToString();
                        object criteriaValueObj = dataGridViewCriteria.Rows[e.RowIndex].Cells[gridViewColumns.colCriteriaValue].Value;
                        string criteriaValue = criteriaValueObj == null ? string.Empty : criteriaValueObj.ToString();
                        //
                        if (string.IsNullOrEmpty(criteriaName))
                        {
                            WriteErrInfo("Необходимо заполнить наименования критерия", "Warning");
                            return;
                        }
                        //
                        using (configurateCriteriaForm configurateCriteria = new configurateCriteriaForm(criteriaName, criteriaValue))
                        {
                            configurateCriteria.Owner = this;
                            if (configurateCriteria.ShowDialog() == DialogResult.OK)
                            {
                                dataGridViewCriteria.Rows[e.RowIndex].
                                    Cells[gridViewColumns.colCriteriaValue].Value = configurateCriteria.getCriteriaValue();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewCriteria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                GridViewColumns gridViewColumns = new GridViewColumns();
                if (dataGridViewCriteria.Rows[e.RowIndex].Cells[gridViewColumns.colIndex].Value == null)
                {
                    dataGridViewCriteria.Rows[e.RowIndex].Cells[gridViewColumns.colIndex].Value =
                        e.RowIndex + 1;
                }
                //
                SetEditTable(true);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void dataGridViewCriteria_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex < dataGridViewCriteria.RowCount - 1)
            //if(!dataGridViewCriteria.Rows[e.RowIndex].IsNewRow)
            {
                //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                GridViewColumns gridViewColumns = new GridViewColumns();
                dataGridViewCriteria.Rows[e.RowIndex].Cells[gridViewColumns.colIndex].Value =
                    e.RowIndex + 1;
            }
            //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
            //dataGridViewCriteria.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewCriteria_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                SetEditTable(true);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }
        //
        #endregion dataGridViewCriteria
        //
        #region MainMenu
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBoxProjName.SelectedIndex < 0)
                    throw new Exception("Ожидалось значение (int)lstBoxProjName.SelectedIndex > -1");
                //
                //GridViewCriterias gridView = new GridViewCriterias();
                //if (gridView.checkValues(dataGridViewCriteria))
                //{
                //    gridView.Save(dataGridViewCriteria, Path.Combine(toolStripStatusLabel.Text,
                //        makeFilePrefix(lstBoxProjName.SelectedIndex, false, false)));
                //    SetEditTable(false);
                //}
                GridViewRoles gridView = new GridViewRoles();
                if (gridView.checkValues(dataGridViewCriteria, dataGridViewRoles))
                {
                    gridView.Save(dataGridViewCriteria, dataGridViewRoles, Path.Combine(toolStripStatusLabel.Text,
                        makeFilePrefix(lstBoxProjName.SelectedIndex, false, false)));
                    SetEditTable(false);
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

        private void btnCreated_Click(object sender, EventArgs e)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(saveFileDialog.FileName);
                if (string.IsNullOrEmpty(directoryName))
                    saveFileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), UniExpConst.projectDir);
                //
                saveFileDialog.FileName = "data.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lstBoxProjName.Items.Clear();
                    //
                    if (File.Exists(saveFileDialog.FileName))
                        File.Delete(saveFileDialog.FileName);
                    //
                    string[] filesNames = Directory.GetFiles(Path.GetDirectoryName(saveFileDialog.FileName),
                            "*.json");
                    toolStripStatusLabel.Text = Path.GetDirectoryName(saveFileDialog.FileName);
                    foreach (string fileName in filesNames)
                    {
                        lstBoxProjName.Items.Add(Path.GetFileName(fileName));
                    }
                    lstBoxProjName.Items.Add(Path.GetFileName(saveFileDialog.FileName));
                    //
                    lstBoxProjName.SelectedIndex = lstBoxProjName.Items.Count - 1;
                    lstBoxProjName.Items[lstBoxProjName.SelectedIndex] =
                        makeFilePrefix(lstBoxProjName.SelectedIndex, true, true);
                    //
                    //setColumnSize();
                }
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Path.Combine(toolStripStatusLabel.Text,
                    makeFilePrefix(lstBoxProjName.SelectedIndex, false, false));
                if (File.Exists(fileName))
                {
                    //GridViewCriterias gridView = new GridViewCriterias();
                    //gridView.Load(dataGridViewCriteria, fileName);
                    ////
                    //SetEditTable(false);
                    //gridView.checkValues(dataGridViewCriteria);
                    GridViewRoles gridView = new GridViewRoles();
                    gridView.Load(dataGridViewCriteria, dataGridViewRoles, fileName);
                    //
                    SetEditTable(false);
                    gridView.checkValues(dataGridViewCriteria, dataGridViewRoles);
                }
                else
                {
                    if (lstBoxProjName.Items.Count > 1)
                    {
                        lstBoxProjName.Items.Remove(lstBoxProjName.SelectedItem);
                        lstBoxProjName.SelectedIndex = 0;
                    }
                    else
                    {
                        lstBoxProjName.Items.Clear();
                        initConrolsGrid();
                        toolStripStatusLabel.Text = "Папка с проектами";
                        dataGridViewCriteria.Enabled = false;
                    }
                    SetEditTable(false);
                }
            }
            catch (ArgumentException aEx)
            {
                WriteErrInfo(aEx.Message, "Warning");
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(openFileDialog.FileName);
                if (string.IsNullOrEmpty(directoryName))
                    openFileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), UniExpConst.projectDir);
                //
                openFileDialog.FileName = "data.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lstBoxProjName.Items.Clear();
                    string[] filesNames = Directory.GetFiles(Path.GetDirectoryName(openFileDialog.FileName),
                        "*.json");
                    toolStripStatusLabel.Text = Path.GetDirectoryName(openFileDialog.FileName);
                    foreach (string fileName in filesNames)
                    {
                        //toolStripStatusLabel.Text = Path.GetDirectoryName(fileName);
                        lstBoxProjName.Items.Add(Path.GetFileName(fileName));
                        if (Path.GetFileName(fileName) == Path.GetFileName(openFileDialog.FileName))
                        {
                            lstBoxProjName.SelectedIndex = lstBoxProjName.Items.Count - 1;
                        }
                    }
                    //
                    //setColumnSize();
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

        private void btnExist_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }
        //
        #endregion MainMenu
        //
        #region lstBoxProjName
        //
        private void lstBoxProjName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstBoxProjName.SelectedItem != null)
                {
                    bool editMode = false;
                    if (!isFilePrefix(lstBoxProjName.SelectedItem.ToString(), out editMode))
                    {
                        int currSelectedIndex = currSelectedIteam(out editMode);
                        if (!editMode)
                        {
                            string fileName = Path.Combine(toolStripStatusLabel.Text,
                                makeFilePrefix(lstBoxProjName.SelectedIndex, false, false));
                            //
                            if (currSelectedIndex != -1)
                                lstBoxProjName.Items[currSelectedIndex] =
                                    makeFilePrefix(currSelectedIndex, false, false);
                            //
                            if (File.Exists(fileName))
                            {
                                //GridViewCriterias gridView = new GridViewCriterias();
                                //gridView.Load(dataGridViewCriteria, fileName);
                                //SetEditTable(false);
                                ////
                                //if (!dataGridViewCriteria.Enabled)
                                //    dataGridViewCriteria.Enabled = true;
                                ////
                                //gridView.checkValues(dataGridViewCriteria);
                                GridViewRoles gridView = new GridViewRoles();
                                gridView.Load(dataGridViewCriteria, dataGridViewRoles, fileName);
                                SetEditTable(false);
                                //
                                if (!dataGridViewCriteria.Enabled)
                                    dataGridViewCriteria.Enabled = true;
                                //
                                gridView.checkValues(dataGridViewCriteria, dataGridViewRoles);
                            }
                            else
                            {
                                initConrolsGrid();
                                //
                                SetEditTable(true);
                                //
                                if (!dataGridViewCriteria.Enabled)
                                    dataGridViewCriteria.Enabled = true;
                            }
                        }
                        else
                        {
                            lstBoxProjName.SelectedIndex = currSelectedIndex;
                            WriteErrInfo("Перед открытием другого проекта необходимо сохранить или отменить изменения текущего проекта",
                                "Warning");
                        }
                    }
                }
            }
            catch (ArgumentException aEx)
            {
                WriteErrInfo(aEx.Message, "Warning");
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }
        //
        #endregion lstBoxProjName
        //
        #region OtherFunction
        //
        private void initConrolsGrid()
        {
            //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
            GridViewColumns gridViewColumns = new GridViewColumns();
            //
            dataGridViewCriteria.Rows.Clear();
            dataGridViewCriteria.Columns.Clear();
            //
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //
            dataGridViewCriteria.Columns.Add(gridViewColumns.colIndex, gridViewColumns.colIndex);
            dataGridViewCriteria.Columns[gridViewColumns.colIndex].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            //dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaIndex].Width = 20;
            dataGridViewCriteria.Columns.Add(gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaName);
            dataGridViewCriteria.Columns.Add(gridViewColumns.colCriteriaValue, gridViewColumns.colCriteriaValue);
            dataGridViewCriteria.Columns[gridViewColumns.colCriteriaValue].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = gridViewColumns.colBtnValue;
            buttonColumn.Name = gridViewColumns.colBtnValue;
            buttonColumn.Text = gridViewColumns.colCriteriaValue;
            //buttonColumn.FlatStyle = FlatStyle.Popup;
            //buttonColumn.DefaultCellStyle.ForeColor = Color.Red;
            //buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridViewCriteria.Columns.Add(buttonColumn);
            //
            //setColumnSize();
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetEditTable(bool editMode)
        {
            if (editMode)
            {
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
            }
            if (lstBoxProjName.SelectedIndex >= 0)
                lstBoxProjName.Items[lstBoxProjName.SelectedIndex] =
                    makeFilePrefix(lstBoxProjName.SelectedIndex, editMode);
        }

        private string makeFilePrefix(int index, bool isEditMode = false, bool isSelected = true)
        {
            string result = string.Empty;
            //
            if (index < 0 || index > lstBoxProjName.Items.Count - 1)
                throw new Exception("makeFilePrefix: Ожидалось значение (int)index");
            if (isEditMode && !isSelected)
                throw new Exception("makeFilePrefix: При (bool)isEditMode = true ожидалось значение" +
                    "(bool)isSelected = true");
            //
            bool editMode = false;
            if (isEditMode)
            {
                if (!isFilePrefix(lstBoxProjName.Items[index].ToString(), out editMode))
                {
                    result = string.Format("{0}{1}", UniExpConst.editableFile, lstBoxProjName.Items[index]);
                }
                else if (isFilePrefix(lstBoxProjName.Items[index].ToString(), out editMode))
                {
                    if (!editMode)
                        result = ((string)lstBoxProjName.Items[index]).
                            Replace(UniExpConst.selectedFilePrefix, UniExpConst.editableFile);
                    else
                        result = (string)lstBoxProjName.Items[index];
                }
            }
            else
            {
                //
                if (!isFilePrefix(lstBoxProjName.Items[index].ToString(), out editMode))
                {
                    if (isSelected)
                        result = string.Format("{0}{1}", UniExpConst.selectedFilePrefix, lstBoxProjName.Items[index]);
                    else
                        result = (string)lstBoxProjName.Items[index];
                }
                else if (isFilePrefix(lstBoxProjName.Items[index].ToString(), out editMode))
                {
                    if (isSelected)
                    {
                        if (editMode)
                            result = ((string)lstBoxProjName.Items[index]).
                                Replace(UniExpConst.editableFile, UniExpConst.selectedFilePrefix);
                        else
                            result = (string)lstBoxProjName.Items[index];
                    }
                    else
                        result = ((string)lstBoxProjName.Items[index]).Substring(UniExpConst.editableFile.Length);
                }
            }
            return result;
        }
        private bool isFilePrefix(string fileName, out bool editMode)
        {
            editMode = false;
            //
            bool result = false;
            //
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("Ожидалось значение (string)fileName");
            //
            if (fileName.IndexOf(UniExpConst.selectedFilePrefix) != -1)
            {
                result = true;
            }
            else if (fileName.IndexOf(UniExpConst.editableFile) != -1)
            {
                editMode = true;
                result = true;
            }
            return result;
        }

        private int currSelectedIteam(out bool editMode)
        {
            editMode = false;
            int result = -1;
            int idx = -1;
            foreach (object item in lstBoxProjName.Items)
            {
                idx++;
                if (((string)item).IndexOf(UniExpConst.selectedFilePrefix) != -1)
                {
                    result = idx;
                    break;
                }
                else if (((string)item).IndexOf(UniExpConst.editableFile) != -1)
                {
                    editMode = true;
                    result = idx;
                    break;
                }
            }
            return result;
        }

        //private void setColumnSize()
        //{
        //    //dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        //    dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //}

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
        //
        #endregion OtherFunction
        //
    }
}

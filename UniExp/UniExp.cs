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
        protected const string selectedFilePrefix = " > ";
        protected const string editableFile = " * ";
        //private bool _editTable = false;
        //protected bool editTable { get { return _editTable; } set { SetEditTable(value); } }

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
                //dataGridViewCriteria.Enabled = false;
                SetEditTable(false);
                //dataGridViewCriteria.Rows.Add(1);
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

        private void dataGridViewCriteria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //editTable = true;
                //
                SetEditTable(true);
            }
            catch (Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

        private void SetEditTable(bool editMode)
        {
            if (editMode)
            {
                dataGridViewCriteria.Enabled = true;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
            }
            else
            {
                dataGridViewCriteria.Enabled = false;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
            }
            //this._editTable = value;
            if (lstBoxProjName.SelectedIndex >= 0)
                lstBoxProjName.Items[lstBoxProjName.SelectedIndex] =
                    makeFilePrefix(lstBoxProjName.SelectedIndex, editMode);
        }

        private string makeFilePrefix(int index, bool isEditMode = false, bool isSelected = true)
        {
            string result = string.Empty;
            //
            if (index < -1)
                throw new Exception("makeFilePrefix: Ожидалось значение (int)index");
            if(isEditMode && !isSelected)
                throw new Exception("makeFilePrefix: При (bool)isEditMode = true ожидалось значение" +
                    "(bool)isSelected = true");
            //
            if (lstBoxProjName.SelectedIndex > -1)
            {
                bool editMode = false;
                if (isEditMode)
                {
                    if (!isFilePrefix(lstBoxProjName.SelectedItem.ToString(), out editMode))
                    {
                        result = string.Format("{0}{1}", editableFile, lstBoxProjName.Items[index]);
                    }
                    else if (isFilePrefix(lstBoxProjName.SelectedItem.ToString(), out editMode))
                    {
                        if (!editMode)
                            result = ((string)lstBoxProjName.Items[index]).
                                Replace(selectedFilePrefix, editableFile);
                        else
                            result = (string)lstBoxProjName.Items[index];
                    }
                }
                //!isEditMode
                else
                {                    
                    //
                    if (!isFilePrefix(lstBoxProjName.SelectedItem.ToString(), out editMode))
                    {
                        if (isSelected)
                            result = string.Format("{0}{1}", selectedFilePrefix, lstBoxProjName.Items[index]);
                        else
                            result = (string)lstBoxProjName.Items[index];
                    }
                    else if (isFilePrefix(lstBoxProjName.SelectedItem.ToString(), out editMode))
                    {
                        if (isSelected)
                        {
                            if (editMode)
                                result = ((string)lstBoxProjName.Items[index]).
                                    Replace(editableFile, selectedFilePrefix);
                            else
                                result = (string)lstBoxProjName.Items[index];
                        }
                        else
                            result = ((string)lstBoxProjName.Items[index]).Substring(editableFile.Length);
                    }
                }
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
        private void SelectFolder_Click(object sender, EventArgs e)
        {
            try
            {

                //?
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filesNames = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.json");
                    foreach (string fileName in filesNames)
                    {
                        toolStripStatusLabel.Text = Path.GetDirectoryName(fileName);
                        lstBoxProjName.Items.Add(Path.GetFileName(fileName));
                    }
                }
            }
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
        }

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
                            GridViewCriterias gridView = new GridViewCriterias();
                            gridView.Load(dataGridViewCriteria, Path.Combine(toolStripStatusLabel.Text, 
                                lstBoxProjName.SelectedItem.ToString()));
                            if (currSelectedIndex != -1)
                                lstBoxProjName.Items[currSelectedIndex] = getFileName(lstBoxProjName.
                                    Items[currSelectedIndex].ToString());
                            //
                            //lstBoxProjName.Items[lstBoxProjName.SelectedIndex] = selectedFilePrefix +
                            //        lstBoxProjName.SelectedItem;
                            lstBoxProjName.Items[lstBoxProjName.SelectedIndex] = 
                                makeFilePrefix(lstBoxProjName.SelectedIndex);
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
            catch(Exception ex)
            {
                WriteErrInfo(ex.Message);
            }
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
            if (fileName.IndexOf(selectedFilePrefix) != -1)
            {
                result = true;
            }
            else if (fileName.IndexOf(editableFile) != -1)
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
            foreach(object item in lstBoxProjName.Items)
            {
                idx++;
                if (((string)item).IndexOf(selectedFilePrefix) != -1)
                {
                    result = idx;
                    break;
                }
                else if(((string)item).IndexOf(editableFile) != -1)
                {
                    editMode = true;
                    result = idx;
                    break;
                }
            }
            return result;
        }

        private string getFileName(string fileName)
        {
            string result = string.Empty;
            //
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("Ожидалось значение (string)fileName");
            //
            return fileName.Substring(selectedFilePrefix.Length);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filesNames = Directory.GetFiles(Path.GetDirectoryName(openFileDialog.FileName),
                        "*.json");
                    foreach (string fileName in filesNames)
                    {
                        toolStripStatusLabel.Text = Path.GetDirectoryName(fileName);
                        lstBoxProjName.Items.Add(Path.GetFileName(fileName));
                        if (Path.GetFileName(fileName) == Path.GetFileName(openFileDialog.FileName))
                        {
                            lstBoxProjName.SelectedIndex = lstBoxProjName.Items.Count - 1;
                            //lstBoxProjName.Items[lstBoxProjName.Items.Count - 1] =
                            //    makeFilePrefix(lstBoxProjName.Items.Count - 1);
                        }
                    }
                }
                //DialogResult dialogResult = DialogResult.No;
                //if (tabControl.TabPages[0].Text == "Новый документ*" ||
                //        openFileDialog.FileName == openFileDialog.FileName + "*")
                //{
                //    dialogResult = MessageBox.Show("Имеются не сохраненные изменения.\nВы действительно хотите " +
                //        "открыть новый файл?", "Предупреждение", 
                //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //}
                //if (dialogResult == DialogResult.Yes)
                //{
                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    GridViewCriterias gridView = new GridViewCriterias();
                //    gridView.Load(dataGridViewCriteria, openFileDialog.FileName);
                //}
                //}
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

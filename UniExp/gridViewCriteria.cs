using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Drawing;

namespace UniExpGridViewCriteria
{
    /*
     * обработка null значений
     * Проверка на коректность данных из файла и из таблицы
     * Везде трайкетч +
     * метод вывода ошибок +
     * Диалоговый выбр файлов при сохранении и загрузки.+
     */
    //public class gridViewColsCriteria
    //{
    //    public string columnName { get; set; }
    //    public gridViewColsCriteria()
    //    {
    //        this.columnName = string.Empty;
    //    }
    //}

    public class GridViewRoleDelims
    {
        public readonly string criteriaOperateAnd = "&";
        public readonly string criteriaOperateOr = "^";
        public readonly string criteriaOperateDilim = "|";
        public readonly string criteriaDilim = ";#";
        public readonly string criteriaOperateAndR = "И";
        public readonly string criteriaOperateOrR = "ИЛИ";

        public GridViewRoleDelims()
        {

        }
    }

    public class GridViewColumns: GridViewRoleDelims
    {
        public readonly string colCriteriaIndex = "№";
        public readonly string colCriteriaName = "Критерий";
        public readonly string colCriteriaValue = "Значения";
        public readonly string colBtnCriteriaValue = "Конструктор";
        public readonly string colCriteriaOperate = "И/ИЛИ";
        public readonly string colRoleIf = "Если";
        public readonly string colRoleTo = "То";

        public GridViewColumns(): base()
        {

        }
    }

    public class GridViewRowCriteria : GridViewColumns
    {
        //public int criteriaIndex { get; set; }
        public string criteriaName { get; set; }
        public string criteriaValue { get; set; }
        public string criteriaOperate { get; set; }

        public GridViewRowCriteria() : base()
        {
            //this.criteriaIndex = 0;
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
            this.criteriaOperate = string.Empty;
        }
    }

    public class GridViewCriterias
    {
        //public List<gridViewColsCriteria> gridViewColsCriterias { get; set; }
        public List<GridViewRowCriteria> gridViewRowCriteria { get; set; }

        public GridViewCriterias()
        {
            //this.gridViewColsCriterias = new List<gridViewColsCriteria>();
            this.gridViewRowCriteria = new List<GridViewRowCriteria>();
        }

        /*
        public void Save(DataGridView dataGridViewCriteria, string fileName = null)
        {
            if (dataGridViewCriteria == null)
                throw new Exception("gridViewCriterias.Update: Ожидалось значение (DataGridView)dataGridViewCriterias");
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("gridViewCriterias.Update: Ожидалось значение (string)fileName");
            //Рабоатет както странно
            //if(dataGridViewCriteria.Rows.Count <= 1)
            //    throw new Exception(string.Format("Перед сохранением необходимо заполнить таблицу '{0}'", 
            //        "Параметр/Значения"));
            //
            //gridViewColsCriterias.Clear();
            this.gridViewRowCriteria.Clear();
            //
            //foreach (DataGridViewColumn dataGridViewColumn in dataGridViewCriteria.Columns)
            //{
            //    this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = dataGridViewColumn.Name });
            //}
            GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
            {
                if (dataGridViewRow.Index == dataGridViewCriteria.RowCount - 1)
                    break;
                //
                this.gridViewRowCriteria.Add(new GridViewRowCriteria()
                {
                    //criteriaIndex = dataGridViewRow.Index,
                    //dataGridViewRow.Cells.IndexOf(dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName]),
                    criteriaName = dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName].Value == null ?
                        string.Empty : dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName].Value.ToString(),
                    criteriaValue = dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaValue].Value == null ?
                        string.Empty : dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaValue].Value.ToString()
                });
            }
            //сериализация
            File.WriteAllText(fileName, JsonSerializer.Serialize<GridViewCriterias>(this));

        }

        public void Load(DataGridView dataGridViewCriteria, string fileName = null)
        {
            if (dataGridViewCriteria == null)
                throw new Exception("gridViewCriterias.Load: Ожидалось значение (DataGridView)dataGridViewCriterias");
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("gridViewCriterias.Load: Ожидалось значение (string)fileName");
            //
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //gridViewColsCriterias.Clear();
            gridViewRowCriteria.Clear();
            //Возмоно пререработать
            dataGridViewCriteria.Rows.Clear();
            dataGridViewCriteria.Columns.Clear();
            //
            //this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = "Параметр" });
            //this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = "Значение" });
            //this.gridViewRowCriteria.Add(new GridViewRowCriteria() { criteriaName = "Критерий1", criteriaValue = "Знач1" });
            //this.gridViewRowCriteria.Add(new GridViewRowCriteria() { criteriaName = "Критерий2", criteriaValue = "Знач2" });
            //this.gridViewRowCriteria.Add(new GridViewRowCriteria() { criteriaName = "Критерий3", criteriaValue = "Знач3" });
            //дсериализация
            GridViewCriterias gridViewCriterias = JsonSerializer.Deserialize<GridViewCriterias>(File.ReadAllText(fileName));
            gridViewRowCriteria.AddRange(gridViewCriterias.gridViewRowCriteria);
            //
            //foreach (gridViewColsCriteria grViewColsCriteria in gridViewColsCriterias)
            //{
            //    dataGridViewCriteria.Columns.Add(grViewColsCriteria.columnName, grViewColsCriteria.columnName);
            //}
            GridViewRowCriteria gridViewRowCriterias = gridViewRowCriteria.FirstOrDefault();
            if (gridViewRowCriterias != null)
            {
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaIndex, gridViewRowCriterias.colCriteriaIndex);
                dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaIndex].
                DefaultCellStyle.BackColor = Color.FromName("Control");
                //dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaIndex].Width = 10;
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaName, gridViewRowCriterias.colCriteriaName);
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaValue, gridViewRowCriterias.colCriteriaValue);
                dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaValue].
                        DefaultCellStyle.BackColor = Color.FromName("Control");
                //
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Name = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Text = gridViewRowCriterias.colCriteriaValue;
                //buttonColumn.FlatStyle = FlatStyle.Popup;
                //buttonColumn.styl = ;
                //buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridViewCriteria.Columns.Add(buttonColumn);
                //
                //int numRow = 0;
                foreach (GridViewRowCriteria grViewRowCriteria in gridViewRowCriteria)
                {
                    dataGridViewCriteria.Rows.Add(string.Empty, grViewRowCriteria.criteriaName,
                        grViewRowCriteria.criteriaValue);
                }
                //
                dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        */

        public void Clear()
        {
            this.gridViewRowCriteria.Clear();
        }

        public void Add(GridViewRowCriteria gridViewRowCriteria)
        {
            if (gridViewRowCriteria == null)
                throw new Exception("GridViewCriterias.Add: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
            //
            this.gridViewRowCriteria.Add(gridViewRowCriteria);
        }

        public bool checkValues(DataGridView dataGridViewCriteria)
        {
            bool result = false;
            //
            try
            {
                //!!!
                // Проверить уникальные значения в столбце критерий+
                // Доавить ограничение на колво символов+
                // Добавить нумерацию в таблицу
                // Обработка ошибки на клике по столбцу
                if (dataGridViewCriteria == null)
                    throw new Exception("gridViewCriterias.checkValues: Ожидалось значение (DataGridView)dataGridViewCriteria");
                //Рабоатет както странно
                if (dataGridViewCriteria.Rows.Count <= 1)
                    throw new Exception(string.Format("Перед сохранением необходимо заполнить таблицу '{0}'",
                        "Параметр/Значения"));
                //
                GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                List<string> lstCriteriaNames = new List<string>();
                List<string> lstUniqCriteriaNames = new List<string>();
                foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
                {
                    if (dataGridViewRow.Index == dataGridViewCriteria.RowCount - 1)
                        break;
                    //
                    if (dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName].Value == null ||
                        string.IsNullOrEmpty(dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName].Value.ToString()))
                    {
                        throw new ArgumentException(string.Format("Заполните поле: '{0}'",
                            gridViewRowCriterias.colCriteriaName, "Warning"));
                    }
                    if (dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaValue].Value == null ||
                        string.IsNullOrEmpty(dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaValue].Value.ToString()))
                    {
                        throw new ArgumentException(string.Format("Заполните поле: '{0}'",
                            gridViewRowCriterias.colCriteriaValue, "Warning"));
                    }
                    //
                    lstCriteriaNames.Add(dataGridViewRow.Cells[gridViewRowCriterias.colCriteriaName].Value.ToString());
                }
                foreach (string criteriaName in lstCriteriaNames)
                {
                    if (!lstUniqCriteriaNames.Contains(criteriaName))
                    {
                        if (criteriaName.Length > 255)
                            throw new Exception(string.Format("Наименование критерия: '{0}' превышает 255 символов",
                                criteriaName));
                        else
                            lstUniqCriteriaNames.Add(criteriaName);
                    }
                }
                if (lstUniqCriteriaNames.Count != lstCriteriaNames.Count)
                {
                    throw new Exception("В рамках одного проекта не может быть критериев с одинаковым наименованием");
                }
                result = true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                    throw new ArgumentException(ex.Message, "Warning");
                else
                    throw new Exception(ex.Message);
            }
            //
            return result;
        }
    }

    public class GridViewRole : GridViewCriterias
    {
        public string criteriaName { get; set; }
        public string criteriaValue { get; set; }

        public GridViewRole() : base()
        {
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
        }
    }

    public class GridViewRoles
    {
        public List<GridViewRole> gridViewRole { get; set; }

        public GridViewCriterias gridViewCriterias { get; set; }

        public GridViewRoles()
        {
            this.gridViewRole = new List<GridViewRole>();
            this.gridViewCriterias = new GridViewCriterias();
        }

        public void Save(DataGridView dataGridViewCriteria, DataGridView dataGridViewRole, string fileName = null)
        {
            if (dataGridViewCriteria == null)
                throw new Exception("GridViewRoles.Save: Ожидалось значение (DataGridView)dataGridViewCriteria");
            if (dataGridViewRole == null)
                throw new Exception("GridViewRoles.Save: Ожидалось значение (DataGridView)dataGridViewRole");
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("GridViewRoles.Save: Ожидалось значение (string)fileName");
            //
            this.gridViewRole.Clear();
            this.gridViewCriterias.Clear();
            //
            GridViewColumns gridViewColumns = new GridViewColumns();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
            {
                if (dataGridViewRow.Index == dataGridViewCriteria.RowCount - 1)
                    break;
                //
                GridViewRowCriteria gridViewRowCriteria = new GridViewRowCriteria();
                gridViewRowCriteria.criteriaName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value == null ?
                    string.Empty : dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value.ToString();
                gridViewRowCriteria.criteriaValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value == null ?
                        string.Empty : dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value.ToString();
                //
                this.gridViewCriterias.Add(gridViewRowCriteria);
            }
            //            
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRole.Rows)
            {
                if (dataGridViewRow.Index == dataGridViewRole.RowCount - 1)
                    break;
                //
                this.gridViewRole.Add(this.rolePerse(dataGridViewRow.Cells[gridViewColumns.colRoleIf].Value, 
                    dataGridViewRow.Cells[gridViewColumns.colRoleTo].Value));
            }
            //
            //сериализация
            File.WriteAllText(fileName, JsonSerializer.Serialize<GridViewRoles>(this));
        }

        public void Load(DataGridView dataGridViewCriteria, DataGridView dataGridViewRole, string fileName = null)
        {
            if (dataGridViewCriteria == null)
                throw new Exception("GridViewRoles.Load: Ожидалось значение (DataGridView)dataGridViewCriteria");
            if (dataGridViewRole == null)
                throw new Exception("GridViewRoles.Load: Ожидалось значение (DataGridView)dataGridViewRole");
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("GridViewRoles.Load: Ожидалось значение (string)fileName");
            //
            // dataGridViewCriteria
            //
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //
            this.gridViewCriterias.Clear();
            //Возмоно пререработать
            dataGridViewCriteria.Rows.Clear();
            dataGridViewCriteria.Columns.Clear();
            //
            //дсериализация
            GridViewRoles gridViewRoles = JsonSerializer.Deserialize<GridViewRoles>(File.ReadAllText(fileName));
            this.gridViewRowCriteria.AddRange(gridViewCriterias.gridViewRowCriteria);
            //
            //foreach (gridViewColsCriteria grViewColsCriteria in gridViewColsCriterias)
            //{
            //    dataGridViewCriteria.Columns.Add(grViewColsCriteria.columnName, grViewColsCriteria.columnName);
            //}
            GridViewRowCriteria gridViewRowCriterias = gridViewRowCriteria.FirstOrDefault();
            if (gridViewRowCriterias != null)
            {
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaIndex, gridViewRowCriterias.colCriteriaIndex);
                dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaIndex].
                DefaultCellStyle.BackColor = Color.FromName("Control");
                //dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaIndex].Width = 10;
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaName, gridViewRowCriterias.colCriteriaName);
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaValue, gridViewRowCriterias.colCriteriaValue);
                dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaValue].
                        DefaultCellStyle.BackColor = Color.FromName("Control");
                //
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Name = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Text = gridViewRowCriterias.colCriteriaValue;
                //buttonColumn.FlatStyle = FlatStyle.Popup;
                //buttonColumn.styl = ;
                //buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridViewCriteria.Columns.Add(buttonColumn);
                //
                //int numRow = 0;
                foreach (GridViewRowCriteria grViewRowCriteria in gridViewRowCriteria)
                {
                    dataGridViewCriteria.Rows.Add(string.Empty, grViewRowCriteria.criteriaName,
                        grViewRowCriteria.criteriaValue);
                }
                //
                dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        protected GridViewRole rolePerse(object roleIfValue, object roleToValue)
        {
            GridViewRole result = new GridViewRole();
            //
            string roleIf = roleIfValue is string && string.IsNullOrEmpty((string)roleIfValue) ? 
                string.Empty : (string)roleIfValue;
            string roleTo = roleToValue is string && 
                string.IsNullOrEmpty((string)roleToValue) ? string.Empty : (string)roleToValue;
            //
            GridViewRoleDelims gridViewRoleDelims = new GridViewRoleDelims();
            //
            if (!string.IsNullOrEmpty(roleTo))
            {
                string[] rolesTo = roleTo.Split(new string[] { gridViewRoleDelims.criteriaDilim }, 
                    StringSplitOptions.RemoveEmptyEntries);
                if (rolesTo.Length != 2)
                    throw new Exception("GridViewRoles.rolePerse: Ожидалось значение rolesTo.Length == 2");
                result.criteriaName = rolesTo[0];
                result.criteriaValue = rolesTo[1];
            }
            if (!string.IsNullOrEmpty(roleIf))
            {
                string[] rolesIf = roleIf.Split(new string[] { gridViewRoleDelims.criteriaOperateAnd + gridViewRoleDelims.criteriaOperateDilim,
                        gridViewRoleDelims.criteriaOperateOr + gridViewRoleDelims.criteriaOperateDilim }, StringSplitOptions.RemoveEmptyEntries);
                if (rolesIf.Length == 0)
                    throw new Exception("GridViewRoles.rolePerse: Ожидалось значение rolesIf.Length > 0");
                //
                foreach (string rIf in rolesIf)
                {
                    string[] rsIf = roleTo.Split(new string[] { gridViewRoleDelims.criteriaDilim }, StringSplitOptions.RemoveEmptyEntries);
                    if (rsIf.Length != 2)
                        throw new Exception("GridViewRoles.rolePerse: Ожидалось значение rsIf.Length == 2");
                    //
                    GridViewRowCriteria gridViewRowCriteria = new GridViewRowCriteria();
                    gridViewRowCriteria.criteriaName = rsIf[0];
                    if (string.IsNullOrEmpty(rsIf[1]))
                        throw new Exception("GridViewRoles.rolePerse: Ожидалось значение (string)rsIf[1]");
                    //
                    gridViewRowCriteria.criteriaOperate = rsIf[1].Substring(rsIf[1].Length - 1, 1);
                    if (gridViewRowCriteria.criteriaOperate == gridViewRoleDelims.criteriaOperateAnd || 
                        gridViewRowCriteria.criteriaOperate == gridViewRoleDelims.criteriaOperateOr)
                    {
                        gridViewRowCriteria.criteriaOperate = 
                            gridViewRowCriteria.criteriaOperate == gridViewRoleDelims.criteriaOperateAnd ?
                            gridViewRoleDelims.criteriaOperateAndR : gridViewRoleDelims.criteriaOperateOrR;
                        gridViewRowCriteria.criteriaValue = rsIf[1].Length == 1 ? string.Empty :
                            rsIf[1].Substring(0, rsIf[1].Length - 1);
                    }
                    else
                    {
                        gridViewRowCriteria.criteriaValue = rsIf[1];
                        gridViewRowCriteria.criteriaOperate = string.Empty;
                    }
                    //
                    result.Add(gridViewRowCriteria);
                }
            }
            //
            return result;
        }

        public bool checkValues()
        {
            bool result = false;
            //
            try
            {

                result = true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                    throw new ArgumentException(ex.Message, "Warning");
                else
                    throw new Exception(ex.Message);
            }
            //
            return result;
        }
    }

}

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
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace UniExpGridViewCriteria
{
    public class UniExpConst
    {
        public static readonly string selectedFilePrefix = " > ";
        public static readonly string editableFile = " * ";
        public static readonly string projectDir = "Projects";

        public UniExpConst()
        {
            
        }
    }

    public class GridViewDelims
    {
        public readonly string gvOpAnd = "&";
        public readonly string gvOpOr = "^";
        public readonly string gvOpDilim = "|";
        public readonly string gvOpOrWDelim = string.Empty;
        public readonly string gvOpAndWDelim = string.Empty;
        public readonly string gvDilim = ";#";
        public readonly string gvOpAndR = "И";
        public readonly string gvOpOrR = "ИЛИ";


        public GridViewDelims()
        {
            this.gvOpOrWDelim = string.Format("{0}{1}", gvOpDilim, gvOpOr);
            this.gvOpAndWDelim = string.Format("{0}{1}", gvOpDilim, gvOpAnd);
        }
    }

    public class GridViewLimit: GridViewDelims
    {
        // критерий
        public readonly int maxLnCriteriaName = 50;
        // значение
        public readonly int maxLnCriteriaValue = 50;
        // таблица критериев (кол-во критериев)
        public readonly int maxCriteriaRows = 100;
        // таблица значений критерия (кол-во значений для одного критерия)
        public readonly int maxCriteriaValueRows = 5;
        // все значения критерия
        public readonly int maxLnCriteriaValues = 0;
        //
        // таблица правила (кол-во правил)
        public readonly int maxRoleRows = 100;
        // таблица критериев правила (кол-во критериев для одного правила)
        public readonly int maxRoleCriteriaRows = 10;
        // таблица значений правила (кол-во значений для одного правила)
        public readonly int maxRoleValueRows = 1;
        // все критерии правила (таблица критериев правила)
        public readonly int maxLnRoleNames = 0;
        // значение правила (таблица критериев правила, таблица значений правила)
        public readonly int maxLnRoleValue = 0;
        //

        public GridViewLimit(): base()
        {
            this.maxLnCriteriaValues = (this.maxCriteriaValueRows * this.maxLnCriteriaValue) +
                (base.gvDilim.Length * (this.maxCriteriaValueRows - 1));
            //
            int lnRoleValue = this.maxLnCriteriaName + base.gvDilim.Length + this.maxLnCriteriaValue;
            this.maxLnRoleValue = lnRoleValue * this.maxRoleValueRows;
            this.maxLnRoleNames = (lnRoleValue * this.maxRoleCriteriaRows) +
                (Math.Max(base.gvOpOrWDelim.Length, base.gvOpAndWDelim.Length) * (this.maxRoleCriteriaRows - 1));
        }
    }

    public class GridViewColumns
    {
        public readonly string colIndex = "№";
        public readonly string colCriteriaName = "Критерий";
        public readonly string colCriteriaValue = "Значение";
        public readonly string colBtnValue = "Конструктор";
        public readonly string colRoleOperate = "И/ИЛИ";
        public readonly string colRoleName = "Если";
        public readonly string colRoleValue = "То";

        public GridViewColumns()
        {

        }
    }

    public class GridViewRowCriteria : GridViewColumns
    {
        public string criteriaName { get; set; }
        public string criteriaValue { get; set; }
        public string criteriaOperate { get; set; }

        public GridViewRowCriteria() : base()
        {
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
            this.criteriaOperate = string.Empty;
        }

        public static string[] GetSplitValue(string fmtCriteriaValue)
        {
            string[] result = new string[] { };
            //
            if (!string.IsNullOrEmpty(fmtCriteriaValue))
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                result = fmtCriteriaValue.Split(new string[] { gridViewDelims.gvDilim },
                    StringSplitOptions.RemoveEmptyEntries);
            }
            //
            return result;
        }

        public static string GetBuildValue(List<string> criteriaValues)
        {
            string result = string.Empty;
            //
            if (criteriaValues != null && criteriaValues.Count > 0)
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                result = string.Join(gridViewDelims.gvDilim, criteriaValues);
            }
            //
            return result;
        }
    }

    public class GridViewCriterias
    {
        //public List<GridViewRowCriteria> gridViewRowCriterias { get; set; }

        public GridViewCriterias()
        {
            //this.gridViewRowCriterias = new List<GridViewRowCriteria>();
        }

        //public GridViewCriterias Add(List<GridViewRowCriteria> gridViewRowCriterias)
        //{
        //    if (gridViewRowCriterias == null)
        //        throw new Exception("GridViewCriterias.Add: Ожидалось значение (GridViewCriterias)gridViewRowCriterias");
        //    //
        //    this.gridViewRowCriterias.Clear();
        //    this.gridViewRowCriterias.AddRange(gridViewRowCriterias);
        //    //
        //    return this;
        //}

        /* удалить после отладки
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

        //public void Clear()
        //{
        //    this.gridViewRowCriterias.Clear();
        //}

        //public void Add(GridViewRowCriteria gridViewRowCriteria)
        //{
        //    if (gridViewRowCriteria == null)
        //        throw new Exception("GridViewCriterias.Add: Ожидалось значение (GridViewRowCriteria)gridViewRowCriteria");
        //    //
        //    this.gridViewRowCriteria.Add(gridViewRowCriteria);
        //}

        //public void Add(GridViewCriterias gridViewCriterias)
        //{
        //    if (gridViewCriterias == null)
        //        throw new Exception("GridViewCriterias.Add: Ожидалось значение (GridViewCriterias)gridViewCriterias");
        //    //
        //    this.gridViewRowCriterias.AddRange(gridViewCriterias.gridViewRowCriterias);
        //}

        //public List<GridViewRowCriteria> Get()
        //{
        //    return this.gridViewRowCriterias;
        //}

        public static bool checkValues(DataGridView dataGridViewCriteria,
            out List<GridViewRowCriteria> gridViewRowCriterias)
        {
            gridViewRowCriterias = new List<GridViewRowCriteria>();
            bool result = false;
            //
            try
            {
                if (dataGridViewCriteria == null)
                    throw new Exception("gridViewCriterias.checkValues: Ожидалось значение (DataGridView)dataGridViewCriteria");
                //
                GridViewLimit gridViewLimit = new GridViewLimit();
                GridViewColumns gridViewColumns = new GridViewColumns();
                if (dataGridViewCriteria.Rows.Count <= 1)
                    throw new ArgumentException(string.Format("Перед сохранением необходимо заполнить таблицу '{0}'",
                        string.Format("{0}/{1}", gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaValue)),
                        "Warning");
                if (dataGridViewCriteria.Rows.Count > gridViewLimit.maxCriteriaRows)
                    throw new ArgumentException(string.Format("В таблице '{0}' должно быть записей не более {1}",
                        string.Format("{0}/{1}", gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaValue),
                        gridViewLimit.maxCriteriaRows), "Warning");
                //
                //GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
                List<string> lstCriteriaNames = new List<string>();
                List<string> lstUniqCriteriaNames = new List<string>();
                List<string> lstUniqCriteriaValues = new List<string>();
                string crName = string.Empty;
                string crValue = string.Empty;
                foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
                {
                    if (dataGridViewRow.Index == dataGridViewCriteria.RowCount - 1)
                        break;
                    //
                    if (dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value == null ||
                        string.IsNullOrEmpty(crName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value.ToString()))
                        throw new ArgumentException(string.Format("Заполните поле: '{0}' для строки {1}",
                            gridViewColumns.colCriteriaName, dataGridViewRow.Index + 1), "Warning");
                    if (crName.Length > gridViewLimit.maxLnCriteriaName)
                        throw new ArgumentException(string.Format("Наименование критерия: '{0}' превышает {1} символов для строки {2}",
                            crName, gridViewLimit.maxLnCriteriaName, dataGridViewRow.Index + 1), "Warning");
                    if (dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value == null ||
                        string.IsNullOrEmpty(crValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value.ToString()))
                        throw new ArgumentException(string.Format("Заполните поле: '{0}' для строки {1}",
                            gridViewColumns.colCriteriaValue, dataGridViewRow.Index + 1), "Warning");
                    if (crValue.Length > gridViewLimit.maxLnCriteriaValues)
                        throw new ArgumentException(string.Format("Значение для критерия: '{0}' превышает {1} символов для строки {2}",
                            crName, gridViewLimit.maxLnCriteriaValues, dataGridViewRow.Index + 1), "Warning");
                    //
                    gridViewRowCriterias.Add(new GridViewRowCriteria() {
                        criteriaName = crName,
                        criteriaValue = crValue
                    });
                    //
                    if (!lstUniqCriteriaValues.Contains(crValue))
                        lstUniqCriteriaValues.Add(crValue);
                    //
                    lstCriteriaNames.Add(crName);
                    //
                }
                foreach (string criteriaName in lstCriteriaNames)
                {
                    if (!lstUniqCriteriaNames.Contains(criteriaName))
                        lstUniqCriteriaNames.Add(criteriaName);
                }
                if (lstCriteriaNames.Count != lstUniqCriteriaNames.Count)
                {
                    gridViewRowCriterias.Clear();
                    throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинакового наименования для '{0}'",
                        gridViewColumns.colCriteriaName), "Warning");
                }
                if (lstCriteriaNames.Count != lstUniqCriteriaValues.Count)
                {
                    gridViewRowCriterias.Clear();
                    throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинакового '{0}' для разных '{1}'",
                        gridViewColumns.colCriteriaValue, gridViewColumns.colCriteriaName), "Warning");
                }
                //
                result = true;
            }
            //catch (Exception ex)
            catch
            {
                //if (ex.GetType() == typeof(ArgumentException))
                //    throw new ArgumentException(ex.Message, "Warning");
                //else
                //    throw new Exception(ex.Message);
                throw;
            }
            //
            return result;
        }

        //public static List<string> getCriterias(DataGridView dataGridViewCriteria)
        //{
        //    List<string> result = new List<string>();
        //    try
        //    {
        //        if (dataGridViewCriteria == null)
        //            throw new Exception("gridViewCriterias.getCriterias: Ожидалось значение (DataGridView)dataGridViewCriteria");
        //        //
        //        GridViewColumns gridViewColumns = new GridViewColumns();
        //        object criteraObjName = null;
        //        string criteraName = string.Empty;
        //        foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
        //        {
        //            if (dataGridViewRow.Index == dataGridViewCriteria.Rows.Count - 1)
        //                break;
        //            //
        //            criteraObjName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value;
        //            criteraName = criteraObjName == null ? string.Empty : criteraObjName.ToString();
        //            //
        //            if(string.IsNullOrEmpty(criteraName))
        //                throw new ArgumentException(string.Format("В рамках проекта должно быть указанно наименование {0}",
        //                    gridViewColumns.colCriteriaName), "Warning");
        //            if(result.Contains(criteraName))
        //                throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинаковых наименований для {0}",
        //                gridViewColumns.colCriteriaName), "Warning");
        //            //
        //            result.Add(criteraName);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return result;
        //}

        //public static List<string> getCriteriaValues(DataGridView dataGridViewCriteria, string searhCriteriaName)
        //{
        //    List<string> result = new List<string>();
        //    try
        //    {
        //        if (dataGridViewCriteria == null)
        //            throw new Exception("gridViewCriterias.getCriteriaValues: Ожидалось значение (DataGridView)dataGridViewCriteria");
        //        if(string.IsNullOrEmpty(searhCriteriaName))
        //            throw new Exception("gridViewCriterias.getCriteriaValues: Ожидалось значение (string)searhCriteriaName");
        //        //
        //        GridViewColumns gridViewColumns = new GridViewColumns();
        //        object criteraObjName = null;
        //        string criteraName = string.Empty;
        //        object criteraObjValue = null;
        //        string criteraFmtValue = string.Empty;
        //        List<string> unqCriteriaNames = new List<string>();
        //        List<string> unqCriteriaValues = new List<string>();
        //        //
        //        foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
        //        {
        //            if (dataGridViewRow.Index == dataGridViewCriteria.Rows.Count - 1)
        //                break;
        //            //
        //            criteraObjName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value;
        //            criteraName = criteraObjName == null ? string.Empty : criteraObjName.ToString();
        //            //
        //            if (string.IsNullOrEmpty(criteraName))
        //                throw new ArgumentException(string.Format("В рамках проекта должно быть указанно наименование {0}",
        //                    gridViewColumns.colCriteriaName), "Warning");
        //            if (unqCriteriaNames.Contains(criteraName))
        //                throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинаковых наименований для {0}",
        //                gridViewColumns.colCriteriaName), "Warning");
        //            else
        //                unqCriteriaNames.Add(criteraName);
        //            //
        //            if (criteraName == searhCriteriaName)
        //            {
        //                criteraObjValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value;
        //                criteraFmtValue = criteraObjValue == null ? string.Empty : criteraObjValue.ToString();
        //                string[] criteraValues = GridViewRowCriteria.GetSplitValue(criteraFmtValue);
        //                if(criteraValues.Length == 0)
        //                    throw new ArgumentException(string.Format("Для {0} '{1}' должно быть указано {2}",
        //                        gridViewColumns.colCriteriaName, searhCriteriaName, 
        //                        gridViewColumns.colCriteriaValue), "Warning");
        //                //
        //                foreach (string criteriaValue in criteraValues)
        //                {
        //                    if (!unqCriteriaValues.Contains(criteriaValue))
        //                        unqCriteriaValues.Add(criteriaValue);
        //                }
        //                //
        //                if (unqCriteriaValues.Count != criteraValues.Length)
        //                    throw new ArgumentException(string.Format("В рамках одного проекта для {0} '{1}' " +
        //                        "не может быть дублирующихся значений", gridViewColumns.colCriteriaName, searhCriteriaName), "Warning");
        //                //
        //                result.AddRange(unqCriteriaValues);
        //                //
        //                break;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return result;
        //}
    }

    public class GridViewRowRole
    {
        public string roleName { get; set; }
        public string roleValue { get; set; }

        public GridViewRowRole(): base()
        {
            this.roleName = string.Empty;
            this.roleValue = string.Empty;
        }

        public static List<GridViewRowCriteria> GetSplitName(string fmtRoleName)
        {
            List<GridViewRowCriteria> result = new List<GridViewRowCriteria>();
            //
            if (!string.IsNullOrEmpty(fmtRoleName))
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                string[] rolesIf = fmtRoleName.Split(new string[] { gridViewDelims.gvOpDilim }, 
                    StringSplitOptions.RemoveEmptyEntries);
                if (rolesIf.Length > 0)
                {
                    //
                    foreach (string roleIf in rolesIf)
                    {
                        string[] crIf = roleIf.Split(new string[] { gridViewDelims.gvDilim }, 
                            StringSplitOptions.RemoveEmptyEntries);
                        if (crIf.Length == 2)
                        {
                            GridViewRowCriteria gridViewRowCriteria = new GridViewRowCriteria();
                            gridViewRowCriteria.criteriaValue = crIf[1];
                            gridViewRowCriteria.criteriaOperate = crIf[0].Substring(0, 1);
                            if (gridViewRowCriteria.criteriaOperate == gridViewDelims.gvOpAnd ||
                                gridViewRowCriteria.criteriaOperate == gridViewDelims.gvOpOr)
                            {
                                gridViewRowCriteria.criteriaOperate =
                                    gridViewRowCriteria.criteriaOperate == gridViewDelims.gvOpAnd ?
                                    gridViewDelims.gvOpAndR : gridViewDelims.gvOpOrR;
                                gridViewRowCriteria.criteriaName = crIf[0].Length == 1 ? string.Empty :
                                    crIf[0].Substring(1);
                            }
                            else
                            {                                
                                gridViewRowCriteria.criteriaOperate = string.Empty;
                                gridViewRowCriteria.criteriaName = crIf[0];
                            }
                            //
                            if (!string.IsNullOrEmpty(gridViewRowCriteria.criteriaName))
                                result.Add(gridViewRowCriteria);
                        }
                    }
                }
            }
            //
            return result;
        }

        public static string GetBuildName(List<GridViewRowCriteria> gridViewRowCriterias)
        {
            string result = string.Empty;
            //
            if (gridViewRowCriterias != null)
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                foreach (GridViewRowCriteria gridViewRowCriteria in gridViewRowCriterias)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result += GridViewRowRole.GetBuildValue(gridViewRowCriteria);
                    }
                    else
                    {
                        result += ((gridViewRowCriteria.criteriaOperate == gridViewDelims.gvOpAndR ? gridViewDelims.gvOpAndWDelim :
                            gridViewRowCriteria.criteriaOperate == gridViewDelims.gvOpOrR ? gridViewDelims.gvOpOrWDelim :
                            string.Empty) + GridViewRowRole.GetBuildValue(gridViewRowCriteria));
                    }
                }
            }
            //
            return result;
        }

        public static GridViewRowCriteria GetSplitValue(string fmtRoleValue)
        {
            GridViewRowCriteria result = new GridViewRowCriteria();
            //
            if (!string.IsNullOrEmpty(fmtRoleValue))
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                string[] roleNameItems = GridViewRowCriteria.GetSplitValue(fmtRoleValue);
                if (roleNameItems.Length == 2 && roleNameItems[1].IndexOf(gridViewDelims.gvDilim) == -1)
                {
                    result.criteriaName = roleNameItems[0];
                    result.criteriaValue = roleNameItems[1];
                }
            }
            //
            return result;
        }

        public static string GetBuildValue(GridViewRowCriteria gridViewRowCriteria)
        {
            string result = string.Empty;
            //
            if (gridViewRowCriteria != null)
            {
                GridViewDelims gridViewDelims = new GridViewDelims();
                if (string.IsNullOrEmpty(gridViewRowCriteria.criteriaName))
                    throw new Exception("GridViewRowRole.GetBuildValue: Ожидалось значение (string)gridViewRowCriteria.name");
                if (string.IsNullOrEmpty(gridViewRowCriteria.criteriaValue))
                    throw new Exception("GridViewRowRole.GetBuildValue: Ожидалось значение (string)gridViewRowCriteria.value");
                if (gridViewRowCriteria.criteriaValue.IndexOf(gridViewDelims.gvDilim) != -1)
                    throw new Exception("GridViewRowRole.GetBuildValue: Ожидалось корректное значение (string)gridViewRowCriteria.value");
                //
                result = GridViewRowCriteria.GetBuildValue(new List<string>()
                {
                    gridViewRowCriteria.criteriaName,
                    gridViewRowCriteria.criteriaValue
                });
            }
            //
            return result;
        }

    }

    public class GridViewRoles
    {
        public List<GridViewRowRole> gridViewRowRoles { get; set; }
        public List<GridViewRowCriteria> gridViewRowCriterias { get; set; }

        public GridViewRoles()
        {
            this.gridViewRowRoles = new List<GridViewRowRole>();
            this.gridViewRowCriterias = new List<GridViewRowCriteria>();
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
            this.DataInit();
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
                this.gridViewRowCriterias.Add(gridViewRowCriteria);
            }
            //            
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRole.Rows)
            {
                if (dataGridViewRow.Index == dataGridViewRole.RowCount - 1)
                    break;
                //
                //this.gridViewRoles.Add(this.rolePerse(dataGridViewRow.Cells[gridViewColumns.colRoleName].Value, 
                //    dataGridViewRow.Cells[gridViewColumns.colRoleValue].Value));
                GridViewRowRole gridViewRowRole = new GridViewRowRole();
                gridViewRowRole.roleName = dataGridViewRow.Cells[gridViewColumns.colRoleName].Value == null ?
                    string.Empty : dataGridViewRow.Cells[gridViewColumns.colRoleName].Value.ToString();
                gridViewRowRole.roleValue = dataGridViewRow.Cells[gridViewColumns.colRoleValue].Value == null ?
                        string.Empty : dataGridViewRow.Cells[gridViewColumns.colRoleValue].Value.ToString();
                this.gridViewRowRoles.Add(gridViewRowRole);
            }
            //
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            //сериализация
            File.WriteAllText(fileName, JsonSerializer.Serialize<GridViewRoles>(this, options));
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
            this.DataInit(dataGridViewCriteria, dataGridViewRole);
            //
            //дсериализация
            GridViewRoles gridViewRoles = JsonSerializer.Deserialize<GridViewRoles>(File.ReadAllText(fileName));
            this.gridViewRowCriterias.AddRange(gridViewRoles.gridViewRowCriterias);
            this.gridViewRowRoles.AddRange(gridViewRoles.gridViewRowRoles);
            //
            GridViewColumns gridViewColumns = new GridViewColumns();
            //
            // dataGridViewCriteria
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //
            // dataGridViewCriteria add columns
            dataGridViewCriteria.Columns.Add(gridViewColumns.colIndex, gridViewColumns.colIndex);
            dataGridViewCriteria.Columns[gridViewColumns.colIndex].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            dataGridViewCriteria.Columns.Add(gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaName);
            dataGridViewCriteria.Columns.Add(gridViewColumns.colCriteriaValue, gridViewColumns.colCriteriaValue);
            dataGridViewCriteria.Columns[gridViewColumns.colCriteriaValue].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            //
            DataGridViewButtonColumn btnColCriteriaValue = new DataGridViewButtonColumn();
            btnColCriteriaValue.HeaderText = gridViewColumns.colBtnValue;
            btnColCriteriaValue.Name = gridViewColumns.colBtnValue;
            btnColCriteriaValue.Text = gridViewColumns.colCriteriaValue;
            btnColCriteriaValue.UseColumnTextForButtonValue = true;
            dataGridViewCriteria.Columns.Add(btnColCriteriaValue);
            //
            // dataGridViewCriteria add rows
            foreach (GridViewRowCriteria gridViewRowCriteria in this.gridViewRowCriterias)
            {
                dataGridViewCriteria.Rows.Add(string.Empty, gridViewRowCriteria.criteriaName,
                    gridViewRowCriteria.criteriaValue);
            }
            //
            dataGridViewCriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //
            // dataGridViewRole
            dataGridViewRole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //
            // dataGridViewRole add columns
            dataGridViewRole.Columns.Add(gridViewColumns.colIndex, gridViewColumns.colIndex);
            dataGridViewRole.Columns[gridViewColumns.colIndex].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            dataGridViewRole.Columns.Add(gridViewColumns.colRoleName, gridViewColumns.colRoleName);
            dataGridViewRole.Columns[gridViewColumns.colRoleName].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            dataGridViewRole.Columns.Add(gridViewColumns.colRoleValue, gridViewColumns.colRoleValue);
            dataGridViewRole.Columns[gridViewColumns.colRoleValue].
                DefaultCellStyle.BackColor = Color.FromName("Control");
            //
            DataGridViewButtonColumn btnColRoleValue = new DataGridViewButtonColumn();
            btnColRoleValue.HeaderText = gridViewColumns.colBtnValue;
            btnColRoleValue.Name = gridViewColumns.colBtnValue;
            btnColRoleValue.Text = gridViewColumns.colCriteriaValue;
            btnColRoleValue.UseColumnTextForButtonValue = true;
            dataGridViewRole.Columns.Add(btnColRoleValue);
            //
            // dataGridViewCriteria add rows
            foreach (GridViewRowRole gridViewRowRole in this.gridViewRowRoles)
            {
                dataGridViewRole.Rows.Add(string.Empty, gridViewRowRole.roleName,
                    gridViewRowRole.roleValue);
            }
            //
            dataGridViewRole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected void DataInit(DataGridView dataGridViewCriteria = null, DataGridView dataGridViewRole = null)
        {
            this.gridViewRowRoles.Clear();
            this.gridViewRowCriterias.Clear();
            //
            if (dataGridViewCriteria != null)
            {
                dataGridViewCriteria.Rows.Clear();
                dataGridViewCriteria.Columns.Clear();
            }
            //
            if (dataGridViewRole != null)
            {
                dataGridViewRole.Rows.Clear();
                dataGridViewRole.Columns.Clear();
            }
        }

        public bool checkRole(List<GridViewRowCriteria> gridViewRowCriterias, 
            string roleName, string roleValue, int numRow)
        {
            bool result = false;
            //
            try
            {
                if (gridViewRowCriterias == null)
                    throw new Exception("GridViewRoles.checkRole: Ожидалось значение (List<GridViewRowCriteria>)gridViewRowCriterias");
                if (string.IsNullOrEmpty(roleName))
                    throw new Exception("GridViewRoles.checkRole: Ожидалось значение (string)roleName");
                if (string.IsNullOrEmpty(roleValue))
                    throw new Exception("GridViewRoles.checkRole: Ожидалось значение (string)roleValue");
                if (numRow < 1)
                    throw new Exception("GridViewRoles.checkRole: Ожидалось значение (int)numRow");
                //
                GridViewColumns gridViewColumns = new GridViewColumns();
                //
                GridViewRowCriteria gridViewRCriteriaRoleValue = GridViewRowRole.GetSplitValue(roleValue);
                List<GridViewRowCriteria> gridViewRCriteriasRole = GridViewRowRole.GetSplitName(roleName);
                // критерии правила и значение правила пересекаются
                if (gridViewRCriteriasRole.FirstOrDefault(cr => cr.criteriaName == gridViewRCriteriaRoleValue.criteriaName &&
                    cr.criteriaValue == gridViewRCriteriaRoleValue.criteriaValue) != null)
                    throw new ArgumentException(string.Format("'{0}' пересекается с '{1}' для строки {2}",
                        gridViewColumns.colRoleValue, gridViewColumns.colRoleName, numRow),
                        "Warning");
                //
                //gridViewRCriteriasRole.Add(gridViewRCriteriaRoleValue);
                GridViewRowCriteria gridViewRCriteria = gridViewRowCriterias.FirstOrDefault(cr =>
                        cr.criteriaName == gridViewRCriteriaRoleValue.criteriaName);
                // в критериях нет критерия значения правила
                if (gridViewRCriteria == null)
                    throw new ArgumentException(string.Format("'{0}' для строки {1} не существует '{2}'",
                        gridViewColumns.colRoleValue, numRow, gridViewColumns.colCriteriaName),
                        "Warning");
                else
                {
                    // в значениях критерия нет значения правила
                    List<string> criteriaValues = GridViewRowCriteria.GetSplitValue(gridViewRCriteria.criteriaValue).ToList();
                    if (!criteriaValues.Contains(gridViewRCriteriaRoleValue.criteriaValue))
                        throw new ArgumentException(string.Format("'{0}' для строки {1} не существует '{2}'",
                            gridViewColumns.colRoleValue, numRow, gridViewColumns.colCriteriaValue),
                            "Warning");
                }
                //
                List<GridViewRowCriteria> uniqGridViewRCriteriasRole = new List<GridViewRowCriteria>();                
                foreach (GridViewRowCriteria gvRCriteriaRole in gridViewRCriteriasRole)
                {
                    gridViewRCriteria = gridViewRowCriterias.FirstOrDefault(cr =>
                        cr.criteriaName == gvRCriteriaRole.criteriaName);
                    // в критериях нет критерия правила
                    if (gridViewRCriteria == null)
                        throw new ArgumentException(string.Format("'{0}' для строки {1} не существует '{2}'",
                            gridViewColumns.colRoleName, numRow, gridViewColumns.colCriteriaName),
                            "Warning");
                    else
                    {
                        // в значениях критерия нет значения правила
                        List<string> criteriaValues = GridViewRowCriteria.GetSplitValue(gridViewRCriteria.criteriaValue).ToList();
                        if (!criteriaValues.Contains(gvRCriteriaRole.criteriaValue))
                            throw new ArgumentException(string.Format("'{0}' для строки {1} не существует '{2}'",
                                gridViewColumns.colRoleName, numRow, gridViewColumns.colCriteriaValue),
                                "Warning");
                    }
                    if (uniqGridViewRCriteriasRole.FirstOrDefault(ucr => ucr.criteriaName == gvRCriteriaRole.criteriaName &&
                        ucr.criteriaValue == gvRCriteriaRole.criteriaValue) == null)
                        uniqGridViewRCriteriasRole.Add(gvRCriteriaRole);
                }
                // в критерии правила есть одинаковые правила (критерий - значение)
                if (uniqGridViewRCriteriasRole.Count != gridViewRCriteriasRole.Count)
                    throw new ArgumentException(string.Format("'{0}' пересекается друг с другом для строки {1}",
                        gridViewColumns.colRoleName, numRow),
                        "Warning");
                //
                result = true;
            }
            //catch (Exception ex)
            catch
            {
                //if (ex.GetType() == typeof(ArgumentException))
                //    throw new ArgumentException(ex.Message, "Warning");
                //else
                //    throw new Exception(ex.Message);
                throw;
            }
            //
            return result;
        }

        public bool checkValues(DataGridView dataGridViewCriteria, DataGridView dataGridViewRole)
        {
            bool result = false;
            //
            try
            {
                List<GridViewRowCriteria> gridViewRowCriterias = new List<GridViewRowCriteria>();
                if (GridViewCriterias.checkValues(dataGridViewCriteria, out gridViewRowCriterias))
                {
                    if (dataGridViewRole == null)
                        throw new Exception("GridViewRoles.checkValues: Ожидалось значение (DataGridView)dataGridViewRole");
                    //
                    GridViewLimit gridViewLimit = new GridViewLimit();
                    GridViewColumns gridViewColumns = new GridViewColumns();
                    if (dataGridViewRole.Rows.Count <= 1)
                        throw new ArgumentException(string.Format("Перед сохранением необходимо заполнить таблицу '{0}'",
                            string.Format("{0}/{1}", gridViewColumns.colRoleName, gridViewColumns.colRoleValue)),
                            "Warning");
                    if (dataGridViewRole.Rows.Count > gridViewLimit.maxRoleRows)
                        throw new ArgumentException(string.Format("В таблице '{0}' должно быть записей не более {1}",
                            string.Format("{0}/{1}", gridViewColumns.colRoleName, gridViewColumns.colRoleValue),
                            gridViewLimit.maxRoleRows), "Warning");
                    //
                    List<string> lstRoleNames = new List<string>();
                    List<string> lstUniqRoleNames = new List<string>();
                    List<string> lstUniqRoleValue = new List<string>();
                    string rName = string.Empty;
                    string rValue = string.Empty;
                    foreach (DataGridViewRow dataGridViewRow in dataGridViewRole.Rows)
                    {
                        if (dataGridViewRow.Index == dataGridViewRole.RowCount - 1)
                            break;
                        //
                        if (dataGridViewRow.Cells[gridViewColumns.colRoleName].Value == null ||
                            string.IsNullOrEmpty(rName = dataGridViewRow.Cells[gridViewColumns.colRoleName].Value.ToString()))
                            throw new ArgumentException(string.Format("Заполните поле: '{0}' для строки {1}",
                                gridViewColumns.colRoleName, dataGridViewRow.Index + 1), "Warning");
                        if (rName.Length > gridViewLimit.maxLnRoleNames)
                            throw new ArgumentException(string.Format("'{0}' для строки {1} превышает {2} символов",
                                gridViewColumns.colRoleName, dataGridViewRow.Index + 1, gridViewLimit.maxLnRoleNames),
                                "Warning");
                        if (dataGridViewRow.Cells[gridViewColumns.colRoleValue].Value == null ||
                            string.IsNullOrEmpty(rValue = dataGridViewRow.Cells[gridViewColumns.colRoleValue].Value.ToString()))
                            throw new ArgumentException(string.Format("Заполните поле: '{0}' для строки {1}",
                                gridViewColumns.colRoleValue, dataGridViewRow.Index + 1), "Warning");
                        if (rValue.Length > gridViewLimit.maxLnRoleValue)
                            throw new ArgumentException(string.Format("'{0}' для строки {1} превышает {2} символов",
                                gridViewColumns.colRoleValue, dataGridViewRow.Index + 1, gridViewLimit.maxLnRoleValue),
                                "Warning");
                        //
                        this.checkRole(gridViewRowCriterias, rName, rValue, dataGridViewRow.Index + 1);
                        //
                        if (!lstUniqRoleValue.Contains(rValue))
                            lstUniqRoleValue.Add(rValue);
                        //
                        lstRoleNames.Add(rName);                        
                    }
                    foreach (string roleName in lstRoleNames)
                    {
                        if (!lstUniqRoleNames.Contains(roleName))
                            lstUniqRoleNames.Add(roleName);
                    }
                    if (lstRoleNames.Count != lstUniqRoleNames.Count)
                        throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинаковых '{0}'",
                            gridViewColumns.colRoleName), "Warning");
                    if (lstRoleNames.Count != lstUniqRoleValue.Count)
                        throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинаковых '{0}' для разных '{1}'",
                            gridViewColumns.colRoleValue, gridViewColumns.colRoleName), "Warning");
                    result = true;
                }
            }
            //catch (Exception ex)
            catch
            {
                //if (ex.GetType() == typeof(ArgumentException))
                //    throw new ArgumentException(ex.Message, "Warning");
                //else
                //    throw new Exception(ex.Message);
                throw;
            }
            //
            return result;
        }

        public static List<GridViewRowCriteria> getCriterias(DataGridView dataGridViewCriteria)
        {
            List<GridViewRowCriteria> result = new List<GridViewRowCriteria>();
            try
            {
                if (dataGridViewCriteria == null)
                    throw new Exception("GridViewRoles.getCriterias: Ожидалось значение (DataGridView)dataGridViewCriteria");
                //
                GridViewColumns gridViewColumns = new GridViewColumns();
                object criteraObjName = null;
                string criteraName = string.Empty;
                object criteraObjValue = null;
                string criteraFmtValue = string.Empty;
                List<string> unqCriteraValues = new List<string>();
                //
                foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
                {
                    if (dataGridViewRow.Index == dataGridViewCriteria.Rows.Count - 1)
                        break;
                    //
                    criteraObjName = dataGridViewRow.Cells[gridViewColumns.colCriteriaName].Value;
                    criteraName = criteraObjName == null ? string.Empty : criteraObjName.ToString();
                    //
                    criteraObjValue = dataGridViewRow.Cells[gridViewColumns.colCriteriaValue].Value;
                    criteraFmtValue = criteraObjValue == null ? string.Empty : criteraObjValue.ToString();
                    //
                    if (string.IsNullOrEmpty(criteraName))
                        throw new ArgumentException(string.Format("В таблице {0}/{1} строка {2} не указано '{3}'",
                            gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaValue, dataGridViewRow.Index + 1,
                            gridViewColumns.colCriteriaName), "Warning");
                    if (string.IsNullOrEmpty(criteraFmtValue))
                        throw new ArgumentException(string.Format("В таблице {0}/{1} строка {2} не указано '{3}'",
                            gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaValue, dataGridViewRow.Index + 1,
                            gridViewColumns.colCriteriaValue), "Warning");
                    if (result.FirstOrDefault(cr => cr.criteriaName == criteraName) != null)
                        throw new ArgumentException(string.Format("В рамках одного проекта не может быть одинаковых наименований для '{0}'",
                        gridViewColumns.colCriteriaName), "Warning");
                    //
                    string[] criteraValues = GridViewRowCriteria.GetSplitValue(criteraFmtValue);
                    unqCriteraValues.Clear();
                    foreach (string criteraValue in criteraValues)
                    {
                        if (!unqCriteraValues.Contains(criteraValue))
                            unqCriteraValues.Add(criteraValue);
                    }
                    if (unqCriteraValues.Count != criteraValues.Length)
                        throw new ArgumentException(string.Format("В таблице {0}/{1} строка {2} указаны одинаковые значения для {3}",
                            gridViewColumns.colCriteriaName, gridViewColumns.colCriteriaValue, dataGridViewRow.Index + 1,
                            gridViewColumns.colCriteriaName), "Warning");
                    //
                    result.Add(new GridViewRowCriteria()
                    {
                        criteriaOperate = string.Empty,
                        criteriaName = criteraName,
                        criteriaValue = criteraFmtValue
                    });
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

    }
}

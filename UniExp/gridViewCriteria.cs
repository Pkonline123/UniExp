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

    public class GridViewColumnsCriteria
    {
        public readonly string colCriteriaName = "Критерий";
        public readonly string colCriteriaValue = "Значения";
        public readonly string colBtnCriteriaValue = "Конструктор";

        public GridViewColumnsCriteria()
        {
           
        }
    }
    public class GridViewRowCriteria : GridViewColumnsCriteria
    {
        public string criteriaName { get; set; }
        public string criteriaValue { get; set; }

        public GridViewRowCriteria()
        {
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
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
                this.gridViewRowCriteria.Add(new GridViewRowCriteria()
                {
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
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaName, gridViewRowCriterias.colCriteriaName);
                dataGridViewCriteria.Columns.Add(gridViewRowCriterias.colCriteriaValue, gridViewRowCriterias.colCriteriaValue);
                dataGridViewCriteria.Columns[gridViewRowCriterias.colCriteriaValue].
                        DefaultCellStyle.BackColor = Color.FromName("Control");
                //
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Name = gridViewRowCriterias.colBtnCriteriaValue;
                buttonColumn.Text = gridViewRowCriterias.colCriteriaValue;
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridViewCriteria.Columns.Add(buttonColumn);

                foreach (GridViewRowCriteria grViewRowCriteria in gridViewRowCriteria)
                {
                    dataGridViewCriteria.Rows.Add(grViewRowCriteria.criteriaName, grViewRowCriteria.criteriaValue);
                }
            }
        }

        public bool chekValues(DataGridView dataGridViewCriteria)
        {
            bool result = false;
            //
            try
            {
                if (dataGridViewCriteria == null)
                    throw new Exception("gridViewCriterias.chekValues: Ожидалось значение (DataGridView)dataGridViewCriterias");
                //Рабоатет както странно
                if (dataGridViewCriteria.Rows.Count <= 1)
                    throw new Exception(string.Format("Перед сохранением необходимо заполнить таблицу '{0}'",
                        "Параметр/Значения"));
                //
                GridViewRowCriteria gridViewRowCriterias = new GridViewRowCriteria();
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
                }
                result = true;
            }
            catch(Exception ex)
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

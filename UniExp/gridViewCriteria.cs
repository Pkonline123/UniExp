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

namespace UniExpGridViewCriteria
{
    /*
     * обработка null значений
     * Проверка на коректность данных из файла и из таблицы
     * Везде трайкетч +
     * метод вывода ошибок +
     * Диалоговый выбр файлов при сохранении и загрузки.+
     */
    public class gridViewColsCriteria
    {
        public string columnName { get; set; }
        public gridViewColsCriteria()
        {
            this.columnName = string.Empty;
        }
    }

    public class gridViewRowCriteria
    {
        public string criteriaName { get; set; }
        public string criteriaValue { get; set; }

        public gridViewRowCriteria()
        {
            this.criteriaName = string.Empty;
            this.criteriaValue = string.Empty;
        }
    }

    public class gridViewCriterias
    {
        public List<gridViewColsCriteria> gridViewColsCriterias { get; set; }
        public List<gridViewRowCriteria> gridViewRowCriteria { get; set; }

        public gridViewCriterias()
        {
            this.gridViewColsCriterias = new List<gridViewColsCriteria>();
            this.gridViewRowCriteria = new List<gridViewRowCriteria>();
        }

        public void Update(DataGridView dataGridViewCriteria, string fileName = "")
        {
            gridViewColsCriterias.Clear();
            gridViewRowCriteria.Clear();
            //
            foreach (DataGridViewColumn dataGridViewColumn in dataGridViewCriteria.Columns)
            {
                this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = dataGridViewColumn.Name });
            }
            foreach (DataGridViewRow dataGridViewRow in dataGridViewCriteria.Rows)
            {
                if (dataGridViewRow.Cells[0].Value != null && dataGridViewRow.Cells[1].Value == null)
                {
                    MessageBox.Show(string.Format("Заполните поле: 'Значение' для критерия: {0}",
                        dataGridViewRow.Cells[0].Value.ToString()), "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //throw new Exception();
                }
                if (dataGridViewRow.Cells[0].Value == null && dataGridViewRow.Cells[1].Value != null)
                {
                    MessageBox.Show(string.Format("Заполните поле: 'Параметр' для значеня: {0}",
                       dataGridViewRow.Cells[1].Value.ToString()), "Предупреждение",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //throw new Exception();
                }
                if (dataGridViewRow.Cells[0].Value == null && dataGridViewRow.Cells[1].Value == null)
                {
                    //dataGridViewRow.Cells[0].DetachEditingControl();
                    dataGridViewRow.Cells[0].Value = "";
                    dataGridViewRow.Cells[1].Value = "";
                }
                this.gridViewRowCriteria.Add(new gridViewRowCriteria()
                {
                    criteriaName = dataGridViewRow.Cells[0].Value.ToString(),
                    criteriaValue = dataGridViewRow.Cells[1].Value.ToString()
                });
            }
            //сериализация
            //File.WriteAllText(fileName, JsonSerializer.Serialize<gridViewColsCriteria>(gridViewColsCriterias));

        }
        public void Load(DataGridView dataGridViewCriteria)
        {
            gridViewColsCriterias.Clear();
            gridViewRowCriteria.Clear();
            //
            this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = "Параметр" });
            this.gridViewColsCriterias.Add(new gridViewColsCriteria() { columnName = "Значение" });
            this.gridViewRowCriteria.Add(new gridViewRowCriteria() { criteriaName = "Критерий1", criteriaValue = "Знач1" });
            this.gridViewRowCriteria.Add(new gridViewRowCriteria() { criteriaName = "Критерий2", criteriaValue = "Знач2" });
            this.gridViewRowCriteria.Add(new gridViewRowCriteria() { criteriaName = "Критерий3", criteriaValue = "Знач3" });
            //
            foreach (gridViewColsCriteria grViewColsCriteria in gridViewColsCriterias)
            {
                dataGridViewCriteria.Columns.Add(grViewColsCriteria.columnName, grViewColsCriteria.columnName);
            }
            foreach (gridViewRowCriteria grViewRowCriteria in gridViewRowCriteria)
            {
                dataGridViewCriteria.Rows.Add(grViewRowCriteria.criteriaName, grViewRowCriteria.criteriaValue);
            }
            //дсериализация
            //WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(File.ReadAllText(fileName));
        }
    }
}

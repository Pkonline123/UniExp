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
    public partial class HelpFrom : Form
    {
        public HelpFrom()
        {
            InitializeComponent();
        }

        private void HelpFrom_Load(object sender, EventArgs e)
        {
            try
            {
                GridViewLimit gridViewLimit = new GridViewLimit();
                //
                StringBuilder sB = new StringBuilder();
                sB.Append("Для начала работы с программой необходимо создать или открыть ранее созданный файл проекта.");
                sB.Append(Environment.NewLine);
                sB.Append("Таблицы:");
                sB.Append(Environment.NewLine);
                sB.Append("1. Новая запись в таблице добавляется автоматически.");
                sB.Append(Environment.NewLine);
                sB.Append("2. Для удаления записи в таблице необходимо выбрать " +
                    "нужноую строку в таблице и нажать клавишу \"Del\".");
                sB.Append(Environment.NewLine);
                sB.Append("3. Для перемешения по таблице можно использовать мышь или клавиши на клавиатуре(\u2190,\u2191,\u2193,\u2192).");
                sB.Append(Environment.NewLine);
                sB.Append("Таблица \"Критериев\":");
                sB.Append(Environment.NewLine);
                sB.Append("1. Для заполнения значений критерия, " +
                    "сначала необходимо заполнить наименование критерия в соответствующем поле, " +
                    "после чего нажать на кнопку и перейти в конструктор заполенния значений для критерия.");
                sB.Append(Environment.NewLine);
                sB.Append("2. В конструкторе необходимо заполнить от 1 до 5 " +
                    "значений для выбранного критерия и нажать кнопку \"Добавить\" в противном случие \"Отменить.\"");
                sB.Append(Environment.NewLine);
                sB.Append("Ограничения:");
                sB.Append(Environment.NewLine);
                sB.Append(string.Format("1. Наименование критерия имеет максимаьную длину в {0} символов.", 
                    gridViewLimit.maxLnCriteriaName));
                sB.Append(Environment.NewLine);
                sB.Append(string.Format("2. В конструкторе для значений критериев наименование значений " +
                    "имеет максимальную длину в {0} символов.",
                    gridViewLimit.maxLnCriteriaValue));
                sB.Append(Environment.NewLine);
                sB.Append(string.Format("3. Максимальное число строк в таблице с критериями: {0}.",
                    gridViewLimit.maxCriteriaRows));
                sB.Append(Environment.NewLine);
                sB.Append("Таблица \"Правил\":");
                sB.Append(Environment.NewLine);
                sB.Append("1. Для создания правил необходимо нажать на кнопку в правом стоблюце таблицы.");
                sB.Append(Environment.NewLine);
                sB.Append("2. В конструкторе заполнить правило и нажать \"Добавить\" или \"Отменить\".");
                sB.Append(Environment.NewLine);
                sB.Append("Ограничения:");
                sB.Append(Environment.NewLine);
                sB.Append(string.Format("1. Максимальное число строк в таблице с правилами: {0}.",
                    gridViewLimit.maxRoleRows));
                txtBoxInfo.Text = sB.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("HelpFrom_Load:{0}", ex.Message));
            }
        }

        private void HelpFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("HelpFrom_KeyDown:{0}", ex.Message));
            }
        }
    }
}

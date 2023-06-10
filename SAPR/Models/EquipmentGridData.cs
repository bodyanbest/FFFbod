using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SAPR.Models
{
    public class EquipmentGridData
    {
        private static readonly List<KeyValuePair<string, double?>> mainProcces = new List<KeyValuePair<string, double?>>() {
               new KeyValuePair<string, double?>("Машина мийна", 3),
               new KeyValuePair<string, double?>("Кантувач кузова", 3),
               new KeyValuePair<string, double?>("Вагоноремонтна машина", 3),
               new KeyValuePair<string, double?>("Правильна машина",3),
               new KeyValuePair<string, double?>("Візок-підйомник", 2),
               new KeyValuePair<string, double?>("Гайковерт", 2),
               new KeyValuePair<string, double?>("Газозварювальний апарат", 2),
               new KeyValuePair<string, double?>("Зварювальний трансформатор", 2),
               new KeyValuePair<string, double?>("Стенд випробування гальм", 2),
               new KeyValuePair<string, double?>("Машина фарбування та сушіння вагонів", 3),
               new KeyValuePair<string, double?>("Верстат-напівавтомат обробки колісних пар", 3.5),
               new KeyValuePair<string, double?>("Дефектоскоп", 3),
               new KeyValuePair<string, double?>("Токарний верстат", 3),
               new KeyValuePair<string, double?>("Строгальний верстат", 3),
               new KeyValuePair<string, double?>("Фрезерний верстат", 3),
               new KeyValuePair<string, double?>("Деревообробний станок", 3),
               new KeyValuePair<string, double?>("Циркулярно-маятникова пилка", 2),
               new KeyValuePair<string, double?>("Електродриль", 2),
               new KeyValuePair<string, double?>("Верстат обробки гальмівних черевиків", 3),
               new KeyValuePair<string, double?>("Автомат виготовлення шплінтів", 4),
               new KeyValuePair<string, double?>("Ковальсько-пресове обладнання",3),
               new KeyValuePair<string, double?>("Прес правки кришок люків та дверей", 2),
               new KeyValuePair<string, double?>("Зварювальний напівавтомат", 3.5),
               new KeyValuePair<string, double?>("Зварювальний автомат", 4),
               new KeyValuePair<string, double?>("Електропіч", 3),
               new KeyValuePair<string, double?>("Ковальський горн", 2),
        };
        private static readonly List<KeyValuePair<string, double?>> supportProcess = new List<KeyValuePair<string, double?>>() {
               new KeyValuePair<string, double?>("Електрокар", 3),
               new KeyValuePair<string, double?>("Кран мостовий однобалковий", 3),
               new KeyValuePair<string, double?>("Кран козловий", 3),
               new KeyValuePair<string, double?>("Верстат універсальний металорізальний", 3),
               new KeyValuePair<string, double?>("Заточувальний верстат", 3),
               new KeyValuePair<string, double?>("Кривошипний механізм", 2),
               new KeyValuePair<string, double?>("Машина свердлильна", 2),
               new KeyValuePair<string, double?>("Автонавантажувач", 2),
               new KeyValuePair<string, double?>("Зварювальний напівавтомат", 3.5),
               new KeyValuePair<string, double?>("Конвеєр", 3),
               new KeyValuePair<string, double?>("Кран бруківка", 3),
               new KeyValuePair<string, double?>("Зварювальний трансформатор", 2),
               new KeyValuePair<string, double?>("Трансбордерний агрегат", 3),
               new KeyValuePair<string, double?>("Транспортний візок",1),
        };

        public static List<DataGridViewRow> GetMainProcessRows(DataGridView example)
        {
            return GetProcessRowsFrom(example, mainProcces);
        }


        public static List<DataGridViewRow> GetSupportProcessRows(DataGridView example)
        {
            return GetProcessRowsFrom(example, supportProcess);
        }

        private static List<DataGridViewRow> GetProcessRowsFrom(DataGridView example, List<KeyValuePair<string, double?>> source)
        {
            List<DataGridViewRow> result = new List<DataGridViewRow>();
            foreach (var record in source)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(example);
                string rowName = record.Key, rowValue = "";
                if (record.Value != null)
                {
                    rowValue = record.Value.ToString();
                }
                row.Cells[0].Value = rowName;
                row.Cells[1].Value = rowValue;
                double nz = 0;
                switch (record.Value) {
                    case 0:
                        nz = 0.1;
                        break;
                    case 1:
                        nz = 0.2;
                        break;
                    case 2:
                        nz = 0.4;
                        break;
                    case 2.25:
                        nz = 0.5;
                        break;
                    case 3:
                        nz = 1;
                        break;
                    case 3.25:
                        nz = 1.1;
                        break;
                    case 3.5:
                        nz = 1.4;
                        break;
                    case 3.75:
                        nz = 1.75;
                        break;
                    case 4:
                        nz = 2.25;
                        break;
                    case 4.25:
                        nz = 2.8;
                        break;
                    case 4.5:
                        nz = 3.5;
                        break;
                    case 4.75:
                        nz = 4.2;
                        break;
                    case 5:
                        nz = 5;
                        break;
                }
                row.Cells[2].Value = nz.ToString();
                result.Add(row);
            }
            return result;
        }
    }
}


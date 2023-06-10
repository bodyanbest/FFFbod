using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAPR.Models
{
    internal class WorkersGridData
    {
        private static readonly List<KeyValuePair<string, double?>> mainWorkers = new List<KeyValuePair<string, double?>>() {
                new KeyValuePair<string, double?>("<header>Слюсарі з ремонту рухомого складу:", null),
                new KeyValuePair<string, double?>( "а) ходових частин", 4.0),
                new KeyValuePair<string, double?>( "б) автозчіпного пристрою, рами та кузова вагона", 7.2),
                new KeyValuePair<string, double?>( "в) гальмівного та пневматичного обладнання", 5.9),
                new KeyValuePair<string, double?>( "г) буксового вузла", 0.4),
                new KeyValuePair<string, double?>( "Столяри", 8.4),
                new KeyValuePair<string, double?>( "Покрівельники", null),
                new KeyValuePair<string, double?>( "Маляри", 3.7),
                new KeyValuePair<string, double?>( "Електрозварювальники, газозварювальники", 2.1),
                new KeyValuePair<string, double?>( "Мийники-прибиральники рухомого складу", null),
                new KeyValuePair<string, double?>( "Машиністи мийної установки", 1.4),
                new KeyValuePair<string, double?>( "Кранівники", 1.4),
                new KeyValuePair<string, double?>( "Стропальники", 1.4),
                new KeyValuePair<string, double?>( "Підсобні (транспортні) робітники", 1.3),
                new KeyValuePair<string, double?>( "<sum>Разом вагоноремонтна дільниця", null),
                new KeyValuePair<string, double?>( "<empty>", null),
                new KeyValuePair<string, double?>( "<header>Колісно-роликова дільниця", null),
                new KeyValuePair<string, double?>( "Токарі з обточування колісних пар за профілем катання", 2.9),
                new KeyValuePair<string, double?>( "Токарі по обточуванню та накатці шийок кількових пар", 2.3),
                new KeyValuePair<string, double?>( "Слюсарі з ремонту рухомого складу", 8.3),
                new KeyValuePair<string, double?>( "Машиністи мийної установки", 0.7),
                new KeyValuePair<string, double?>( "Електрозварювальники", 3.4),
                new KeyValuePair<string, double?>( "Дефектоскопісти", 1.1),
                new KeyValuePair<string, double?>( "Підсобні (транспортні) робітники", 1.4),
                new KeyValuePair<string, double?>( "<sum>Разом по колісно-роликовій ділянці", null),
                new KeyValuePair<string, double?>( "<empty>", null),
                new KeyValuePair<string, double?>( "<header>Деревообробне відділення", null),
                new KeyValuePair<string, double?>( "Столяри-верстатники", 2.7),
                new KeyValuePair<string, double?>( "Столяри", 1.2),
                new KeyValuePair<string, double?>( "Підсобні (транспортні) робітники", 1.4),
                new KeyValuePair<string, double?>( "<sum>Разом по деревообробному відділенню", null),
                new KeyValuePair<string, double?>( "<empty>", null),
                new KeyValuePair<string, double?>( "<header>Ремонтно-комплектувальна дільниця", null),
                new KeyValuePair<string, double?>( "Ковалі", 1.9),
                new KeyValuePair<string, double?>( "Ресорувальники з обробки гарячого металу", 1.0),
                new KeyValuePair<string, double?>( "Токарі:", 1.7),
                new KeyValuePair<string, double?>( "Строгальники", 0.9),
                new KeyValuePair<string, double?>( "Свердлувальники:", 0.9),
                new KeyValuePair<string, double?>( "Фрезерувальники", 0.7),
                new KeyValuePair<string, double?>( "<header>Слюсарі з ремонту рухомого складу:", null),
                new KeyValuePair<string, double?>( "а) вагонних деталей та вузлів", 4.1),
                new KeyValuePair<string, double?>( "б) автозчіпного пристрою", 4.3),
                new KeyValuePair<string, double?>( "в) тріангелів:", 1.3),
                new KeyValuePair<string, double?>( "г) дверей, люків та бортів", 1.3),
                new KeyValuePair<string, double?>( "<header>Електрозварювальники з ремонту:", null),
                new KeyValuePair<string, double?>( "а) автозчіпного пристрою", 1.9),
                new KeyValuePair<string, double?>( "б) тріангелів", 0.8),
                new KeyValuePair<string, double?>( "в) дверей люків та бортів:", 0.7),
                new KeyValuePair<string, double?>( "Строгальники з ремонту автозчіпного пристрою", 1.3),
                new KeyValuePair<string, double?>( "Електрозварювальники, газозварювальники", 1.8),
                new KeyValuePair<string, double?>( "Дефектоскопісти", 1.0),
                new KeyValuePair<string, double?>( "Підсобні (транспортні) робітники", 1.3),
                new KeyValuePair<string, double?>( "<sum>Разом по ремонтно-комплектувальній дільниці", null),
                new KeyValuePair<string, double?>( "<empty>", null),
                new KeyValuePair<string, double?>( "Контрольний пункт з ремонту гальм (АКП)", null),
                new KeyValuePair<string, double?>( "Слюсарі з ремонту рухомого складу", 9.0),
                new KeyValuePair<string, double?>( "Токарі", 1.0),
                new KeyValuePair<string, double?>( "Підсобні (транспортні) робітники", 0.5),
                new KeyValuePair<string, double?>("<sum>Разом по АКП", null )
            };
        private static readonly List<KeyValuePair<string, double?>> choresWorkers = new List<KeyValuePair<string, double?>>() {
               new KeyValuePair<string, double?>("Слюсарі з ремонту обладнання", 41.5),
               new KeyValuePair<string, double?>("Слюсарі з ремонту інструменту", 6.5),
               new KeyValuePair<string, double?>("Слюсарі-електрики", 11.5),
               new KeyValuePair<string, double?>("Токарі", 5.0),
               new KeyValuePair<string, double?>("Свердлувальники", 1.4),
               new KeyValuePair<string, double?>("Строгальники-фрезерувальники", 2.2),
               new KeyValuePair<string, double?>("Електрогазозварювальники", 2.5),
               new KeyValuePair<string, double?>("Ковалі", 3.1),
               new KeyValuePair<string, double?>("Маляри", 4.0),
               new KeyValuePair<string, double?>("Столяри", 8.5),
               new KeyValuePair<string, double?>("Підсобні (транспортні) робітники", 13.8),
               new KeyValuePair<string, double?>("<sum>Разом", null),
        };

        public static List<DataGridViewRow> GetMainWorkersRows(DataGridView example)
        {
            List<DataGridViewRow> result = new List<DataGridViewRow>();
            double sum = 0;
            foreach (var record in mainWorkers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(example);
                int specSymbol = record.Key.IndexOf(">");
                string rowName, rowValue = "";
                if (specSymbol != -1)
                {
                    rowName = record.Key.Substring(specSymbol + 1);
                    string commandWord = record.Key.Substring(0, specSymbol + 1);
                    switch (commandWord)
                    {
                        case "<sum>":
                            rowValue = sum.ToString();
                            sum = 0;
                            break;
                        case "<header>":
                        case "<empty>":
                            break;
                    }
                }
                else
                {
                    rowName = record.Key;
                    if (record.Value != null)
                    {
                        rowValue = record.Value.ToString();
                        sum += Double.Parse(rowValue);
                    }
                }
                row.Cells[0].Value = rowName;
                row.Cells[1].Value = rowValue;
                row.Cells[1].ValueType = typeof(double);
                row.Cells[2].ValueType = typeof(double);
                result.Add(row);
            }
            return result;
        }

        public static List<DataGridViewRow> GetChoresWorkersRows(DataGridView example)
        {
            List<DataGridViewRow> result = new List<DataGridViewRow>();
            double sum = 0;
            foreach (var record in choresWorkers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(example);
                int specSymbol = record.Key.IndexOf(">");
                string rowName, rowValue = "";
                if (specSymbol != -1)
                {
                    rowName = record.Key.Substring(specSymbol + 1);
                    string commandWord = record.Key.Substring(0, specSymbol + 1);
                    switch (commandWord)
                    {
                        case "<sum>":
                            rowValue = sum.ToString();
                            sum = 0;
                            break;
                        case "<header>":
                        case "<empty>":
                            break;
                    }
                }
                else
                {
                    rowName = record.Key;
                    if (record.Value != null)
                    {
                        rowValue = record.Value.ToString();
                        sum += Double.Parse(rowValue);
                    }
                }
                row.Cells[0].Value = rowName;
                row.Cells[1].Value = rowValue;
                row.Cells[1].ValueType = typeof(double);
                row.Cells[2].ValueType = typeof(double);
                result.Add(row);
            }
            return result;
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SAPR.Models
{
    public class RepairGroup
    {
        public int GroupNumber { get; set; }
        public string CarType { get; set; }
        public string KindRepair { get; set; }
        public int CarQty { get; set; }
        public int HardComplains { get; set; }
        private Dictionary<string, string> GetXMLAtributes()
        {
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "groupNumber", $"{GroupNumber}" },
                { "carType", $"{CarType}" },
                { "kindRepair", $"{KindRepair}" },
                { "carQty", $"{CarQty}" },
                { "hardComplains", $"{HardComplains}" },
            };
            return result;
        }
        public void AddAsXMLObject(XElement rootElement)
        {
            if (rootElement != null)
            {

                XElement repairGroup = new XElement("repairGroup");
                foreach (KeyValuePair<string, string> item in GetXMLAtributes())
                {
                    XAttribute attribute = new XAttribute(item.Key, item.Value);
                    repairGroup.Add(attribute);
                }
                rootElement.Add(repairGroup);
            }
        }

        public void AddAsGridViewRow(DataGridView dataGrid)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGrid);

            row.Cells[0].Value = GroupNumber;

            DataGridViewComboBoxCell wagonTypeCell = new DataGridViewComboBoxCell();
            wagonTypeCell.Items.AddRange(new string[] { "Піввагон", "Цистерна", "Критий", "Плафторма", "Хопер", "Думпкар",
                "Окатишевоз", "Вагон - бункер", "Спецвагон 1", "Спецвагон 2" });
            row.Cells[1] = wagonTypeCell;
            row.Cells[1].Value = CarType;

            DataGridViewComboBoxCell repairTypeCell = new DataGridViewComboBoxCell();
            repairTypeCell.Items.AddRange(new string[] { "Д", "К", "М", "У" });
            row.Cells[2] = repairTypeCell;
            row.Cells[2].Value = KindRepair;

            row.Cells[3].Value = CarQty;
            row.Cells[4].Value = HardComplains;

            dataGrid.Rows.Add(row);
        }

        public void InitializeFromGridViewRow(DataGridViewRow row)
        {
            GroupNumber = int.Parse(row.Cells[0].Value.ToString());
            CarType = (string)row.Cells[1].Value;
            KindRepair = (string)row.Cells[2].Value;
            CarQty = int.Parse(row.Cells[3].Value.ToString());
            HardComplains = int.Parse(row.Cells[4].Value.ToString());
        }

        public void InitializeFromXml(XElement element)
        {
            if (element != null)
            {
                GroupNumber = int.Parse(element.Attribute("groupNumber").Value);
                CarType = element.Attribute("carType").Value;
                KindRepair = element.Attribute("kindRepair").Value;
                CarQty = int.Parse(element.Attribute("carQty").Value);
                HardComplains = int.Parse(element.Attribute("hardComplains").Value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SAPR.Models
{
    internal class EconomicParameters
    {
        //computational parameters
        public Parameter expensesTotaled = new Parameter("Зведені витрати");
        public Parameter generalExpenses = new Parameter("Загальні витрати");
        public Parameter idleWagonExpenses = new Parameter("Витрати на перебування вагону у неробочому парку");
        public Parameter oneTimeExpenses = new Parameter("Одноразові витрати");
        public Parameter heatingExpenses = new Parameter("Витрати на опалення будівлі депо");
        public Parameter ventilationExpenses = new Parameter("Витрати на ветиляцію будівлі депо");
        public Parameter lightningExpenses = new Parameter("Витрати на електричне освітлення будівлі депо");
        public Parameter depreciationExpenses = new Parameter("Амортизаційні відрахування");
        public Parameter repairExpenses = new Parameter("Відрахування на ремонт");
        public Parameter repairAnnualCost = new Parameter("Річна собіватрість ремонту вагонів");

        //basic parameters
        public Parameter totalSalary = new Parameter("Загальна заробітна плата виробничих робітників");
        public Parameter powerExpenses = new Parameter("Витрати на силову енергію");
        public Parameter compressedAirExpenses = new Parameter("Витрати на стиснене повітря");
        public Parameter equipmentRepairExpenses = new Parameter("Витрати на поточний ремонт обладнання та оснащення");
        public Parameter materialExpenses = new Parameter("Витрати на матеріали та запасні частини");
        public Parameter toolExpenses = new Parameter("Витрати на ремонт інструменту");
        public Parameter equipmentDepreciationExpenses = new Parameter("Щорічні амортизаційні відрахування від вартості обладнання та оснащення");
        public Parameter constructionExpenses = new Parameter("Вартість технологічного обладнання");
        public Parameter technologicalEquipmentExpenses = new Parameter("Вартість технологічного обладнання");
        public Parameter specificAnnualHeatingExpenses = new Parameter("Питомі річні витрати на опалення 10 м3 будівельного об'єму будівлі");
        public Parameter specificAnnualVentilationExpenses = new Parameter("Питомі річні витрати на вентиляцію 10 м3 будівельного об'єму будівлі");
        public Parameter specificAnnualLightningExpenses = new Parameter("Питомі річні витрати на освітлення 10 м3 будівельного об'єму будівлі");
        public Parameter buildingVolume = new Parameter("Об'єм будівлі, м3");
        public Parameter buildingSquare = new Parameter("Площа будівлі, м2");
        public Parameter correctionHeatingPowerFactor = new Parameter("Поправочний коефіцієнт для урахування зміни вартості теплової енергії");
        public Parameter constructionVolumeExpenses = new Parameter("Вартість 1 м3 будівельного об'єму будівлі");
        public Parameter restorationDeductionRate = new Parameter("Норма відрахувань на повне відновлення будівлі");
        public Parameter capitalRepairDeductionRate = new Parameter("Норма відрахувань на капітальний ремонт будівлі");
        public Parameter annualRepairExpensesIndicator = new Parameter("Показник річного обсягу поточних ремонтів від вартості будівлі, %");
        public Parameter economicNormativeCoefficient = new Parameter("Нормативний коефіцієнт економічної ефективності капітальних вкладень");
        public Parameter annualWagonRepairProgram = new Parameter("Річна програма ремонту вагонів");
        public Parameter averageIdleDuration = new Parameter("Середня тривалість перебування вагона у неробочому парку, годин");
        public Parameter oneHourIdleExpenses = new Parameter("Витратна ставка однієї години простою вагона, грн");

        public EconomicParameters()
        {
            Func<List<Parameter>, double?> totalSum = (parameters) =>
            {
                double result = 0;
                foreach (var parameter in parameters)
                {
                    result += parameter.Value ?? 0;
                }
                return result;
            };
            Func<List<Parameter>, double?> totalMultiplying = (parameters) =>
            {
                double result = 1;
                foreach (var parameter in parameters)
                {
                    result *= parameter.Value ?? 1;
                }
                return result;
            };
            Func<List<Parameter>, double?> tenthMultiplying = (parameters) =>
            {
                return totalMultiplying(parameters) / 10;
            };

            repairAnnualCost.ValueCalculation = totalSum;
            repairAnnualCost.ConnectedParameters = new List<Parameter>
            {
                totalSalary,
                heatingExpenses,
                ventilationExpenses,
                lightningExpenses,
                powerExpenses,
                compressedAirExpenses,
                equipmentRepairExpenses,
                toolExpenses,
                materialExpenses,
                repairExpenses,
                depreciationExpenses,
                equipmentDepreciationExpenses
            };

            oneTimeExpenses.ValueCalculation = totalSum;
            oneTimeExpenses.ConnectedParameters = new List<Parameter>
            {
                technologicalEquipmentExpenses,
                constructionExpenses
            };

            heatingExpenses.ValueCalculation = tenthMultiplying;
            heatingExpenses.ConnectedParameters = new List<Parameter>
            {
                specificAnnualHeatingExpenses,
                buildingVolume,
                correctionHeatingPowerFactor,
            };

            ventilationExpenses.ValueCalculation = tenthMultiplying;
            ventilationExpenses.ConnectedParameters = new List<Parameter>
            {
                specificAnnualVentilationExpenses,
                buildingVolume,
                correctionHeatingPowerFactor,
            };

            lightningExpenses.ValueCalculation = tenthMultiplying;
            lightningExpenses.ConnectedParameters = new List<Parameter>
            {
                specificAnnualLightningExpenses,
                buildingSquare,
            };

            depreciationExpenses.ValueCalculation = (parameters) => parameters[0].Value * parameters[1].Value * (parameters[2].Value + parameters[3].Value) / 100;
            depreciationExpenses.ConnectedParameters = new List<Parameter>
            {
                buildingVolume,
                constructionVolumeExpenses,
                restorationDeductionRate,
                capitalRepairDeductionRate
            };

            repairExpenses.ValueCalculation = (parameters) => totalMultiplying(parameters) / 100;
            repairExpenses.ConnectedParameters = new List<Parameter>
            {
                buildingVolume,
                constructionVolumeExpenses,
                annualRepairExpensesIndicator,
            };

            expensesTotaled.ValueCalculation = (parameters) => (parameters[0].Value + parameters[1].Value * parameters[2].Value) / parameters[3].Value;
            expensesTotaled.ConnectedParameters = new List<Parameter>
            {
                repairAnnualCost,
                oneTimeExpenses,
                economicNormativeCoefficient,
                annualWagonRepairProgram
            };

            idleWagonExpenses.ValueCalculation = totalMultiplying;
            idleWagonExpenses.ConnectedParameters = new List<Parameter>
            {
                averageIdleDuration,
                oneHourIdleExpenses,
            };

            generalExpenses.ValueCalculation = totalSum;
            generalExpenses.ConnectedParameters = new List<Parameter>
            {
                expensesTotaled,
                idleWagonExpenses
            };
        }

        public EconomicParameters(IEnumerable<XElement> parameters): this() {
            List<Parameter> innerParameters = GetParameters();
            List<XElement> tempParameters = new List<XElement>(parameters);
            foreach (Parameter currInnerParam in innerParameters)
            {
                foreach (XElement element in tempParameters)
                {
                    XAttribute name = element.Attribute("name");
                    XAttribute value = element.Attribute("value");
                    if (name.Value == currInnerParam.Name){
                        if (value.Value == "")
                        {
                            currInnerParam.Value = null;
                        }
                        else
                        {
                            try
                            {

                                currInnerParam.Value = Convert.ToDouble(value.Value);
                            }
                            catch (FormatException ex)
                            {
                                currInnerParam.Value = Convert.ToDouble(value.Value.Replace(".",","));
                            }
                        }
                        tempParameters.Remove(element);
                        break;
                    }
                }
            }
        }

        public List<Parameter> GetParameters()
        {
            return new List<Parameter> {
                expensesTotaled,
                generalExpenses,
                idleWagonExpenses,
                oneTimeExpenses,
                heatingExpenses,
                ventilationExpenses,
                lightningExpenses,
                depreciationExpenses,
                repairExpenses,
                repairAnnualCost,

                totalSalary,
                powerExpenses,
                compressedAirExpenses,
                equipmentRepairExpenses,
                materialExpenses,
                toolExpenses,
                equipmentDepreciationExpenses,
                constructionExpenses,
                technologicalEquipmentExpenses,
                specificAnnualHeatingExpenses,
                specificAnnualVentilationExpenses,
                specificAnnualLightningExpenses,
                buildingVolume,
                buildingSquare,
                correctionHeatingPowerFactor,
                constructionVolumeExpenses,
                restorationDeductionRate,
                capitalRepairDeductionRate,
                annualRepairExpensesIndicator,
                economicNormativeCoefficient,
                annualWagonRepairProgram,
                averageIdleDuration,
                oneHourIdleExpenses,
            };
        }

        public List<Parameter> GetCalculateParameters()
        {
            return new List<Parameter> {
                expensesTotaled,
                generalExpenses,
                idleWagonExpenses,
                oneTimeExpenses,
                heatingExpenses,
                ventilationExpenses,
                lightningExpenses,
                depreciationExpenses,
                repairExpenses,
                repairAnnualCost
            };
        }

        public List<Parameter> GetRepairWagonParameters() {
            return new List<Parameter> {
                expensesTotaled,
                generalExpenses,
                idleWagonExpenses
            };
        }

        public List<Parameter> GetBuildingMaintenanceParameters()
        {
            return new List<Parameter> { 
                heatingExpenses,
                ventilationExpenses,
                lightningExpenses,
            };
        }
        public List<Parameter> GetRepairAndDeprecationParameters()
        {
            return new List<Parameter> {
                depreciationExpenses,
                repairExpenses,
            };
        }

        internal class Parameter
        {
            public string Name;
            private double? value;
            public Parameter(string name, double? value = null)
            {
                this.Name = name;
                this.value = value;
            }
            public List<Parameter> ConnectedParameters { get; set; }
            public Func<List<Parameter>, double?> ValueCalculation = null;
            public double? Value
            {
                get
                {
                    if (ValueCalculation == null)
                    {
                        return value;
                    }
                    foreach (var parameter in ConnectedParameters)
                    {
                        if (parameter.Value == null)
                        {
                            return null;
                        }
                    }
                    return ValueCalculation(ConnectedParameters);
                }
                set
                {
                    this.value = value;
                }
            }
            public override string ToString()
            {
                return $"{GetType()} \"{Name}\"";
            }

            public void AddAsGridViewRow(DataGridView dataGrid)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGrid);


                row.Cells[0].Value = Name;
                row.Cells[1].Value = Value;

                dataGrid.Rows.Add(row);
            }

            public void AddAsXMLObject(XElement rootElement)
            {
                if (rootElement != null)
                {
                    XElement economicParameter = new XElement("economicParameter");
                    XAttribute value, name = new XAttribute("name", Name);
                    if (Value != null)
                    {
                        value = new XAttribute("value", Value);
                    }
                    else {
                        value = new XAttribute("value", "");
                    }
                    economicParameter.Add(name);
                    economicParameter.Add(value);
                    rootElement.Add(economicParameter);
                }
            }
        }
    }
}


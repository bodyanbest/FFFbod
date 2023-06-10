//namespace SAPR
//{
//    using System;
//    using System.Windows.Forms;
//    using System.ComponentModel;

//    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
//    {
//        public DataGridViewNumericUpDownColumn() : base(new DataGridViewNumericUpDownCell())
//        {
//        }

//        public override DataGridViewCell CellTemplate
//        {
//            get => base.CellTemplate;
//            set
//            {
//                // Ensure that the cell used for the template is a DataGridViewNumericUpDownCell.
//                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumericUpDownCell)))
//                {
//                    throw new InvalidCastException("Must be a DataGridViewNumericUpDownCell");
//                }

//                base.CellTemplate = value;
//            }
//        }
//    }

//    public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
//    {
//        public DataGridViewNumericUpDownCell() : base()
//        {
//            this.Style.Format = "N2";
//        }

//        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
//        {
//            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
//            //var control = this.DataGridView.EditingControl as DataGridViewNumericUpDownEditingControl;
//            //if (control != null)
//            //{
//            //    control.Value = Convert.ToDecimal(this.Value);
//            //}
//        }

//        //public override Type EditType => typeof(DataGridViewNumericUpDownEditingControl);

//        public override Type ValueType => typeof(decimal);

//        public override object DefaultNewRowValue => 0m;

//        public override bool KeyEntersEditMode(KeyEventArgs e) => e.KeyCode != Keys.Space;

//        //public override void ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
//        //{
//        //    base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
//        //    var value = Convert.ToDecimal(formattedValue);
//        //    if (this.ValueType != typeof(decimal))
//        //    {
//        //        value = (decimal)Convert.ChangeType(value, this.ValueType);
//        //    }
//        //    this.Value = value;
//        //}
//    }

//    //public class DataGridViewNumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
//    //{
//    //    private bool valueChanged;
//    //    private int rowIndex;

//    //    public DataGridViewNumericUpDownEditingControl()
//    //    {
//    //        this.Minimum = decimal.MinValue;
//    //        this.Maximum = decimal.MaxValue;
//    //        this.DecimalPlaces = 2;
//    //    }

//    //    public object EditingControlFormattedValue
//    //    {
//    //        get => this.Value.ToString("N2");
//    //        set => this.Value = Convert.ToDecimal(value);
//    //    }

//    //} 
//}

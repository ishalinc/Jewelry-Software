using System;
using System.Windows.Forms;
using System.Globalization;



namespace IshalInc.wJewel.Desktop.Libraries
{
    class NullableDateTimePicker : System.Windows.Forms.MaskedTextBox
    {


        #region Component Designer generated code
        private void InitializeComponent()
        {
          
        }
        #endregion

        public NullableDateTimePicker()
            : base()
        {
            InitializeComponent();
            base.PromptChar = ' ';
            base.Mask = "00.00.0000";
            base.PromptChar = ' ';
            base.ValidatingType = typeof(System.DateTime);
            base.TypeValidationCompleted += new TypeValidationEventHandler
               (TypeValidationCompletedHandler);




        }

        public void FormatDate()
        {
            this.DataBindings[0].Format += new ConvertEventHandler(Date_Format);
            this.DataBindings[0].Parse += new ConvertEventHandler(Date_Parse);
        }

        public Object Value
        {

            get
            {

                DateTime validdateTime;
                DateTime.TryParse(this.Text, System.Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out validdateTime);
                return ((validdateTime == DateTime.MinValue) ? string.Empty : string.Format("{0:MM.dd.yyyy}", validdateTime));

            }
            set
            {
                DateTime validdateTime;
                if (value != null)
                {
                    DateTime.TryParse(value.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out validdateTime);
                    base.Text = string.Format("{0:MM.dd.yyyy}", validdateTime);
                }
            }
        }
        private static void Date_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()) || e.Value.ToString() == "  .  .")
                e.Value = null;
            else
            {
                e.Value = (DateTime)e.Value;

            }
        }

        static void Date_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value != null && (e.Value.ToString() == "  .  ." || string.IsNullOrEmpty(e.Value.ToString())))
                e.Value = null;
        }




        private void TypeValidationCompletedHandler(object sender, TypeValidationEventArgs e)
        {
            if (this.Text.ToString() != "  .  .")
            {
                DateTime validdateTime;

                if (DateTime.TryParse(this.Text, out validdateTime))
                {
                    this.Text = string.Format("{0:MM.dd.yyyy}", validdateTime);
                    e.Cancel = false;
                    this.ForeColor = System.Drawing.Color.Black;
                    //
                }
                else
                {
                    this.ForeColor = System.Drawing.Color.Red;
                    e.Cancel = true;
                }

            }


        }



    }
}

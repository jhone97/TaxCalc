using TaxApp.Entites;
using TaxEngine.ComputationContext;
using TaxEngine.Dispatchers;

namespace TaxApp.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ViewHandler(this);
        }


        public static TaxableEnitiy GetEntityFromUI(Form1 tf)
        {
            TaxableEnitiy te = new TaxableEnitiy();
            te.taxparams = new TaxParamVO();

            int gid = 1, gage = 61;
            double gda = 1, gbasic = 2, gallowance = 3, ghra = 1, gdeductions = 1, gcess = 1;
            char gsex = 'M';

            //if (!( Int32.TryParse(tf.Idtxt.Text,out gid) &
            //     Char.TryParse(tf.Sextxt.Text,out gsex) &&
            //     Int32.TryParse(tf.Agetxt.Text,out gage) &&
            //     Double.TryParse(tf.DAtxt.Text,out gda) &&
            //     Double.TryParse(tf.AllowanceTxt.Text,out gallowance) &&
            //      Double.TryParse(tf.Basictxt.Text,out gbasic) &&
            //       Double.TryParse(tf.HRAtxt.Text,out ghra) &&
            //       Double.TryParse(tf.Deductionstxt.Text,out gdeductions) &&
            //       Double.TryParse(tf.CESStxt.Text,out gcess)))
            //{
            //    return null;
            //}




            te.Id = gid;
            te.Name = tf.textBoxName.Text;
            te.Age = gage;
            te.Sex = (gsex == 'M' || gsex == 'm') ? 'M' : 'F';
            te.Location = tf.textBoxLocation.Text;
            te.taxparams.Basic = gbasic;
            te.taxparams.DA = gda;
            te.taxparams.HRA = ghra;
            //te.taxparams.Cess = gcess;
            te.taxparams.Deductions = gdeductions;
            te.taxparams.Allowance = gallowance;
            te.taxparams.Computed = false;
            return te;
        }

        public static void ShowError()
        {
            MessageBox.Show("Error in input");
        }
        public static void ViewHandler(Form1 tf)
        {
            TaxableEnitiy te = GetEntityFromUI(tf);
            if (te == null)
            {
                ShowError();
                return;
            }
            string archetype = ComputeArchetype(te);
            COMPUTATION_CONTEXT ctx = new COMPUTATION_CONTEXT();
            TaxDTO td = new TaxDTO { Id = te.Id, taxparams = te.taxparams };
            ctx.Put("tax_cargo", td);
            bool rs = CommandDIspatcher.Dispatch(archetype, ctx);
            if (rs)
            {
                TaxDTO temp = (TaxDTO)ctx.Get("tax_cargo");
                tf.label.Text = Convert.ToString(temp.taxparams.TaxLiability);
                tf.Refresh();
            }
        }

        public static string ComputeArchetype(TaxableEnitiy te)
        {
            return (te.Age > 60) ? "SeniorCitizen" : "OrdinaryCitizen";
        }

    }
}

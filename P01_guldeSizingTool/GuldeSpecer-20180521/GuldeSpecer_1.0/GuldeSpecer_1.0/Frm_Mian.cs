using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuldeSpecer_1._0
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        

        private void Frm_Main_Load(object sender, EventArgs e) 
        {

        }
        private void Btn_SpecG_Click(object sender, EventArgs e)
        {
            Form Frm_GetSpec = new Form();
            Frm_GetSpec.Show();
        }

        private void Btn_GetBOMNBR_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            Frm_GetBOMNO frm2 = new Frm_GetBOMNO();
            frm2.Show();
                       
                        /*this.Hide();*/
            
        }
        
    }
}

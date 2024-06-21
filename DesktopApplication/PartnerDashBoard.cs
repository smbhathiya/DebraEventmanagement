using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class PartnerDashboard : Form
    {
        private string email;
        private string userType;

        public PartnerDashboard(string email, string userType)
        {
            InitializeComponent();
            this.email = email;
            this.userType = userType;
        }
    }
}

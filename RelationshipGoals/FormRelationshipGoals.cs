using RelationshipGoals.Properties;
using RelationshipGoals.SQL;
using System.Reflection;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormRelationshipGoals : Form
    {
        public FormRelationshipGoals()
        {
            InitializeComponent();
            Show(); //Forces to show (even blank) Form
        }

        private void FormRelationshipGoals_Load(object sender, System.EventArgs e)
        {
            if (!SQLHandler.Check(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password))
            {
                MessageBox.Show("Your SQL settings are not valid! Please provide valid SQL settings in the following window.");
                new FormSettings().ShowDialog(this);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static string sqlConnection = "server=localhost;uid=root;pwd=;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlDataAdapter;
        public string sqlQuery;
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtTeamkiri = new DataTable();
            sqlQuery = "select team_id as `Team id`, team_name as `nama team` from team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtTeamkiri);
            comboBoxtim1.DisplayMember = "nama team";
            comboBoxtim1.ValueMember = "Team id";
            comboBoxtim1.DataSource = dtTeamkiri;

            DataTable dtTeamkanan = new DataTable();
            sqlQuery = "select team_id as `Team id`, team_name as `nama team` from team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtTeamkanan);
            comboBoxtim2.DisplayMember = "nama team";
            comboBoxtim2.ValueMember = "Team id";
            comboBoxtim2.DataSource = dtTeamkanan;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxtim1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmanagerteamkiri = new DataTable();
            sqlQuery = "SELECT manager.manager_name as `manager name`, player.player_name as `captain` " +
                "FROM team, player, manager " +
                "where team.captain_id = player.player_id and manager.manager_id = team.manager_id and team.team_id = '"+comboBoxtim1.SelectedValue.ToString()+"'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtmanagerteamkiri);
            labelmanagerkiri.Text = dtmanagerteamkiri.Rows[0]["manager name"].ToString();
            labelcaptainkiri.Text = dtmanagerteamkiri.Rows[0]["captain"].ToString();


            DataTable dtstadium = new DataTable();
            sqlQuery = "SELECT concat(home_stadium, ', ', city) as `nama stadium`, capacity as `kapasitas` from team where team_id = '"+comboBoxtim1.SelectedValue.ToString()+"'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtstadium);
            labelstadium.Text = dtstadium.Rows[0]["nama stadium"].ToString();
            labelcapacity.Text = dtstadium.Rows[0]["kapasitas"].ToString();
        }

        private void comboBoxtim2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmanagerteamkanan = new DataTable();
            sqlQuery = "SELECT manager.manager_name as `manager name`, player.player_name as `captain` " +
                "FROM team, player, manager " +
                "where team.captain_id = player.player_id and manager.manager_id = team.manager_id and team.team_id = '" + comboBoxtim1.SelectedValue.ToString() + "'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtmanagerteamkanan);
            labelmanagerkanan.Text = dtmanagerteamkanan.Rows[0]["manager name"].ToString();
            labelcaptainkanan.Text = dtmanagerteamkanan.Rows[0]["captain"].ToString();
        }

        private void labelstadium_Click(object sender, EventArgs e)
        {

        }
    }
}

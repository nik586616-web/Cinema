using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class FSessions : Form
    {
        ClassAdo classAdo = new ClassAdo();
        string sql = @"select sessions.id_session, movies.movie_name as 'Фильм', halls.hall_name as 'Зал', sessions.Sdate as 'Дата', sessions.Stime as 'Время', sessions.Price as 'Цена' 
                from movies, sessions, halls where sessions.id_movie = movies.id_movie and sessions.id_hall = halls.id_hall";
        int movieId = 0;
        public FSessions()
        {
            InitializeComponent();
        }

        private void FSessions_Load(object sender, EventArgs e)
        {
            movieId = int.Parse(lblmovieid.Text);
            sql += " and movies.id_movie = " + movieId;
            classAdo.DataGridBind(sql, dgvSession);
            dgvSession.Columns["id_session"].Visible = false;
            DataGridViewButtonColumn orderBtn = new DataGridViewButtonColumn();
            orderBtn.Name = "order";
            orderBtn.HeaderText = "Заказ";
            orderBtn.Text = "Заказать";
            orderBtn.UseColumnTextForButtonValue = true;
            orderBtn.Width = 150;
            dgvSession.Columns.Add(orderBtn);
        }

        private void dgvSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSession.Columns["order"].Index)
            {
                int nRow = dgvSession.CurrentRow.Index;
                string sessionId = dgvSession["id_session", nRow].ToString();
                string movie = dgvSession["Фильм", nRow].Value.ToString();
                string hall = dgvSession["Зал", nRow].Value.ToString();
                string dateStr = dgvSession["Дата", nRow].Value.ToString();
                string timeStr = dgvSession["Время", nRow].Value.ToString();
                string price = dgvSession["Цена", nRow].Value.ToString();
                FShema1 fShema= new FShema1();
                fShema.lblsessionid.Text = sessionId;
                fShema.ShowDialog();
            }
        }
    }
}

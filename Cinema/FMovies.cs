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
    public partial class FMovies : Form
    {
        ClassAdo classAdo = new ClassAdo();
        string sql = "select * from movies";
        public FMovies()
        {
            InitializeComponent();
        }

        private void FMovies_Load(object sender, EventArgs e)
        {
            getDgvMovies();
        }
        public void getDgvMovies()
        {
            DataSet ds = classAdo.GetDataSet(sql);

            dgvMovies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMovies.Rows.Clear();
            dgvMovies.Columns.Clear();

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "img";
            imageColumn.Width = 150;
            imageColumn.HeaderText = "Постер";
            dgvMovies.Columns.Add(imageColumn);

            dgvMovies.Columns.Add("id_movie", "id_movie");
            dgvMovies.Columns["id_movie"].Visible = false;

            dgvMovies.Columns.Add("Movie", "Movie");
            dgvMovies.Columns["Movie"].Width = 450;
            dgvMovies.Columns["Movie"].HeaderText="Фильм";


            DataGridViewButtonColumn sessionBtn = new DataGridViewButtonColumn();
            sessionBtn.UseColumnTextForButtonValue = true;
            sessionBtn.Name = "session";
            sessionBtn.HeaderText = "Заказ";
            sessionBtn.Text = "Заказать";
            sessionBtn.Width = 150;
            dgvMovies.Columns.Add(sessionBtn);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvMovies.Rows.Add();
                dgvMovies.Rows[i].Height = 150;
                String imgFile = "";
                if (ds.Tables[0].Rows[i]["img"].ToString() != "")
                {
                    imgFile = ds.Tables[0].Rows[i]["img"].ToString();
                }
                else
                {
                    imgFile = "picture.png";
                }
                imgFile = "img/" + imgFile;
                Image image = new Bitmap(imgFile);
                Bitmap result = new Bitmap(image, 150, 150);
                dgvMovies.Rows[i].Cells["img"].Value = result;

                dgvMovies.Rows[i].Cells["id_movie"].Value = ds.Tables[0].Rows[i]["id_movie"];
                String str = "Наименование фильма: " + ds.Tables[0].Rows[i]["movie_name"].ToString() + "\n" +
                    "Производитель: " + ds.Tables[0].Rows[i]["genre"].ToString() + "\n" +
                    "Длительность: " + ds.Tables[0].Rows[i]["dlitelnost"].ToString() + "мин. \n" +
                    "Возрастной рейтинг: " + ds.Tables[0].Rows[i]["ageRating"].ToString() + "\n" +
                    "Описание: " + ds.Tables[0].Rows[i]["description"].ToString();
                dgvMovies.Rows[i].Cells["Movie"].Value = str;
            }
        }

        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMovies.Columns[e.ColumnIndex].Name == "session")
            {
                string movieId = dgvMovies.Rows[e.RowIndex].Cells["id_movie"].Value.ToString();
                string movieName = dgvMovies.Rows[e.RowIndex].Cells["Movie"].Value.ToString();
                MessageBox.Show($"Вы выбрали фильм: \n{movieName}\n\nПереход к выбору сеанса...", "Бронирование");
                FSessions fSessions = new FSessions();
                fSessions.lblmovieid.Text = movieId;
                fSessions.ShowDialog();
            }
        }
    }
}

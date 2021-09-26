using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curriculum
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public Form1()
        {
            InitializeComponent();
            ConfigurarTabela();
            ConfigurarTabelaFormacao();
        }

        private void ConfigurarTabelaFormacao()
        {
            dt2.Columns.Add("id", typeof(Int32));
            dt2.Columns["id"].AutoIncrement = true;
            dt2.Columns["id"].AutoIncrementSeed = 1;

            dt2.Columns.Add("Formação", typeof(string));

            dataGridView1.DataSource = dt2;
        }

        private void ConfigurarTabela()
        {
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementSeed = 1;

            dt.Columns.Add("Empresa", typeof(string));
            dt.Columns.Add("Cargo", typeof(string));
            dt.Columns.Add("Periodo", typeof(string));

            dataGridView2.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarFormForma())
            {
                AtualizarLinhaForm(Convert.ToInt32("0" + lblFormacao.Text));
                limparFormForma();
                txtFormacao.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                AtualizarLinha(Convert.ToInt32("0" + lblEx.Text));
                LimparForm();
                txtEmp.Focus();
            }
        }

        private bool ValidarFormForma()
        {
            var result = true;
            if (txtFormacao.Text == "")
            {
                MessageBox.Show("Insira a sua formação", "Validar", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtFormacao.Focus();
                result = false;
            }
            return result;
        }

        private bool ValidarForm()
        {
            var result = true;
            if (txtEmp.Text == "")
            {
                MessageBox.Show("Insira a sua formação", "Validar", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmp.Focus();
                result = false;
            }
            else if (txtCargo.Text == "")
            {
                MessageBox.Show("Insira a sua formação", "Validar", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCargo.Focus();
                result = false;
            }
            else if (txtPeriodo.Text == "")
            {
                MessageBox.Show("Insira a sua formação", "Validar", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPeriodo.Focus();
                result = false;
            }
            return result;
        }

        private void AtualizarLinha(int id)
        {
            if (id == 0)
            {
                dt.Rows.Add(null, txtEmp.Text, txtCargo.Text, txtPeriodo.Text);
            }
            else
            {
                DataRow[] row = dt.Select("id =" + id);
                if (row.Length > 0)
                {
                    row[0]["Empresa"] = txtEmp.Text;
                    row[0]["Cargo"] = txtCargo.Text;
                    row[0]["Periodo"] = txtPeriodo;
                }
            }
        }

        private void AtualizarLinhaForm(int id)
        {
            if (id == 0)
            {
                dt2.Rows.Add(null, txtFormacao.Text);
            }
            else
            {
                DataRow[] row = dt2.Select("id =" + id);
                if (row.Length > 0)
                {
                    row[0]["Formação"] = txtFormacao.Text;
                }
            }
        }

        private void limparFormForma()
        {
            lblFormacao.Text = "";
            txtFormacao.Clear();
        }

        private void LimparForm()
        {
            lblID.Text = "";
            txtEmp.Clear();
            txtCargo.Clear();
            txtPeriodo.Clear();
        }

        private void txtFormacao_Leave(object sender, EventArgs e)
        {
            GetFormacao(txtFormacao.Text);
        }

        private void txtEmp_Leave(object sender, EventArgs e)
        {
            GetEmpresa(txtEmp.Text);
        }

        private void GetEmpresa(string empresa)
        {
            DataRow[] row = dt.Select("Empresa = '" + empresa + "'");
            if (row.Length > 0)
            {
                lblEx.Text = row[0]["id"].ToString();
                txtEmp.Text = row[0]["Empresa"].ToString();
                txtCargo.Text = row[0]["Cargo"].ToString();
                txtPeriodo.Text = row[0]["Periodo"].ToString();
            }
        }

        private void GetFormacao(string formacao)
        {
            DataRow[] row = dt2.Select("Formação = '" + formacao + "'");
            if (row.Length > 0)
            {
                lblFormacao.Text = row[0]["id"].ToString();
                txtFormacao.Text = row[0]["Formação"].ToString();
            }
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (lblFormacao.Text != "")
            {
                if (MessageBox.Show("Deseja excluir?", "Validar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirLinhaForm(Convert.ToInt32(0 + lblFormacao.Text));
                    limparFormForma();
                    txtFormacao.Focus();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lblEx.Text != "")
            {
                if (MessageBox.Show("Deseja excluir?", "Validar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirLinha(Convert.ToInt32(0 + lblEx.Text));
                    limparFormForma();
                    txtEmp.Focus();
                }
            }
        }

        private void ExcluirLinhaForm(int id)
        {
            DataRow[] row = dt2.Select("id = " + id);
            if (row.Length > 0)
                row[0].Delete();
        }

        private void ExcluirLinha(int id)
        {
            DataRow[] row = dt.Select("id = " + id);
            if (row.Length > 0)
                row[0].Delete();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtFormacao_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

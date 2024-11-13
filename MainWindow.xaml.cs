using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection? conexao = null;

        public MainWindow()
        {

            InitializeComponent();

            string URL = "";
            try
            {
                conexao = new(URL);
                conexao.Open();
                LabelStatus.Content = "Conexão OK";
            }
            catch (Exception ex)
            {

            }
        }

        private bool VerificarCampos()
        {
            return TextBoxCpf.Text != "" && TextBoxNome.Text != "" && TextBoxEndereco.Text != "" && TextBoxMatricula.Text == "";
        }

        private void Limpar()
        {
            TextBoxCpf.Text = "";
            TextBoxNome.Text = "";
            TextBoxEndereco.Text = "";
            TextBoxMatricula.Text = "";
        }

        private void BotaoSalvar_Click(object sender, RoutedEventArgs e)
        {
            Empregado emp = new()
            {
                CPF = TextBoxCpf.Text,
                Nome = TextBoxNome.Text,
                Endereco = TextBoxEndereco.Text,
            };

            if ((conexao != null) && VerificarCampos())
            {
                emp.Salvar(conexao);
                LabelStatus.Content = "Salvo OK";
                Limpar();
            }
            else
            {
                LabelStatus.Content = "Não salvo DesOK";

            }
        }

        private void BotaoLimpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }
    }
}
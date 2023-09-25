using Acme.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Acme.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //1º instanciando o objeto DTO
            FuncionarioDTO funcionario = new FuncionarioDTO();
            funcionario.Nome = TxtNome.Text;
            funcionario.Cpf = TxtCpf.Text;
            funcionario.Email = TxtEmail.Text;
            funcionario.Telefone = TxtTelefone.Text;
            funcionario.Sexo = TxtSexo.Text;
            funcionario.DtNascimento = Convert.ToDateTime(TxtDtNascimento.Text);
            funcionario.DtAdmissao = Convert.ToDateTime(TxtAdmissao.Text);
            funcionario.Logradouro = TxtLogradouro.Text;
            funcionario.Numero = TxtNumero.Text;
            funcionario.Complemento = TxtComplemento.Text;
            funcionario.Bairro = TxtBairro.Text;
            funcionario.Cidade = TxtCidade.Text;
            funcionario.Uf = TxtUf.Text;
            funcionario.Cep = TxtCep.Text;
            funcionario.SalarioBruto = Convert.ToDecimal(TxtSalario.Text);
            funcionario.IdDepartamento = Convert.ToInt32(CmbDepartamento.Text);
            funcionario.IdCargo = Convert.ToInt32(CmbCargo.Text);
        }

    }
}

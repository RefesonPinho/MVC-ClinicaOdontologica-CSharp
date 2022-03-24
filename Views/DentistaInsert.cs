using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;
using Teste;

namespace Views2
{
    public class InsertDentista : Baseform2
    {
        public delegate void HandleButton(object sender, EventArgs e);

        private System.ComponentModel.IContainer components = null;
        TextBox text;
        Label lblInsert;
        Label lblNome;
        Label lblCPF;
        Label lblFone;
        Label lblEmail;
        Label lblSenha;
        Label lblRegistro;
        Label lblSalario;
        Label lblIdEspecialidade;
        TextBox textNome;
        TextBox textCpf;
        TextBox textFone;
        TextBox textEmail;
        TextBox textSenha;
        TextBox textRegistro;
        TextBox textSalario;
        TextBox textIdEspecialidade;

        Button btnConfirm1;
        Button btnCancel1;

        public InsertDentista() : base("Seja bem-vindo")
        {
            this.lblInsert = new Label();
            this.lblInsert.Text = "Dados Dentista:";
            this.lblInsert.Location = new Point(100, 50);
            
            this.lblNome = new Label();
            this.lblNome.Text = " Nome";
            this.lblNome.Location = new Point(120, 100);

            textNome = new TextBox();
            textNome.Location = new Point(10,125);
            textNome.Size = new Size(360,20);

            this.lblCPF = new Label();
            this.lblCPF.Text = "CPF";
            this.lblCPF.Location = new Point(120, 150);

            textCpf = new TextBox();
            textCpf.Location = new Point(10,175);
            textCpf.Size = new Size(360,20);

            this.lblFone = new Label();
            this.lblFone.Text = "Telefone";
            this.lblFone.Location = new Point(120, 200);

            textFone= new TextBox();
            textFone.Location = new Point(10,225);
            textFone.Size = new Size(360,20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(120, 250);

            textEmail = new TextBox();
            textEmail.Location = new Point(10,275);
            textEmail.Size = new Size(360,20);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(120, 300);

            textSenha = new TextBox();
            textSenha.Location = new Point(10,325);
            textSenha.Size = new Size(360,20);

            this.lblRegistro = new Label();
            this.lblRegistro.Text = "Registro";
            this.lblRegistro.Location = new Point(120, 350);

            textRegistro = new TextBox();
            textRegistro.Location = new Point(10,375);
            textRegistro.Size = new Size(360,20);

            this.lblSalario = new Label();
            this.lblSalario.Text = "Salário";
            this.lblSalario.Location = new Point(120, 400);

            textSalario = new TextBox();
            textSalario.Location = new Point(10,425);
            textSalario.Size = new Size(360,20);

            this.lblIdEspecialidade = new Label();
            this.lblIdEspecialidade.Text = "Id Especialidade";
            this.lblIdEspecialidade.Location = new Point(100, 450);

            textIdEspecialidade = new TextBox();
            textIdEspecialidade.Location = new Point(10,475);
            textIdEspecialidade.Size = new Size(360,20);

            this.btnConfirm1 = new ButtonForm(this.Controls, "Confirmar", 40,520, this.handleConfirmClick);
            this.btnCancel1 = new ButtonForm(this.Controls, "Cancelar", 150, 520, this.handleCancelClick);

            
            
            this.components = new System.ComponentModel.Container();

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.lblFone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.lblIdEspecialidade);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textCpf);
            this.Controls.Add(this.textFone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.textRegistro);
            this.Controls.Add(this.textSalario);
            this.Controls.Add(this.textIdEspecialidade);
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            double Salario = Convert.ToDouble(textSalario.Text);
            int IdEspecialidade = int.Parse(textIdEspecialidade.Text); 
            try
            {
                DentistaController.InserirDentista(
                    textNome.Text,
                    textCpf.Text,
                    textFone.Text,
                    textEmail.Text,
                    textSenha.Text,
                    textRegistro.Text,
                    Salario,
                    IdEspecialidade
                );

                MessageBox.Show("Dados inseridos com sucesso.");

            }
            catch (System.Exception)
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }
            Views3.ConfirmClick menu = new Views3.ConfirmClick();
            menu.ShowDialog();  
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            Teste.MenuPrincipal menu = new Teste.MenuPrincipal();
            menu.ShowDialog();
        }  
    }
        
    public class LabelField : Label
    {

        public LabelField(string Text, int X, int Y)
        {
            this.Text = Text;
            this.Location = new Point(X, Y);
        }

    }

    public class TextBoxField : TextBox 
    {

        public TextBoxField(int X, int Y, int Height, int Width)
        {
            this.Location = new Point(X, Y);
            this.Size = new Size(Height, Width);
            this.ForeColor = System.Drawing.Color.Purple;
        }
    }

    public class TextBoxPass : TextBoxField
    {
        public TextBoxPass(int X, int Y, int Height, int Width)
            : base(X, Y, Height, Width)
        {
            this.PasswordChar = '*';
        }
    }

    public class ButtonForm : Button
    {
        public ButtonForm(
            Control.ControlCollection Ref,
            string Text,
            int X, 
            int Y,
            HandleButton handleAction 
        )
        {
            this.Text = Text;
            this.Location = new Point(X, Y);
            this.Size = new Size(80, 30);
            this.Click += new EventHandler(handleAction);
            Ref.Add(this);
        }
    }

    public class Field
    {
        public LabelField label1;
        public TextBoxField textField2;

        public Field(
            Control.ControlCollection Ref,
            string Text,
            int Y,
            bool isCenterTitle = false,
            bool isPass = false
        )
        {
            const int _MarginLabel = 35;
            const int _Height = 280;
            const int _Width = 30;

            this.label1 = new LabelField(Text, isCenterTitle ? 120 : 10, Y);
            if (!isPass)
            {
                this.textField2 = new TextBoxField(10, Y + _MarginLabel, _Height, _Width);
            }
            else
            {
                this.textField2 = new TextBoxPass(10, Y + _MarginLabel, _Height, _Width);
            }

            Ref.Add(label1);
            Ref.Add(textField2);
        }
    }

    public class Baseform2 : Form
    {
        public Baseform2(string Title)
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
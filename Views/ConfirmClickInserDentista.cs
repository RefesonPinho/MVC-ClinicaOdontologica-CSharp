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

namespace Views3
{
    public class ConfirmClick : Form
    {
        public delegate void HandleButton(object sender, EventArgs e);

        private System.ComponentModel.IContainer components = null;
        Label lblInsert;

        Button btnSim;
        Button btnNao;
        TextBox textNome;
        TextBox textCpf;
        TextBox textFone;
        TextBox textEmail;
        TextBox textSenha;
        TextBox textRegistro;
        TextBox textSalario;
        TextBox textIdEspecialidade;

        public ConfirmClick() 
        {
            this.lblInsert = new Label();
            this.lblInsert.Text = "Deseja confirmar?:";
            this.lblInsert.Location = new Point(100, 50);
            this.lblInsert.Size = new Size(100, 50);


            this.btnSim = new ButtonForm(this.Controls, "Sim", 20,100, this.handlebtnSimClick);
            this.btnNao = new ButtonForm(this.Controls, "Não",80 ,100, this.handlebtnNaoClick);
            
            this.components = new System.ComponentModel.Container();

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textCpf);
            this.Controls.Add(this.textFone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.textRegistro);
            this.Controls.Add(this.textSalario);
            this.Controls.Add(this.textIdEspecialidade);
               
        }
        private void handlebtnSimClick(object sender, EventArgs e) 
        {   
            double salario = Convert.ToDouble(textSalario.Text);
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
                    salario,
                    IdEspecialidade
                );

                MessageBox.Show("Dados inseridos com sucesso.");
                exemplo_winforms.DentistaMenu menu = new exemplo_winforms.DentistaMenu();
                menu.ShowDialog();

            }
            catch (System.Exception)
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }
                
           
        }
        private void handlebtnNaoClick(object sender, EventArgs e)
        {
            Views2.InsertDentista menu = new  Views2.InsertDentista();
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
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace Teste
{
    public delegate void HandleButton(object sender, EventArgs e);
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class Login : BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        Field fieldUser;
        Field fieldPass;

        Button btnConfirm;
        Button btnCancel;

        public Login() : base("Login")
        {
            this.fieldUser = new Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Field(this.Controls, "Senha", 80, true, true);
            this.fieldPass.textField.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm = new ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnCancel = new ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancelClick);
            
            this.components = new System.ComponentModel.Container();
        }

        private void handleConfirmClick(object sender, EventArgs e) {
            DialogResult result;

            result = MessageBox.Show(
                $"Usuário: {this.fieldUser.textField.Text}" +
                $"\nSenha: {this.fieldPass.textField.Text}",
                "Titulo da Mensagem",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }
        
        private void handleCancelClick(object sender, EventArgs e) {
            this.Close();
        }

    }

    public class MenuPrincipal : BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        Label lblLogin;

        Button btnDentista;
        Button btnPaciente;
        Button btnProcedi;
        Button btnEspeciali;
        Button btnSala;
        Button btnAgendamento;
        Button btnCancel;

        Button btnCnfirm1;
        Button btnCancel1;
        public MenuPrincipal() : base("Menu Principal")
        {
            this.lblLogin = new Label();
            this.lblLogin.Text = "Olá Fulano";
            this.lblLogin.Location = new Point(117, 20);

            this.btnDentista = new Button();
            this.btnDentista.Text = "Dentista";
            this.btnDentista.Location = new Point(40, 60);
            this.btnDentista.Size = new Size(100, 30);
            this.btnDentista.Click += new EventHandler(this.handleDentistaClick);

            this.btnPaciente = new Button();
            this.btnPaciente.Text = "Paciente";
            this.btnPaciente.Location = new Point(160, 60);
            this.btnPaciente.Size = new Size(100, 30);
            this.btnPaciente.Click += new EventHandler(this.handlePacienteClick);

            this.btnProcedi = new Button();
            this.btnProcedi.Text = "Procedimento";
            this.btnProcedi.Location = new Point(40, 100);
            this.btnProcedi.Size = new Size(100, 30);
            this.btnProcedi.Click += new EventHandler(this.handleProcedimentoClick);

            this.btnEspeciali = new Button();
            this.btnEspeciali.Text = "Especialidade";
            this.btnEspeciali.Location = new Point(160, 100);
            this.btnEspeciali.Size = new Size(100, 30);
            this.btnEspeciali.Click += new EventHandler(this.handleEspecialidadeClick);

            this.btnSala = new Button();
            this.btnSala.Text = "Sala";
            this.btnSala.Location = new Point(40, 140);
            this.btnSala.Size = new Size(100, 30);
            this.btnSala.Click += new EventHandler(this.handleSalaClick);

            this.btnAgendamento = new Button();
            this.btnAgendamento.Text = "Agendamento";
            this.btnAgendamento.Location = new Point(160, 140);
            this.btnAgendamento.Size = new Size(100, 30);
            this.btnAgendamento.Click += new EventHandler(this.handleAgendamentoClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Sair";
            this.btnCancel.Location = new Point(110, 200);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.btnDentista);
            this.Controls.Add(this.btnPaciente);
            this.Controls.Add(this.btnProcedi);
            this.Controls.Add(this.btnEspeciali);
            this.Controls.Add(this.btnSala);
            this.Controls.Add(this.btnAgendamento);
            this.Controls.Add(this.btnCancel);

        }
        private void handlePacienteClick(object sender, EventArgs e)
        {
           exemplo_winforms.PacienteMenu menu = new exemplo_winforms.PacienteMenu();
            menu.ShowDialog();
            this.Close();
        }
        private void handleDentistaClick(object sender, EventArgs e)
        {
            exemplo_winforms.DentistaMenu menu = new exemplo_winforms.DentistaMenu();
            menu.ShowDialog();
        }
        private void handleProcedimentoClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleEspecialidadeClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleSalaClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
         private void handleAgendamentoClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
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

    public class Field
    {
        public LabelField label;
        public TextBoxField textField;

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

            this.label = new LabelField(Text, isCenterTitle ? 120 : 10, Y);
            if (!isPass)
            {
                this.textField = new TextBoxField(10, Y + _MarginLabel, _Height, _Width);
            }
            else
            {
                this.textField = new TextBoxPass(10, Y + _MarginLabel, _Height, _Width);
            }

            Ref.Add(label);
            Ref.Add(textField);
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

    public class BaseForm : Form
    {
        public BaseForm(string Title)
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

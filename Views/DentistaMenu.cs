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

namespace exemplo_winforms
{
    public class DentistaMenu : Baseform2
    {
        private System.ComponentModel.IContainer components = null;

        ListView listView1;
        Button btnInsert;
        Button btnAlterar;
        Button btnExcluir;
        Button btnVoltar;

        public DentistaMenu() : base("Dentista")
        {
            ListView listView1 = new ListView();
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader();
            list0.Text = "Id";
            list0.Width = -2;
            ColumnHeader list1 = new ColumnHeader();
            list1.Text = "Nome";
            list1.Width = -2;
            ColumnHeader list2 = new ColumnHeader();
            list2.Text = "CPF";
            list2.Width = -2;
            ColumnHeader list3 = new ColumnHeader();
            list3.Text = "Fone";
            list3.Width = -2;
            ColumnHeader list4 = new ColumnHeader();
            list4.Text = "Email";
            list4.Width = -2;
            ColumnHeader list5 = new ColumnHeader();
            list5.Text = "Senha";
            list5.Width = -2;
            ColumnHeader list6 = new ColumnHeader();
            list6.Text = "Registro";
            list6.Width = -2;
            ColumnHeader list7 = new ColumnHeader();
            list7.Text = "Salario";
            list7.Width = -2;
            ColumnHeader list8 = new ColumnHeader();
            list8.Text = "IdEspecialidade";
            list8.Width = -2;

            // Add the column headers to listView1.
            listView1.Columns.AddRange(new ColumnHeader[] 
                {list0, list1, list2, list3, list4, list5, list6, list7, list8});


                // Create items and add them to myListView.
			listView1.View = View.Details;
			foreach(Dentista item in DentistaController.VisualizarDentista())
            {
                ListViewItem listDentista = new ListViewItem(item.Id + "");
                listDentista.SubItems.Add(item.Nome);	
                listDentista.SubItems.Add(item.Cpf + "");
                listDentista.SubItems.Add(item.Fone);
                listDentista.SubItems.Add(item.Email);
                listDentista.SubItems.Add(item.Senha);
                listDentista.SubItems.Add(item.Registro);
                listDentista.SubItems.Add(item.Salario + "");
                listDentista.SubItems.Add(item.IdEspecialidade + "");
                listView1.Items.AddRange(new ListViewItem[]{listDentista});
            }
        
            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(40, 230);
            this.btnInsert.Size = new Size(100, 30);
            this.btnInsert.Click += new EventHandler(this.handleInsertClick);

            this.btnAlterar = new Button();
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Location = new Point(150, 230);
            this.btnAlterar.Size = new Size(100, 30);
            this.btnAlterar.Click += new EventHandler(this.handleAlterarClick);

            this.btnExcluir = new Button();
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new Point(260, 230);
            this.btnExcluir.Size = new Size(100, 30);
            this.btnExcluir.Click += new EventHandler(this.handleExcluirClick);

            this.btnVoltar = new Button();
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Location = new Point(370, 230);
            this.btnVoltar.Size = new Size(100, 30);
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);
            
            this.components = new System.ComponentModel.Container();

            

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView1);    
            this.Controls.Add(this.listView1);
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = "Informa????es do Dentista:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views2.InsertDentista menu = new Views2.InsertDentista();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           DentistaMenu menu = new DentistaMenu();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            DentistaMenu menu = new DentistaMenu();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
            Teste.MenuPrincipal menu = new Teste.MenuPrincipal();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogo_da_velha
{
    public partial class Form1 : Form
    {

        int Xponto = 0, Oponto = 0, empate = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        public int horizontal { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;
            if (btn.Text == "" && jogo_final == false)
            {

                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = "X";
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = "O";
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
            }
        } // final botão

        void Vencedor(int PlayerVencedor)
        {
            jogo_final = true;

            if(PlayerVencedor == 1)
            {
                Xponto++;
                Xpontos.Text = Convert.ToString(Xponto);
                MessageBox.Show("Jogador X ganhou");
                turno = true;
            }
            else
            {
                Oponto++;
                Opontos.Text = Convert.ToString(Oponto);
                MessageBox.Show("Jogador O ganhou");
                turno = false;
            }
        }

        void Checagem(int ChecagemPlayer)
        {
            string suporte;

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }//final do suporte

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    //checagem horizontal
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }
            }//final checagem de horizontal


            //checagem vertical
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {

                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }
            }//final checagem de vertical

            //verificação diagonal 
            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }//diagnoal esquerda para direita

            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }//diagnoal direita para esquerda 
            }

            if(rodadas == 9 && jogo_final == false)
            {
                empate++;
                empates.Text = Convert.ToString(empate);
                MessageBox.Show("Empate!");
                jogo_final = true;

            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            rodadas = 0;
            jogo_final = false;
            for(int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void Q6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

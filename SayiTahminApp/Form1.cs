using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int adim_sayisi = 0;
        public static string sayi1 = "";
        public static string tahmin_Sayisi;
        private void Form1_Load(object sender, EventArgs e)
        {
            //BUTTON TİPİ
            btnTahmin.TabStop = false;
            btnTahmin.FlatStyle = FlatStyle.Flat;
            btnTahmin.FlatAppearance.BorderSize = 0;
            btnNewGame.TabStop = false;
            btnNewGame.FlatStyle = FlatStyle.Flat;
            btnNewGame.FlatAppearance.BorderSize = 0;
            //
            int sayac = 0;
            Random RastgeleSayi = new Random();
            //string sayi1 = "";
            string bir, iki, uc, dort;
            while (sayac==0)
            {
                sayi1 = RastgeleSayi.Next(1023, 9876).ToString();
                bir = sayi1.Substring(0, 1);
                iki = sayi1.Substring(1, 1);
                uc = sayi1.Substring(2, 1);
                dort = sayi1.Substring(3, 1);
                if (bir != iki && bir != uc && bir != dort && iki != uc && iki != dort && uc != dort)
                {
                    labelSayi.Text = sayi1;
                }
                else  //Eğer rakamları farklı sayı üretemezse üretene kadar yeni başlat.
                {
                    Application.Restart();
                }
                sayac++;
            }//while sonu
        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {
            adim_sayisi++;
            lblAdim.Text =("Adım Sayiniz: " + adim_sayisi.ToString());
            int sayi = Convert.ToInt32(sayi1);
            tahmin_Sayisi = txtBoxTahmin.Text; //tahmini String olarak aldım.
            int tahmin_edilen_deger = Convert.ToInt32(tahmin_Sayisi);
            if (tahmin_edilen_deger < sayi)
            {
                lblTahminFarkı.Text = "Tahmin değeriniz Sayı'dan küçük!";
                //MessageBox.Show("Tahmin değeriniz Sayı'dan küçük!");
                
            }
            else if (tahmin_edilen_deger > sayi)
            {
                lblTahminFarkı.Text = "Tahmin değeriniz Sayı'dan büyük!";
                //MessageBox.Show("Tahmin ettiğiniz sayı değeri Sayı'dan büyük!");

            }
            else
                lblTahminFarkı.Text = "Tebrikler Kazandınız!";
            if(lblTahminFarkı.Text== "Tebrikler Kazandınız!")
            {
                txtBoxTahmin.Visible = false;
                MessageBox.Show("Yeni oyun başlatılıyor!");
                System.Threading.Thread.Sleep(2000);
                Application.Restart();
            }
                
               
            //MessageBox.Show("Tebrikler Kazandınız!");
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni Oyun Başlatılıyor!");
            Application.Restart();
        }

        private void txtBoxTahmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }//form1 load sonu
    }


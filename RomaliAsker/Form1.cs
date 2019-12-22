using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RomaliAsker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                
                    lblSnc1.Text = "";
                    lblSnc2.Text = "";
                    lblSure.Text = "";
                    lblKontrol.Text = "";
                    int sayi = Convert.ToInt32(txtSayi.Text);
                    int adim = Convert.ToInt32(txtAdim.Text);
                    int sayac = sayi;//sayacı sayıya eşitlemekte amaç 2 değer kalana kadar her do while döngüsünde 1 azaltarak 2 kalınca döngüden çıkarmak
                    int[] dizi = new int[sayi];
                    int deger = 1;

                    for (int i = 0; i < sayi; i++)//dizi elemanlarına değer ata
                    {
                        dizi[i] = deger;
                        deger++;
                    }

                    int a = adim - 1;//-1 olmasının nedeni a yı dizilerde kullanacağımız için doğru değer olması için 1 eksik olmalı

                    do
                    {
                        int sayac2 = 0;
                        for (; ; )//bu döngü içinde a nıncı sayının 0 olup olmadığını kontrol ediyoruz eğer 0 sa + değer bulana kadar bir artıyor
                        {
                            if (dizi[a] == 0)
                            {
                                a++;
                                if (a > sayi - 1)//a arttığında eğer diziden fazla bi değer olursa dizinin başına dön
                                {
                                    a = 0;
                                }
                            }
                            else
                                break;
                        }//0 değeri değilse fordan çık

                        if (dizi[a] != 0)
                        {
                            dizi[a] = 0;

                            for (int i = a + 1; i < a + adim + sayac2; i++)
                            {//bu forun içinde a değerini 0 a eşitledikten sonra a'nın 1 sonrasındaki değerden adıma kadar 0 değeri varsa o 0 değerleri adımdan sayılmayacağı için onları sayac2 ye eklemek ve onları daha sonra fazladan adım olarak kullanmak 
                                int cevap = i;

                                if (cevap > sayi - 1)
                                {
                                    cevap = (cevap % sayi); //eğer değer diziden büyükse dizinin başına dönülüyor
                                }
                                if (dizi[cevap] == 0)// 0 değeri varsa sayaca ekleniyor
                                    sayac2++;
                            }//for sonu

                            a = a + adim + sayac2; // arada 0 değer varsa a'ya adım olarak ekleniyor

                            if (a > sayi - 1)
                            {
                                a = (a % sayi);//eğer değer diziden büyükse dizinin başına dönülüyor
                            }
                        }

                        sayac--;//baştaki adıma eşit olan sayac 1 azaltılıyor ve 2 olana kadar döngü devam ediyor
                    } while (sayac != 2);

                    for (int i = 0; i < sayi; i++)
                    {
                        if (dizi[i] == 0)
                            continue;
                        else
                        {
                            if (lblSnc1.Text == "")
                            {
                                lblSnc1.Text = Convert.ToString(dizi[i]);
                            }
                            else
                                lblSnc2.Text = Convert.ToString(dizi[i]);
                        }
                    }

                
                watch.Stop();
                lblSure.Text = Convert.ToString(watch.Elapsed.Milliseconds);
            }//try sonu

            catch (Exception)
            {   
                lblKontrol.Text = "Geçerli Değer Giriniz...";   
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;


namespace CamasirMakinesiYapayZekaOdev3
{
    public partial class Form1 : Form
    {
        public Series cizgi1;
        public Series cizgi2;
        public Series cizgi3;
        public Series nokta1;
        public Chart grafik = new Chart();

        private List<Veri> veriler;
        public DataGridView dataGridView1;

        public string hasUye;
        public string mikUye;
        public string kirUye;

        public List<double> mamdaniFirst = new List<double>();
        public List<string> donusName = new List<string>();
        public List<string> sureName = new List<string>();
        public List<string> deterName = new List<string>();
        public Form1()
        {
            InitializeComponent();

            grafik.Size = new System.Drawing.Size(500, 150);

            ChartArea alan = new ChartArea();
            alan.Name = "GrafikAlanı";

            // X ekseninin sınırlarını ayarlama
            alan.AxisX.Minimum = 0;
            alan.AxisX.Maximum = 10;

            // Y ekseninin sınırlarını ayarlama
            alan.AxisY.Minimum = 0;
            alan.AxisY.Maximum = 1;
            grafik.ChartAreas.Add(alan);

            // Sabit çizgi oluşturma

            //1.Çizgi
            cizgi1 = new Series();
            cizgi1.ChartArea = "GrafikAlanı";
            cizgi1.ChartType = SeriesChartType.Line;
            cizgi1.Points.AddXY(0, 1);
            cizgi1.Points.AddXY(2, 1);
            cizgi1.Points.AddXY(4, 0);
            cizgi1.Color = System.Drawing.Color.Blue;
            grafik.Series.Add(cizgi1);

            //2.Çizgi
            cizgi2 = new Series();
            cizgi2.ChartArea = "GrafikAlanı";
            cizgi2.ChartType = SeriesChartType.Line;
            cizgi2.Points.AddXY(3, 0);
            cizgi2.Points.AddXY(5, 1);
            cizgi2.Points.AddXY(7, 0);
            cizgi2.Color = System.Drawing.Color.Green;
            grafik.Series.Add(cizgi2);

            //3.Çizgi
            cizgi3 = new Series();
            cizgi3.ChartArea = "GrafikAlanı";
            cizgi3.ChartType = SeriesChartType.Line;
            cizgi3.Points.AddXY(5.5, 0);
            cizgi3.Points.AddXY(8, 1);
            cizgi3.Points.AddXY(10, 1);
            cizgi3.Color = System.Drawing.Color.DeepPink;
            grafik.Series.Add(cizgi3);

            // Grafik konumunu ayarlama
            grafik.Location = new System.Drawing.Point(200, 0);

            // Forma grafik ekleme
            this.Controls.Add(grafik);

            veriler = new List<Veri>();
            veriler.Add(new Veri(1, "hassas", "küçük", "küçük", "hassas", "kısa", "çok_az"));
            veriler.Add(new Veri(2, "hassas", "küçük", "orta", "normal_hassas", "kısa", "az"));
            veriler.Add(new Veri(3, "hassas", "küçük", "büyük", "orta", "normal_kısa", "orta"));
            veriler.Add(new Veri(4, "hassas", "orta", "küçük", "hassas", "kısa", "orta"));
            veriler.Add(new Veri(5, "hassas", "orta", "orta", "normal_hassas", "normal_kısa", "orta"));
            veriler.Add(new Veri(6, "hassas", "orta", "büyük", "orta", "orta", "fazla"));
            veriler.Add(new Veri(7, "hassas", "büyük", "küçük", "normal_hassas", "normal_kısa", "orta"));
            veriler.Add(new Veri(8, "hassas", "büyük", "orta", "normal_hassas", "orta", "fazla"));
            veriler.Add(new Veri(9, "hassas", "büyük", "büyük", "orta", "normal_uzun", "fazla"));
            veriler.Add(new Veri(10, "orta", "küçük", "küçük", "normal_hassas", "normal_kısa", "az"));
            veriler.Add(new Veri(11, "orta", "küçük", "orta", "orta", "kısa", "orta"));
            veriler.Add(new Veri(12, "orta", "küçük", "büyük", "normal_güçlü", "orta", "fazla"));
            veriler.Add(new Veri(13, "orta", "orta", "küçük", "normal_hassas", "normal_kısa", "orta"));
            veriler.Add(new Veri(14, "orta", "orta", "orta", "orta", "orta", "orta"));
            veriler.Add(new Veri(15, "orta", "orta", "büyük", "orta", "uzun", "fazla"));
            veriler.Add(new Veri(16, "orta", "büyük", "küçük", "hassas", "orta", "orta"));
            veriler.Add(new Veri(17, "orta", "büyük", "orta", "hassas", "normal_uzun", "fazla"));
            veriler.Add(new Veri(18, "orta", "büyük", "büyük", "hassas", "uzun", "çok_fazla"));
            veriler.Add(new Veri(19, "sağlam", "küçük", "küçük", "orta", "orta", "az"));
            veriler.Add(new Veri(20, "sağlam", "küçük", "orta", "normal_güçlü", "orta", "orta"));
            veriler.Add(new Veri(21, "sağlam", "küçük", "büyük", "güçlü", "normal_uzun", "fazla"));
            veriler.Add(new Veri(22, "sağlam", "orta", "küçük", "orta", "orta", "orta"));
            veriler.Add(new Veri(23, "sağlam", "orta", "orta", "normal_güçlü", "normal_uzun", "orta"));
            veriler.Add(new Veri(24, "sağlam", "orta", "büyük", "güçlü", "orta", "çok_fazla"));
            veriler.Add(new Veri(25, "sağlam", "büyük", "küçük", "normal_güçlü", "normal_uzun", "fazla"));
            veriler.Add(new Veri(26, "sağlam", "büyük", "orta", "normal_güçlü", "uzun", "fazla"));
            veriler.Add(new Veri(27, "sağlam", "büyük", "büyük", "güçlü", "uzun", "çok_fazla"));

            this.dataGridView1 = new DataGridView();
            dataGridView1.Location = new System.Drawing.Point(225, 175);
            dataGridView1.Size = new System.Drawing.Size(700, 200);
            this.dataGridView1.Columns.Add("No", "No");
            this.dataGridView1.Columns.Add("Hassaslık", "Hassaslık");
            this.dataGridView1.Columns.Add("Miktar", "Miktar");
            this.dataGridView1.Columns.Add("Kirlilik", "Kirlilik");
            this.dataGridView1.Columns.Add("Dönüş Hızı", "Dönüş Hızı");
            this.dataGridView1.Columns.Add("Süre", "Süre");
            this.dataGridView1.Columns.Add("Deterjan", "Deterjan");

            

            foreach (var veri in veriler)
            {
                this.dataGridView1.Rows.Add(
                    veri.No,
                    veri.Hassaslık,
                    veri.Miktar,
                    veri.Kirlilik,
                    veri.DönüşHızı,
                    veri.Süre,
                    veri.Deterjan
                );
            }

            this.Controls.Add(dataGridView1);
        }

        /*public void drawPoint(double x, double y)
        {
            Console.WriteLine("Üyelik Hesaplandı...");
            nokta1 = new Series();
            nokta1.ChartArea = "GrafikAlanı";
            nokta1.ChartType = SeriesChartType.Line;
            nokta1.Points.AddXY(x, y);
            nokta1.Points.AddXY(x, y+0.01);
            nokta1.Color = System.Drawing.Color.Red;
            nokta1.BorderWidth = 7;
            grafik.Series.Add(nokta1);
        }*/
        public class Veri
        {
            public int No { get; set; }
            public string Hassaslık { get; set; }
            public string Miktar { get; set; }
            public string Kirlilik { get; set; }
            public string DönüşHızı { get; set; }
            public string Süre { get; set; }
            public string Deterjan { get; set; }
            public Veri(int no, string hassaslık, string miktar, string kirlilik, string dönüşHızı, string süre, string deterjan)
            {
                No = no;
                Hassaslık = hassaslık;
                Miktar = miktar;
                Kirlilik = kirlilik;
                DönüşHızı = dönüşHızı;
                Süre = süre;
                Deterjan = deterjan;
            }
        }

        // Üyelik Değeri Hesaplama
        public double getYValue(Series series, double xValue)
        {
            double yValue = 0;

            if (series != null && series.Points != null)
            {
                for (int i = 1; i < series.Points.Count; i++)
                {
                    if (series.Points[i - 1].XValue <= xValue && series.Points[i].XValue >= xValue)
                    {
                        // xValue ile i-1 ve i arasındaki noktaları bulduk
                        // lineer interpolasyon kullanarak y değerini hesapla
                        double x0 = series.Points[i - 1].XValue;
                        double x1 = series.Points[i].XValue;

                        // YValues dizisinin boyutunu kontrol et
                        if (series.Points[i - 1].YValues.Length > 0 && series.Points[i].YValues.Length > 0)
                        {
                            double y0 = series.Points[i - 1].YValues[0];
                            double y1 = series.Points[i].YValues[0];

                            yValue = y0 + ((xValue - x0) / (x1 - x0)) * (y1 - y0);
                        }
                        break;
                    }
                }
            }

            return yValue;
        }

        public void paintLine(int lineNum)
        {
            dataGridView1.Rows[lineNum - 1].DefaultCellStyle.BackColor = Color.Blue;
        }

        public void CalculateMemberDegree(double hasNum, double mikNum, double kirNum, int hasNo, int mikNo, int kirNo)
        {
            double hasNum1 = 0;
            double mikNum1 = 0;
            double kirNum1 = 0;
            //Hassasiyet
            if (hasNo == 1)
            {
                hasNum1 = getYValue(cizgi1, hasNum);
            }
            else if (hasNo == 2)
            {
                hasNum1 = getYValue(cizgi2, hasNum);
            }
            else if (hasNo == 3)
            {
                hasNum1 = getYValue(cizgi1, hasNum);
            }

            //Miktar
            if (mikNo == 1)
            {
                mikNum1 = getYValue(cizgi1, mikNum);
            }
            else if (mikNo == 2)
            {
                mikNum1 = getYValue(cizgi2, mikNum);
            }
            else if (mikNo == 3)
            {
                mikNum1 = getYValue(cizgi1, mikNum);
            }

            //Kirlilik
            if (kirNo == 1)
            {
                kirNum1 = getYValue(cizgi1, kirNum);
            }
            else if (kirNo == 2)
            {
                kirNum1 = getYValue(cizgi2, kirNum);
            }
            else if (kirNo == 3)
            {
                kirNum1 = getYValue(cizgi1, kirNum);
            }

            //MAMDANI ILK AŞAMA
            Console.WriteLine("Hassasiyet: " + hasNum1 + " Miktar: " + mikNum1 +" Kirlilik: " + kirNum1);
            double minNum = Math.Min(Math.Min(hasNum1, mikNum1), kirNum1);
            mamdaniFirst.Add(minNum);

            richTextBox1.AppendText($"\n{hasNum1}\n{mikNum1}\n{kirNum1}");
        }
        private void CalculateCentroid(List<string> name, List<double> number, int processNum)
        {
            List<Tuple<string, double>> matchList = new List<Tuple<string, double>>();
            for (int i = 0; i < Math.Min(name.Count, number.Count); i++)
            {
                Tuple<string, double> tuple = new Tuple<string, double>(name[i], number[i]);
                matchList.Add(tuple);
            }

            Dictionary<string, double> totalValues = new Dictionary<string, double>();
            foreach (var tuple in matchList)
            {
                if (!totalValues.ContainsKey(tuple.Item1))
                {
                    totalValues[tuple.Item1] = 0;
                }
                totalValues[tuple.Item1] += tuple.Item2;
            }


            List<double> mamdaniMax = new List<double>();
            foreach (var tuple in matchList)
            {
                if (totalValues.ContainsKey(tuple.Item1))
                {
                    mamdaniMax.Add(totalValues[tuple.Item1]);
                    totalValues.Remove(tuple.Item1);
                }
                else
                {
                    mamdaniMax.Add(tuple.Item2);
                }
            }

            mamdaniMax.RemoveAll(i => i == 0);
            double a = 0;
            double b = 0;
            double average = 0;
            double count = 0;
            foreach (var i in mamdaniMax)
            {
                count++;
                average += i;
            }
            average /= count;

            while (true)
            {
                if (a == 0) { 
                    a = mamdaniMax.Max();
                    mamdaniMax.Remove(a);
                }
                else if (b == 0)
                {
                    try
                    {
                        b = mamdaniMax.Max();
                    }
                    catch {
                        break;
                    }
                }
                else if (a == b)
                {
                    mamdaniMax.Remove(b);
                    b = 0;
                }
                else
                {
                    break;
                }
            }

            double firstNum = a;
            double secondNum = b;

            
            //1.Değer a | 2.Değer b
            // 1: Dönüş Hızı, 2: Süre, 3: Deterjan  
            if (processNum == 1)
            {
                average *= 10;
                label12.Text = average.ToString();
                double A = average;
                a = 0;
                b = 0;
                if (A <= 0.5)
                {
                    a = 0;
                    b = 0.5;
                }
                else if(A <= 1.5)
                {
                    a = 0.5;
                    b = 1.5;
                }
                else if (A <= 2.75)
                {
                    a = 1.5;
                    b = 2.75;
                }
                else if (A <= 5)
                {
                    a = 2.75;
                    b = 5;
                }
                else if (A <= 7.25)
                {
                    a = 5;
                    b = 7.25;
                }
                else if (A <= 8.5)
                {
                    a = 7.25;
                    b = 8.5;
                }
                else if (A <= 9.5)
                {
                    a = 8.5;
                    b = 9.5;
                }

                double Centroid = (firstNum*a + secondNum*b)/(firstNum+secondNum);
                label10.Text = Centroid.ToString();
            }

            else if (processNum == 2)
            {
                average *= 100;
                label18.Text = average.ToString();
                double A = average;
                a = 0;
                b = 0;
                if (A <= 22.5)
                {
                    a = 0;
                    b = 22.5;
                }
                else if (A <= 40)
                {
                    a = 22.5;
                    b = 40;
                }
                else if (A <= 57.5)
                {
                    a = 40;
                    b = 57.5;
                }
                else if (A <= 75)
                {
                    a = 57.5;
                    b = 75;
                }
                else if (A <= 92.5)
                {
                    a = 75;
                    b = 92.5;
                }
                else if (A <= 100)
                {
                    a = 92.5;
                    b = 100;
                }

                double Centroid = (firstNum * a + secondNum * b) / (firstNum + secondNum);
                label16.Text = Centroid.ToString();
            }
            else if (processNum == 3)
            {
                average *= 300;
                label24.Text = average.ToString();
                double A = average;
                a = 0;
                b = 0;
                if (A <= 20)
                {
                    a = 0;
                    b = 20;
                }
                else if (A <= 85)
                {
                    a = 20;
                    b = 85;
                }
                else if (A <= 150)
                {
                    a = 85;
                    b = 150;
                }
                else if (A <= 215)
                {
                    a = 150;
                    b = 215;
                }
                else if (A <= 280)
                {
                    a = 215;
                    b = 280;
                }
                else if (A <= 300)
                {
                    a = 280;
                    b = 300;
                }

                double Centroid = (firstNum * a + secondNum * b) / (firstNum + secondNum);
                label22.Text = Centroid.ToString();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double hasNum = (double)numericUpDown1.Value;
            double kirNum = (double)numericUpDown2.Value;
            double mikNum = (double)numericUpDown3.Value;

            string donusHizi, sure, deterjan;   

            Console.WriteLine("HAS: " + hasNum + " KİR: "+ kirNum + " MİK: " + mikNum);

            string hasUye = null, kirUye=null, mikUye=null;

            
            //HASSASLIK UYELIK HESAPLAMASI
            if (hasNum <= 3)
            {
                hasUye = "saglam";
                double hasNum1 = getYValue(cizgi1, hasNum);
                Console.WriteLine(hasNum1);
            }
            else if(hasNum >= 3 && hasNum <= 4)
            {
                hasUye = "saglam-orta";
                if(hasNum >= 3 && hasNum <= 3.5)
                {
                    double hasNum1 = getYValue(cizgi2, hasNum);
                    Console.WriteLine(hasNum1);
                }
                else if (hasNum >= 3.5 && hasNum <= 4)
                {
                    double hasNum1 = getYValue(cizgi1, hasNum);
                    Console.WriteLine(hasNum1);
                }
            }
            else if (hasNum > 4 && hasNum < 5.5)
            {
                hasUye = "orta";
                double hasNum1 = getYValue(cizgi2, hasNum);
                Console.WriteLine(hasNum1);
            }
            else if (hasNum >= 5.5 && hasNum <= 7)
            {
                hasUye = "orta-hassas";
                if (hasNum >= 5.5 && hasNum <= 6.25)
                {
                    double hasNum1 = getYValue(cizgi3, hasNum);
                    Console.WriteLine(hasNum1);
                }
                else if (hasNum >= 6.25 && hasNum <= 7)
                {
                    double hasNum1 = getYValue(cizgi2, hasNum);
                    Console.WriteLine(hasNum1);
                }
            }
            else if (hasNum > 7 && hasNum <= 10)
            {
                hasUye = "hassas";
                
                double hasNum1 = getYValue(cizgi3, hasNum);
                Console.WriteLine(hasNum1);
                
            }

            //MIKTAR UYELIK HESAPLAMASI
            if (mikNum < 3)
            {
                mikUye = "kucuk";
                double mikNum1 = getYValue(cizgi1, mikNum);
                Console.WriteLine(mikNum1);
            }
            else if (mikNum >= 3 && mikNum <= 4)
            {
                mikUye = "kucuk-orta";
                if (mikNum >= 3 && mikNum <= 3.5)
                {
                    double mikNum1 = getYValue(cizgi2, mikNum);
                    Console.WriteLine(mikNum1);
                }
                else if (mikNum >= 3.5 && mikNum <= 4)
                {
                    double mikNum1 = getYValue(cizgi1, mikNum);
                    Console.WriteLine(mikNum1);
                }
            }
            else if (mikNum > 4 && mikNum < 5.5)
            {
                mikUye = "orta";
                double mikNum1 = getYValue(cizgi2, mikNum);
                Console.WriteLine(mikNum1);
            }
            else if (mikNum >= 5.5 && mikNum <= 7)
            {
                mikUye = "orta-buyuk";
                if (mikNum >= 5.5 && mikNum <= 6.25)
                {
                    double mikNum1 = getYValue(cizgi3, mikNum);
                    Console.WriteLine(mikNum1);
                }
                else if (mikNum >= 6.25 && mikNum <= 7)
                {
                    double mikNum1 = getYValue(cizgi2, mikNum);
                    Console.WriteLine(mikNum1);
                }
            }
            else if (mikNum > 7 && mikNum <= 10)
            {
                mikUye = "buyuk";
                double mikNum1 = getYValue(cizgi3, mikNum);
                Console.WriteLine(mikNum1);
            }

            //KIRLILIK UYELIK HESAPLAMASI
            if (kirNum < 3)
            {
                kirUye = "kucuk";
                double kirNum1 = getYValue(cizgi1, kirNum);
                Console.WriteLine(kirNum1);
            }
            else if (kirNum >= 3 && kirNum <= 4)
            {
                kirUye = "kucuk-orta";
                if (kirNum >= 3 && kirNum <= 3.5)
                {
                    double kirNum1 = getYValue(cizgi2, kirNum);
                    Console.WriteLine(kirNum1);
                }
                else if (kirNum >= 3.5 && kirNum <= 4)
                {
                    double kirNum1 = getYValue(cizgi1, kirNum);
                    Console.WriteLine(kirNum1);
                }
            }
            else if (kirNum > 4 && kirNum < 5.5)
            {
                kirUye = "orta";
                double kirNum1 = getYValue(cizgi2, kirNum);
                Console.WriteLine(kirNum1);
            }
            else if (kirNum >= 5.5 && kirNum <= 7)
            {
                kirUye = "orta-buyuk";
                if (kirNum >= 5.5 && kirNum <= 6.25)
                {
                    double kirNum1 = getYValue(cizgi3, kirNum);
                    Console.WriteLine(kirNum1);
                }
                else if (kirNum >= 6.25 && kirNum <= 7)
                {
                    double kirNum1 = getYValue(cizgi2, kirNum);
                    Console.WriteLine(kirNum1);
                }
            }
            else if (kirNum > 7 && kirNum <= 10)
            {
                kirUye = "buyuk";
                double kirNum1 = getYValue(cizgi3, kirNum);
                Console.WriteLine(kirNum1);
            }

            label7.Text = hasUye; label8.Text = mikUye; label9.Text = kirUye;

            Console.WriteLine("Hassaslık: " + hasUye + " Miktar: " + mikUye + " Kirlilik: " + kirUye);

            //1 kucuk-kucuk-kucuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
            {
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1, 1, 1);

                paintLine(1);
                donusHizi = "Hassas"; sure = "Kısa"; deterjan = "cok_az"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan); donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //2 kucuk-kucuk-orta
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
            {
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1, 1, 2);
                paintLine(2);
                donusHizi = "Hassas"; sure = "Kısa"; deterjan = "cok_az"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //3 kucuk-kucuk-buyuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&(mikUye == "kucuk" || mikUye == "kucuk-orta" ) && (kirUye == "buyuk" || kirUye == "orta-buyuk"))
            {
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1, 1,3);
                paintLine(3);
                donusHizi = "Orta"; sure = "Kısa"; deterjan = "cok_az"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //4 kucuk-orta-kucuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
            {

                CalculateMemberDegree(hasNum, mikNum, kirNum, 1, 2,1);
                paintLine(4);
                donusHizi = "Hassas"; sure = "Kısa"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //5 kucuk-orta-orta
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{

                CalculateMemberDegree(hasNum, mikNum, kirNum, 1, 2,2);
                paintLine(5);
                donusHizi = "Normal_Hassas"; sure = "Normal_Kısa"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //6 kucuk-orta-buyuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1,2,3);
                paintLine(6);
                donusHizi = "Orta"; sure = "Orta"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //7 kucuk-buyuk-kucuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1,3,1);
                paintLine(7);
                donusHizi = "Normal_Hassas"; sure = "Normal_Kısa"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //8 kucuk-buyuk-orta
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 1,3,2);
                paintLine(8);
                donusHizi = "Normal_Hassas"; sure = "Orta"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //9 kucuk-buyuk-buyuk
            if ((hasUye == "hassas" || hasUye == "orta-hassas" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{

                CalculateMemberDegree(hasNum, mikNum, kirNum, 1,3,3);
                paintLine(9);
                donusHizi = "Orta"; sure = "Normal_Uzun"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //10 orta-kucuk-kucuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,1,1);
                paintLine(10);
                donusHizi = "Normal_Hassas"; sure = "Normal_Kısa"; deterjan = "Az"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //11 orta-kucuk-orta
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,1,2);
                paintLine(11);
                donusHizi = "Orta"; sure = "Kısa"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //12 orta-kucuk-buyuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,1,3);
                paintLine(12);
                donusHizi = "Normal_Güçlü"; sure = "Orta"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //13 orta-orta-kucuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,2,1);
                paintLine(13);
                donusHizi = "Normal_Hassas"; sure = "Normal_Kısa"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //14 orta-orta-orta
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,2,2);
                paintLine(14);
                donusHizi = "Orta"; sure = "Orta"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //15 orta-orta-buyuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,2,3);
                paintLine(15);
                donusHizi = "Hassas"; sure = "Uzun"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //16 orta-buyuk-kucuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,3,1);
                paintLine(16);
                donusHizi = "Hassas"; sure = "Orta"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //17 orta-buyuk-orta
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,3,2);
                paintLine(17);
                donusHizi = "Hassas"; sure = "Normal_Uzun"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //18 orta-buyuk-buyuk
            if ((hasUye == "orta" || hasUye == "orta-hassas" || hasUye == "orta-buyuk" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 2,3,3);
                paintLine(18);
                donusHizi = "Hassas"; sure = "Uzun"; deterjan = "Çok_Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //19 buyuk-kucuk-kucuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,1,1);
                paintLine(19);
                donusHizi = "Orta"; sure = "Orta"; deterjan = "Az"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //20 buyuk-kucuk-orta
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,1,2);
                paintLine(20);
                donusHizi = "Normal_Güçlü"; sure = "Orta"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //21 buyuk-kucuk-buyuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "kucuk" || mikUye == "kucuk-orta" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{ 
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,1,3);
                paintLine(21);
                donusHizi = "Güçlü"; sure = "Normal_Uzun"; deterjan = "Fazla";
            }
            //22 buyuk-orta-kucuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,2,1);
                paintLine(22);
                donusHizi = "Orta"; sure = "Orta"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //23 buyuk-orta-orta
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,2,2);
                paintLine(23);
                donusHizi = "Normal_Güçlü"; sure = "Normal_Uzun"; deterjan = "Orta"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //24 buyuk-orta-buyuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "orta" || mikUye == "kucuk-orta" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,2,3);
                paintLine(24);
                donusHizi = "Güçlü"; sure = "Orta"; deterjan = "Çok_Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //25 buyuk-buyuk-kucuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "kucuk" || kirUye == "kucuk-orta"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,3,1);
                paintLine(25);
                donusHizi = "Normal_Güçlü"; sure = "Normal_Uzun"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //26 buyuk-buyuk-orta
            if ((hasUye == "saglam" || hasUye == "saglam-orta" )&&( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "orta" || kirUye == "kucuk-orta" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3,3,2);
                paintLine(26);
                donusHizi = "Normal_Güçlü"; sure = "Uzun"; deterjan = "Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            //27 buyuk-buyuk-buyuk
            if ((hasUye == "saglam" || hasUye == "saglam-orta" ) && ( mikUye == "buyuk" || mikUye == "orta-buyuk" )&&( kirUye == "buyuk" || kirUye == "orta-buyuk"))
{
                CalculateMemberDegree(hasNum, mikNum, kirNum, 3, 3, 3);
                paintLine(27);
                donusHizi = "Güçlü"; sure = "Uzun"; deterjan = "Çok_Fazla"; donusName.Add(donusHizi); sureName.Add(sure); deterName.Add(deterjan);
            }
            

            CalculateCentroid(donusName, mamdaniFirst, 1);
            CalculateCentroid(sureName, mamdaniFirst, 2);
            CalculateCentroid(deterName, mamdaniFirst, 3);
        }
    }
}

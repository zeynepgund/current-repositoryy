using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dovizson2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            string TCMB_Kur = "https://www.tcmb.gov.tr/kurlar/today.xml";

            var TCMB_xml = new XmlDocument();
            string USDAlis;
            string USDSatis;
            string GBPAlis;
            string GBPSatis;
            string EUROAlis;
            string EUROSatis;
            TCMB_xml.Load(TCMB_Kur);

            USDAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            USDSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            GBPAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP'/ForexBuying").InnerXml;
            GBPSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP'/ForexSelling").InnerXml;
            EUROAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR'/ForexBuying").InnerXml;
            EUROSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR'/ForexSelling").InnerXml;

            LbDolarAlis.Text = USDAlis;
            LbDolarSatis.Text = USDSatis;
            LbGbpAlis.Text = GBPAlis;
            LbGbpSatis.Text = GBPSatis;
            LbEuroAlis.Text = EUROAlis;
            LbEuroSatis.Text = EUROSatis;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string TCMB_Kur = "https://www.tcmb.gov.tr/kurlar/today.xml";

            var TCMB_xml = new XmlDocument();
            string USDAlis;
            string USDSatis;
            string GBPAlis;
            string GBPSatis;
            string EUROAlis;
            string EUROSatis;

            TCMB_xml.Load(TCMB_Kur);
            USDAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            USDSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            GBPAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;
            GBPSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;
            EUROAlis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;
            EUROSatis = TCMB_xml.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;

            LbDolarAlis.Text = USDAlis;
            LbDolarSatis.Text = USDSatis;
            LbGbpAlis.Text = GBPAlis;
            LbGbpSatis.Text = GBPSatis;
            LbEuroAlis.Text = EUROAlis;
            LbEuroSatis.Text = EUROSatis;
        }
        private void button2_Click(object sender, EventArgs e)

        {
            decimal miktar;
            nmSonuc.Minimum = 0; 
            nmSonuc.Maximum = decimal.MaxValue; 
            {
                if (decimal.TryParse(DovizTutar.Text, out miktar))
                {
                    decimal USDAlis;
                    if (decimal.TryParse(LbDolarAlis.Text, out USDAlis))
                    {
                        decimal sonuc = miktar * USDAlis;

                        if (sonuc < nmSonuc.Minimum)
                        {
                            sonuc = nmSonuc.Minimum;
                        }
                        else if (sonuc > nmSonuc.Maximum)
                        {
                            sonuc = nmSonuc.Maximum;
                        }

                        nmSonuc.Value = Convert.ToDecimal(sonuc);
                    }
                    decimal GBPAlis;
                    if (decimal.TryParse(LbGbpAlis.Text, out GBPAlis))
                    {
                        decimal sonuc = miktar * GBPAlis;

                        if (sonuc < nmSonuc.Minimum)
                        {
                            sonuc = nmSonuc.Minimum;
                        }
                        else if (sonuc > nmSonuc.Maximum)
                        {
                            sonuc = nmSonuc.Maximum;
                        }

                        nmSonuc.Value = Convert.ToDecimal(sonuc);
                    }
                    else
                    {
                        MessageBox.Show("Sterlin alış fiyatı alınamadı.");
                    }
                    decimal EUROAlis;
                    if (decimal.TryParse(LbEuroAlis.Text, out EUROAlis))
                    {
                        decimal sonuc = miktar * EUROAlis;
                        if (sonuc < nmSonuc.Minimum)
                        {
                            sonuc = nmSonuc.Minimum;
                        }
                        else if (sonuc > nmSonuc.Maximum)
                        {
                            sonuc = nmSonuc.Maximum;
                        }

                        nmSonuc.Value = Convert.ToDecimal(sonuc);
                        
                    }

                    
                }

            }

        }

        
    }
}

      





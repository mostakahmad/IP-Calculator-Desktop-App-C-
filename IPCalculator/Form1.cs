using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        long frst;
        long scnd;
        long thrd;
        long frth;
        long cidr;
        long nth;
        int block_4th, block_3rd, block_2nd;

        private void getIP1_Click(object sender, EventArgs e)
        {
            if (ipNum1.Text != "" && ipNum2.Text != "" && ipNum3.Text != "" && ipNum4.Text != "")
            {
                frst = Convert.ToInt64(ipNum1.Text);
                scnd = Convert.ToInt64(ipNum2.Text);
                thrd = Convert.ToInt64(ipNum3.Text);
                frth = Convert.ToInt64(ipNum4.Text);


                if ((frst < 0 || frst > 255) || (scnd < 0 || scnd > 255) || (thrd < 0 || thrd > 255) || (frth < 0 || frth > 255))
                {
                    MessageBox.Show("          Your IP Address Is Invalid\n\t\tPlease Retry");
                    ipNum1.Text = "";
                    ipNum2.Text = "";
                    ipNum3.Text = "";
                    ipNum4.Text = "";
                }

                else
                {

                    if (nthNum1.Text != "")
                    {
                        //calculation code
                        nth = Convert.ToInt64(nthNum1.Text);
                        
                        long  res = (frst*16581375)+(scnd*65025)+(thrd*255)+frth+nth;
                        

                        if (res > 4244897280)
                        {
                            MessageBox.Show("THE "+nth+"th IP IS NOT VALID IN IPV4");
                            nthNum1.Text = "";
                        }
                        else
                        {
                            frst = (res / 16581375);
                            if (frst>255)
                            {
                                frst = 255;
                            }
                            res = res - (frst * 16581375);

                            scnd = (res / 65025);
                            if (scnd > 255)
                            {
                                scnd = 255;
                            }
                            res = res - (scnd * 65025);

                            thrd = (res / 255);
                            if (thrd > 255)
                            {
                                thrd = 255;
                            }
                            res = res - (thrd * 255);
                            frth = res;




                            outPut2.Text = "The " + nth + "th IP";
                            //outPut3.Text = "Of " + ipNum1.Text + "." + ipNum2.Text + "." + ipNum3.Text + "." + ipNum4.Text + " Is: ";
                            outPut1.Text = frst + "." + scnd + "." + thrd.ToString() + "." + frth.ToString();
                            outPut3.Text = "IS";
                        }
                        


                        
                    }
                    else
                    {
                        if (nthNum1.Text != "")
                            MessageBox.Show("          You Give A Negative Number\n\tPlease Give A Positive Value");
                        else
                            MessageBox.Show("          Please Give the nth Number");

                        nthNum1.Text = "";
                    }
                }
            }



            else
            {
                MessageBox.Show("          Your IP Address Is Invalid\n\tPlease Retry");
                ipNum1.Text = "";
                ipNum2.Text = "";
                ipNum3.Text = "";
                ipNum4.Text = "";
            }

            


        }

        private void ipNum1_TextChanged(object sender, EventArgs e)
        {

        }

        //IP IDENTIFICATION
        private void button1_Click(object sender, EventArgs e)
        {
            if (ipNumID1.Text != "" && ipNumID2.Text != "" && ipNumID3.Text != "" && ipNumID4.Text != "")
            {
                frst = Convert.ToInt32(ipNumID1.Text);
                scnd = Convert.ToInt32(ipNumID2.Text);
                thrd = Convert.ToInt32(ipNumID3.Text);
                frth = Convert.ToInt32(ipNumID4.Text);
                if (cidrNumID1.Text!="")
                    cidr = Convert.ToInt32(cidrNumID1.Text);


                if ((frst < 0 || frst > 255) || (scnd < 0 || scnd > 255) || (thrd < 0 || thrd > 255) || (frth < 0 || frth > 255))
                {
                    MessageBox.Show("          Your IP Address Is Invalid\n\t\tPlease Retry");
                    ipNumID1.Text = "";
                    ipNumID2.Text = "";
                    ipNumID3.Text = "";
                    ipNumID4.Text = "";
                }

                else if (frst == 127)   //&& cidr >= 1 && cidr <= 32
                {
                    outPutID1.Text = "THIS IS A CLASS \"A\" IP";
                    outPutID2.Text = "  - 127.x.x.x Series IP's are Reserved";
                    outPutID3.Text = "  - Reserved for Loopback & Use is:-";
                    outPutID4.Text = "    \"Internal Testing on the Local Machine.\"";

                }
                else if (frst >= 240)
                {
                    outPutID1.Text = "This is a Class \"E\" IP";
                    outPutID2.Text = "  - This Class's IP's are Reserved";
                    outPutID3.Text = "  - Reserved for \"Future Testing Purpose\"";
                    outPutID4.Text = "  - Never Utilized in a Standard Way";
                }
                else if (frst >= 224 && frst <= 239)
                {
                    outPutID1.Text = "This is a Class \"D\" IP";
                    outPutID2.Text = "  - This Class Has no Host IP";
                    outPutID3.Text = "  - This Class's IP's are Used for:-";
                    outPutID4.Text = "    \"Uniquely Identified Multicasting\"";
                }

                else if (cidrNumID1.Text != "" && cidr  >= 1 && cidr  <= 32)
                {
                    //calculation code
                    
                    if (frst >= 192 && frst <=223)
                    {
                      

                        if (cidr<24)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"C\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else 
                        {
                        if (cidr== 31 || cidr  == 32)
                        {
                            outPutID1.Text = "This is a Class \"C\" IP";
                            outPutID2.Text = "  - Has no Host IP";
                            outPutID3.Text = "  - CIDR 31-32 IP's for this Class are Used for:-";
                            outPutID4.Text = "    \"Broadcasting Purpose\"";
                        }
                        else
                        {
                            int block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                           // MessageBox.Show(block_4th.ToString());
                            int low = 0;
                            int high = block_4th;

                            for (int i = 0 ; i < 256; i= i + block_4th)
                            {
                                if (frth == low)
                                {
                                    outPutID1.Text = "This is a Network IP";
                                    outPutID2.Text = "  - Broadcasl IP : "+frst.ToString()+"."+scnd.ToString()+"."+thrd.ToString()+"."+(high-1).ToString();
                                    outPutID3.Text = "  - Valid Host Range:-";
                                    outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString()+")";
                                    break;
                                }
                                else if (frth == high)
                                {
                                    outPutID1.Text = "This is a Network IP";
                                    outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high+block_4th) - 1).ToString();
                                    outPutID3.Text = "  - Valid Host Range:-";
                                    outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high+block_4th) - 2).ToString()+")";
                                    break;
                                }
                                else if (frth == high - 1)
                                {
                                    outPutID1.Text = "This is a Broadcast IP";
                                    outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                    outPutID3.Text = "  - Valid Host Range:-";
                                    outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                    break;

                                }
                                else if (frth>low && frth<high)
                                {
                                    outPutID1.Text = "This is a Host IP";
                                    outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString();
                                    outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                    outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                    break;
                                }
                                low = high;
                                high = high + block_4th;
                            }

                        }
                    }
                    }


                    //CLASS B CALCULATION

                    else if (frst >= 128 && frst <= 191)
                    {


                        if (cidr < 16)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"C\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else
                        {
                            if (cidr == 31 || cidr == 32)
                            {
                                outPutID1.Text = "This is a Class \"B\" IP";
                                outPutID2.Text = "  - Has no Host IP";
                                outPutID3.Text = "  - CIDR 31-32 IP's for this Class are Used for:-";
                                outPutID4.Text = "    \"Broadcasting Purpose\"";
                            }
                            else
                            {

                                if (cidr >= 16 && cidr <= 24)
                                {

                                    int block_3rd = (int)(Math.Pow(2, (24 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                                    //int block_4th = 256;
                                    int low = 0;
                                    int high = block_3rd;
                                    //MessageBox.Show(high.ToString());

                                    for (int i = 0; i < 256; i = i + block_3rd)
                                    {
                                        if (thrd == low)
                                        {
                                            if (frth == 0)
                                            {
                                                outPutID1.Text = "This is a Network IP";
                                                outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                                break;//
                                            }
                                            else if (frth == 255)
                                            {
                                                outPutID1.Text = "This is a Broadcast IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                                break;

                                            }

                                            else
                                            {
                                                outPutID1.Text = "This is a Host IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                                outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                                outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255" + ")";
                                                break;
                                            }
                                        }

                                        else if (thrd == high - 1 && frth == 255)
                                        {
                                            outPutID1.Text = "This is a Broadcast IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                            break;

                                        }
                                        
                                        
                                        else if (thrd > low && thrd < high)
                                        {
                                            outPutID1.Text = "This is a Host IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                            outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                            break;
                                        }
                                        low = high;
                                        high = high + block_3rd;
                                    }
                                }
                                else
                                {
                                    int block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                                    // MessageBox.Show(block_4th.ToString());
                                    int low = 0;
                                    int high = block_4th;

                                    for (int i = 0; i < 256; i = i + block_4th)
                                    {
                                        if (frth == low)
                                        {
                                            outPutID1.Text = "This is a Network IP";
                                            outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;
                                        }
                                        else if (frth == high)
                                        {
                                            outPutID1.Text = "This is a Network IP";
                                            outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high + block_4th) - 1).ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high + block_4th) - 2).ToString() + ")";
                                            break;
                                        }
                                        else if (frth == high - 1)
                                        {
                                            outPutID1.Text = "This is a Broadcast IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;

                                        }
                                        else if (frth > low && frth < high)
                                        {
                                            outPutID1.Text = "This is a Host IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString();
                                            outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;
                                        }
                                        low = high;
                                        high = high + block_4th;
                                    }

                                }





                                
                            }
                        }
                    }

                    //CLASS A CALCULATION

                    else if (frst >= 0 && frst <= 126)
                    {


                        if (cidr < 8)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"A\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else
                        {
                            if (cidr == 31 || cidr == 32)
                            {
                                outPutID1.Text = "This is a Class \"A\" IP";
                                outPutID2.Text = "  - Has no Host IP";
                                outPutID3.Text = "  - CIDR 31-32 IP's for this Class are Used for:-";
                                outPutID4.Text = "    \"Broadcasting Purpose\"";
                            }
                            else
                            {

                                if (cidr >= 16 && cidr <= 24)
                                {

                                    int block_3rd = (int)(Math.Pow(2, (24 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                                    //int block_4th = 256;
                                    int low = 0;
                                    int high = block_3rd;
                                    //MessageBox.Show(high.ToString());

                                    for (int i = 0; i < 256; i = i + block_3rd)
                                    {
                                        if (thrd == low)
                                        {
                                            if (frth == 0)
                                            {
                                                outPutID1.Text = "This is a Network IP";
                                                outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                                break;//
                                            }
                                            else if (frth == 255)
                                            {
                                                outPutID1.Text = "This is a Broadcast IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                                break;

                                            }

                                            else
                                            {
                                                outPutID1.Text = "This is a Host IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                                outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                                outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255" + ")";
                                                break;
                                            }
                                        }

                                        else if (thrd == high - 1 && frth == 255)
                                        {
                                            outPutID1.Text = "This is a Broadcast IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                            break;

                                        }
                                        
                                        
                                        else if (thrd > low && thrd < high)
                                        {
                                            outPutID1.Text = "This is a Host IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0";
                                            outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1" + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254" + ")";
                                            break;
                                        }
                                        low = high;
                                        high = high + block_3rd;
                                    }
                                }
                                else if (cidr>=25)
                                {
                                    int block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                                    // MessageBox.Show(block_4th.ToString());
                                    int low = 0;
                                    int high = block_4th;

                                    for (int i = 0; i < 256; i = i + block_4th)
                                    {
                                        if (frth == low)
                                        {
                                            outPutID1.Text = "This is a Network IP";
                                            outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;
                                        }
                                        else if (frth == high)
                                        {
                                            outPutID1.Text = "This is a Network IP";
                                            outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high + block_4th) - 1).ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + ((high + block_4th) - 2).ToString() + ")";
                                            break;
                                        }
                                        else if (frth == high - 1)
                                        {
                                            outPutID1.Text = "This is a Broadcast IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString();
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = "    (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;

                                        }
                                        else if (frth > low && frth < high)
                                        {
                                            outPutID1.Text = "This is a Host IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString();
                                            outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString();
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString() + ") To (" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString() + ")";
                                            break;
                                        }
                                        low = high;
                                        high = high + block_4th;
                                    }

                                }

                                ///////////////////////////////////
                                else if (cidr >= 8 && cidr < 16)
                                {

                                    int block_2nd = (int)(Math.Pow(2, (16 - (cidr = Convert.ToInt32(cidrNumID1.Text)))));
                                    //int block_4th = 256;
                                    int low = 0;
                                    int high = block_2nd;
                                    //MessageBox.Show(high.ToString());

                                    for (int i = 0; i < 256; i = i + block_2nd)
                                    {
                                        if (scnd == low)
                                        {
                                            if (thrd == 0 && frth == 0)
                                            {
                                                outPutID1.Text = "This is a Network IP";
                                                outPutID2.Text = "  - Broadcasl IP : " + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "255";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1" + ") To (" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254" + ")";
                                                break;//
                                            }
                                            else if (thrd == 255 && frth == 255)
                                            {
                                                outPutID1.Text = "This is a Broadcast IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "0";
                                                outPutID3.Text = "  - Valid Host Range:-";
                                                outPutID4.Text = "    (" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1" + ") To (" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254" + ")";
                                                break;

                                            }

                                            else
                                            {
                                                outPutID1.Text = "This is a Host IP";
                                                outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "0";
                                                outPutID3.Text = "  - Broadcasl IP : " + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "255";
                                                outPutID4.Text = " V.H: (" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1" + ") To (" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254" + ")";
                                                break;
                                            }
                                        }

                                        else if (scnd == high-1 && thrd == 255 && frth == 255)
                                        {
                                            outPutID1.Text = "This is a Broadcast IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "0";
                                            outPutID3.Text = "  - Valid Host Range:-";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1" + ") To (" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254" + ")";
                                            break;

                                        }


                                        else if (scnd > low && scnd < high)
                                        {
                                            outPutID1.Text = "This is a Host IP";
                                            outPutID2.Text = "  - Network IP : " + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "0";
                                            outPutID3.Text = "  - Broadcasl IP check: " + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "255";
                                            outPutID4.Text = " V.H: (" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1" + ") To (" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254" + ")";
                                            break;
                                        }
                                        low = high;
                                        high = high + block_2nd;
                                    }
                                }




                            }
                        }
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("          your cidr is invalid\n\tplease retry");
                    cidrNumID1.Text = "";
                }


            }



            else
            {
                MessageBox.Show("          Your IP Address Is Invalid\n\tPlease Retry");
                ipNumID1.Text = "";
                ipNumID2.Text = "";
                ipNumID3.Text = "";
                ipNumID4.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int low;;
            int high;
            listFLSM1.Items.Clear();

            if (ipNumFL1.Text != "" && ipNumFL2.Text != "" && ipNumFL3.Text != "" && ipNumFL4.Text != "")
            {
                frst = Convert.ToInt32(ipNumFL1.Text);
                scnd = Convert.ToInt32(ipNumFL2.Text);
                thrd = Convert.ToInt32(ipNumFL3.Text);
                frth = Convert.ToInt32(ipNumFL4.Text);


                if ((frst < 0 || frst > 255) || (scnd < 0 || scnd > 255) || (thrd < 0 || thrd > 255) || (frth < 0 || frth > 255))
                {
                    MessageBox.Show("          Your IP Address Is Invalid\n\t\tPlease Retry");
                    ipNumFL1.Text = "";
                    ipNumFL2.Text = "";
                    ipNumFL3.Text = "";
                    ipNumFL4.Text = "";
                }

                else if (cidrNumFL1.Text != "" && (cidr = Convert.ToInt32(cidrNumFL1.Text)) >= 1 && (cidr = Convert.ToInt32(cidrNumFL1.Text)) <= 32)
                {
                    //cidr code

                    if (frst >= 224 && frst<= 239)
                    {
                        MessageBox.Show("Sorry! Subnetting is not possible for Class \"D\" IP");
                        ipNumFL1.Text = "";
                        ipNumFL2.Text = "";
                        ipNumFL3.Text = "";
                        ipNumFL4.Text = "";
                    }

                    else if (frst >= 240 && frst <= 255)
                    {
                        MessageBox.Show("Sorry! Subnetting is not possible for Class \"E\" IP");
                        ipNumFL1.Text = "";
                        ipNumFL2.Text = "";
                        ipNumFL3.Text = "";
                        ipNumFL4.Text = "";
                    }

                    else if (frst >= 192 && frst <= 223)
                    {
                        if (cidr<24)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"C\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else if (cidr==31 || cidr==32 )
                        {
                            MessageBox.Show("There Has No Host IP For CIDR "+cidr+" For Class \"C\"");
                            cidrNumID1.Text = "";
                        }
                        else
                        {
                            int block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                            low = 0;
                            high = block_4th;
                            int id = 1;

                            
                            listFLSM1.Items.Clear();

                            for (int i= 0 ; i < 256 ;i = i+block_4th)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id-1].SubItems.Add(""+frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString());
                                listFLSM1.Items[id-1].SubItems.Add(""+frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString());
                                listFLSM1.Items[id-1].SubItems.Add(""+frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString());
                                listFLSM1.Items[id-1].SubItems.Add(""+frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString());
                                id++;
                                low = high;
                                high = high + block_4th;
                            }
                        }
                    }

                    //CLASS B CALCULATION
                        
                    else if (frst >= 128 && frst <= 191)
                    {
                        if (cidr < 16)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"B\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else if (cidr == 31 || cidr == 32)
                        {
                            MessageBox.Show("There Has No Host IP For CIDR " + cidr + " For Class \"B\"");
                            cidrNumID1.Text = "";
                        }
                        else if (cidr >= 24)
                        {
                            
                            
                            
                                block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                                block_3rd = 1;
                                low = 0;
                                high = block_4th;
                          
                            
                            int id = 1;
                            int sub = (int)(Math.Pow(2, ((cidr = Convert.ToInt32(cidrNumFL1.Text))-16)));

                            listFLSM1.Items.Clear();

                            if (sub>1000)
                            {
                                MessageBox.Show("Total Subnets Of This IP: " + sub+"\nFirst 1000 Subnets are Shown Here.");
                                sub = 1000;
                            }

                            thrd = 0;

                            for (int i = 1; i <= sub; i++)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString());
                                id++;
                                low = high;
                                high = high + block_4th;
                                if (low==256)
                                {
                                    low = 0;
                                    high = block_4th;
                                    thrd++;

                                }
                            }
                        }

                        else
                        {



                            block_4th = 256;
                            block_3rd = (int)(Math.Pow(2, (24 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                            low = 0;
                            high = block_3rd;


                            int id = 1;
                            int sub = (int)(Math.Pow(2, ((cidr = Convert.ToInt32(cidrNumFL1.Text)) - 16)));

                            listFLSM1.Items.Clear();

                            

                            //thrd = 0;

                            for (int i = 1; i <= sub; i++)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255");
                                id++;
                                low = high;
                                high = high + block_3rd;
                                //if (low == 256)
                                //{
                                //    low = 0;
                                //    high = block_4th;
                                //    //thrd++;

                                //}
                            }
                        }
                    }

                    //CLASS A CALCULATION

                    else if (frst >= 0 && frst <= 127)
                    {
                        if (cidr < 8)
                        {
                            MessageBox.Show("CIDR " + cidr + " IS NOT APPLICABLE FOR \"A\" CLASS IP");
                            cidrNumID1.Text = "";
                        }
                        else if (cidr == 31 || cidr == 32)
                        {
                            MessageBox.Show("There Has No Host IP For CIDR " + cidr + " For Class \"A\"");
                            cidrNumID1.Text = "";
                        }
                        else if (cidr >= 24)
                        {



                            block_4th = (int)(Math.Pow(2, (32 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                            block_3rd = 1;
                            low = 0;
                            high = block_4th;


                            int id = 1;
                            int sub = (int)(Math.Pow(2, ((cidr = Convert.ToInt32(cidrNumFL1.Text)) - 8)));
                            //MessageBox.Show(sub.ToString());
                            if (sub > 1000)
                            {
                                MessageBox.Show("Total Subnets Of This IP: " + sub + "\nFirst 1000 Subnets are Shown Here.");
                                sub = 1000;
                            }
                            listFLSM1.Items.Clear();
                            

                            thrd = 0;
                            scnd = 0;

                            for (int i = 1; i <= sub; i++)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + low.ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (low + 1).ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 2).ToString());
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + thrd.ToString() + "." + (high - 1).ToString());
                                id++;
                                low = high;
                                high = high + block_4th;
                                if (low == 256)
                                {
                                    low = 0;
                                    high = block_4th;
                                    thrd++;
                                    if (thrd==256)
                                    {
                                        thrd = 0;
                                        scnd++;
                                    }
                                }
                            }
                        }

                        else if (cidr >= 16)
                        {



                            block_4th = 256;
                            block_3rd = (int)(Math.Pow(2, (24 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                            low = 0;
                            high = block_3rd;


                            int id = 1;
                            int sub = (int)(Math.Pow(2, ((cidr = Convert.ToInt32(cidrNumFL1.Text)) - 8)));
                            if (sub > 1000)
                            {
                                MessageBox.Show("Total Subnets Of This IP: " + sub + "\nFirst 1000 Subnets are Shown Here.");
                                sub = 1000;
                            }
                            listFLSM1.Items.Clear();

                            scnd = 0;

                            for (int i = 1; i <= sub; i++)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "0");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + low.ToString() + "." + "1");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "254");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + scnd.ToString() + "." + (high - 1).ToString() + "." + "255");
                                id++;
                                low = high;
                                high = high + block_3rd;
                                if (low == 256)
                                {
                                    low = 0;
                                    high = block_3rd;
                                    scnd++;

                                }
                            }
                        }

                        else
                        {



                            //block_4th = 256;
                            block_2nd = (int)(Math.Pow(2, (16 - (cidr = Convert.ToInt32(cidrNumFL1.Text)))));
                            low = 0;
                            high = block_2nd;


                            int id = 1;
                            int sub = (int)(Math.Pow(2, ((cidr = Convert.ToInt32(cidrNumFL1.Text)) - 8)));

                            listFLSM1.Items.Clear();

                            //scnd = 0;

                            for (int i = 1; i <= sub; i++)
                            {
                                listFLSM1.Items.Add("" + id);
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "0");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + low.ToString() + "." + "0" + "." + "1");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "254");
                                listFLSM1.Items[id - 1].SubItems.Add("" + frst.ToString() + "." + (high - 1).ToString() + "." + "255" + "." + "255");
                                id++;
                                low = high;
                                high = high + block_2nd;
                                //if (low == 256)
                                //{
                                //    low = 0;
                                //    high = block_3rd;
                                //    scnd++;

                                //}
                            }
                        }
                    }
                    
                    
                    
                    
                }
                else
                {
                    MessageBox.Show("          Your CIDR Is Invalid\n\tPlease Retry");
                    cidrNumFL1.Text = "";
                }


            }



            else
            {
                MessageBox.Show("          Your IP Address Is Invalid\n\tPlease Retry");
                ipNumFL1.Text = "";
                ipNumFL2.Text = "";
                ipNumFL3.Text = "";
                ipNumFL4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ipNumVL1.Text != "" && ipNumVL2.Text != "" && ipNumVL3.Text != "" && ipNumVL4.Text != "")
            {
                frst = Convert.ToInt32(ipNumVL1.Text);
                scnd = Convert.ToInt32(ipNumVL2.Text);
                thrd = Convert.ToInt32(ipNumVL3.Text);
                frth = Convert.ToInt32(ipNumVL4.Text);


                if ((frst < 0 || frst > 255) || (scnd < 0 || scnd > 255) || (thrd < 0 || thrd > 255) || (frth < 0 || frth > 255))
                {
                    MessageBox.Show("          Your IP Address Is Invalid\n\t\tPlease Retry");
                    ipNumVL1.Text = "";
                    ipNumVL2.Text = "";
                    ipNumVL3.Text = "";
                    ipNumVL4.Text = "";
                }

                else if (cidrNumVL1.Text != "" && (cidr = Convert.ToInt32(cidrNumVL1.Text)) >= 1 && (cidr = Convert.ToInt32(cidrNumVL1.Text)) <= 32)
                {
                    //cidr code

                    if ((sL1.Text != "" && sR1.Text != "") || (sL2.Text != "" && sR2.Text != "") || (sL3.Text != "" && sR3.Text != "") || (sL4.Text != "" && sR4.Text != "") || (sL5.Text != "" && sR5.Text != ""))
                    {
                        if (frst >= 224 && frst <= 239)
                        {
                            MessageBox.Show("Sorry! Subnetting is not possible for Class \"D\" IP");
                            ipNumVL1.Text = "";
                            ipNumVL2.Text = "";
                            ipNumVL3.Text = "";
                            ipNumVL4.Text = "";
                        }

                        else if (frst >= 240 && frst <= 255)
                        {
                            MessageBox.Show("Sorry! Subnetting is not possible for Class \"E\" IP");
                            ipNumVL1.Text = "";
                            ipNumVL2.Text = "";
                            ipNumVL3.Text = "";
                            ipNumVL4.Text = "";
                        }


                            //CLASS C CALCULATION

                        else if (frst >= 192 && frst <= 223)
                        {

                            if (cidr >= 1 && cidr < 24)
                            {
                                MessageBox.Show("VLSM IS NOT POSSIBLE FOR CIDR " + cidr);
                                cidrNumVL1.Text = "";
                            }

                            else
                            {
                                int[] host= new int[10];
                                string[] name = new string[10];
                                int index = 1;

                                if (sR1.Text != "")
                                host[index++] = Convert.ToInt32(sR1.Text);
                                if (sR2.Text != "")
                                host[index++] = Convert.ToInt32(sR2.Text);
                                if (sR3.Text != "")
                                host[index++] = Convert.ToInt32(sR3.Text);
                                if (sR4.Text != "")
                                host[index++] = Convert.ToInt32(sR4.Text);
                                if (sR5.Text != "")
                                host[index++] = Convert.ToInt32(sR5.Text);
                            }


                        }
                        


























                    }
                    else
                    {
                        MessageBox.Show("Please Give at least One section name and its host PC number that have to be connected in a Network.");
                    }

                }
                else
                {
                    MessageBox.Show("          Your CIDR Is Invalid\n\tPlease Retry");
                    cidrNumVL1.Text = "";
                }


            }



            else
            {
                MessageBox.Show("          Your IP Address Is Invalid\n\tPlease Retry");
                ipNumVL1.Text = "";
                ipNumVL2.Text = "";
                ipNumVL3.Text = "";
                ipNumVL4.Text = "";
            }
        }

        private void getIP2_Click(object sender, EventArgs e)
        {
            ipNum1.Text = "";
            ipNum2.Text = "";
            ipNum3.Text = "";
            ipNum4.Text = "";
            nthNum1.Text = "";
            outPut1.Text = "";
            outPut2.Text = "";
            outPut3.Text = "";
        }

        private void clearID_Click(object sender, EventArgs e)
        {
            ipNumID1.Text = "";
            ipNumID2.Text = "";
            ipNumID3.Text = "";
            ipNumID4.Text = "";
            outPutID1.Text = "";
            outPutID2.Text = "";
            outPutID3.Text = "";
            outPutID4.Text = "";
            cidrNumID1.Text = "";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

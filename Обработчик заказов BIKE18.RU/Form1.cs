using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Обработчик_заказов_BIKE18.RU
{
    public partial class Form1 : Form
    {
        Thread Delegate_table;
        public string page = "1";
        Epplus excel = new Epplus();
        Dictionary<string, string> sprav_id_zakazov = new Dictionary<string, string>();
        CookieContainer cookies = new CookieContainer();
        nethouse Nethouseru = new nethouse();
        public Form1()
        {
            InitializeComponent();
        }


        

        private  void Form1_Load(object sender, EventArgs e)
        {
            textBox_login_nethouse.Text = Properties.Settings.Default.login_nethouse;
            textBox_pass_nethouse.Text = Properties.Settings.Default.pass_nethouse;
            textBox_pochta.Text = Properties.Settings.Default.login_pochta;
            textBox_pass_pocha.Text = Properties.Settings.Default.pass_pochta;

            ServicePointManager.DefaultConnectionLimit = 100;
            cookies = Nethouseru.Signin();
            button2.Enabled = false;
            for (int i = 0; i < 20; i++)
            {
                dataGridView1.Rows.Add();
                
            }
            if (cookies.Count != 1)
            {
                Thread tabl = new Thread(() => Pars_zakazy());
                Delegate_table = tabl;
                Delegate_table.IsBackground = true;
                Delegate_table.Start();
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
                button_auth.Enabled = true;

            }

            
        }

        public void Pars_zakazy()
        {
            
            while (true)
            {
                
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/get-orders?page=" + page + "&status=all");
                    req.Accept = "application/json, text/plain, *";
                    req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
                    req.CookieContainer = cookies;
                    req.ContentType = "application/x-www-form-urlencoded";

                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    StreamReader sr = new StreamReader(resp.GetResponseStream());
                    string otvet = sr.ReadToEnd();
                    otvet = Regex.Unescape(otvet);
                resp.Close();
                    MatchCollection sovpad = new Regex("(?<=\"name\":\").*?(?=\")").Matches(otvet);
                    dataGridView1.Invoke(new Action(() =>
                    {
                        for (int i = 0; i <20; i++)
                        {
                            dataGridView1.Rows[i].Cells[0].Value = sovpad[i].Value;
                        }

                        sovpad = new Regex("(?<=\"clientName\":\").*?(?=\")").Matches(otvet);

                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = sovpad[i].Value;
                        }

                        sovpad = new Regex("(?<=\"status\":\").*?(?=\")").Matches(otvet);

                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = sovpad[i].Value.Replace("active", "В обработке").Replace("canceled", "Отменен").Replace("delivery", "Доставка").Replace("new", "Новый").Replace("processed", "Выполнен").Replace("pickup", "Самовывоз");
                            if (sovpad[i].Value == "new")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }

                        sovpad = new Regex("(?<=\"isPaid\":).*?(?=,)").Matches(otvet);
                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Time new Romans", 16);
                            dataGridView1.Rows[i].Cells[3].Value = sovpad[i].Value.Replace("true", "+").Replace("false", "-");
                        }


                        sovpad = new Regex("(?<=\"total\":).*?(?=,)").Matches(otvet);

                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[4].Value = sovpad[i].Value;
                        }

                        sovpad = new Regex("(?<=\"timestamp\":).*?(?=,)").Matches(otvet);

                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            DateTime date = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(sovpad[i].Value));
                            dataGridView1.Rows[i].Cells[5].Value = date.ToString().Substring(0, date.ToString().Length - 3);
                        }

                        sovpad = new Regex("(?<=\"id\":).*?(?=,)").Matches(otvet);
                        MatchCollection sovpad_dly_sprav = new Regex("(?<=\"name\":\").*?(?=\")").Matches(otvet);
                        sprav_id_zakazov.Clear();
                        for (int i = 0; i < sovpad.Count; i++)
                        {
                            sprav_id_zakazov.Add(sovpad_dly_sprav[i].Value, sovpad[i].Value);
                        }

                    }));
                    Thread.Sleep(5000);
               
            }
                
            }
            
            
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.login_nethouse = textBox_login_nethouse.Text;
            Properties.Settings.Default.pass_nethouse = textBox_pass_nethouse.Text;
            Properties.Settings.Default.login_pochta = textBox_pochta.Text;
            Properties.Settings.Default.pass_pochta = textBox_pass_pocha.Text;
            Properties.Settings.Default.Save();


            button1.Text = "Идет выставление счета, подождите...";
            //button1.Enabled = false;
            string[] faily = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf");
            for (int i = 0; i < faily.Length; i++)
                File.Delete(faily[i]);

            Solution();

        }
        public void Solution()
        {
            List<string> list_select = new List<string>();
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (dataGridView1.SelectedCells[i].ColumnIndex == 0)
                {
                    list_select.Add(dataGridView1.SelectedCells[i].Value.ToString());
                    break;
                }
            }

            foreach (string w in list_select)
            {
                button1.Enabled = false;
                ////try {
                string id_zakaza = sprav_id_zakazov[w];

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/get/" + id_zakaza);
                req.Accept = "application/json, text/plain, *";
                    req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
                    req.CookieContainer = cookies;
                    req.ContentType = "application/x-www-form-urlencoded";

                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    StreamReader sr = new StreamReader(resp.GetResponseStream());
                    string otvet = Regex.Unescape(sr.ReadToEnd());
                resp.Close();

                    MatchCollection sovpad = new Regex("(?<=clientName\": \").*?(?=\")").Matches(otvet);
                    string name = sovpad[0].Value;

                    sovpad = new Regex("(?<=clientPhone\": \").*?(?=\")").Matches(otvet);
                    string phone = sovpad[0].Value;

                    sovpad = new Regex("(?<=clientEmail\": \").*?(?=\")").Matches(otvet);
                    string email = sovpad[0].Value;

                
                sovpad = new Regex("(?<=\",\"content\":\").*?(?=\",\")").Matches(otvet);

                string adres = "";
                    string koment = "";
                    string pasport = "";

                if (sovpad.Count > 0)
                    adres = sovpad[0].ToString();
                
                if(sovpad.Count > 1)
                    koment = sovpad[1].ToString();

                if (sovpad.Count > 2)
                    pasport  = sovpad[1].ToString();
                string isPaid = new Regex("(?<=\"isPaid\":).*?(?=,)").Match(otvet).ToString();


                sovpad = new Regex("(?<=\"totalItems\": ).*?(?=,)").Matches(otvet);
                    string cena = sovpad[0].Value;


                    sovpad = new Regex("(?<=\"name\": \").*?(?=\")").Matches(otvet);
                    string name_pozic = sovpad[1].Value;



                    sovpad = new Regex("(?<=\"deliveryType\": \").*?(?=\")").Matches(otvet);
                    bool pochta;
                    if (sovpad[0].Value == "Почтой России")
                    {
                        pochta = true;
                    }
                    else
                    {
                        pochta = false;
                    }

                textBox_price.Invoke(new Action(() => cena = textBox_price.Text));
                excel.Zapis_shablona(adres, name, pasport, koment, email, phone, w, cena, pochta, radioButton1.Checked, name_pozic);
                //Print(id_zakaza, email, w);
          
                string kom_manager = "";
                string puthDogovor = "";
                richTextBox_com_manager.Invoke(new Action(() => kom_manager = richTextBox_com_manager.Text));
                if (radioButton1.Checked)
                    textBox_puth_dogovor.Invoke(new Action(() => puthDogovor = textBox_puth_dogovor.Text));

                new SendEmail().Send(email, w, radioButton1.Checked, puthDogovor, kom_manager);
                if (radioButton1.Checked)
                    richTextBox2.Invoke(new Action(() => richTextBox2.Text += "Выставлен счет с прикреплением договора на заказ №" + w + "\n"));
                else
                    richTextBox2.Invoke(new Action(() => richTextBox2.Text += "Выставлен счет без договора на заказ №" + w + "\n"));

                Status(id_zakaza);
                //}
                //catch { }
            }

            button1.Invoke(new Action(() => button1.Text = "Обработать выделенные заказы"));
            button1.Invoke(new Action(() => button1.Enabled = true));
            list_select.Clear(); 
            
        }

               

        //public Task<EventArgs> WaitForLoadingFramesComplete(IWebView wv)
        //{
        //    var tcs = new TaskCompletionSource<EventArgs>();
        //    FrameEventHandler handler = ((sender, e) =>
        //    {
        //        if (!(sender as IWebView).IsLoading)
        //        {
        //            tcs.TrySetResult(e);
        //        }
        //    }
        //    );
        //    wv.LoadingFrameComplete += handler;
        //    tcs.Task.ContinueWith(_ =>
        //    {
        //        wv.LoadingFrameComplete -= handler;
        //    }, TaskContinuationOptions.ExecuteSynchronously);
        //    return tcs.Task;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
          
           
                page = (Convert.ToInt32(page)-1).ToString();
                Delegate_table.Abort();
                Thread tabl = new Thread(new ThreadStart(Pars_zakazy));
                Delegate_table = tabl;
                Delegate_table.IsBackground = true;
                Delegate_table.Start();
                label1.Text = "Страница " + page;
                if (page == "1")
                {
                    button2.Invoke(new Action(() => button2.Enabled = false));
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            page = (Convert.ToInt32(page) + 1).ToString();
            Delegate_table.Abort();
            Thread tabl = new Thread(new ThreadStart(Pars_zakazy));
            Delegate_table = tabl;
            Delegate_table.IsBackground = true;
            Delegate_table.Start();
            if (page != "1")
            {
                button2.Invoke(new Action(() => button2.Enabled = true));
            }
            label1.Text = "Страница " + page;
        }

        

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Разработчик: Черницын Сергей\nDeveloped by Serkser\n\nДата: 04.11.2015");
        }


        public void Status(string id_zakaza)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/get/" + id_zakaza);
            req.Accept = "application/json, text/plain, *";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
            req.CookieContainer = cookies;
            req.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string otvet = Regex.Unescape(sr.ReadToEnd());
            resp.Close();


            MatchCollection sovpad = new Regex("(?<=\"id\": ).*?(?=,)").Matches(otvet);
            string id = sovpad[0].Value;

            string deliveryType = new Regex("(?<=\"deliveryType\": \").*?(?=\")").Match(otvet).Value;
            

            sovpad = new Regex("(?<=\"deliveryPrice\": ).*?(?=,)").Matches(otvet);
            string deliveryPrice = sovpad[0].Value;

            sovpad = new Regex("(?<=\"consumerId\": ).*?(?=,)").Matches(otvet);
            string consumerId = sovpad[0].Value;

            sovpad = new Regex("(?<=\"clientName\": \").*?(?=\",)").Matches(otvet);
            string clientNAme = sovpad[0].Value;  

            sovpad = new Regex("(?<= \"clientPhone\": \").*?(?=\",)").Matches(otvet);
            string clientPhone = sovpad[0].Value;

            sovpad = new Regex("(?<=\"clientEmail\": ).*?(?=\",)").Matches(otvet);
            string clientEmail = sovpad[0].Value;
            if (clientEmail.Contains("\""))
                clientEmail = clientEmail.Replace("\"", "");

            string consumerInfo_adress = "";
          
            string consumerInfo_koment = "";
          
            string consumerInfo_pasport = "";

            sovpad = new Regex("(?<=content\":\")[\\w\\W]*?(?=\",\"label)").Matches(otvet);

            if (sovpad.Count > 0)
                consumerInfo_adress = sovpad[0].ToString();

            if (sovpad.Count > 1)
                consumerInfo_koment = sovpad[1].ToString();

            if (sovpad.Count > 2)
                consumerInfo_pasport = sovpad[2].ToString();
            string isPaid = new Regex("(?<=\"isPaid\":).*?(?=,)").Match(otvet).ToString();
            string status = new Regex("(?<=status\": \").*?(?=\",)").Match(otvet).ToString();


            req = (HttpWebRequest)WebRequest.Create("https://bike18.nethouse.ru/api/order/save");
            req.Accept = "application/json, text/plain, */*";
            req.Proxy = null;
            req.Method = "POST";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";
            req.CookieContainer = cookies;
            req.ContentType = "application/x-www-form-urlencoded";

            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes("id=" + id + "&deliveryType=" + deliveryType + "&deliveryPrice=" + deliveryPrice + "&consumerId=" + consumerId + "&clientName=" + clientNAme + "&clientPhone=" + clientPhone + "&clientEmail=" + clientEmail + "&consumerInfo[address][content]=" + consumerInfo_adress + "&consumerInfo[address][label]=Адрес доставки" + "&consumerInfo[address][type]=0" + "&consumerInfo[comment][content]=" + consumerInfo_koment + "&consumerInfo[comment][label]=Комментарий (необязательное поле)" + "&consumerInfo[comment][type]=1" + "&consumerInfo[field1][content]=" + consumerInfo_pasport + "&consumerInfo[field1][label]=Паспортные данные (необязательное поле)" + "&consumerInfo[field1][type]=1" + "&status=" + "active" + "&isPaid=" + isPaid + "&getCategories=");

            req.ContentLength = bytes.Length;
            Stream s = req.GetRequestStream();
            s.Write(bytes, 0, bytes.Length);
            s.Close();

            resp = (HttpWebResponse)req.GetResponse();
            resp.Close();
            
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells[0].ColumnIndex == 0 && (string)dataGridView1.SelectedCells[0].Value != null)
            {
                string id_ = sprav_id_zakazov[(string)dataGridView1.SelectedCells[0].Value];
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/get/"+ id_);
                req.Accept = "application/json, text/plain, */*";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36 OPR/34.0.2036.50";
                req.CookieContainer = cookies;
                req.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string otvet =sr.ReadToEnd();

                string price = new Regex("(?<=\"totalItems\": ).*?(?=,)").Match(otvet).Value.Split('.')[0];
                textBox_price.Text = price;

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox_pass_pocha_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button_file_dogovor.Enabled = radioButton1.Checked;
            textBox_puth_dogovor.Enabled = radioButton1.Checked;
        }

        private void button_file_dogovor_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
                textBox_puth_dogovor.Text = file.FileName;
        }

        private void button_auth_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.login_nethouse = textBox_login_nethouse.Text;
            Properties.Settings.Default.pass_nethouse = textBox_pass_nethouse.Text;
            Properties.Settings.Default.login_pochta = textBox_pochta.Text;
            Properties.Settings.Default.pass_pochta = textBox_pass_pocha.Text;
            Properties.Settings.Default.Save();

            ServicePointManager.DefaultConnectionLimit = 100;
            cookies = Nethouseru.Signin();
            CookieContainer cookiesYandex = Nethouseru.SigninYa();
            button2.Enabled = false;

            if (cookies.Count != 1)
            {
                Thread tabl = new Thread(() => Pars_zakazy());
                Delegate_table = tabl;
                Delegate_table.IsBackground = true;
                Delegate_table.Start();
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
                button2.Enabled = true;

            }
            if (cookiesYandex.Count == 1)
            {        MessageBox.Show("Неверный пароль!");
            button2.Enabled = true;
        }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                int numberRow = e.RowIndex;
                string number = dataGridView1.Rows[numberRow].Cells[0].Value.ToString();
                StatusPrice(number);
                string s = dataGridView1.Rows[numberRow].Cells[3].Value.ToString();
                if (s == "1")
                    dataGridView1.Rows[numberRow].Cells[3].Value = "0";
                else
                    dataGridView1.Rows[numberRow].Cells[3].Value = "1";
                richTextBox2.AppendText("Изменен статус оплаты заказа № " + number + "\n");
            }
        }

        public void StatusPrice(string number)
        {
            string id_zakaza = sprav_id_zakazov[number];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/get/" + id_zakaza);
            req.Accept = "application/json, text/plain, *";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
            req.CookieContainer = cookies;
            req.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string otvet = Regex.Unescape(sr.ReadToEnd());

            MatchCollection sovpad = new Regex("(?<=\"id\": ).*?(?=,)").Matches(otvet);
            string id = sovpad[0].Value;

            string deliveryType = new Regex("(?<=\"deliveryType\": \").*?(?=\")").Match(otvet).Value;

            sovpad = new Regex("(?<=\"deliveryPrice\": ).*?(?=,)").Matches(otvet);
            string deliveryPrice = sovpad[0].Value;

            sovpad = new Regex("(?<=\"consumerId\": ).*?(?=,)").Matches(otvet);
            string consumerId = sovpad[0].Value;

            sovpad = new Regex("(?<=\"clientName\": \").*?(?=\",)").Matches(otvet);
            string clientNAme = sovpad[0].Value;

            sovpad = new Regex("(?<= \"clientPhone\": \").*?(?=\",)").Matches(otvet);
            string clientPhone = sovpad[0].Value;

            sovpad = new Regex("(?<=clientEmail\": \").*(?=\",)").Matches(otvet);
            string clientEmail = sovpad[0].Value;            

            string consumerInfo_adress = new Regex("(?<=\\{\"address\":\\{\"content\":\").*?(?=\",)").Match(otvet).Value;

            MatchCollection consumerInfo = new Regex("(?<={\")[\\w\\W]*?(?=\"})").Matches(otvet);

            string typeAdress = new Regex("(?<=type\":\").*?(?=\")").Match(consumerInfo[0].ToString()).ToString();
            string ContentAdress = new Regex("(?<=content\":\").*?(?=\")").Match(consumerInfo[0].ToString()).ToString();

            string typeKoment = new Regex("(?<=type\":\").*?(?=\")").Match(consumerInfo[1].ToString()).ToString();
            string ContentKoment = new Regex("(?<=content\":\").*?(?=\")").Match(consumerInfo[1].ToString()).ToString();

            string typePasport = new Regex("(?<=type\":\").*?(?=\")").Match(consumerInfo[2].ToString()).ToString();
            string ContentPasport = new Regex("(?<=content\":\").*?(?=\")").Match(consumerInfo[2].ToString()).ToString();

            string consumerInfo_koment = new Regex("(?<=\"comment\":\\{\"content\":\").*?(?=\")").Match(otvet).Value;

            string status = new Regex("(?<=status\": \")[\\w\\W]*?(?=\")").Match(otvet).Value;

            string isPaid = new Regex("(?<=isPaid\": )[\\w\\W]*?(?=,)").Match(otvet).Value;
            if (isPaid == "1")
                isPaid = "0";
            else
                isPaid = "1";

            string customTotal = new Regex("(?<=customTotal\":).*?(?=,)").Match(otvet).ToString();
            if (customTotal == " null")
                customTotal = "";
            string paymentMethod = new Regex("(?<=paymentMethod\": \").*?(?=\")").Match(otvet).ToString();
            
            req = (HttpWebRequest)WebRequest.Create("http://bike18.nethouse.ru/api/order/save");
            req.Accept = "application/json, text/plain, */*";
            req.Method = "POST";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.80 Safari/537.36 OPR/33.0.1990.58";
            req.CookieContainer = cookies;
            req.ContentType = "application/x-www-form-urlencoded";

            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes("id=" + id + "&deliveryType=" + deliveryType + "&deliveryPrice=" + deliveryPrice + "&consumerId=" + consumerId + "&clientName=" + clientNAme + "&clientPhone=" + clientPhone + "&clientEmail=" + clientEmail + "&consumerInfo[0][type]=" + typeAdress + "&consumerInfo[0][content]=" + ContentAdress + "&consumerInfo[0][label]=%D0%90%D0%B4%D1%80%D0%B5%D1%81%20%D0%B4%D0%BE%D1%81%D1%82%D0%B0%D0%B2%D0%BA%D0%B8&consumerInfo[1][type]=" + typeKoment + "&consumerInfo[1][content]=" + ContentKoment + "&consumerInfo[1][label]=%D0%9A%D0%BE%D0%BC%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%80%D0%B8%D0%B9%20(%D0%BD%D0%B5%D0%BE%D0%B1%D1%8F%D0%B7%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D0%BE%D0%B5%20%D0%BF%D0%BE%D0%BB%D0%B5)&consumerInfo[2][type]=" + typePasport + "&consumerInfo[2][content]=" + ContentPasport + "&consumerInfo[2][label]=%D0%9F%D0%B0%D1%81%D0%BF%D0%BE%D1%80%D1%82%D0%BD%D1%8B%D0%B5%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D0%B5%20(%D0%BD%D0%B5%D0%BE%D0%B1%D1%8F%D0%B7%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D0%BE%D0%B5%20%D0%BF%D0%BE%D0%BB%D0%B5)&status=" + status + "&isPaid=" + isPaid + "&customTotal=" + customTotal + "&paymentMethod=" + paymentMethod + "&getCategories=");
            req.ContentLength = bytes.Length;
            Stream s = req.GetRequestStream();
            s.Write(bytes, 0, bytes.Length);
            s.Close();

            resp = (HttpWebResponse)req.GetResponse();


        }
    }
}

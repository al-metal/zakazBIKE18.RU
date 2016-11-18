using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Обработчик_заказов_BIKE18.RU
{
    class nethouse
    {


        public CookieContainer Signin()
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://nethouse.ru/signin");
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
            req.ContentType = "application/x-www-form-urlencoded";
            req.CookieContainer = cookies;
            req.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes("login="+Properties.Settings.Default.login_nethouse+"&password="+Properties.Settings.Default.pass_nethouse+"&quick_expire=0&submit=%D0%92%D0%BE%D0%B9%D1%82%D0%B8");
            req.ContentLength = bytes.Length;
            Stream s = req.GetRequestStream();
            s.Write(bytes, 0, bytes.Length);
            s.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string hernya = sr.ReadToEnd();

            return cookies;
        }

        public CookieContainer SigninYa()
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://passport.yandex.ru/passport?mode=auth&retpath=https://mail.yandex.ru");
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 OPR/32.0.1948.69";
            req.ContentType = "application/x-www-form-urlencoded";
            req.CookieContainer = cookies;
            req.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes("login=" + Properties.Settings.Default.login_pochta + "&passwd=" + Properties.Settings.Default.pass_pochta);
            req.ContentLength = bytes.Length;
            Stream s = req.GetRequestStream();
            s.Write(bytes, 0, bytes.Length);
            s.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string hernya = sr.ReadToEnd();

            return cookies;
        }
    }
}

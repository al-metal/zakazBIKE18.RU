using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Обработчик_заказов_BIKE18.RU
{
    class SendEmail
    {
        public void Send(string email_kuda, string nomer_zakaz, bool tech, string puth_dogovor, string kom_manager)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.yandex.ru";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.login_pochta, Properties.Settings.Default.pass_pochta);
            string srok = null;
            //if (!tech)
            //{
            //     srok = "\nЗаказ поступит к вам в течении 2-3 недель после оплаты.";
            //}
            string text_pisma = "Здравствуйте.\n\nВаш заказ №" + nomer_zakaz + " имеет статус:\nОжидает оплаты\n\nКомментарий менеджера BIKE18.RU:\n"+kom_manager+ "\n\nДля оплаты в любом банке по квитанции или безналичному расчету используйте Наши реквизиты:\nООО \"СПЕЦДОСТАВКА\"\nИНН: 1840032306\nКПП: 184001001\nОКПО: 16904620\nОГРН: 1141840009673\nЮр. адрес: 426062, Россия, Ижевск, Спортивная улица, 117\nФакт. адрес: 426006, Россия, Ижевск, Телегина 30.\nБанк: Филиал «Нижегородский» ОАО «АЛЬФА-БАНК» г. Нижний Новгород\nБИК: 042202824\nК/счет: 30101810200000000824\nР/счет: 40702810229100000307\n\nЧасто бывает удобно совершить платеж более быстрым и легким способом:\n- оплата по номеру карты Сбербанка: 4276 6800 1378 9506 (Екатерина Александровна В.);\n- оплата по номеру карты Альфа-Банка 4083 9720 5334 3192 ( вл. Екатерина Александровна В.);\n- оплата на Яндекс Деньги 410012562837706;\n- оплата на Qiwi кошелёк 9225173143.\n\n\nСопроводительные документы в приложении к письму. Просим уведомить нас об оплате ответным письмом.";

            MailMessage mm;
                try
            {
                 mm = new MailMessage("moto@bike18.ru", email_kuda, "BIKE18.RU: Обновление информации по вашему заказу №" + nomer_zakaz, text_pisma);
            }
            catch
            {
                MessageBox.Show("У клиента не указан email!");
                return;
            }
                mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
          
            File.Move("Шаблон счет.pdf", @"Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf");
            Thread.Sleep(2000);
          



            string[] attach = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.pdf");
            ////for(int i=0; i<attach.Length; i++)
            mm.Attachments.Add(new Attachment("Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf", MediaTypeNames.Text.Plain));
            if(tech)
                mm.Attachments.Add(new Attachment(puth_dogovor, MediaTypeNames.Text.Plain));
            client.Send(mm);

            foreach(var w in mm.Attachments)
            {
                w.Dispose();
            }

            string zagolovok = "";
            if (tech)
            {
                zagolovok = "BIKE18.RU: Выставлен счет с прикреплением договора на заказ №" + nomer_zakaz;
            }
            else
            {
                zagolovok = "BIKE18.RU: Выставлен счет без договора на заказ №" + nomer_zakaz;
            }
            mm = new MailMessage("moto@bike18.ru", "moto@bike18.ru", zagolovok, text_pisma);

             attach = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf");
            //for (int i = 0; i < attach.Length; i++)
                mm.Attachments.Add(new Attachment(@"Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf", MediaTypeNames.Text.Plain));
            if (tech)
                mm.Attachments.Add(new Attachment(puth_dogovor, MediaTypeNames.Text.Plain));
            client.Send(mm);

            foreach (var w in mm.Attachments)
            {
                w.Dispose();
            }

          
            if (new FileInfo("Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf").Exists == true)
                if (new FileInfo(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf").Exists)
                { File.Delete(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf");
                    File.Move("Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf", Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf");
                }
                else
                    File.Move("Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf", Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " договор.pdf");
            if (new FileInfo(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf").Exists)
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf");
                File.Move("Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf", Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf");
            }
            else
                File.Move("Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf", Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + " счет.pdf");
            if (new FileInfo(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + ".pdf").Exists)
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + ".pdf");
                File.Move("Заказ №" + nomer_zakaz.Replace("/", ".") + ".pdf", Directory.GetCurrentDirectory() + "\\Все отправленные договора\\" + "Заказ №" + nomer_zakaz.Replace("/", ".") + ".pdf");
            }
           



        }


    }
}

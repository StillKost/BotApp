using BotApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static async void SetBot()
        {
            var instance = new Instance().CreateInstance();

            if (instance == null)
            {
                MessageBox.Show("Укажите токен бота в настройках");
            }
            else
            {
                try
                {
                    instance.MessageCreated += async e =>
                    {
                        var author = e.Author;
                        //var isInIgnore = new SettingsController().GetSettingValue("IgnorableUsers")
                        //                                         .ToUpperInvariant()
                        //                                         .Contains(author.Username.ToUpperInvariant());

                        //Не отвечаем ботам и пользователям из игнор-листа.
                        if (!author.IsBot /*&& !isInIgnore*/)
                        {
                            string message = e.Message.Content;
                            string answer = "ответ";
                            await e.Message.RespondAsync(answer);
                            //Logger.Log(message, answer, author, EventType.AnsweredMessage);
                        }
                    };

                    await instance.ConnectAsync();
                }
                catch (Exception ex)
                {
                    //Logger.Log(ex);
                }

                //await instance.DisconnectAsync();
                MessageBox.Show("Бот запущен");
            }

            //await Task.Delay(-1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var t = new Task(SetBot);
            t.Start();
        }
    }
}

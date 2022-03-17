using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int port = 8080; // порт для приема входящих запросов
        public static Form1 instance = null;

        private delegate void SetControlPropertyThreadSafeDelegate(
     Control control,
     string propertyName,
     object propertyValue);

        public static void SetControlPropertyThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        public Form1()
        {
            InitializeComponent();
            instance = this;
            Thread thread1 = new Thread(Server);
            thread1.Start();
        }

        public static void Server()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(ipEntry.AddressList[1], port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SetControlPropertyThreadSafe(instance.label8, "Text", ipPoint.Address.ToString());
            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем прослушивание
            listenSocket.Listen(10);

            while (true)
            {
                Socket handler = listenSocket.Accept();
                // получаем сообщение
                int bytes = 0; // количество полученных байтов
                StringBuilder builder = new StringBuilder();
                while (true)
                {

                    byte[] data = new byte[256]; // буфер для получаемых данных
                    do
                    {
                        bytes = handler.Receive(data);
                        string input = Encoding.ASCII.GetString(data, 0, bytes);
                        if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                            builder.Clear();
                        builder.Append(input);
                    }
                    while (handler.Available > 0);
                    int value = -1;
                    var lines = builder.ToString().Split(' ', '\n');
                    int.TryParse(lines[0], out value);
                    //
                    SetControlPropertyThreadSafe(instance.label9, "Text",value.ToString());
                    SetControlPropertyThreadSafe(instance.label5, "Size", 100);
                    if (value/100 == 1)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "Text", "10%");
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.PaleGreen);
                    }
                    if (value/100 == 2)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "Text", "20%");
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.LawnGreen);
                    }
                    if (value / 100 == 3)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "30%");
                    }
                    if (value/100 == 4)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "40%");
                    }
                    if (value/100 == 5)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "50%");
                        }
                    if (value/100 == 6)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "60%");
                        }
                    if (value / 100 == 7)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.Crimson);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "70%");
                        }
                    if (value / 100 == 8)
                    {
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.DarkOrange);
                        SetControlPropertyThreadSafe(instance.label4, "Text", "80%");

                    }
                    if (value / 100 == 9  )
                    {
                        SetControlPropertyThreadSafe(instance.label4, "Text", "90%");
                        SetControlPropertyThreadSafe(instance.label4, "BackColor", Color.Red);
                    }
                    if ((value % 100) / 10 == 1)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "Text", "10%");
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.PaleGreen);
                    }
                    if ((value % 100) / 10 == 2)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "Text", "20%");
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.LawnGreen);
                    }
                    if ((value % 100) / 10 == 3)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "30%");
                    }
                    if ((value % 100) / 10 == 4)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "40%");
                    }
                    if ((value % 100) / 10 == 5)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "50%");
                    }
                    if ((value % 100) / 10 == 6)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "60%");
                    }
                    if ((value % 100) / 10 == 7)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.Crimson);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "70%");
                    }
                    if ((value % 100) / 10 == 8)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.DarkOrange);
                        SetControlPropertyThreadSafe(instance.label5, "Text", "80%");

                    }
                    if ((value % 100) / 10 == 9)
                    {
                        SetControlPropertyThreadSafe(instance.label5, "Text", "90%");
                        SetControlPropertyThreadSafe(instance.label5, "BackColor", Color.Red);
                    }
                    if (value % 10 == 1)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "Text", "10%");
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.PaleGreen);
                    }
                    if (value % 10 == 2)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "Text", "20%");
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.LawnGreen);
                    }
                    if (value % 10 == 3)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "30%");
                    }
                    if (value % 10 == 4)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.LimeGreen);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "40%");
                    }
                    if (value % 10 == 5)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "50%");
                    }
                    if (value %10 == 6)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.Yellow);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "60%");
                    }
                    if (value % 10 == 7)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.Crimson);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "70%");
                    }
                    if (value % 10 == 8)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.DarkOrange);
                        SetControlPropertyThreadSafe(instance.label6, "Text", "80%");

                    }
                    if (value % 10 == 9)
                    {
                        SetControlPropertyThreadSafe(instance.label6, "Text", "90%");
                        SetControlPropertyThreadSafe(instance.label6, "BackColor", Color.Red);
                    }

                }
                    
                }
            }
    }
}

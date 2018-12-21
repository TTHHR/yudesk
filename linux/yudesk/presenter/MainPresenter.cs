using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using cn.qingyuyu.yudesk.view;
using Newtonsoft.Json.Linq;

namespace cn.qingyuyu.yudesk.presenter
{
    public class MainPresenter
    {
        private Boolean running=false;
        private MainWindowInterface mwi = null;
        private String token = "";
        public MainPresenter(MainWindowInterface mwi)
        {
            this.mwi = mwi;
        }
        public void SetToken(String token)
        {
            this.token = token;
            Console.WriteLine("set Token: "+token);
            start();
        }
        private void start()
        {
            if(token!=""&&!running)
            {
                running = true;
                ThreadStart ts = new ThreadStart(getNetData);
                Thread thread = new Thread(ts);
                thread.Start();
            }
        }
        private void getNetData()
        {
            byte[] result = new byte[1024];
            while(running)
            {
                try
                {
                    //设定服务器IP地址
                    IPHostEntry host = Dns.GetHostEntry("wjy.qingyuyu.cn");
                    IPAddress ip = host.AddressList[0];
                    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect(new IPEndPoint(ip, 2333)); //配置服务器IP与端口
                     
                    //通过 clientSocket 发送数据
                    string str = "{\"token\":\""+token+"\",\"need\":\"get\"}\n";
               
                clientSocket.Send(Encoding.ASCII.GetBytes(str));
                    clientSocket.Shutdown(SocketShutdown.Send);
                   
                    //通过clientSocket接收数据
                    int receiveLength = clientSocket.Receive(result);
                    String data = Encoding.ASCII.GetString(result, 0, receiveLength);
                    JObject dataJson = JObject.Parse(data);
                    if (dataJson.GetValue("code").ToString() == "ok")
                    {
                        mwi.SetInfoLabel(dataJson.GetValue("data").ToString());
                    }
                    else
                    {
                        mwi.SetInfoLabel(dataJson.GetValue("msg").ToString());
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                Thread.Sleep(3000);
            }
        }
        public void exit()
        {
            running = false;
        }
    }
}

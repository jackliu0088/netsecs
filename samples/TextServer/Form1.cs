using Secs4Net;
using Secs4Net.Sml;
using Sunny.UI;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using Options = Microsoft.Extensions.Options.Options;


namespace TextServer
{
    public partial class Form1 : UIForm
    {
        SecsGem? _secsGem;
        HsmsConnection? _connector;
        readonly ISecsGemLogger _logger;
        private readonly BindingList<PrimaryMessageWrapper> _recvBuffer = new();
        CancellationTokenSource _cancellationTokenSource = new();
        SecsMessageList _messages;

        public Form1()
        {
            InitializeComponent();
            radioActiveMode.DataBindings.Add("Enabled", btnEnable, "Enabled");
            radioPassiveMode.DataBindings.Add("Enabled", btnEnable, "Enabled");
            txtAddress.DataBindings.Add("Enabled", btnEnable, "Enabled");
            numPort.DataBindings.Add("Enabled", btnEnable, "Enabled");
            numDeviceId.DataBindings.Add("Enabled", btnEnable, "Enabled");
            numBufferSize.DataBindings.Add("Enabled", btnEnable, "Enabled");
            
            Application.ThreadException += (sender, e) => MessageBox.Show(e.Exception.ToString());
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => MessageBox.Show(e.ExceptionObject.ToString());
            _logger = new SecsLogger(this);
            _messages = new SecsMessageList("common.json");
            foreach (var message in _messages)
            {
                if (message.Name!.Contains("HOST<->EQP"))
                {
                    TreeNode node = new()
                    {
                        Text = @"S" + message.S + @"F" + message.F + (message.ReplyExpected ? "W" : "") + @"--" +
                               message.Name,
                        Tag = message
                    };
                    treeView1.Nodes.Add(node);
                }

                if (!message.Name!.Contains("HOST->EQP"))
                {
                    continue;
                }

                TreeNode treeNode = new()
                {
                    Text = @"S" + message.S + @"F" + message.F + (message.ReplyExpected ? "W" : "") + @"--" +
                           message.Name,
                    Tag = message
                };
                treeView1.Nodes.Add(treeNode);
            }
            treeView1.ExpandAll();
            button2.Enabled= false;
            button1.Enabled= false;
            sendBtuuon.Enabled= false;
        }

        private async void btnEnable_Click(object sender, EventArgs e)
        {
            _secsGem?.Dispose();

            if (_connector is not null)
            {
                await _connector.DisposeAsync();
            }

            var options = Options.Create(new SecsGemOptions
            {
                IsActive = radioActiveMode.Checked,
                IpAddress = txtAddress.Text,
                Port = (int)numPort.Value,
                SocketReceiveBufferSize = (int)numBufferSize.Value,
                DeviceId = (ushort)numDeviceId.Value,
            });

            _connector = new HsmsConnection(options, _logger);
            _secsGem = new SecsGem(options, _connector, _logger);

            _connector.ConnectionChanged += delegate
            {
                Invoke((MethodInvoker)delegate
                {
                    lbStatus.Text = _connector.State.ToString();
                });
            };

            btnEnable.Enabled = false;
            _ = _connector.StartAsync(_cancellationTokenSource.Token);
            btnDisable.Enabled = true;
            sendBtuuon.Enabled = true;
            button1.Enabled = true;

            try
            {
                await foreach (var pm in _secsGem.GetPrimaryMessageAsync(_cancellationTokenSource.Token))
                {
                    using var primaryMessage = pm.PrimaryMessage;
                    try
                    {
                        var funcitionNumber = (byte)(primaryMessage.F + 1);
                        //通过发送命令查找json集合中的数据并根据发送过来的命令返回相应数据
                        var s = _messages.FirstOrDefault(s =>
                            s.S == primaryMessage.S && s.F == funcitionNumber);
                        
                        //using var secondaryMessage = new SecsMessage(primaryMessage.S, (byte)(primaryMessage.F + 1))
                        //{
                        //    SecsItem = primaryMessage.SecsItem,
                        //};
                        if (s != null)
                        {
                            using var secondaryMessage = new SecsMessage(s.S, s.F) { SecsItem = s.SecsItem };
                            await pm.TryReplyAsync(secondaryMessage, _cancellationTokenSource.Token);
                            _recvBuffer.Clear();
                        }
                        else
                        {
                            _recvBuffer.Clear();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex + "Exception occurred when processing primary message");
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.Error(ex + "错误：");
            }
        }

        private async void btnDisable_Click(object sender, EventArgs e)
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }
            if (_connector is not null)
            {
                await _connector.DisposeAsync();
            }
            _secsGem?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            _secsGem = null;
            btnEnable.Enabled = true;
            btnDisable.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
            sendBtuuon.Enabled = false;
            lbStatus.Text = @"Disable";
            _recvBuffer.Clear();
           
        }

       
        class SecsLogger : ISecsGemLogger
        {
            readonly Form1 _form;
            internal SecsLogger(Form1 form)
            {
                _form = form;
            }
            public void MessageIn(SecsMessage msg, int id)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                    
                    _form.richTextBox1.SelectionColor = Color.White;
                    AddLine(_form.richTextBox1,
                        $"<--[0x{id:X8}]{DateTime.Now:yyyy-MM-dd hh:mm:ss fff)}: " + msg.ToSml());
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                });
            }

            public void MessageOut(SecsMessage msg, int id)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                
                    _form.richTextBox1.SelectionColor = Color.White;
                    AddLine(_form.richTextBox1,
                        $"--> [0x{id:X8}] {DateTime.Now:yyyy-MM-dd hh:mm:ss fff)}: " + msg.ToSml());
                    AddLine(_form.richTextBox1,
                        $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " +
                        Convert.ToHexString(Encoding.Default.GetBytes(msg.ToSml())));
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                  
                });
            }

            public void Info(string msg)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                   
                    _form.richTextBox1.SelectionColor = Color.Blue;
                    AddLine(_form.richTextBox1, $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + msg);
                  
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                });
            }
            public string ToBinary(string str)
            {
                //把字符串转成字符数组
                byte[] data = Encoding.Unicode.GetBytes(str);
                StringBuilder result = new(data.Length * 8);

                foreach (byte b in data)
                {
                    result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                }
                return result.ToString();
            }

            public void Warning(string msg)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                    _form.richTextBox1.SelectionColor = Color.Green;
                    AddLine(_form.richTextBox1, $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + msg);
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                });
            }

            public void Error(string msg, SecsMessage? message, Exception? ex)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                    _form.richTextBox1.SelectionColor = Color.Red;
                    AddLine(_form.richTextBox1, $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + msg);
                    _form.richTextBox1.SelectionColor = Color.Red;
                    if (message != null)
                        AddLine(_form.richTextBox1,
                            $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + message?.ToSml());
                    _form.richTextBox1.SelectionColor = Color.Gray;
                    if (ex != null)
                        AddLine(_form.richTextBox1,
                            $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + ex);
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                });
            }

            public void Debug(string msg)
            {
                _form.Invoke((MethodInvoker)delegate
                {
                    _form.richTextBox1.SelectionColor = Color.Yellow;
                    AddLine(_form.richTextBox1, $"{DateTime.Now:yyyy-MM-dd hh:mm:ss fff}: " + msg);
                    _form.richTextBox1.SelectionStart = _form.richTextBox1.TextLength;
                    _form.richTextBox1.ScrollToCaret();
                });
            }

#if NET472
            public void Error(string msg)
            {
                Error(msg, null, null);
            }

            public void Error(string msg, Exception ex)
            {
                Error(msg, null, ex);
            }
#endif
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SecsMessage? node = treeView1.SelectedNode.Tag as SecsMessage;
            smlTextBox.Text = node.ToSml();

        }

        private async void sendBtuuon_Click(object sender, EventArgs e)
        {
            if (_secsGem is null || string.IsNullOrWhiteSpace(smlTextBox.Text) || _connector?.State != ConnectionState.Selected)
            {
                return;
            }
            try
            {
                treeView1.SelectedNode.BackColor = Color.Green;
                var reply = await _secsGem.SendAsync(smlTextBox.Text.ToSecsMessage());
             
            }
            catch (SecsException ex)
            {

                AddLine(richTextBox1, ex.Message);
            }

        }
        public static void AddLine(RichTextBox box, string text, uint? maxLine = 200)
        {
            string newLineIndicator = "\n";
            if (maxLine is > 0)
            {
                if (box.Lines.Count() >= maxLine)
                {
                    List<string> lines = box.Lines.ToList();
                    lines.RemoveAt(0);
                    box.Lines = lines.ToArray();
                }
            }
            string line = string.IsNullOrEmpty(box.Text) ? text : newLineIndicator + text;
            box.AppendText(line);
        }

        private CancellationTokenSource TokenSource;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_secsGem is null || string.IsNullOrWhiteSpace(smlTextBox.Text) ||
                _connector?.State != ConnectionState.Selected)
            {
                return;
            }
            button1.Enabled = false;
            button2.Enabled = true;
            _logger.Info("开始！");

            TokenSource = new CancellationTokenSource();
            string? textString = smlTextBox.Text;
            try
            {
                await Task.Factory.StartNew(async () =>
                {
                    Thread.CurrentThread.IsBackground = false;
                    while (true)
                    {
                        if (TokenSource.IsCancellationRequested)
                        {
                            _logger.Info("停止");
                            GC.Collect();
                            return;
                        }

                        TokenSource.Token.ThrowIfCancellationRequested();
                        await _secsGem.SendAsync(textString.ToSecsMessage());
                        Task.Delay(10);
                    }
                }, TokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine(exception);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TokenSource.Cancel();
            TokenSource.Dispose();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private SerialPort serialPort;
        private void button3_Click(object sender, EventArgs e)
        {
            serialPort = new();
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.PortName = "COM1";
            serialPort.DataReceived += SerialPort_DataReceived;

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //获得条码信息
            string serialNum = "";
            //延时确保扫描完全
            Thread.Sleep(100);

            int count = serialPort.BytesToRead;
            byte[] data = new byte[count];
            serialPort.Read(data, 0, count);
            foreach (byte item in data)
            {
                serialNum += Convert.ToChar(item);
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {

                    //显示信息

                    textBox1.Text = serialNum;
                }));

            }
        }
    }
}

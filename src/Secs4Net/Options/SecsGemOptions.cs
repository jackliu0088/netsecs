namespace Secs4Net;

public record SecsGemOptions
{
    /// <summary>
    /// 设备ID
    /// </summary>
    public ushort DeviceId { get; init; }

    /// <summary>
    /// Configure connection as Active or Passive mode.
    /// 主动或被动模式。
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// When <see cref="IsActive"/> is <see langword="true"/> the IP address will be treated remote device's IP address, 
    /// opposite the connection will bind on this IP address as Passive mode.
    /// 设置IP
    /// Default value is "127.0.0.1".
    /// </summary>
    public string IpAddress { get; init; } = "127.0.0.1";

    /// <summary>
    /// When <see cref="IsActive"/> is <see langword="true"/> the port number will be treated remote device's TCP port number, 
    /// opposite the connection will bind on the port number as Passive mode.
    /// 端口
    /// Default value is 5000.
    /// </summary>
    public int Port { get; init; } = 5000;

    /// <summary>
    /// Configure the timeout interval in milliseconds between the primary message sent till to receive the secondary message.
    /// Default value is 45000 milliseconds.
    /// T3超时默认值,发送主要消息和次要消息之间的超时时间
    /// </summary>
    public int T3 { get; init; } = 45000;

    /// <summary>
    /// Configure the timeout interval in milliseconds between the connection state transition from <see cref="ConnectionState.Connecting"/> to <see cref="ConnectionState.Connected"/>.
    /// Default value is 10000 milliseconds.
    /// T5超时默认值 连接中和连接上之间的超时时间
    /// </summary>
    public int T5 { get; init; } = 10000;

    /// <summary>
    /// Configure the timeout interval in milliseconds between the control message sent till to receive the reply message.
    /// Default value is 5000 milliseconds.
    /// T6超时默认值 心跳时间
    /// </summary>
    public int T6 { get; init; } = 5000;

    /// <summary>
    /// Configure the timeout interval in milliseconds between the connection state transition from <see cref="ConnectionState.Connected"/> to <see cref="ConnectionState.Selected"/>.
    /// Default value is 10000 milliseconds.
    /// T7超时默认值 
    /// </summary>
    public int T7 { get; init; } = 10000;

    /// <summary>
    /// Configure the timeout interval in milliseconds between the chunk received to next chunk during decoding a <see cref="SecsMessage"/>.
    /// Default value is 5000 milliseconds.
    /// T3超时默认值
    /// </summary>
    public int T8 { get; init; } = 5000;

    /// <summary>
    /// Configure the timer interval in milliseconds between each <see cref="MessageType.LinkTestRequest"/> request.
    /// 配置定制器间隔
    /// Default value is 60000.
    /// T3超时默认值
    /// </summary>
    public int LinkTestInterval { get; init; } = 60000;

    /// <summary>
    /// Configure a value that specifies the size of the receive buffer of the System.Net.Sockets.Socket.
    /// socket缓冲区大小
    /// Default value is 8192 bytes.
    /// </summary>
    public int SocketReceiveBufferSize { get; init; } = 8192;

    /// <summary>
    /// Configure the initial buffer size in bytes for the <see cref="SecsMessage"/> encoding.
    /// 为消息数据设置缓冲区大小
    /// Default value is 4096 bytes.
    /// </summary>
    public int EncodeBufferInitialSize { get; init; } = 4096;
}

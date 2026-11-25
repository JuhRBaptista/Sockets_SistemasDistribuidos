
using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Connect(String server)
    {
        try
        {
            // Define a porta do servidor
            Int32 port = 13000;

            // Cria a conexão TCP com o servidor
            using TcpClient client = new TcpClient(server, port);

            Console.WriteLine("Conectado ao servidor!");

            // Obtém o horário local do cliente
            String horaLocal = DateTime.Now.ToString("HH:mm:ss");

            // Converte o horário em um array de bytes
            Byte[] data = Encoding.UTF8.GetBytes(horaLocal);

            // Obtém o fluxo de comunicação
            NetworkStream stream = client.GetStream();

            // Envia o horário ao servidor
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Horário enviado: {0}", horaLocal);

            // Recebe a resposta do servidor
            data = new Byte[256];

            Int32 bytes = stream.Read(data, 0, data.Length);

            String responseData = Encoding.UTF8.GetString(data, 0, bytes);

            Console.WriteLine("\nResposta do servidor:");
            Console.WriteLine(responseData);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\nPressione Enter para continuar...");
        Console.Read();
    }

    static void Main()
    {
        // Endereço IP do servidor
        String server = "127.0.0.1";

        Connect(server);
    }
}

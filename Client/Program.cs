using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    // Método responsável por estabelecer a conexão com o servidor
    // e realizar a comunicação por meio do protocolo TCP.
    static void Connect(String server)
    {
        try
        {
            // Define a porta utilizada pelo servidor TCP.
            Int32 port = 13000;

            // Cria uma conexão TCP com o servidor informado,
            // utilizando seu endereço IP e a porta definida.
            // O using garante que a conexão seja liberada ao final do método.
            using TcpClient client = new TcpClient(server, port);

            // Informa que a conexão com o servidor foi estabelecida.
            Console.WriteLine("Conectado ao servidor!");

            // Obtém o horário local do computador do cliente,
            // formatando-o no padrão horas:minutos:segundos.
            String horaLocal = DateTime.Now.ToString("HH:mm:ss");

            // Converte o horário de texto para um vetor de bytes,
            // utilizando a codificação UTF-8 para permitir o envio pela rede.
            Byte[] data = Encoding.UTF8.GetBytes(horaLocal);

            // Obtém o fluxo de comunicação associado à conexão TCP.
            // Esse fluxo permite enviar dados ao servidor e receber sua resposta.
            NetworkStream stream = client.GetStream();

            // Envia os bytes correspondentes ao horário local para o servidor.
            // Os parâmetros indicam o vetor, a posição inicial e a quantidade de bytes.
            stream.Write(data, 0, data.Length);

            // Exibe no terminal o horário enviado ao servidor.
            Console.WriteLine("Horário enviado: {0}", horaLocal);

            // Cria um novo vetor de 256 bytes para armazenar
            // os dados que serão recebidos como resposta do servidor.
            data = new Byte[256];

            // Aguarda a resposta do servidor e armazena os dados recebidos no vetor.
            // O método retorna a quantidade de bytes efetivamente recebidos.
            Int32 bytes = stream.Read(data, 0, data.Length);

            // Converte os bytes recebidos em uma string utilizando UTF-8.
            // A conversão considera somente a quantidade de bytes recebidos.
            String responseData = Encoding.UTF8.GetString(data, 0, bytes);

            // Exibe a resposta recebida do servidor no terminal.
            Console.WriteLine("\nResposta do servidor:");
            Console.WriteLine(responseData);
        }

        // Captura exceções que podem ocorrer caso o argumento
        // utilizado para estabelecer a conexão seja nulo.
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }

        // Captura erros relacionados à comunicação por sockets,
        // como falhas ao tentar estabelecer uma conexão com o servidor.
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        // Aguarda uma entrada do teclado antes de encerrar o programa.
        Console.WriteLine("\nPressione Enter para continuar...");
        Console.Read();
    }

    // Método principal da aplicação, responsável por iniciar a execução.
    static void Main()
    {
        // Define o endereço IP do servidor ao qual o cliente irá se conectar.
        // O endereço 127.0.0.1 representa o próprio computador (localhost).
        String server = "127.0.0.1";

        // Chama o método Connect(), iniciando a comunicação com o servidor.
        Connect(server);
    }
}


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Globalization;

class MyTcpListener
{
    public static void Main()
    {
        // Declara o objeto responsável por representar o servidor TCP.
        // Ele começa como null porque ainda não foi inicializado.
        TcpListener server = null;

        try
        {
            // Define a porta e o endereço IP em que o servidor irá operar.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // Cria o servidor TCP utilizando o endereço IP e a porta definidos.
            server = new TcpListener(localAddr, port);

            // Inicia o servidor e permite que ele receba conexões.
            server.Start();

            // Cria um vetor de 256 bytes para armazenar os dados recebidos.
            Byte[] bytes = new Byte[256];

            // Mantém o servidor em execução, aguardando novas conexões.
            while (true)
            {
                Console.Write("Aguardando conexão... ");

                // Aguarda uma conexão de um cliente.
                // O using garante que a conexão seja liberada ao sair deste escopo.
                using TcpClient client = server.AcceptTcpClient();

                Console.WriteLine("Cliente conectado!");

                // Obtém o endereço IP do cliente conectado.
                string ipCliente =
                    ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                // Obtém o fluxo de comunicação TCP para receber e enviar dados.
                NetworkStream stream = client.GetStream();

                int i;

                // Lê os dados enviados pelo cliente.
                // O laço continua enquanto houver dados para receber.
                // Quando Read() retorna 0, significa que o cliente encerrou a conexão.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Converte os bytes recebidos em texto utilizando UTF-8.
                    // Trim() remove espaços em branco no início e no final da mensagem.
                    string data = Encoding.UTF8.GetString(bytes, 0, i).Trim();

                    // Verifica se o texto recebido corresponde ao formato HH:mm:ss.
                    // Se for válido, converte o texto para um objeto TimeSpan.
                    if (TimeSpan.TryParseExact(
                        data,
                        @"hh\:mm\:ss",
                        CultureInfo.InvariantCulture,
                        out TimeSpan horaRecebida))
                    {
                        // Obtém o horário atual do computador que executa o servidor.
                        // TimeOfDay extrai somente o horário, sem a data.
                        TimeSpan horaLocal = DateTime.Now.TimeOfDay;

                        // Calcula a diferença entre o horário local e o horário recebido.
                        TimeSpan diferenca = horaLocal - horaRecebida;

                        // Exibe no terminal as informações recebidas e os resultados.
                        Console.WriteLine("\n--- Informações recebidas ---");
                        Console.WriteLine("IP do cliente: " + ipCliente);
                        Console.WriteLine("Hora recebida: " + horaRecebida);
                        Console.WriteLine("Hora local: " + horaLocal.ToString(@"hh\:mm\:ss"));
                        Console.WriteLine("Diferença: " + diferenca);

                        // Monta a mensagem que será enviada de volta ao cliente.
                        string resposta =
                            $"Horário recebido: {horaRecebida}\n" +
                            $"Horário local: {horaLocal.ToString(@"hh\:mm\:ss")}\n" +
                            $"Diferença: {diferenca}";

                        // Converte a resposta de texto para um vetor de bytes (UTF-8).
                        byte[] msg = Encoding.UTF8.GetBytes(resposta);

                        // Envia a resposta ao cliente pelo fluxo de comunicação TCP.
                        stream.Write(msg, 0, msg.Length);
                    }
                    else
                    {
                        // Caso o horário recebido seja inválido,
                        // prepara uma mensagem informando o formato esperado.
                        string erro = "Formato inválido. Envie HH:mm:ss.";

                        // Converte a mensagem de erro para bytes.
                        byte[] msg = Encoding.UTF8.GetBytes(erro);

                        // Envia a mensagem de erro ao cliente.
                        stream.Write(msg, 0, msg.Length);
                    }
                }
            }
        }
        // Captura erros relacionados à comunicação por sockets.
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Interrompe o servidor e libera seus recursos,
            // caso ele tenha sido inicializado.
            server?.Stop();
        }

        // Aguarda uma entrada do teclado antes de encerrar o programa.
        Console.WriteLine("\nPressione Enter para continuar...");
        Console.Read();
    }
}

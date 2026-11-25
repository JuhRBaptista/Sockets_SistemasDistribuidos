
# Servidor TCP com C# e .NET

Projeto desenvolvido para implementar um sistema de comunicação cliente-servidor utilizando o protocolo TCP, com a linguagem C# e a plataforma .NET.

O servidor recebe um horário enviado pelo cliente, identifica seu endereço IP, compara o horário recebido com o horário local da máquina e retorna a diferença calculada.

## Sobre o projeto

O objetivo é explorar os conceitos fundamentais da comunicação em rede por meio de sockets TCP, permitindo a troca de informações entre aplicações cliente e servidor.

O servidor permanece em execução aguardando conexões. Quando um cliente se conecta, os dados são recebidos, interpretados e processados. Em seguida, uma resposta é enviada ao cliente pela mesma conexão.

## Funcionalidades

- Estabelecimento de conexões TCP utilizando `TcpListener` e `TcpClient`.
- Recebimento de dados por meio de `NetworkStream`.
- Identificação do endereço IP do cliente conectado.
- Validação do horário recebido no formato `HH:mm:ss`.
- Obtenção do horário local do servidor.
- Cálculo da diferença entre os horários.
- Envio dos resultados ao cliente.
- Tratamento de mensagens com formato inválido.

## Tecnologias utilizadas

| Tecnologia | Descrição |
|---|---|
| C# | Linguagem de programação utilizada no desenvolvimento. |
| .NET | Plataforma utilizada para execução da aplicação. |
| TCP | Protocolo de comunicação utilizado entre cliente e servidor. |
| Sockets | Interface utilizada para estabelecer a comunicação em rede. |

## Configuração do servidor

O servidor utiliza as seguintes configurações:

| Parâmetro | Valor |
|---|---|
| Endereço IP | `127.0.0.1` |
| Porta | `13000` |
| Codificação | UTF-8 |
| Formato do horário | `HH:mm:ss` |
| Tamanho do buffer | 256 bytes |

> **Observação:** o endereço `127.0.0.1` permite conexões apenas da própria máquina. Para comunicação entre computadores diferentes, é necessário configurar um endereço IP acessível pela rede.

## Como executar

### 1. Pré-requisitos

- .NET SDK instalado.
- Terminal ou ambiente de desenvolvimento compatível com C#.

### 2. Clonar o repositório

```bash
git clone URL_DO_REPOSITORIO
```

Entre na pasta do projeto:

```bash
cd NOME_DO_REPOSITORIO
```

### 3. Executar o servidor

Caso o projeto ainda não tenha sido criado com o template do .NET:

```bash
dotnet new console
```

Substitua o conteúdo do arquivo `Program.cs` pelo código-fonte do servidor.

Para executar:

```bash
dotnet run
```

O servidor será iniciado e ficará aguardando conexões na porta `13000`.

## Funcionamento

O processo de comunicação ocorre nas seguintes etapas:

1. O servidor é iniciado e começa a aguardar conexões TCP.
2. Um cliente estabelece uma conexão com o servidor.
3. O servidor identifica o endereço IP do cliente.
4. O cliente envia um horário no formato `HH:mm:ss`.
5. O servidor recebe e valida a informação.
6. O horário recebido é comparado com o horário local do servidor.
7. A diferença entre os horários é calculada.
8. O servidor envia uma resposta ao cliente.

### Exemplo de comunicação

**Mensagem enviada pelo cliente:**

```text
14:30:00
```

**Informações exibidas no servidor:**

```text
--- Informações recebidas ---
IP do cliente: 127.0.0.1
Hora recebida: 14:30:00
Hora local: 14:32:15
Diferença: 00:02:15
```

**Resposta enviada ao cliente:**

```text
Horário recebido: 14:30:00
Horário local: 14:32:15
Diferença: 00:02:15
```

Caso o cliente envie uma informação em formato inválido, o servidor retorna:

```text
Formato inválido. Envie HH:mm:ss.
```

## Estrutura do projeto

```text
.
├── Program.cs
└── README.md
```

## Conceitos abordados

- Arquitetura cliente-servidor.
- Comunicação orientada à conexão.
- Protocolo TCP (Transmission Control Protocol).
- Sockets de rede.
- Fluxos de dados (`NetworkStream`).
- Codificação e decodificação de mensagens.
- Manipulação de horários com `DateTime` e `TimeSpan`.
- Tratamento de exceções em aplicações de rede.

## Autor

Desenvolvido por **Júlia Ribeiro Baptista**.

Projeto acadêmico desenvolvido para estudo e aplicação dos conceitos de comunicação em redes utilizando sockets TCP, C# e .NET.

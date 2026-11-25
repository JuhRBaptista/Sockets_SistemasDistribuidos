
# Sistema de Comunicação TCP com C# e .NET

Projeto desenvolvido para implementar um sistema de comunicação cliente-servidor utilizando o protocolo TCP, a linguagem C# e a plataforma .NET.

O sistema é composto por duas aplicações independentes: um servidor TCP, responsável por receber e processar as informações, e um cliente TCP, responsável por estabelecer a conexão e enviar dados ao servidor.

A aplicação permite que o cliente envie seu horário local, enquanto o servidor compara essa informação com seu próprio horário e retorna a diferença calculada.

## Sobre o projeto

O objetivo é explorar os conceitos fundamentais da comunicação em rede por meio de sockets TCP, permitindo a troca de informações entre aplicações cliente e servidor.

A comunicação ocorre por meio de uma conexão TCP estabelecida entre as duas aplicações. O cliente envia seu horário local no formato `HH:mm:ss`, e o servidor realiza o processamento e retorna uma resposta contendo os horários e a diferença calculada.

## Funcionalidades

**Servidor TCP**
- Aguarda e aceita conexões de clientes.
- Identifica o endereço IP do cliente conectado.
- Recebe e interpreta os dados enviados.
- Valida o horário recebido no formato `HH:mm:ss`.
- Obtém o horário local do servidor.
- Calcula a diferença entre os horários.
- Envia os resultados ao cliente.
- Trata mensagens com formato inválido.

**Cliente TCP**
- Estabelece conexão com o servidor.
- Obtém o horário local da máquina.
- Envia o horário ao servidor.
- Recebe a resposta do servidor.
- Exibe os resultados no terminal.
- Trata exceções relacionadas à conexão e à comunicação.

## Tecnologias utilizadas

| Tecnologia | Descrição |
|---|---|
| C# | Linguagem de programação utilizada no desenvolvimento. |
| .NET | Plataforma utilizada para execução das aplicações. |
| TCP | Protocolo de comunicação utilizado entre cliente e servidor. |
| Sockets | Interface utilizada para estabelecer a comunicação em rede. |
| UTF-8 | Codificação utilizada na troca de mensagens. |

## Estrutura do projeto

```text
.
├── Servidor/
│   ├── Program.cs
│   └── Servidor.csproj
│
├── Cliente/
│   ├── Program.cs
│   └── Cliente.csproj
│
└── README.md
```

## Configurações da comunicação

| Parâmetro | Valor |
|---|---|
| Endereço IP | `127.0.0.1` |
| Porta | `13000` |
| Protocolo | TCP |
| Codificação | UTF-8 |
| Formato do horário | `HH:mm:ss` |

> **Observação:** o endereço `127.0.0.1` permite a comunicação apenas entre aplicações executadas na mesma máquina. Para comunicação entre computadores diferentes, é necessário configurar o endereço IP do servidor na rede.

## Como executar o projeto

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

Abra um terminal na pasta principal do repositório e execute:

```bash
cd Servidor
dotnet run
```

O servidor será iniciado e ficará aguardando conexões na porta `13000`.

### 4. Executar o cliente

Abra um segundo terminal na pasta principal do repositório e execute:

```bash
cd Cliente
dotnet run
```

O cliente estabelecerá uma conexão com o servidor, enviará seu horário local e aguardará a resposta.

**Importante:** o servidor deve ser iniciado antes do cliente.

## Funcionamento da comunicação

O processo de comunicação ocorre nas seguintes etapas:

1. O servidor é iniciado e começa a aguardar conexões TCP.
2. O cliente estabelece uma conexão com o servidor.
3. O cliente obtém seu horário local utilizando `DateTime.Now`.
4. O horário é convertido em bytes utilizando UTF-8 e enviado ao servidor.
5. O servidor recebe os dados e identifica o endereço IP do cliente.
6. O horário recebido é validado e convertido para `TimeSpan`.
7. O servidor obtém seu próprio horário local e calcula a diferença.
8. O resultado é convertido em bytes e enviado de volta ao cliente.
9. O cliente recebe e exibe a resposta no terminal.

## Exemplo de execução

**Servidor:**

```text
Aguardando conexão... Cliente conectado!

--- Informações recebidas ---
IP do cliente: 127.0.0.1
Hora recebida: 14:30:00
Hora local: 14:32:15
Diferença: 00:02:15
```

**Cliente:**

```text
Conectado ao servidor!
Horário enviado: 14:30:00

Resposta do servidor:
Horário recebido: 14:30:00
Horário local: 14:32:15
Diferença: 00:02:15
```


Desenvolvido por **Júlia Ribeiro Baptista** e **Gabriel Nunes da Silva**.

Projeto acadêmico desenvolvido para estudo e aplicação dos conceitos de comunicação em redes utilizando sockets TCP, C# e .NET.

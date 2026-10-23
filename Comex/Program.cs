using System.ComponentModel.Design;

List <Cliente> clientes = new List<Cliente>()
{
    new Cliente("Vinicius", "123456789", "vinicius@email.com", "Engenheiro", "1234567890", new Endereco("Centro", "São Paulo", "Apto 101", 123, "Rua Exemplo", "SP")),
    new Cliente("Matheus", "987654321", "matheus@email.com", "Designer", "0987654321", new Endereco("Jardim", "São Paulo", "Casa 10", 456, "Rua Exemplo", "SP"))
};

List <Produto> produtos = new List<Produto>()  
{
    new Produto("Produto A", "Descrição do Produto A", 10.99f, 100),
    new Produto("Produto B", "Descrição do Produto B", 15.99f, 50),
};

Dictionary<Cliente, Dictionary<string, int>> carrinho = new Dictionary<Cliente, Dictionary<string, int>>();


void tituloPrograma(string titulo)
{
    int quantidadaDeLetras = titulo.Length + 22;
    string sinalIguais = string.Empty.PadLeft(quantidadaDeLetras, '=');
    Console.Clear();
    Console.WriteLine($"{sinalIguais}");
    Console.WriteLine($"=          {titulo}          =");
    Console.WriteLine($"{sinalIguais}\n");
}


void ExibirMenudeOpcoes()
{
    Console.Clear();
    tituloPrograma("PROJETO COMEX");
    Console.WriteLine("Menu de Opções:\n");
    Console.WriteLine(" 1. Cadastrar Cliente");
    Console.WriteLine(" 2. Listar Clientes");
    Console.WriteLine(" 3. Cadastrar Produto");
    Console.WriteLine(" 4. Listar Produtos");
    Console.WriteLine(" 5. Ajustar Preço de Produto");
    Console.WriteLine(" 6. Adicionar Produto ao Carrinho");
    Console.WriteLine(" 7. Abrir Carrinho");
    Console.WriteLine("-1. Sair");
    Console.Write("\nDigite uma das opções: ");

    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            CadastrarCliente();
            break;
        case 2:
            ListarClientes();
            break;
        case 3:
            CadastrarProduto();
            break;
        case 4:
            ListarProdutos();
            break;
        case 5:
            AjustarPrecoProduto();
            break;
        case 6:
            AdicionarProdutoAoCarrinho();
            break;
        case 7:
            ListarItensDoCarrinho();
            break;
        case -1:
            Console.WriteLine("\nCOMEX FINALIZADO!");
            Thread.Sleep(2000);
            Environment.Exit(0);
            break;
        default:
            //Console.WriteLine("\nOpção inválida! Voltando ao menu principal...");
            Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            ExibirMenudeOpcoes();
            break;
    }
}


void CadastrarCliente()
{
    Console.Clear();
    tituloPrograma("CADASTRO DE CLIENTE");
    Console.Write("Digite o nome do cliente: ");
    string nome = Console.ReadLine()!;
    if (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("\nNenhum cliente informado. Voltando ao menu principal...");
        Thread.Sleep(2000);
        ExibirMenudeOpcoes();
    }
    else
    {
        Console.Write("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine()!;
        Console.Write("Digite o email do cliente: ");
        string email = Console.ReadLine()!;
        Console.Write("Digite a profissão do cliente: ");
        string profissao = Console.ReadLine()!;
        Console.Write("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine()!;
        Console.WriteLine("\n--- Endereço ---");
        Console.Write("Digite a rua: ");
        string rua = Console.ReadLine()!;
        Console.Write("Digite o número: ");
        int numero = int.Parse(Console.ReadLine()!);
        Console.Write("Digite o bairro: ");
        string bairro = Console.ReadLine()!;
        Console.Write("Digite a cidade: ");
        string cidade = Console.ReadLine()!;
        Console.Write("Digite o estado: ");
        string estado = Console.ReadLine()!;
        Console.Write("Digite o complemento (opcional): ");
        string complemento = Console.ReadLine()!;
        Endereco endereco = new Endereco(bairro, cidade, complemento, numero, rua, estado);
        Cliente cliente = new Cliente(nome, cpf, email, profissao, telefone, endereco);
        clientes.Add(cliente);
        Console.WriteLine($"\nCliente {cliente.Nome} cadastrado com sucesso!");
        Thread.Sleep(2000);
        ExibirMenudeOpcoes();
    }
}

void ListarClientes()
{
    Console.Clear();
    tituloPrograma("LISTAGEM DE CLIENTES");
    foreach (var cliente in clientes)
    {
        Console.WriteLine($"Nome: {cliente.Nome} | CPF: {cliente.Cpf}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    ExibirMenudeOpcoes();
}

void CadastrarProduto()
{
    Console.Clear();
    tituloPrograma("CADASTRO DE PRODUTO");
    Console.Write("Digite o nome do produto: ");
    string nome = Console.ReadLine()!;
    if (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("\nNenhum produto informado. Voltando ao menu principal...");
        Thread.Sleep(2000);
        ExibirMenudeOpcoes();
    }
    else
    {
        Console.Write("Digite o preço do produto: ");
        float preco = float.Parse(Console.ReadLine()!);
        Console.Write("Digite a Descrição do Produto: ");
        string descricao = Console.ReadLine()!;
        Console.Write("Digite a quantidade do produto: ");
        int quantidade = int.Parse(Console.ReadLine()!);
        produtos.Add(new Produto(nome, descricao, preco, quantidade)); // Armazena o preço em centavos para evitar problemas de precisão
        Console.WriteLine($"\nProduto {nome} com preço {preco:C} cadastrado com sucesso!");
        Thread.Sleep(2000);
        ExibirMenudeOpcoes();
    }
}

void ListarProdutos()
{
    Console.Clear();
    tituloPrograma("LISTAGEM DE PRODUTOS");
    foreach (var produto in produtos)
    {       
        Console.WriteLine($"Nome: {produto.Nome} | Preço: {produto.Preco:C} | Quantidade: {produto.Quantidade}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    ExibirMenudeOpcoes();
}
void AjustarPrecoProduto()
{
    Console.Clear();
    tituloPrograma("AJUSTE DE PREÇO DE PRODUTO");
    Console.Write("Digite o nome do produto: ");
    string nome = Console.ReadLine()!;
    Produto produtoEncontrado = produtos.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    if (produtoEncontrado != null)
    {
        Console.Write("Digite o novo preço do produto: ");
        float novoPreco = float.Parse(Console.ReadLine()!);
        produtoEncontrado.Preco = novoPreco;
        Console.WriteLine($"\nPreço do produto {nome} ajustado para {novoPreco:C} com sucesso!");
    }
    else
    {
        Console.WriteLine($"\nProduto {nome} não encontrado! Retornando ao menu principal...");
    }
    Thread.Sleep(2000);
    ExibirMenudeOpcoes();
} 

void AdicionarProdutoAoCarrinho()
{
    Console.Clear();
    tituloPrograma("ADICIONAR PRODUTO AO CARRINHO");
    Console.Write("Digite qual usuário está realizando a compra: ");
    string usuario = Console.ReadLine()!;
    Cliente clienteEncontrado = clientes.Find(c => c.Nome.Equals(usuario, StringComparison.OrdinalIgnoreCase));
    if (clienteEncontrado != null)
    {
        Console.WriteLine($"\nUsuário {usuario} encontrado! Prosseguindo com a compra...");
        if (!carrinho.ContainsKey(clienteEncontrado))
        {
            carrinho[clienteEncontrado] = new Dictionary<string, int>();
        }
        while (true)
        {
            Console.Write("Digite o nome do produto (ou deixe vazio para voltar ao menu): ");
            string nomeProduto = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(nomeProduto))
            {
                Console.WriteLine("\nNenhum produto informado. Voltando ao menu principal...");
                break;
            }
            Produto produtoEncontrado = produtos.Find(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
            if (produtoEncontrado != null)
            {
                Console.Write("Digite a quantidade: ");
                int quantidade = int.Parse(Console.ReadLine()!);
                // Adiciona ou acumula a quantidade do produto no carrinho do cliente
                if (carrinho[clienteEncontrado].ContainsKey(produtoEncontrado.Nome))
                {
                    carrinho[clienteEncontrado][produtoEncontrado.Nome] += quantidade;
                }
                else
                {
                    carrinho[clienteEncontrado][produtoEncontrado.Nome] = quantidade;
                }

                Console.WriteLine($"\n{quantidade} unidades do produto {nomeProduto} adicionado ao carrinho com sucesso!");
            }
            else
            {
                Console.WriteLine($"\nProduto {nomeProduto} não encontrado!");
            }
            Console.Write("\nDeseja adicionar outro produto para o mesmo usuário? (s/n): ");
            string resposta = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(resposta) || resposta.ToLower() != "s")
            {
                Console.WriteLine("\nVoltando ao menu principal...");
                break;
            }
        }
        Thread.Sleep(1000);
        ExibirMenudeOpcoes();
    }
    else
    {
        Console.WriteLine($"\nUsuário {usuario} não encontrado! Voltando ao menu principal...");
        Thread.Sleep(2000);
        ExibirMenudeOpcoes();
    }
}

void ListarItensDoCarrinho()
{
    Console.Clear();
    tituloPrograma("LISTAGEM DE ITENS NO CARRINHO");

    Console.Write("Qual cliente deseja visualizar o carrinho? ");
    string cliente = Console.ReadLine()!;
    Cliente clienteEncontrado = clientes.Find(c => c.Nome.Equals(cliente, StringComparison.OrdinalIgnoreCase));
    if (clienteEncontrado != null && carrinho.ContainsKey(clienteEncontrado))
    {
        Console.WriteLine($"Usuário: {clienteEncontrado.Nome}");
        float total = 0f;
        foreach (var kv in carrinho[clienteEncontrado])
        {
            string nomeProduto = kv.Key;
            int quantidade = kv.Value;
            Produto prod = produtos.Find(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
            decimal precoUnitario = prod != null ? (decimal)prod.Preco : 0m;
            Console.WriteLine($"  Produto: {nomeProduto} | Preço: {precoUnitario:C} | Quantidade: {quantidade}");
            float subtotal = (float)precoUnitario * quantidade;
            total += subtotal;
        }

        Console.WriteLine($"\nValor Total: {total:C}");
        Console.Write($"Gostaria de finalizar a compra? (s/n): ");
        string finalizarCompra = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(finalizarCompra) || finalizarCompra.ToLower() != "s")
        {
            Console.WriteLine("\nVoltando ao menu principal...");
            Thread.Sleep(2000);
            ExibirMenudeOpcoes();
        }
        else
        {
            if (total <= 0)
            {
                Console.WriteLine("O valor total da compra é inválido, adicione itens ao carrinho.");
            }
            else
            {
                Console.Write("Insira o numero do cartão de crédito: ");
                string numeroCartao = Console.ReadLine()!;
                Console.WriteLine($"Pagamento de {total:C} realizado com sucesso no cartão {numeroCartao}!");
                carrinho[clienteEncontrado].Clear(); // Limpa o carrinho após a compra
            }
        }

    }
    else
    {
        Console.WriteLine($"\nCliente {cliente} não encontrado ou sem itens no carrinho!");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    ExibirMenudeOpcoes();
}

ExibirMenudeOpcoes();
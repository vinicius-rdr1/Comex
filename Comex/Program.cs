using System.ComponentModel.Design;

Console.WriteLine("Hello, World!");
Dictionary<string, int> clientes = new Dictionary<string, int>()
{
    ["Vinicius"] = 123456789,
    ["Matheus"] = 987654321
};
Dictionary<string, int> produtos = new Dictionary<string, int>()
{
    ["Alexa"] = 50000,
    ["Pc Gamer"] = 250000,
    ["Celular"] = 150000
};
Dictionary<string, Dictionary<string, int>> carrinho = new Dictionary<string, Dictionary<string, int>>();



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
    Console.WriteLine(" 7. Finalizar uma Compra");
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
            FecharCompra();
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
        int cpf = int.Parse(Console.ReadLine()!);
        clientes.Add(nome, cpf);
        Console.WriteLine($"\nCliente {nome} com CPF {cpf} cadastrado com sucesso!");
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
        Console.WriteLine($"Nome: {cliente.Key} | CPF: {cliente.Value}");
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
        decimal preco = decimal.Parse(Console.ReadLine()!);
        produtos.Add(nome, (int)(preco * 100)); // Armazena o preço em centavos para evitar problemas de precisão
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
        decimal preco = produto.Value / 100m; // Converte de centavos para reais
        Console.WriteLine($"Nome: {produto.Key} | Preço: {preco:C}");
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

    if (produtos.ContainsKey(nome))
    {
        Console.Write("Digite o novo preço do produto: ");
        decimal novoPreco = decimal.Parse(Console.ReadLine()!);
        produtos[nome] = (int)(novoPreco * 100);
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

    if (clientes.ContainsKey(usuario))
    {
        Console.WriteLine($"\nUsuário {usuario} encontrado! Prosseguindo com a compra...");
        // Se o usuário ainda não tem um carrinho, cria um novo
        if (!carrinho.ContainsKey(usuario))
        {
            carrinho[usuario] = new Dictionary<string, int>();
        }

        // Loop para permitir adicionar vários produtos sem reiniciar a função
        while (true)
        {
            Console.Write("Digite o nome do produto (ou deixe vazio para voltar ao menu): ");
            string nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("\nNenhum produto informado. Voltando ao menu principal...");
                break;
            }

            if (produtos.ContainsKey(nome))
            {
                // Permite adicionar produtos repetidos: armazena quantidade no carrinho
                if (carrinho[usuario].ContainsKey(nome))
                {
                    carrinho[usuario][nome] += 1; // incrementa quantidade
                    Console.WriteLine($"\nProduto {nome} adicionado novamente. Quantidade atual: {carrinho[usuario][nome]}");
                }
                else
                {
                    carrinho[usuario][nome] = 1; // primeira unidade
                    Console.WriteLine($"\nProduto {nome} adicionado ao carrinho com sucesso!");
                }
            }
            else
            {
                Console.WriteLine($"\nProduto {nome} não encontrado!");
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

void FecharCompra()
{
    Console.Clear();
    tituloPrograma("FECHAR COMPRA");
    if (carrinho.Count == 0)
    {
        Console.WriteLine("Ainda não existem carrinhos cadastrados.");
    }
    else
    {
        Console.Write("\nDigite o nome do usuário para visualizar seus produtos no carrinho:");
        string usuario = Console.ReadLine()!;
        if (carrinho.ContainsKey(usuario))
        {
            Console.WriteLine($"\nUsuário: {usuario}");
            decimal total = 0m;
            foreach (var produto in carrinho[usuario])
            {
                int quantidade = produto.Value; // quantidade armazenada no carrinho
                int precoCents = produtos.ContainsKey(produto.Key) ? produtos[produto.Key] : 0; // busca preço atual em centavos
                decimal precoUnitario = precoCents / 100m;
                decimal subtotal = precoUnitario * quantidade;
                total += subtotal;
                Console.WriteLine($"  Nome: {produto.Key} | Quantidade: {quantidade} | Preço Unit.: {precoUnitario:C} | Subtotal: {subtotal:C}");
            }
            Console.Write("\nTotal: ");
            Console.WriteLine($"{total:C}\n");
            Console.Write("Deseja finalizar a compra? (s/n): ");
            string resposta = Console.ReadLine()!;
            if (resposta.ToLower() == "s")
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
                    carrinho[usuario].Clear(); // Limpa o carrinho após a compra
                }
            }
            else
            {
                Console.WriteLine("Compra cancelada.");
            }
        }

    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    ExibirMenudeOpcoes();
}

ExibirMenudeOpcoes();
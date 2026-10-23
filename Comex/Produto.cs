using System;
using System.Runtime.CompilerServices;

class Produto
{
    public Produto(string nome, string descricao, float preco, int quantidade)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Quantidade = quantidade;
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public float Preco { get; set; }
    public int Quantidade { get; set; }   

    public void ExibirInformacoesProduto()
    {   
        Console.WriteLine($"Nome: {Nome} | Descrição: {Descricao} | Preço: {Preco:C} | Quantidade: {Quantidade}\n");        
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public void alterarQuantidade(int novaQuantidade)
    {
        Quantidade = novaQuantidade;
    }
}

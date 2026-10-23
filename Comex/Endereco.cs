class Endereco
{
    public Endereco(string bairro, string cidade, string complemento, int numero, string rua, string estado)
    {
        Bairro = bairro;
        Cidade = cidade;
        Complemento = complemento;
        Estado = estado;
        Rua = rua;
        Numero = numero;
    }

    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Complemento { get; set; }
    public string Estado { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }

    public void exibirEndereco()
    {
        Console.WriteLine($"Rua: {Rua}, Número: {Numero}");
        Console.WriteLine($"Bairro: {Bairro}");
        Console.WriteLine($"Cidade: {Cidade}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Complemento: {Complemento}");
    }

}
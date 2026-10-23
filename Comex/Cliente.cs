class Cliente
{
    public Cliente(string nome, string cpf, string email, string profissao, string telefone, Endereco endereco)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Profissao = profissao;
        Telefone = telefone;
        Endereco = endereco;
    }

    public string Nome { get;  }
    public string Cpf { get;  }
    public string Email { get;}
    public string Profissao { get; }
    public string Telefone { get;  }
    public Endereco Endereco { get;  }

    public void exibirInformacoes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {Cpf}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Profissão: {Profissao}");
        Console.WriteLine($"Telefone: {Telefone}");
        Console.WriteLine("Endereço:");
        Endereco.exibirEndereco();
    }
}
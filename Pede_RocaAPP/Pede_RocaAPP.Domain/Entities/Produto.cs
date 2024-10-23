using Pede_RocaAPP.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser um valor positivo.")]
        public int Estoque { get; set; }

        [Range(0, 1, ErrorMessage = "O fator promocional deve ser entre 0 e 1.")]
        public decimal FatorPromocao { get; set; }

        [Required(ErrorMessage = "O UID da foto é obrigatório.")]
        [StringLength(250, ErrorMessage = "O UID da foto deve ter no máximo 250 caracteres.")]
        public string UidFoto { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
        public Guid IdUnidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        //public Guid ImagensProdutoId { get; set; }
        //public ImagensProdutos ImagensProduto { get; set; }

        public ICollection<ProdutosPedido> ProdutosPedidos { get; set; } = new List<ProdutosPedido>();
        public ICollection<ProdutoFavorito> ProdutosFavoritos { get; set; } = new List<ProdutoFavorito>();

        public Produto()
        {
        }

        public Produto(string nome, string descricao, decimal preco, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade)
        {
            Id = Guid.NewGuid();
            ValidateDomain(nome, descricao, preco, estoque, fatorPromocional, uidFoto, idCategoria, idUnidade);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            FatorPromocao = fatorPromocional;
            UidFoto = uidFoto;
            IdCategoria = idCategoria;
            IdUnidade = idUnidade;
            Status = true;
        }

        //public Produto(string nome, string descricao, decimal preco, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade, Guid idImagensProdutos)
        //{
        //    Id = Guid.NewGuid();
        //    ValidateDomain(nome, descricao, preco, estoque, fatorPromocional, uidFoto, idCategoria, idUnidade);
        //    Nome = nome;
        //    Descricao = descricao;
        //    Preco = preco;
        //    Estoque = estoque;
        //    FatorPromocao = fatorPromocional;
        //    UidFoto = uidFoto;
        //    IdCategoria = idCategoria;
        //    IdUnidade = idUnidade;
        //    ImagensProdutosId = idImagensProdutos;
        //    Status = true;
        //}

        private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3 || nome.Length > 100, "O nome deve ter entre 3 e 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(descricao), "A descrição é obrigatória.");
            DomainExceptionValidation.When(descricao.Length < 5 || descricao.Length > 200, "A descrição deve ter entre 5 e 200 caracteres.");

            DomainExceptionValidation.When(preco < 0, "Preço inválido.");
            DomainExceptionValidation.When(Math.Round(preco, 2) != preco, "Preço inválido. Deve ter no máximo duas casas decimais.");

            DomainExceptionValidation.When(estoque < 0 || estoque > 9999, "Estoque inválido.");

            DomainExceptionValidation.When(fatorPromocional < 0 || fatorPromocional > 1, "Fator promocional inválido.");

            DomainExceptionValidation.When(uidFoto.Length > 250, "UID da foto inválido.");

            DomainExceptionValidation.When(idCategoria == Guid.Empty, "O idCategoria é obrigatório.");

            DomainExceptionValidation.When(idUnidade == Guid.Empty, "O idUnidade é obrigatório.");
        }

    }

    public class AtualizarFotoProdutoRequest
    {
        public string UidFotoProduto { get; set; }
    }

    public class AtualizarStatusProdutoResponse
    {
        public bool Status { get; set; }
    }

    public class AtualizarEstoqueProdutoResponse
    {
        public int Quantidade { get; set; }
        public bool Adicionar { get; set; }
    }
}

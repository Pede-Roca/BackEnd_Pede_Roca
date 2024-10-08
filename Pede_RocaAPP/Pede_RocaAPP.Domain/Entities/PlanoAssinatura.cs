﻿using Pede_RocaAPP.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class PlanoAssinatura
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public PlanoAssinatura()
        {
        }

        public PlanoAssinatura(Guid idUsuario, decimal preco, bool ativo)
        {
            Id = Guid.NewGuid();
            ValidateDomain(idUsuario, preco, ativo);
            Preco = preco;
            Ativo = ativo;
            IdUsuario = idUsuario;
        }

        private void ValidateDomain(Guid idUsuario, decimal preco, bool ativo)
        {
            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
            DomainExceptionValidation.When(preco < 0, "Preço inválido, deve ser maior ou igual a zero.");
        }
    }
}

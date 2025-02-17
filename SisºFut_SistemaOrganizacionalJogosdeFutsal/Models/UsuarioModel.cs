﻿using SisºFut_SistemaOrganizacionalJogosdeFutsal.Enums;
using SisºFut_SistemaOrganizacionalJogosdeFutsal.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisºFut_SistemaOrganizacionalJogosdeFutsal.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisºFut_SistemaOrganizacionalJogosdeFutsal.Models;
using SisºFut_SistemaOrganizacionalJogosdeFutsal.Repositorio;

using System;
using System.IO;

namespace SisºFut_SistemaOrganizacionalJogosdeFutsal.Controllers
{
    public class CadastroPublicoController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITimeXQuadrasRepositorio _timeXquadrasRepositorio;
        private readonly IQuadrasRepositorio _quadrasRepositorio;

        public CadastroPublicoController(IUsuarioRepositorio usuarioRepositorio,


            ITimeXQuadrasRepositorio timeXquadras,
            IQuadrasRepositorio quadras)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _timeXquadrasRepositorio = timeXquadras;
            _quadrasRepositorio = quadras; 
        }

        [HttpGet]
        [AllowAnonymous] // Permite acesso sem login
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Cadastro(CadastroModel cadastro)
        {
            try
            {




                if (!string.IsNullOrEmpty(cadastro.usuario.Login) && !string.IsNullOrEmpty(cadastro.usuario.Senha)) 
                {

                    var base64 = "";

                    if (cadastro.usuario.FotoArquivo != null && cadastro.usuario.FotoArquivo.Length > 0)
                    {
                        base64 = ConverterParaBase64(cadastro.usuario.FotoArquivo);
                        cadastro.usuario.Foto = base64;
                    }


                    cadastro.usuario.Perfil = Enums.PerfilEnum.Padrao; // Define um perfil padrão
                    var a = _usuarioRepositorio.Adicionar(cadastro.usuario);

                    if (!string.IsNullOrEmpty(cadastro.DS_Endereco) && !string.IsNullOrEmpty(cadastro.NM_Quadra))
                    {
                        QuadrasModel quadras = new QuadrasModel { DS_Endereco = cadastro.DS_Endereco, NM_Quadra = cadastro.NM_Quadra, id_Time = a.Id };
                        _quadrasRepositorio.Adicionar(quadras);
                    }

                    //_timeXquadrasRepositorio.Adicionar(new TimeXQuadrasModel { id_Quadra = quadras.Id, id_Time = cadastro.usuario.Id }); 

                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index", "Login"); // Redireciona para login
                }

                return View(cadastro.usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar usuário. Detalhe: {erro.Message}";
                return View(cadastro.usuario);
            }
        }



        public string ConverterParaBase64(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                arquivo.CopyTo(memoryStream); // versão síncrona
                var bytes = memoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }




    }
}

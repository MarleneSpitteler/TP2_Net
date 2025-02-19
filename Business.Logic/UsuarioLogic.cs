﻿using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic 
    {
        public UsuarioLogic()
        {
            this.UsuarioData = new UsuarioAdapter();
        }

        public UsuarioAdapter UsuarioData { get; set; }

        public Usuario GetOne(int id)
        {
            Usuario usu;
            try
            {
                usu = UsuarioData.GetOne(id);

            }
            catch (Exception Ex)
            {   
                Exception ExcepcionManejada = new Exception("Error al recuperar el usuario", Ex);
                throw ExcepcionManejada;
            }
            return usu;
        }

        public List<Usuario> GetAll()
        { List<Usuario> usuarios;
            try 
            {
                usuarios= UsuarioData.GetAll(); 
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            return usuarios;
        }

        public void Save(Usuario usu)
        {
            try
            {
                UsuarioData.Save(usu);
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExceptionManejada;
            }
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public Usuario ValidarUsuario(string usuario)
        {
            return UsuarioData.ValidarUsuario(usuario);
        }

        public bool ValidarContraseña(string usuario, string pass, Usuario usu)
        {
            return UsuarioData.ValidarContraseña(usuario, pass, usu);
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : AplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if(Modo==ModoForm.Alta)
            {
                this.txtLegajo.ReadOnly = false;
            }
        }
        private void EnableForm(bool enable)
        {
            this.txtID.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtUsuario.Enabled = enable;
            this.txtClave.Enabled = enable;
            this.txtConfirmarClave.Enabled = enable;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            if (modo == ModoForm.Baja)
            {
                EnableForm(false);
            }
            Modo = modo;
            UsuarioLogic usr = new UsuarioLogic();
            try 
            { 
                UsuarioActual = usr.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {  
                Notificar("Error", "Error al recuperar lista de usuarios" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtLegajo.Text = this.UsuarioActual.Legajo.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            UsuarioLogic usr = new UsuarioLogic();
            Usuario nuevoUsu = new Usuario();
            UsuarioActual = nuevoUsu;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoUsu.Legajo = int.Parse(this.txtLegajo.Text);
                nuevoUsu.Clave = this.txtClave.Text;
                nuevoUsu.NombreUsuario = this.txtUsuario.Text;
                nuevoUsu.Habilitado = this.chkHabilitado.Checked;

                if (Modo == ModoForm.Alta)
                {
                   
                    PersonaLogic perlo = new PersonaLogic();
                    Persona per = new Persona();
                    per = perlo.GetOne(nuevoUsu.Legajo);
                    if (per != null)
                    {
                        nuevoUsu.State = BusinessEntity.States.New;
                        nuevoUsu.IdPersona = per.ID;
                        nuevoUsu.Nombre = per.Nombre;
                        nuevoUsu.Apellido = per.Apellido;
                        nuevoUsu.Email = per.Email;
                        usr.Save(nuevoUsu);
                    }
                    else
                    {
                        Notificar("Error",
                                        "La persona con ese legajo no se encuentra registrada.",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoUsu.ID = int.Parse(this.txtID.Text);
                    nuevoUsu.State = BusinessEntity.States.Modified;
                    PersonaLogic perlo = new PersonaLogic();
                    Persona per = new Persona();
                    per = perlo.GetOne(nuevoUsu.Legajo);
                    nuevoUsu.IdPersona = per.ID;
                    nuevoUsu.Nombre = per.Nombre;
                    nuevoUsu.Apellido = per.Apellido;
                    nuevoUsu.Email = per.Email;
                    usr.Save(nuevoUsu);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoUsu.ID = int.Parse(this.txtID.Text);
                nuevoUsu.State = BusinessEntity.States.Deleted;
                usr.Save(nuevoUsu);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
        }

        public override bool Validar()
        {
            bool rta = false;
            if (this.txtUsuario.Text != String.Empty && this.txtLegajo.Text != String.Empty
                && this.txtClave.Text != String.Empty && this.txtConfirmarClave.Text != String.Empty)
            {
                if (this.txtClave.Text == this.txtConfirmarClave.Text)
                {
                    int cantCarac = this.txtClave.Text.Length;

                    if (cantCarac >= 8)
                    {
                        foreach (char item in this.txtClave.Text)
                        {
                            rta = char.IsWhiteSpace(item);
                            if (rta)
                                break;
                        }

                        if (rta)
                        {
                            Notificar("Contraseña inválida",
                                        "La contraseña no puede contener espacios en blanco",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                            rta = false;
                        }
                        else
                        {
                            rta = true;
                        }
                       
                    }
                    else
                    {
                        Notificar("Contraseña inválida",
                                         "La contraseña al menos 8 caracteres",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Notificar("Contraseña inválida",
                                         "El campo Clave no coincide con el campo Confirmar Clave",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                }
            }
            else
            {
                Notificar("Ficha de usuario vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }

            return rta;
        }

        public Usuario UsuarioActual { get; set; }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
             
            if (Validar())
            {
                    GuardarCambios();
                    this.txtLegajo.ReadOnly = true;
                    this.Close();
            }
            
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.txtLegajo.ReadOnly = true;
            this.Close();
        }

        // txtClave
        private void ckbSeeClave1_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtClave.Text;
            if (ckbSeeClave1.Checked)
            {
                txtClave.UseSystemPasswordChar = false;
                txtClave.Text = text;
            }
            else
            {
                txtClave.UseSystemPasswordChar = true;
                txtClave.Text = text;
            }
        }

        // txtConfirmarClave
        private void ckbSeeClave2_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtConfirmarClave.Text;
            if (ckbSeeClave2.Checked)
            {
                txtConfirmarClave.UseSystemPasswordChar = false;
                txtConfirmarClave.Text = text;
            }
            else
            {
                txtConfirmarClave.UseSystemPasswordChar = true;
                txtConfirmarClave.Text = text;
            }
        }
    }
}
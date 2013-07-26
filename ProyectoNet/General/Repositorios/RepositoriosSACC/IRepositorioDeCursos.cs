﻿using System;
namespace General.Repositorios
{
    public interface IRepositorioDeCursos
    {
        void ActualizarInscripcionesACurso(System.Collections.Generic.List<General.Alumno> alumnos_a_inscribir, General.Curso curso, General.Usuario usuario);
        bool AgregarCurso(General.Curso curso);
        General.Curso GetCursoById(int id);
        System.Collections.Generic.List<General.Curso> GetCursos();
        bool ModificarCurso(General.Curso curso);
        bool QuitarCurso(General.Curso curso, General.Usuario usuario);
        bool TieneAsignadoAlumnos(General.Curso un_curso);
        bool TieneAsignadoDocente(General.Curso un_curso);
    }
}

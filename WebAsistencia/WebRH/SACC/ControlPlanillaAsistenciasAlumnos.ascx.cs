﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSViaticos;

public partial class ControlPlanillaAsistenciasAlumnos : System.Web.UI.UserControl
{
    int anio = 2013;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack)
            //GuardarDetalleAsistencias();
        if (Request.QueryString.Count > 0)
        {
            this.CursoId.Value = Request["idCurso"];
            this.Mes.Value = Request["mes"];
        }
        CargarAsistencias();

    }

    public void CargarAsistencias()
    {
        var id_curso = int.Parse(this.CursoId.Value);
        var mes = int.Parse("0" + this.Mes.Value);
        
        if (id_curso != 0 && mes != 0)
        {
            var dias = DateTime.DaysInMonth(anio, mes);
            var fecha_desde = new DateTime(2013, mes, 01);
            var fecha_hasta = new DateTime(2013, mes, dias);

            var planilla = Servicio().GetPlanillaInasistenciaAlumnoPorMes(id_curso, fecha_desde, fecha_hasta);
            var curso = JsonConvert.DeserializeObject<JObject>(Servicio().GetCursoById(id_curso));
            this.Curso.Value = curso.ToString();

            this.planillaJSON.Value = planilla.ToString();
        }
        else
            this.planillaJSON.Value = "";
    }



    public void GuardarDetalleAsistencias()
    {
        var detalle_asistencias_JSON = JsonConvert.DeserializeObject<JArray>(this.DetalleAsistencias.Value);
        if (detalle_asistencias_JSON != null)
        {
            var servicio = Servicio();
            
            var detalle_asistencias_dto = new List<AsistenciaDto>();
            foreach (var item in detalle_asistencias_JSON)
            {
                var id_alumno = int.Parse(item["id_alumno"].ToString());
                var fecha = DateTime.Parse(item["fecha"].ToString());
                var valor = int.Parse(item["valor"].ToString());
                var asistencia_dto = new AsistenciaDto();
                asistencia_dto.IdAlumno = id_alumno;
                asistencia_dto.IdCurso = int.Parse(this.CursoId.Value);
                asistencia_dto.Fecha = fecha;
                asistencia_dto.Valor = valor;
                detalle_asistencias_dto.Add(asistencia_dto);
            }
            servicio.GuardarDetalleAsistencias(detalle_asistencias_dto.ToArray(), (Usuario)Session["usuario"]);

            var curso = this.Curso.Value;
        }
    }


    public void ActualizarCurso(CursoDto detalle_curso_JSON)
    {
        //Curso detalle_curso_JSON = JsonConvert.DeserializeObject<Curso>(this.curso_con_observaciones.Value);
        if (detalle_curso_JSON != null)
        {
            var servicio = Servicio();
            detalle_curso_JSON.Horarios = servicio.GetCursoDtoById(detalle_curso_JSON.Id, (Usuario)Session["usuario"]).Horarios;

           /* var curso = new CursoDto();

            curso.Id = detalle_curso_JSON.Id;
            curso.Materia = detalle_curso_JSON.Materia;
            curso.Docente = detalle_curso_JSON.Docente;
            curso.EspacioFisico = detalle_curso_JSON.EspacioFisico;

            //var horariosDto = new List<HorarioDto>();
            //servicio.GetHorariosDeCursoById()
            //servicio.GetCursoById(curso.Id)//GetHorariosDto(horariosDto); 
            curso.Horarios = servicio.GetCursoDtoById(curso.Id, (Usuario)Session["usuario"]).Horarios;
            curso.FechaInicio = detalle_curso_JSON.FechaInicio.ToString();
            curso.FechaFin = detalle_curso_JSON.FechaFin.ToString();
            curso.Observaciones = detalle_curso_JSON.Observaciones;*/

            servicio.ModificarCurso(detalle_curso_JSON); //, (Usuario)Session["usuario"]); Ver si hay que agregar usuario o no

            //var curso = this.Curso.Value;
        }
    }



    private WSViaticosSoapClient Servicio(){
        return new WSViaticosSoapClient();
    }
    protected void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarAsistencias();
    }
}
    



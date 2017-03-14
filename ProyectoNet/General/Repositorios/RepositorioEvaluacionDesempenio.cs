﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using General.MAU;
using System.Reflection;

namespace General.Repositorios
{
    public class RepositorioEvaluacionDesempenio
    {
        private static RepositorioEvaluacionDesempenio _instancia;

        IConexionBD _conexion;
        private RepositorioEvaluacionDesempenio(IConexionBD conexion)
        {
            _conexion = conexion;
        }

        public static RepositorioEvaluacionDesempenio NuevoRepositorioEvaluacion(IConexionBD conexion)
        {
            if (!(_instancia != null)) _instancia = new RepositorioEvaluacionDesempenio(conexion);
            return _instancia;
        }

        public string getFormularioDeEvaluacion(int nivel, int evaluado, int evaluacion)
        {
            var parametros = new Dictionary<string, object>();
            var list_de_pregYRtas = new List<FormEvaluacion> { };
            var list_de_pregYRtasRespondidas = new List<Object> { };
            var tablaDatos = new TablaDeDatos();

            if (evaluacion != 0)
            {
                parametros.Add("@id_evaluacion", evaluacion);
                tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluacion", parametros);
                

                if (tablaDatos.Rows.Count > 0)
                {
                    tablaDatos.Rows.ForEach(row =>
                    {
                        list_de_pregYRtasRespondidas.Add(new
                        {
                            idPregunta = row.GetSmallintAsInt("id_pregunta", 0),
                            Enunciado = row.GetString("Enunciado", "Sin enunciado"),
                            Rta1 = row.GetString("Rpta1", "Sin información"),
                            Rta2 = row.GetString("Rpta2", "Sin información"),
                            Rta3 = row.GetString("Rpta3", "Sin información"),
                            Rta4 = row.GetString("Rpta4", "Sin información"),
                            Rta5 = row.GetString("Rpta5", "Sin información"),
                            OpcionElegida = row.GetSmallintAsInt("opcion_elegida", 0)

                        });
                    });

                }
            }

                parametros = new Dictionary<string, object>();
                parametros.Add("@id_formulario", nivel);
                tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Formulario", parametros);

                if (tablaDatos.Rows.Count > 0)
                {
                    tablaDatos.Rows.ForEach(row =>
                    {
                        FormEvaluacion form = new FormEvaluacion();
                        form.Orden = row.GetSmallintAsInt("Orden", 0);
                        form.idPregunta = row.GetSmallintAsInt("id_pregunta", 0);
                        form.idConcepto = row.GetSmallintAsInt("id_concepto", 0);
                        form.Enunciado = row.GetString("Enunciado", "Sin enunciado");
                        form.Factor = row.GetString("Factor", "0");
                        form.idNivel = row.GetSmallintAsInt("id_nivel", 0);
                        form.DescripcionNivel = row.GetString("descripcion_nivel", "Sin información");
                        form.DetalleNivel = row.GetString("detalle_nivel", "Sin información");
                        form.Rta1 = row.GetString("Rpta1", "Sin información");
                        form.Rta2 = row.GetString("Rpta2", "Sin información");
                        form.Rta3 = row.GetString("Rpta3", "Sin información");
                        form.Rta4 = row.GetString("Rpta4", "Sin información");
                        form.Rta5 = row.GetString("Rpta5", "Sin información");
                        form.Concepto = row.GetString("concepto", "Sin información");
                        form.OpcionElegida = 0;


                        list_de_pregYRtas.Add(form);
                        
                    });

                }
            

            foreach (var item in list_de_pregYRtasRespondidas)
            {
                var idPreguntaDeLaEvaluacion = (int)item.GetType().GetProperty("idPregunta").GetValue(item, null);
                var opcionElegida = (int)item.GetType().GetProperty("OpcionElegida").GetValue(item, null);
                foreach (var subForm in list_de_pregYRtas)
	            {
                    
                    if (subForm.idPregunta == idPreguntaDeLaEvaluacion)
                    {
                        subForm.OpcionElegida = opcionElegida;
                    }
                    
	            }
            }
            

            return JsonConvert.SerializeObject(list_de_pregYRtas);
        }
        
        public string GetNivelesFormulario(string id_nivel)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_nivel", int.Parse(id_nivel));
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_CATEGORIAS_NIVEL", parametros);
            object respuesta;

            respuesta = new { id_nivel = tablaDatos.Rows[0].GetSmallintAsInt("id_nivel"),
                              deficiente = tablaDatos.Rows[0].GetSmallintAsInt("deficiente"),
                              regular = tablaDatos.Rows[0].GetSmallintAsInt("regular"),
                              bueno = tablaDatos.Rows[0].GetSmallintAsInt("bueno"),
                              destacado = tablaDatos.Rows[0].GetSmallintAsInt("destacado"),
                              descripcion_nivel = tablaDatos.Rows[0].GetString("descripcion")
            };
            return JsonConvert.SerializeObject(respuesta);
        }

        public string GetAgentesEvaluablesPor(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluador", usuario.Owner.Id);
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluados_Evaluador", parametros);

            var tipos_consultas = new List<Object> { };
            var detalle_preguntas = new List<Object> { };
            var primer_row = true;
            object evaluador = new { };

            if (tablaDatos.Rows.Count > 0)
            {
                var id_evaluacion_anterior = 0;
                tablaDatos.Rows.ForEach(row =>
                {

                    if (primer_row == true)
                    {
                        primer_row = false;
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        evaluador = newEvaluadoFromRow(row, detalle_preguntas, id_evaluado);
                    }

                    if (row.GetSmallintAsInt("id_evaluacion", 0) != id_evaluacion_anterior || id_evaluacion_anterior == 0)
                    {
                        tipos_consultas.Add(evaluador);
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        detalle_preguntas = new List<object>();
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        evaluador = newEvaluadoFromRow(row, detalle_preguntas, id_evaluado);
                        AddDetallePreguntasA(detalle_preguntas, row);
                        
                    }
                    else
                    {
                        AddDetallePreguntasA(detalle_preguntas, row);
                    }
                });
            }

            return JsonConvert.SerializeObject(tipos_consultas);
        }

        protected void AddDetallePreguntasA(List<object> detalle_preguntas, RowDeDatos row)
        {
            detalle_preguntas.Add(new
            {
                id_pregunta = row.GetSmallintAsInt("id_pregunta", 0),
                orden_pregunta = row.GetSmallintAsInt("orden_pregunta", 0),
                respuesta_elegida = row.GetSmallintAsInt("opcion_elegida", 0),
                enunciado = row.GetString("enunciado", ""),
                rpta1 = row.GetString("rpta1", ""),
                rpta2 = row.GetString("rpta2", ""),
                rpta3 = row.GetString("rpta3", ""),
                rpta4 = row.GetString("rpta4", ""),
                rpta5 = row.GetString("rpta5", ""),
            });
        }

        protected object newEvaluadoFromRow(RowDeDatos row, List<object> detalle_preguntas, int id_evaluado)
        {
            return new
                        {
                            id_evaluado = id_evaluado,
                            apellido = row.GetString("apellido"),
                            nombre = row.GetString("nombre"),
                            nro_documento = row.GetInt("NroDocumento"),
                            id_evaluacion = row.GetInt("id_evaluacion", 0),
                            estado = row.GetSmallintAsInt("estado_evaluacion", 0),
                            id_periodo = row.GetInt("id_periodo", 0),
                            descripcion_periodo = row.GetString("descripcion_periodo", ""),
                            id_nivel = row.GetSmallintAsInt("id_nivel", 0),
                            descripcion_nivel = row.GetString("descripcion_nivel", ""),
                            deficiente = row.GetSmallintAsInt("deficiente", 0),
                            regular = row.GetSmallintAsInt("regular", 0),
                            bueno = row.GetSmallintAsInt("bueno", 0),
                            destacado = row.GetSmallintAsInt("destacado", 0),
                            detalle_preguntas = detalle_preguntas
                        };
        }

        public int insertarEvaluacion(int idEvaluado, int idEvaluador, int idFormulario, int periodo, int estado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", 0);
            parametros.Add("@id_evaluador", idEvaluador);
            parametros.Add("@id_evaluado", idEvaluado);
            parametros.Add("@id_formulario", idFormulario);
            parametros.Add("@id_periodo", periodo);
            parametros.Add("@estado", estado);
            parametros.Add("@baja", 0);
            //parametros.Add("@fecha", DateTime());


            return (int)_conexion.EjecutarEscalar("dbo.EVAL_INS_Evaluacion", parametros);

        }

        public void updateEvaluacion(int idEval, int idEvaluado, int idEvaluador, int idFormulario, int periodo, int estado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEval);
            parametros.Add("@id_evaluador", idEvaluador);
            parametros.Add("@id_evaluado", idEvaluado);
            parametros.Add("@id_formulario", idFormulario);
            parametros.Add("@id_periodo", periodo);
            parametros.Add("@estado", estado);
            parametros.Add("@baja", 0);
            parametros.Add("@fecha", DateTime.Today);

            _conexion.Ejecutar("dbo.EVAL_UPD_Evaluacion", parametros);

        }

        public void insertarEvaluacionDetalle(int idEvaluacion, int idPregunta, int opcion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEvaluacion);
            parametros.Add("@id_pregunta", idPregunta);
            parametros.Add("@opcion_elegida", opcion);

            _conexion.Ejecutar("dbo.EVAL_INS_Evaluacion_Detalle", parametros);

        }

        public void deleteEvaluacionDetalle(int idEval)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEval);

            _conexion.Ejecutar("dbo.EVAL_DEL_Evaluacion_Detalle", parametros);
        }
    }

}

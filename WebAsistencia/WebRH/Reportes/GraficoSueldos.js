﻿var GraficoSueldos = {
    Inicializar: function () {
        var _this = this;

        $('#txt_fecha_desde_sueldo').datepicker();
        $('#txt_fecha_desde_sueldo').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#txt_fecha_desde_sueldo').datepicker("setDate", new Date());

        localStorage.removeItem("alias");
        localStorage.removeItem("idArea");

        $('#btn_buscar_sueldo').click(function () {
            _this.BuscarDatos();

        });
    },

    FormatearNumero: function (numero) {
        var _this = this;
        if (numero == 0) return "";
        return '$' + _this.FormatearConPunto(numero.toFixed(2).toString().replace(".", ","));
    },

    FormatearABlanco: function (numero) {
        if (numero == 0) return "";
        return numero;
    },

    FormatearConPunto: function (n) {
        n = n.toString()
        while (true) {
            var n2 = n.replace(/(\d)(\d{3})($|,|\.)/g, '$1.$2$3')
            if (n == n2) break
            n = n2
        }
        return n;
    },

    BuscarDatos: function () {
        var _this = this;
        var buscar = true;

        var fecha = $('#txt_fecha_desde_sueldo').val();
        //Me fijo si esta seteado el storage
        if (typeof (Storage) !== "undefined") {
            var id_area = localStorage.getItem("idArea");
            var alias = localStorage.getItem("alias");
            if (fecha == null || fecha == "") {
                buscar = false;
                alertify.error("Debe completar la fecha de corte para la búsqueda de datos");
            }
            if (id_area == null || id_area == "") {
                buscar = false;
                alertify.error("Debe seleccinar un área desde el organigrama");
            }
            if (buscar) {
                _this.GraficoYTabla(fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "div_tabla_detalle_sueldo", "tabla_detalle_sueldo");
            }

        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

    },

    GraficoYTabla: function (fecha, id_area, incluir_dependencias, div_tabla, tabla) {
        var _this = this;
        $('#div_resultados_sueldos').show();
        $('#search_detalle_sueldo').show();
        $('#exportar_datos_detalle_sueldo').show();

        var spinner = new Spinner({ scale: 3 });
        spinner.spin($("html")[0]);

        Backend.GetReporteSueldosPorArea({ fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (sueldos) {
                if (sueldos != null) {
                    // _this.VisualizarContenido(true);
                    _this.DibujarTablaDetalle(sueldos, div_tabla, tabla);
                    _this.BuscadorDeTabla();

                } else {
                    _this.VisualizarContenido(false);
                    alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                }
                spinner.stop();
            })
            .onError(function () {
                alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                spinner.stop();
            })
    },

    DibujarTablaDetalle: function (resultado, div_tabla, tabla) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search").show();
        $("#exportar_datos").show();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];

        columnas.push(new Columna("Area", { generar: function (un_registro) { return un_registro.areaDescripMedia } }));
        columnas.push(new Columna("Documento", { generar: function (un_registro) { return _this.FormatearConPunto(un_registro.nroDocumento); } }));
        columnas.push(new Columna("Apellido", { generar: function (un_registro) { return un_registro.apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_registro) { return un_registro.nombre } }));
        columnas.push(new Columna("SueldoBruto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.sueldoBruto); } }));
        columnas.push(new Columna("SueldoNeto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.sueldoNeto); } }));
        columnas.push(new Columna("ExtrasBruto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.xtrasBruto); } }));
        columnas.push(new Columna("ExtrasNeto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.xtrasNeto); } }));
        //columnas.push(new Columna("SAC Bruto", { generar: function (un_registro) { return un_registro.SACBruto } }));
        //columnas.push(new Columna("SAC Neto", { generar: function (un_registro) { return un_registro.SACNeto } }));
        columnas.push(new Columna("HsSimples", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.hsSimples); } }));
        columnas.push(new Columna("Hs50%", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.hs50); } }));
        columnas.push(new Columna("Hs100%", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.hs100); } }));
        columnas.push(new Columna("Comidas", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.comidas); } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    console.log(un_registro);
                    localStorage.setItem("documento", un_registro.nroDocumento);
                    window.open('ConsultaIndividual.aspx', '_blank');
                    //window.location.replace("ConsultaIndividual.aspx");
                });

                return btn_accion;
            }
        }));

        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) {
        });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);
        _this.BuscadorDeTablaDetalle();
    },

    BuscadorDeTablaDetalle: function () {

        var options = {
            valueNames: ['Area', 'Documento', 'Apellido', 'Nombre', 'SueldoBruto', 'SueldoNeto', 'ExtrasBruto', 'ExtrasNeto', 'HsSimples', 'Hs50%', 'Hs100%', 'Comidas']
        };
        var featureList = new List('div_tabla_detalle_sueldo', options);
    },

    ConvertirFecha: function (fecha) {
        var dia = fecha.substring(8, 10);
        var mes = fecha.substring(5, 7);
        var anio = fecha.substring(0, 4);
        return dia + "/" + mes + "/" + anio;
    },

    VisualizarContenido: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_torta_totales').show();
        }
    },


    BuscarExcel: function (tipo, fecha, id_area) {
        var _this = this;

        var tipo = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde').val();
        //Me fijo si esta seteado el storage
        var id_area = localStorage.getItem("idArea");

        if (id_area == null) {
            return;
        }

        var resultado = Backend.ejecutarSincronico("ExcelGenerado", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked")}]);

        if (resultado.length > 0) {

            var a = window.document.createElement('a');
            a.href = "data:application/vnd.ms-excel;base64," + resultado;
            a.download = "RECIBOS_DE_SUELDO_" + fecha + "_.xlsx";

            document.body.appendChild(a)
            a.click();
            document.body.removeChild(a)


        }

    }

}

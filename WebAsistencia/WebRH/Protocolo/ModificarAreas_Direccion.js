﻿var ModificarAreas_Direccion = {

    Iniciar: function () {
        var _this = this;
        _this.DefinirEventos();
        _this.CargarCombos();
        _this.SettearValores(area.DireccionCompleta)

    },

    DefinirEventos: function () {
        var _this = this;
        $('#btn_nuevo_edificio').click(function () {
            $("#div_agregar_edificio").show();
            $("#div_agregar_oficina").hide();

        });

        $('#btn_nueva_oficina_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();
        });

        $('#btn_volver_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();
            _this.ReescribirDatos();

        });

        $('#btn_guardar_oficina').click(function () {
            _this.GuardarCambiosEnOficina();
        });
        $('#btn_guardar_edificio').click(function () {
            _this.GuardarCambiosEnEdificio();
        });

        $('#btn_volver_oficina').click(function () {
            $("#div_agregar_oficina").hide();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").show();
            _this.ReescribirDatos();
        });


        $('#cmb_edificio_provincia').change(function () {
            $('#cmb_edificio_localidad').empty();
            area.DireccionCompleta.Localidad.IdProvincia = $('#cmb_edificio_provincia').find('option:selected').val();
            _this.CargarComboLocalidad();
        });

        $('#cmb_edificio_localidad').change(function () {
            area.DireccionCompleta.CodigoPostal = "";
            $('#txt_oficina_codigopostal').val(area.DireccionCompleta.CodigoPostal);
        });

        $('#cmb_direccion_edificio').change(function () {
            area.DireccionCompleta.IdEdificio = $('#cmb_direccion_edificio').val();
            _this.CargarComboOficina();
        });

    },
    CargarCombos: function () {
        this.CargarComboProvincia();
        this.CargarComboLocalidad();
        this.CargarComboEdificio();
        this.CargarComboOficina();
    },

    CargarComboProvincia: function () {
        var combo = $('#cmb_edificio_provincia');

        var provincias = Backend.ejecutarSincronico("BuscarProvincias", [{ IdPais: 0}]);

        if (provincias.length > 0) {
            for (var i = 0; i < provincias.length; i++) {
                combo.append('<option value="' + provincias[i].Id + '">' + provincias[i].Nombre + '</option>');
            }
        }
    },

    CargarComboLocalidad: function () {
        var combo = $('#cmb_direccion_localidad');
        var combo2 = $('#cmb_edificio_localidad');

        var provincia = area.DireccionCompleta.Localidad.IdProvincia;
        var localidades = Backend.ejecutarSincronico("BuscarLocalidades", [{ IdProvincia: parseInt(provincia)}]);

        if (localidades.length > 0) {
            for (var i = 0; i < localidades.length; i++) {
                combo.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
                combo2.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
            }
            if (provincia.toString() != "") {
                if (provincia == 0) {
                    $('#cmb_direccion_localidad').val(localidades[0].Id).change();
                    $('#cmb_edificio_localidad').val(localidades[0].Id).change();
                } else {
                    $('#cmb_direccion_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                    $('#cmb_edificio_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                }
            }
        }
    },

    CargarComboEdificio: function () {
        var combo = $('#cmb_direccion_edificio');
        var combo2 = $('#cmb_oficina_edificio');

        var id_localidad = area.DireccionCompleta.Localidad.Id;
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorLocalidad", [{ IdLocalidad: parseInt(id_localidad)}]);

        if (edificios.length > 0) {
            for (var i = 0; i < edificios.length; i++) {
                combo.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
                combo2.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
            }
        }
    },

    CargarComboOficina: function () {
        var combo = $('#cmb_direccion_oficina');
        combo.empty();
        var id_edificio = area.DireccionCompleta.IdEdificio;
        var id_area = area.Id;
        var oficinas = Backend.ejecutarSincronico("ObtenerOficinaPorEdificio", [{ IdEdificio: parseInt(id_edificio), IdArea: parseInt(id_area)}]);

        if (oficinas.length > 0) {
            for (var i = 0; i < oficinas.length; i++) {
                combo.append('<option value="' + oficinas[i].Id + '">' + oficinas[i].Descripcion + '</option>');
            }
        }
    },

    SettearValores: function (direccion) {
        $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
        $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);

        $("#txt_direccion_Calle").val(direccion.Calle);
        $("#txt_direccion_Nro").val(direccion.Numero);
        $("#txt_direccion_Piso").val(direccion.Piso);
        $("#txt_direccion_Oficina").val(direccion.Dto);
        $("#txt_direccion_UF").val(direccion.UF);

        $('#cmb_direccion_edificio').val(direccion.IdEdificio).change();
        $('#cmb_direccion_oficina').val(direccion.IdOficina).change();

        $("#txt_oficina_piso").val(direccion.Piso);
        $("#txt_oficina_oficina").val(direccion.Dto);
        $("#txt_oficina_uf").val(direccion.UF);

        $('#cmb_oficina_edificio').val(direccion.IdEdificio).change();

        $("#cmb_edificio_provincia").val(direccion.Localidad.NombreProvincia);
        $("#cmb_edificio_localidad").val(direccion.Localidad.CodigoPostal);
        $("#txt_edificio_calle").val(direccion.Calle);
        $("#txt_oficina_codigopostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_edificio_numero").val(direccion.Numero);

    },

    GuardarCambiosEnOficina: function () {
        area.DireccionCompleta.Piso = $('#txt_oficina_piso').val();
        area.DireccionCompleta.Dto = $('#txt_oficina_oficina').val();
        area.DireccionCompleta.UF = $('#txt_oficina_uf').val();
        alertify.alert("Se han modificado los datos de la Oficina");
    },

    GuardarCambiosEnEdificio: function () {
        if ($("#txt_oficina_codigopostal").esValido()) {
            area.DireccionCompleta.CodigoPostal = $('#txt_oficina_codigopostal').val();
            area.DireccionCompleta.Calle = $('#txt_edificio_calle').val();
            area.DireccionCompleta.Numero = $('#txt_edificio_numero').val();
            area.DireccionCompleta.Localidad.Id = $('#cmb_edificio_localidad').find('option:selected').val();
            area.DireccionCompleta.Localidad.IdProvincia = $('#cmb_edificio_provincia').find('option:selected').val();
            area.DireccionCompleta.Localidad.NombreProvincia = $('#cmb_edificio_provincia').find('option:selected').text();
            alertify.alert("Se han modificado los datos del Edificio");

        }
    },


    ReescribirDatos: function () {
        var _this = this;
        _this.SettearValores(area.DireccionCompleta)
    }

}



        
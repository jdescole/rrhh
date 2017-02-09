﻿$(document).ready(function () {
    Backend.start(function () {
        var boton_usuario = new BotonDesplegable("foto_usuario_icono", "contenedor_menu_usuarios");
        var boton_aplicaciones = new BotonDesplegable("menu_cuadrados", "contenedor_menu_cuadrados");
        var boton_mensajes = new BotonDesplegable("menu_mensajes", "contenedor_menu_mensajes");


        $('#boton_home').click(function () {
            window.location.href = '../Portal/Portal.aspx';
        });


        Backend.GetMenuPara('PRINCIPAL').onSuccess(function (modulos) {

            for (var i = 0; i < modulos.Items.length; i++) {

                var item = modulos.Items[i];
                var modulito = $('<a>')
                modulito.attr('href', item.Acceso.Url);
                //                modulito.text(item.NombreItem);
                var imagen = $('<img>');
                imagen.attr('src', '../MenuPrincipal/' + item.NombreItem.replace(/ /g, '_') + '.png');
                imagen.attr('class', 'sombrita');
                imagen.attr('style', 'margin: 5px;');
                modulito.append(imagen);
                $('#contenedor_menu_cuadrados').append(modulito);

                //                item.Orden = ;

            }

        });


        Backend.GetUsuarioLogueado().onSuccess(function (usuario) {

            document.getElementById('nombre_user').innerHTML = usuario.Owner.Nombre;
            document.getElementById('apellido_user').innerHTML = usuario.Owner.Apellido;
            document.getElementById('dni_user').innerHTML = usuario.Owner.Documento;
            document.getElementById('email_user').innerHTML = usuario.MailRegistro;

            $('#cambiar-constrasena_usuario').click(function () {

                alertify.confirm('Modificar contraseña', '¿Está seguro de querer reinciar la contraseña', function () {
                    Backend.ResetearPassword(usuario.Id).onSuccess(
                        function (nueva_clave) {
                            alertify.alert("Se ha modificado la contraseña.", "La nueva contraseña para el usuario: "
                                                + usuario.Alias + " es: " + nueva_clave);
                        });
                }

        , function () {
            alertify.alert("Modificación cancelada.");
        }
        );
            })

            if (usuario.Owner.IdImagen >= 0) {
                var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario_menu") });
                var img2 = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario_icono") });
                $("#foto_usuario_menu").show();
                $("#foto_usuario_generica").hide();
            }
            else {
                $("#foto_usuario_menu").hide();
                $("#foto_usuario_generica").show();
            }


            $('#cambiar-email_usuario').click(function () {
                alertify.prompt(' ', 'Ingrese el mail del usuario', ''
               , function (evt, value) {

                   Backend.ModificarMailRegistro(usuario.Id, value).onSuccess(function () {

                       alertify.success("Se ha modificado correctamente su mail");
                       alertify.prompt().close();
                       $('#email_user').text(value);
                   }).onError(function () {
                       alertify.error("Error al modificar el mail");
                       alertify.prompt().close();
                   });
               }
               , function () {
               });

            });


        });
    });
});
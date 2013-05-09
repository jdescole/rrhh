

describe("Administrador de Mensajes", function () {
    it("Deber�a mostrar un mensaje de Error", function () {
        loadFixtures('mensaje_error.html');
        
        var mostrador_de_mensajes = {
            mostrar: function () { }
        };

        spyOn(mostrador_de_mensajes, 'mostrar');

        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, 'div-mensaje');
        administrador.informarAlUsuario();

        expect(mostrador_de_mensajes.mostrar).toHaveBeenCalledWith("error");
    });

    it("Deber�a mostrar un mensaje de �xito", function () {
        loadFixtures('mensaje_exito.html');
        var mostrador_de_mensajes = {
            mostrar: function () { }
        };

        spyOn(mostrador_de_mensajes, 'mostrar');

        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, 'div-mensaje');
        administrador.informarAlUsuario();

        expect(mostrador_de_mensajes.mostrar).toHaveBeenCalledWith("Exito");
    });
});


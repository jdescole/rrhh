describe("----------------------------------------------------------------COMIENZO TEST SACC----------------------------------------------------------------", function () {
    it("EJECUCI�N DE PRUEBAS", function () {
    });
});



describe("Se inicializa el Bot�n de Asistencias", function () {
    it("El bot�n deber�a ser un cuadrado Blanco y estar en Status Asistencia No Cargada", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_blanco_clicked");
        expect(botonAsistencia.val()).toEqual("  ");

    });

});


describe("El bot�n de Asistencia est� Cuadrado Blanco y se clickea", function () {
    it("El bot�n cambia a color Verde P y su Status es Presente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 1 vez
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_verde_clicked");
        expect(botonAsistencia.val()).toEqual("P");

    });
    
});


describe("El bot�n de Asistencia est� Cuadrado Verde y se clickea", function () {
    it("El bot�n cambia a color Amarillo A y su Status es Ausente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 2 veces
        botonAsistencia.click();
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_amarillo_clicked");
        expect(botonAsistencia.val()).toEqual("A");

    });

});
﻿var VistaDeImagenModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagenModi.prototype.start = function () {
    this.imagen = this.o.imagen;
    //this.lbl_nombre = this.o.ui.find('#lbl_nombre');
    this.img_thumbnail = this.o.ui.find('#img_thumbnail');

    //this.lbl_nombre.text(this.o.imagen.nombre)
    this.img_thumbnail.attr("src", "data:image/png;base64," + this.imagen.bytesImagen);

    this.onclick = function () { };

    var _this = this;
    this.o.ui.click(function () {
        if (imagenOnDrag === undefined) _this.onClick(_this.imagen);
    });

    this.o.ui.draggable({ revert: "invalid",
        start: function (ui) {
            imagenOnDrag = _this;
        },
        stop: function (ui) {
            setTimeout(function () { imagenOnDrag = undefined; }, 300);
        },
        helper: "clone"
    });
};

VistaDeImagenModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};

VistaDeImagenModi.prototype.borrar = function () {
    this.o.ui.remove();
};

VistaDeImagenModi.prototype.onClick = function () {
}; 
﻿var NodoEnArbolDeFuncionalidades = function (funcionalidad) {
    this.title = funcionalidad.nombre;
    this.key = funcionalidad.nombre;
    if (funcionalidad.sub_funcionalidades.length > 0) {
        this.children = [];
        for (var i = 0; i < funcionalidad.sub_funcionalidades.length; i++) {
            this.children.push(new NodoEnArbolDeFuncionalidades(funcionalidad.sub_funcionalidades[i]));
        }
    }
};
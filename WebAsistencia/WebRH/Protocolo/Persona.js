﻿var Persona = function (persona) {
    this._persona = persona;
    this.start();
    //_this = this;
};

Persona.prototype.start = function () {

};

Persona.prototype.id = function () {
    return this._persona.Id;
};

Persona.prototype.documento = function () {
    return this._persona.Documento;
};

Persona.prototype.nombre = function () {
    return this._persona.Apellido + ", " + this._persona.Nombre;
};

Persona.prototype.area = function () {
    return this._persona.Area.Alias;
};


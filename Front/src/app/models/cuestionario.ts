import { Usuario } from './../../../../Frontend/src/app/models/usuario';
import { Pregunta } from "./pregunta";

export class Cuestionario{
    id?:number;
    nombre:string;
    descripcion:string;
    fechaCreacion?:Date;
    preguntas:Pregunta[];
    usuario?:Usuario;

    constructor(nombre:string,descripcion:string,fechaCreacion:Date,preguntas:Pregunta[],usuario:Usuario) {
        this.nombre =nombre;
        this.descripcion = descripcion;
        this.fechaCreacion = fechaCreacion;
        this.preguntas = preguntas;
        this.usuario = usuario;
    }

}
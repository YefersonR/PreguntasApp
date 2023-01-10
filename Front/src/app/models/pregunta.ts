import { Respuesta } from "./respuesta";
export class Pregunta{
    descripcion:string;
    respuestas:Respuesta[];
    hide?:boolean;
    
    constructor(descripcion:string,respuesta:Respuesta[]) {
        this.descripcion = descripcion;
        this.respuestas = respuesta;
        this.hide = true;
    }
}
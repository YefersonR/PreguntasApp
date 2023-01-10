export class Respuesta {
    id? : number;
    descripcion:string;
    esCorrecta:boolean;

    constructor(esCorrecta:boolean,descripcion:string,id?:number) {
        this.esCorrecta = esCorrecta;
        this.descripcion = descripcion;
        this.id = id;
    }
}
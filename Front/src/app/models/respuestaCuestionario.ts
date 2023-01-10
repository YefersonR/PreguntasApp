import { RespuestaCuestionarioDetalles } from './respuestaCuestionarioDetalle';
export class RespuestaCuestionario{
    id?:number;
    CuestionarioId:number;
    fecha?:Date
    NombreParticipante:string;
    RespuestaDetalles:RespuestaCuestionarioDetalles[]=[]
}
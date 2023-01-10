import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { EstadisticasComponent } from './cuestionarios/estadisticas/estadisticas.component';
import { DetalleRespuestaComponent } from './cuestionarios/estadisticas/detalle-respuesta/detalle-respuesta.component'
import { ChangePasswordComponent } from './change-password/change-password.component';
import { CuestionariosComponent } from './cuestionarios/cuestionarios.component';
import { NuevoCuestionarioComponent } from './cuestionarios/nuevo-cuestionario/nuevo-cuestionario.component';
import { PasoUnoComponent } from './cuestionarios/nuevo-cuestionario/paso-uno/paso-uno.component';
import { PasoDosComponent } from './cuestionarios/nuevo-cuestionario/paso-dos/paso-dos.component';
import { NuevaPreguntaComponent } from './cuestionarios/nuevo-cuestionario/paso-dos/nueva-pregunta/nueva-pregunta.component';
import { CuestionarioComponent } from './cuestionarios/cuestionario/cuestionario.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    ChangePasswordComponent,
    CuestionariosComponent,
    NuevoCuestionarioComponent,
    PasoUnoComponent,
    PasoDosComponent,
    NuevaPreguntaComponent,
    CuestionarioComponent,
    EstadisticasComponent,
    DetalleRespuestaComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule
  ]
})
export class DashboardModule { }

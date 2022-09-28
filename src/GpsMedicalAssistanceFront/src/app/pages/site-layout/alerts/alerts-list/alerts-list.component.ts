import { Component, OnInit } from '@angular/core';
import * as dayjs from 'dayjs';

@Component({
  selector: 'app-alerts-list',
  templateUrl: './alerts-list.component.html',
  styleUrls: ['./alerts-list.component.scss']
})
export class AlertsListComponent implements OnInit {

  alertsList: any[] = [
    { id: 1, imageUrl: 'assets/icons/user.png', name: 'Eduardo', lastName: 'Rodriguez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 2, imageUrl: 'assets/icons/user.png', name: 'Pedro', lastName: 'Salas', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM- YYYY') },
    { id: 3, imageUrl: 'assets/icons/user.png', name: 'Juan', lastName: 'Fuentes', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 4, imageUrl: 'assets/icons/user.png', name: 'María', lastName: 'Estela', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 5, imageUrl: 'assets/icons/user.png', name: 'Alexandra', lastName: 'Parra', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 6, imageUrl: 'assets/icons/user.png', name: 'Pablo', lastName: 'Aguiar', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 7, imageUrl: 'assets/icons/user.png', name: 'Isabella', lastName: 'Castillos', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 8, imageUrl: 'assets/icons/user.png', name: 'Carlos', lastName: 'Perez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    { id: 8, imageUrl: 'assets/icons/user.png', name: 'Carlos', lastName: 'Perez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}

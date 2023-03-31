import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  public eventos: any = [
    {
      Tema: 'Angular 15',
      Local: 'Belo Horizonte'
    },
    {
      Tema: '.NET 5',
      Local: 'São Paulo'
    },
    {
      Tema: 'Angular e suas novidades',
      Local: 'Rio de Janeiro'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }
}

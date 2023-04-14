import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  public widthImg: number = 50;
  public marginImg: number = 2;
  public showImg: boolean = true;

  public eventos: any = [];
  public filterEventos: any = [];
  private _filterInitialEventos: string = '';

  public get filterInitialList(): string {
    return this._filterInitialEventos;
  }

  public set filterInitialList(value : string) {
    this._filterInitialEventos = value;
    this.filterEventos = this._filterInitialEventos ? this.findEventos(this._filterInitialEventos) : this.eventos;
  }

  public findEventos(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }


  changeImg() {
    this.showImg = !this.showImg;
  }


  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.filterEventos = this.eventos
      },
      error => console.log(error)
    );
  }
}

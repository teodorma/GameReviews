import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  games: any[]; // Presupunem că aveți un model Game sau orice structură de date

  constructor() { }

  ngOnInit(): void {
  }
}

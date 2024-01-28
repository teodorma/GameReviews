import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.css']
})
export class GameDetailsComponent implements OnInit {
  @Input() game: any; // Presupunem că 'game' este pasat ca input

  constructor() { }

  ngOnInit(): void {
  }
}

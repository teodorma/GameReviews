import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-review-form',
  templateUrl: './review-form.component.html',
  styleUrls: ['./review-form.component.css']
})
export class ReviewFormComponent implements OnInit {
  review: any = {}; // Structura pentru review

  constructor() { }

  ngOnInit(): void {
  }

  submitReview() {
    // Logica pentru trimiterea review-ului la server
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GameInfoComponent } from './core/components/game-info/game-info.component';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, GameInfoComponent, CategoryListComponent, AddCategoryComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'GameReviewAng';
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "../navbar/navbar";

@Component({
  selector: 'app-main-page',
  imports: [RouterOutlet, NavbarComponent],
  standalone: true,
  templateUrl: './main-page.html',
  styleUrl: './main-page.css'
})
export class MainPageComponent {

}

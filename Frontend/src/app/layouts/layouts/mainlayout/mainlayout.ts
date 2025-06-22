import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar';
import { FooterComponent } from '../footer/footer';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, FooterComponent],
  template: 
    `
  <div class="page-wrapper d-flex flex-column min-vh-100">
  <app-navbar></app-navbar>

  <main class="flex-fill">
    
  </main>

  <app-footer></app-footer>
</div>
`
})
export class Mainlayout {

}

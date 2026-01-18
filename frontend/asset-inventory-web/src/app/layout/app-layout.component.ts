import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [MenubarModule, RouterOutlet],
  templateUrl: './app-layout.component.html'
})
export class AppLayoutComponent {

  menuItems: MenuItem[] = [
    { label: 'Assets', icon: 'pi pi-box', routerLink: '/assets' },
    { label: 'Categories', icon: 'pi pi-tags', routerLink: '/categories' },
  ];
}

import { Component } from '@angular/core';
import { Router, RouterOutlet, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  template: `<router-outlet></router-outlet>`
})
export class AppComponent {
    constructor(
      private router: Router,
      private activatedRoute: ActivatedRoute,
      private titleService: Title
    ) {
      this.router.events
        .pipe(filter(event => event instanceof NavigationEnd))
        .subscribe(() => {
          const title = this.getTitle(this.activatedRoute);
          this.titleService.setTitle(
            title ? `${title} | Asset Inventory` : 'Asset Inventory'
          );
        });
    }

  private getTitle(route: ActivatedRoute): string {
    let title = '';
    if (route.firstChild) {
      title = this.getTitle(route.firstChild);
    } else if (route.snapshot.data['title']) {
      title = route.snapshot.data['title'];
    }
    return title;
  }
}

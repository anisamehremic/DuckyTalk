import { Component, OnInit } from '@angular/core';
import {
  Router,
  NavigationEnd,
  NavigationStart,
  RouteConfigLoadStart,
  RouteConfigLoadEnd,
} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'demo1';

  showSidebar = false;
  showNavbar = false;
  showFooter = false;
  isLoading = false;
  
  constructor(private router: Router) {
    // Removing Sidebar, Navbar, Footer for Documentation, Error and Auth pages
    router.events.forEach((event) => {
      if (event instanceof NavigationStart) {
        if (
          event.url === '/user-pages/login' ||
          event.url === '/user-pages/register' ||
          event.url === '/error-pages/404' ||
          event.url === '/error-pages/500' ||
          event.url === '/'
        ) {
          this.showSidebar = false;
          this.showNavbar = false;
          this.showFooter = false;
          document.querySelector('.main-panel').classList.add('w-100');
          document
            .querySelector('.page-body-wrapper')
            .classList.add('full-page-wrapper');
          document
            .querySelector('.content-wrapper')
            .classList.remove('auth', 'auth-img-bg');
          document
            .querySelector('.content-wrapper')
            .classList.remove('auth', 'lock-full-bg');
          if (
            event.url === '/error-pages/404' ||
            event.url === '/error-pages/500'
          ) {
            document.querySelector('.content-wrapper').classList.add('p-0');
          }
        } else if(
          event.url === '/dashboard' ||
          event.url === '/general-pages/main' ||
          event.url === '/general-pages/news-feed' ||
          event.url === '/career/main' ||
          event.url === '/career/survey' ||
          event.url === '/user-pages/settings'
        ) {
          this.showSidebar = true;
          this.showNavbar = true;
          this.showFooter = true;
          document.querySelector('.main-panel').classList.remove('w-100');
          document
            .querySelector('.page-body-wrapper')
            .classList.remove('full-page-wrapper');
          document
            .querySelector('.content-wrapper')
            .classList.remove('auth', 'auth-img-bg');
          document.querySelector('.content-wrapper').classList.remove('p-0');
        }
      }
    });

    // Spinner for lazyload modules
    router.events.forEach((event) => {
      if (event instanceof RouteConfigLoadStart) {
        this.isLoading = true;
      } else if (event instanceof RouteConfigLoadEnd) {
        this.isLoading = false;
      }
    });
  }

  ngOnInit() {
    // Scroll to top after route change
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}

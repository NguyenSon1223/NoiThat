import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app';
import { appConfig } from './app/app.config';
import { provideHttpClient } from '@angular/common/http';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),   // Cho phép gọi HTTP (HttpClient)
    ...appConfig.providers // Bao gồm route từ app.config.ts
  ]
}).catch(err => console.error(err));
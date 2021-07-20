import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CSFRInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.getCookieValue('XSRF-REQUEST-TOKEN');
    return next.handle(request.clone({
      headers: request.headers.set('X-XSFR-TOKEN', token)
    }));
  }

  private getCookieValue(name: string): string {
    const cookies = decodeURIComponent(document.cookie).split('; ');
    for (const cookie of cookies) {
      if (cookie.startsWith(`${name}=`)) {
        return cookie.substring(name.length + 1);
      }
    }
    return '';
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = environment.config.apis.projectRenanApi;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<any[]> {
    const url = `${this.apiUrl}users`;
    return this.http.get<any[]>(url);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginDTO } from '../models/dto';

const domaineServeur = "https://localhost:7291/";

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    constructor(private http: HttpClient) {}

    login(loginDTO: LoginDTO): Observable<any> {
        return this.http.post(`${domaineServeur}api/Users/Login`, loginDTO);
    }

    register(registerDTO: any): Observable<any> {
        return this.http.post(`${domaineServeur}api/Users/Register`, registerDTO);
    }
}
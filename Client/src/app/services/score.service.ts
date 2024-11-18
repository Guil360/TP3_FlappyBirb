import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const domaineServeur = "https://localhost:7059/";

@Injectable({
    providedIn: 'root'
})
export class ScoreService {
    constructor(private http: HttpClient) {}

    getMyScores(token: string): Observable<any> {
        return this.http.get(
            `${domaineServeur}api/Scores/GetMyScores`, 
            { 
                headers: new HttpHeaders().set("Authorization", `Bearer ${token}`) 
            }
        );
    }

    getPublicScores(): Observable<any> {
        return this.http.get(`${domaineServeur}api/Scores/GetPublicScores`);
    }

    toggleVisibility(scoreId: number, token: string, Visible: boolean): Observable<void> {
        return this.http.put<void>(
            `${domaineServeur}api/Scores/ChangeScoreVisibility`, 
            { scoreId, visible: Visible }, 
            { 
                headers: new HttpHeaders()
                    .set("Authorization", `Bearer ${token}`)
                    .set("Content-Type", "application/json")
            }
        );
    }
}